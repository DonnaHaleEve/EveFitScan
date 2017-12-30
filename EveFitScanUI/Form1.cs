using System;
using System.Collections.Generic;
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
                if (m_bFirstFire) {
                    m_bFirstFire = false;
                    return;
                }

                if (!m_bCaptureClipboard) {
                    return;
                }

                IDataObject obj = Clipboard.GetDataObject();

                string format = string.Empty;

                if (obj.GetDataPresent(DataFormats.OemText)) {
                    format = DataFormats.OemText;
                }
                else if (obj.GetDataPresent(DataFormats.Text)) {
                    format = DataFormats.Text;
                }
                else if (obj.GetDataPresent(DataFormats.UnicodeText)) {
                    format = DataFormats.UnicodeText;
                }

                if (!string.IsNullOrEmpty(format)) {
                    string data = (string)obj.GetData(format);

                    if (data == m_LastCopy) {
                        return;
                    }

                    m_FitScanProcessor.NewPaste(data);
                    //this.m_ClipboardText.Text = data;
                }

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.clipboardViewerNext = NativeMethods.SetClipboardViewer(this.Handle);      // Adds our form to the chain of clipboard viewers.

            m_FitScanProcessor = new FitScanProcessor();
            m_FitScanProcessor.EventShipFitChanged += new FitScanProcessor.DelegateShipFitChanged(OnShipFitChanged);
            m_FitScanProcessor.EventShipTankChanged += new FitScanProcessor.DelegateShipTankChanged(OnShipTankChanged);

            m_ComboBoxItems.Clear();
            //m_ComboBoxItems.Add("AAA");
            //m_ComboBoxItems.Add("BBB");
            //m_ComboBoxItems.Add("CCC");
            //m_ComboBoxItems.Add("DDD");

            m_BindingSource = new BindingSource(m_ComboBoxItems, null);
            m_ComboBoxShipType.DataSource = m_BindingSource;
            m_ComboBoxShipType.SelectedIndex = -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.ChangeClipboardChain(this.Handle, this.clipboardViewerNext);        // Removes our from the chain of clipboard viewers when the form closes.
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "EveFitScan Version " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() + @"
2017 Donna Hale <donna.hale.eve@gmail.com>

Comments/Suggestions/Complaints can be posted in the appropriate 
thread on the Goonfleet Forums or sent to me via Jabber.";

            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = File.ReadAllText("license.txt");

            MessageBox.Show(message, "License", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bitbucket.org/Donna_Hale_Eve/fitscan_eve/overview");
        }

        private void m_ButtonResetFit_Click(object sender, EventArgs e)
        {
            m_FitScanProcessor.ResetFit();
        }

        private List<string> m_ComboBoxItems = new List<string>();
        private BindingSource m_BindingSource = new BindingSource();

        private void m_ComboBoxShipType_TextUpdate(object sender, EventArgs e)
        {
            string Text = m_ComboBoxShipType.Text;
            if (Text.Length >= 3) {
                List<string> SuggestedNames = (List<string>)m_FitScanProcessor.SuggestNames(Text);
                m_ComboBoxItems.Clear();
                m_ComboBoxItems = SuggestedNames;

                m_BindingSource.DataSource = null;
                m_BindingSource.DataSource = m_ComboBoxItems;

                m_ComboBoxShipType.DataSource = null;
                if (m_ComboBoxItems.Count > 0)
                {
                    m_ComboBoxShipType.DataSource = m_BindingSource;
                }
                m_ComboBoxShipType.SelectedIndex = -1;
                m_ComboBoxShipType.DroppedDown = true;
                Cursor.Current = Cursors.Default;

                m_ComboBoxShipType.Text = Text;
                m_ComboBoxShipType.SelectionStart = (Text.Length > 0) ? Text.Length : 0;
                m_ComboBoxShipType.SelectionLength = 0;
            }
        }

        private void m_ComboBoxShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ComboBoxShipType.SelectedIndex >= 0) {
                string Text = m_ComboBoxShipType.Text;
                m_FitScanProcessor.SetShipName(Text);
            }
        }

        private void m_ButtonCopyCODE_Click(object sender, EventArgs e)
        {
            bool prevClipboard = m_bCaptureClipboard;

            m_bCaptureClipboard = false;

            Clipboard.SetText(m_FitScanProcessor.CODEToolURL);

            m_bCaptureClipboard = prevClipboard;
        }

        private void m_ButtonCopyEFT_Click(object sender, EventArgs e)
        {
            bool prevClipboard = m_bCaptureClipboard;

            m_bCaptureClipboard = false;

            Clipboard.SetText(m_FitScanProcessor.EFTFit);

            m_bCaptureClipboard = prevClipboard;
        }

        private void toggleAlwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = toggleAlwaysOnTopToolStripMenuItem.Checked;
        }
    }
}
