using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using HtmlAgilityPack;

namespace EveFitScanUI
{

    public partial class Form1 : Form
    {
        const string m_DownloadPageURL = "https://bitbucket.org/Donna_Hale_Eve/fitscan_eve/downloads/";

        private void BackgroundWorkerUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            HtmlWeb web = new HtmlWeb { UsingCache = false };
            var doc = web.Load(m_DownloadPageURL);
            var names = doc.DocumentNode.SelectNodes("//table[@id='uploaded-files']//tr//td[@class='name']/a");
            Regex BuildRegex = new Regex(@"EveFitScan_build_(\d+)\.(\d+)\.(\d+)\.(\d+)\.zip", RegexOptions.IgnoreCase);
            List<Version> availableVersions = new List<Version>();
            foreach (HtmlNode name in names) {
                var buildName = name.InnerText;
                Match match = BuildRegex.Match(buildName);
                if (match.Success && match.Groups.Count == 5) {
                    List<int> v = new List<int>();
                    for (int i = 1; i <= 4; ++i) {
                        string groupStr = match.Groups[i].ToString();
                        int vv = 0;
                        if (Int32.TryParse(groupStr, out vv) && vv >= 0) {
                            v.Add(vv);
                        }
                    }
                    if (v.Count == 4) {
                        availableVersions.Add(new Version(v[0], v[1], v[2], v[3]));
                    }
                }
            }
            if (availableVersions.Count > 0) {
                availableVersions.Sort();
                e.Result = availableVersions[availableVersions.Count - 1];
                return;
            }
           
            e.Result = new Version(0,0,0,0);
        }

        private void BackgroundWorkerUpdate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled && e.Error == null) {
                string TypeStr = e.Result.GetType().ToString();
                Version latestVersion = (Version)e.Result;
                Version currentVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
                if (latestVersion > currentVersion) {
                    string message = "You are currently running version " + currentVersion + "." + System.Environment.NewLine + System.Environment.NewLine +
                        "However, there is a newer version available: " + latestVersion + "." + System.Environment.NewLine + System.Environment.NewLine +
                        "Would you like to download it now?"
                        ;
                    DialogResult Res = MessageBox.Show(message, "Newer version available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Res == DialogResult.Yes) {
                        System.Diagnostics.Process.Start(m_DownloadPageURL);
                        Close();
                    }
                }
            }
        }

    }
}
