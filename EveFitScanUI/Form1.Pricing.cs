using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EveFitScanUI
{

    public partial class Form1 : Form
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        private Mutex m_Guard = new Mutex();
        private Dictionary<string, int> m_ItemsWithUnknownPrices = new Dictionary<string,int>();

        private void OnNewItemsWithUnknownPrices()
        {
            if (ConfigHelper.Instance.GetPrices) {
                m_Guard.WaitOne();

                foreach (string Item in m_FitScanProcessor.ItemsWithUnknownPrices) {
                    if (!m_ItemsWithUnknownPrices.ContainsKey(Item)) {
                        m_ItemsWithUnknownPrices.Add(Item, 1);
                    }
                }
                bool Empty = m_ItemsWithUnknownPrices.Count == 0;

                m_Guard.ReleaseMutex();

                if (!m_BackgroundWorker.IsBusy && !Empty) {
                    RestartWorker();
                }
            }
        }

        private void RestartWorker() {
            Debug.Assert(!m_BackgroundWorker.IsBusy);
            m_Guard.WaitOne();

            string ItemsString = "";
            foreach (string Item in m_ItemsWithUnknownPrices.Keys) {
                ItemsString += Item + "\r\n";
            }
            m_ItemsWithUnknownPrices.Clear();

            m_Guard.ReleaseMutex();

            if (ItemsString.Length > 0) {
                m_BackgroundWorker.RunWorkerAsync(ItemsString);
            }
        }

        private void m_BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.Assert(!m_BackgroundWorker.IsBusy);
            if (e.Error == null) {
                MessageBox.Show("no error", "RunWorkerCompleted", MessageBoxButtons.OK);
                string Result = (string)e.Result;
                char[] Separators = { '\r', '\n' };
                char[] SeparatorTab = { '\t' };
                string[] Lines = Result.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, double> Prices = new Dictionary<string, double>();
                foreach (string Line in Lines) {
                    string[] Parts = Line.Split(SeparatorTab, StringSplitOptions.RemoveEmptyEntries);
                    if (Parts.Length == 2) {
                        double Price = 0.0;
                        if (Double.TryParse(Parts[0], out Price)) {
                            if (!Prices.ContainsKey(Parts[1])) {
                                Prices.Add(Parts[1], Price);
                            }
                        }
                    }
                }
                m_FitScanProcessor.ConsumeNewPrices(Prices);
            }
            RestartWorker();
        }

        private void m_BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ItemString = (string)e.Argument;

            string Result = "";
            do
            {
                string EvepraisalResponse = QueryEvepraisal(ItemString);
                if (EvepraisalResponse.Length == 0)
                    break;

                EvepraisalResponse Response = new EvepraisalResponse();
                if (!DeserializeResponse(EvepraisalResponse, ref Response))
                    break;

                Result = ProcessResponse(Response);
            } while (false);

            e.Result = Result;
        }

        private string ProcessResponse(EvepraisalResponse Response)
        {
            string Result = "";
            foreach (Item it in Response.appraisal.items) {
                string Name = it.typeName;
                double SplitPrice = 0.5 * (it.prices.sell.min + it.prices.buy.max);
                Result += String.Format("{0:f2}\t{1}\n", SplitPrice, Name);
            }
            return Result;
        }

        private string QueryEvepraisal(string Text) {
            string ResponseString = "";
            try
            {
                var Request = (HttpWebRequest)WebRequest.Create("https://evepraisal.com/appraisal.json?market=jita&persist=no");

                string FormDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());

                MemoryStream PostDataStream = GetPostDataStream(FormDataBoundary, Text);

                Request.Method = WebRequestMethods.Http.Post;
                Request.ContentType = "multipart/form-data; boundary=" + FormDataBoundary;
                Request.ContentLength = PostDataStream.Length;
                Request.UserAgent = "FitScan by Donna Hale";

                using (var Stream = Request.GetRequestStream())
                {
                    PostDataStream.WriteTo(Stream);
                }
                PostDataStream.Close();

                var response = (HttpWebResponse)Request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception)
            {
                ResponseString = "";
            }
            return ResponseString;
        }

        private bool DeserializeResponse(string ResponseString, ref EvepraisalResponse Response) {
            bool Success = false;
            try
            {
                Response = JsonConvert.DeserializeObject<EvepraisalResponse>(ResponseString);
                Success = true;
            }
            catch (Exception)
            {
                Success = false;
            }
            return Success;
        }

        private MemoryStream GetPostDataStream(string boundary, string Content)
        {
            MemoryStream postDataStream = new MemoryStream();

            string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                boundary,
                "uploadappraisal",
                "appraisal.txt",
                "application/octet-stream");
            postDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

            postDataStream.Write(encoding.GetBytes(Content), 0, encoding.GetByteCount(Content));

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            postDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            return postDataStream;
        }

    }

    #region ===== aux classes for evepraisal json response =====

    public class Price
    {
        public double avg;
        public double max;
        public double median;
        public double min;
        public double percentile;
        public double stddev;
        public int volume;
        public int order_count;
    };
    public class Prices
    {
        public Price all;
        public Price buy;
        public Price sell;
    };
    public class Item
    {
        public string name;
        public int typeID;
        public string typeName;
        public Prices prices;
    };
    public class Appraisal
    {
        //public int created;
        //public string kind;
        public string market_name;
        public List<Item> items;
        //public string raw;
        //public int price_percentage;
        //public bool live;
    };
    public class EvepraisalResponse
    {
        public Appraisal appraisal;
    };

    #endregion ====================================================
}
