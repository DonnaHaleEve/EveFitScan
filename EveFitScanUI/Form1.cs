using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constant for the WM_DRAWCLIPBOARD message.
        /// </summary>
        private const int WMDRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
        private const int WMCHANGECBCHAIN = 0x030D;  // WM_CHANGECBCHAIN message

        /// <summary>
        /// Holds the Handle to the next clipboard viewer in the chain.
        /// </summary>
        private IntPtr clipboardViewerNext;                // Our variable that will hold the value to identify the next window in the clipboard viewer chain

        private bool m_bFirstFire = true;
        private string m_LastCopy = string.Empty;
        private FitScanProcessor m_FitScanProcessor = null;

        public Form1()
        {
            InitializeComponent();

            Rectangle resolution = SystemInformation.VirtualScreen;
            if (
                ConfigHelper.Instance.WindowPositionX < resolution.X ||
                ConfigHelper.Instance.WindowPositionX >= resolution.Width ||
                ConfigHelper.Instance.WindowPositionY < resolution.Y ||
                ConfigHelper.Instance.WindowPositionY >= resolution.Height
            ) {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(ConfigHelper.Instance.WindowPositionX, ConfigHelper.Instance.WindowPositionY);
            }
        }

        private bool m_bCaptureClipboard = true;

        /// <summary>
        /// This processes window messages such as clipboard events.
        /// </summary>
        /// <param name="m">Window Message</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WMDRAWCLIPBOARD) {
                if (m_bFirstFire)
                {
                    m_bFirstFire = false;
                }
                else {
                    if (m_bCaptureClipboard)
                    {
                        IDataObject obj = Clipboard.GetDataObject();

                        string format = string.Empty;

                        if (obj.GetDataPresent(DataFormats.OemText))
                        {
                            format = DataFormats.OemText;
                        }
                        else if (obj.GetDataPresent(DataFormats.Text))
                        {
                            format = DataFormats.Text;
                        }
                        else if (obj.GetDataPresent(DataFormats.UnicodeText))
                        {
                            format = DataFormats.UnicodeText;
                        }

                        if (!string.IsNullOrEmpty(format))
                        {
                            string data = (string)obj.GetData(format);

                            if (data == m_LastCopy)
                            {
                                return;
                            }

                            m_FitScanProcessor.NewPaste(data, m_checkBoxPassive.Checked);
                        }
                    }
                }

                NativeMethods.SendMessage(clipboardViewerNext,m.Msg,m.WParam,m.LParam);
            }
            else if (m.Msg == WMCHANGECBCHAIN)
            {
                if (m.WParam == clipboardViewerNext)
                {
                    clipboardViewerNext = m.LParam;
                }
                else {
                    NativeMethods.SendMessage(clipboardViewerNext, m.Msg, m.WParam, m.LParam);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.toggleAlwaysOnTopToolStripMenuItem.Checked = ConfigHelper.Instance.AlwaysOnTop;
            if (ConfigHelper.Instance.AlwaysOnTop) {
                this.TopMost = true;
            }
            this.getPricesToolStripMenuItem.Checked = ConfigHelper.Instance.GetPrices;

            this.clipboardViewerNext = NativeMethods.SetClipboardViewer(this.Handle);      // Adds our form to the chain of clipboard viewers.

            m_FitScanProcessor = new FitScanProcessor();
            m_FitScanProcessor.EventShipFitChanged += new FitScanProcessor.DelegateShipFitChanged(OnShipFitChanged);
            m_FitScanProcessor.EventShipTankChanged += new FitScanProcessor.DelegateShipTankChanged(OnShipTankChanged);
            m_FitScanProcessor.EventNewItemsWithUnknownPrices += new FitScanProcessor.DelegateNewItemsWithUnknownPrices(OnNewItemsWithUnknownPrices);
            m_FitScanProcessor.EventFitValueChanged += new FitScanProcessor.DelegateFitValueChanged(OnFitValueChanged);

            m_ComboBoxItems.Clear();

            m_BindingSource = new BindingSource(m_ComboBoxItems, null);
            m_ComboBoxShipType.DataSource = m_BindingSource;
            m_ComboBoxShipType.SelectedIndex = -1;

            this.m_checkBoxPassive.Checked = ConfigHelper.Instance.PassiveTank;
            m_FitScanProcessor.SetPassive(ConfigHelper.Instance.PassiveTank);

            m_BackgroundWorkerUpdate.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigHelper.Instance.WindowPositionX = this.Location.X;
            ConfigHelper.Instance.WindowPositionY = this.Location.Y;

            NativeMethods.ChangeClipboardChain(this.Handle, this.clipboardViewerNext);        // Removes our from the chain of clipboard viewers when the form closes.
        }


    }
}
