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
        private HistoryManager m_HistoryManager = null;
        private GankShips m_gankShips = null;

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

                            m_FitScanProcessor.NewPaste(data, m_checkBoxPassive.Checked, m_checkBoxADCActive.Checked);
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
            if (ConfigHelper.Instance.AlwaysOnTop) {
                this.TopMost = true;
            }

            this.clipboardViewerNext = NativeMethods.SetClipboardViewer(this.Handle);      // Adds our form to the chain of clipboard viewers.

            m_FitScanProcessor = new FitScanProcessor();
            m_FitScanProcessor.EventShipFitChanged += new FitScanProcessor.DelegateShipFitChanged(OnShipFitChanged);
            m_FitScanProcessor.EventShipTankChanged += new FitScanProcessor.DelegateShipTankChanged(OnShipTankChanged);
            m_FitScanProcessor.EventNewItemsWithUnknownPrices += new FitScanProcessor.DelegateNewItemsWithUnknownPrices(OnNewItemsWithUnknownPrices);
            m_FitScanProcessor.EventFitValueChanged += new FitScanProcessor.DelegateFitValueChanged(OnFitValueChanged);

            m_gankShips = new GankShips();

            m_HistoryManager = new HistoryManager();

            m_ComboBoxItems.Clear();

            m_BindingSource = new BindingSource(m_ComboBoxItems, null);
            m_ComboBoxShipType.DataSource = m_BindingSource;
            m_ComboBoxShipType.SelectedIndex = -1;

            this.m_checkBoxPassive.Checked = ConfigHelper.Instance.PassiveTank;
            m_FitScanProcessor.SetPassive(ConfigHelper.Instance.PassiveTank);

            this.m_comboBoxSysSecurity.SelectedIndex = ConfigHelper.Instance.SysSecurity;

            this.m_checkBoxSTK.Checked = ConfigHelper.Instance.STK;
            m_FitScanProcessor.SetSTK(ConfigHelper.Instance.STK);

            LoadPassiveColdHot();
            Load_DPS_RoF();
            ConfigSTKDisplay();

            m_BackgroundWorkerUpdate.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigHelper.Instance.WindowPositionX = this.Location.X;
            ConfigHelper.Instance.WindowPositionY = this.Location.Y;

            NativeMethods.ChangeClipboardChain(this.Handle, this.clipboardViewerNext);        // Removes our from the chain of clipboard viewers when the form closes.
        }

        private void m_ComboBoxSysSecurity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigHelper.Instance.SysSecurity = this.m_comboBoxSysSecurity.SelectedIndex;
            this.labelSeconds.Text = m_gankShips.GetSeconds(this.m_comboBoxSysSecurity.Text);
            m_FitScanProcessor.SetSTK(true);
        }

        private void LoadPassiveColdHot()
        {
            if (ConfigHelper.Instance.PassiveColdHot == "Passive")
                m_radioPassive.Checked = true;
            else if (ConfigHelper.Instance.PassiveColdHot == "Hot")
                m_radioHot.Checked = true;
            else
                m_radioCold.Checked = true;
        }

        private void m_textBox_DPS_Mjolnir_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Mjolnir.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Mjolnir = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Nova_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Nova.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Nova = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Antimatter_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Antimatter.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Antimatter = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Void_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Void.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Void = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_VoidL_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_VoidL.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_VoidL = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Multifrequency_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Multifrequency.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Multifrequency = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_EMP_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_EMP.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_EMP = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Fusion_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Fusion.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Fusion = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Phased_Plasma_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Phased_Plasma.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Phased_Plasma = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_DPS_Hail_ValueChanged(object sender, EventArgs e)
        {
            int DPS = 0;
            if (Int32.TryParse(m_textBox_DPS_Hail.Text, out DPS))
                if (DPS != 0) ConfigHelper.Instance.DPS_Hail = DPS;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Mjolnir_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Mjolnir.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Mjolnir = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Nova_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Nova.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Nova = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Antimatter_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Antimatter.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Antimatter = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Void_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Void.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Void = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_VoidL_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_VoidL.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_VoidL = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Multifrequency_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Multifrequency.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Multifrequency = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_EMP_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_EMP.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_EMP = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Fusion_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Fusion.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Fusion = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Phased_Plasma_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Phased_Plasma.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Phased_Plasma = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void m_textBox_RoF_Hail_ValueChanged(object sender, EventArgs e)
        {
            double RoF = 0;
            if (Double.TryParse(m_textBox_RoF_Hail.Text, out RoF))
                if (RoF != 0) ConfigHelper.Instance.RoF_Hail = RoF;
            m_FitScanProcessor.SetSTK(true);
        }

        private void Load_DPS_RoF()
        {
            m_textBox_DPS_Mjolnir.Text = ConfigHelper.Instance.DPS_Mjolnir.ToString();
            m_textBox_DPS_Nova.Text = ConfigHelper.Instance.DPS_Nova.ToString();
            m_textBox_DPS_Antimatter.Text = ConfigHelper.Instance.DPS_Antimatter.ToString();
            m_textBox_DPS_Void.Text = ConfigHelper.Instance.DPS_Void.ToString();
            m_textBox_DPS_VoidL.Text = ConfigHelper.Instance.DPS_VoidL.ToString();
            m_textBox_DPS_Multifrequency.Text = ConfigHelper.Instance.DPS_Multifrequency.ToString();
            m_textBox_DPS_EMP.Text = ConfigHelper.Instance.DPS_EMP.ToString();
            m_textBox_DPS_Fusion.Text = ConfigHelper.Instance.DPS_Fusion.ToString();
            m_textBox_DPS_Phased_Plasma.Text = ConfigHelper.Instance.DPS_Phased_Plasma.ToString();
            m_textBox_DPS_Hail.Text = ConfigHelper.Instance.DPS_Hail.ToString();

            m_textBox_RoF_Mjolnir.Text = ConfigHelper.Instance.RoF_Mjolnir.ToString();
            m_textBox_RoF_Nova.Text = ConfigHelper.Instance.RoF_Nova.ToString();
            m_textBox_RoF_Antimatter.Text = ConfigHelper.Instance.RoF_Antimatter.ToString();
            m_textBox_RoF_Void.Text = ConfigHelper.Instance.RoF_Void.ToString();
            m_textBox_RoF_VoidL.Text = ConfigHelper.Instance.RoF_VoidL.ToString();
            m_textBox_RoF_Multifrequency.Text = ConfigHelper.Instance.RoF_Multifrequency.ToString();
            m_textBox_RoF_EMP.Text = ConfigHelper.Instance.RoF_EMP.ToString();
            m_textBox_RoF_Fusion.Text = ConfigHelper.Instance.RoF_Fusion.ToString();
            m_textBox_RoF_Phased_Plasma.Text = ConfigHelper.Instance.RoF_Phased_Plasma.ToString();
            m_textBox_RoF_Hail.Text = ConfigHelper.Instance.RoF_Hail.ToString();
        }

        private void m_radioPassive_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radioPassive.Checked)
            {
                ConfigHelper.Instance.PassiveColdHot = "Passive";
                m_FitScanProcessor.SetPassive(true);
                m_checkBoxADCActive.Enabled = false;
            }
            else if (m_radioHot.Checked)
            {
                ConfigHelper.Instance.PassiveColdHot = "Hot";
                m_FitScanProcessor.SetPassive(false);
                m_checkBoxADCActive.Enabled = true;
            }
            else
            {
                ConfigHelper.Instance.PassiveColdHot = "Cold";
                m_FitScanProcessor.SetPassive(false);
                m_checkBoxADCActive.Enabled = true;
            }
        }
    }
}
