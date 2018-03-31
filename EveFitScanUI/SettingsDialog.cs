using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog() {
            InitializeComponent();
        }
        private void SettingsDialog_Load(object sender, EventArgs e) {
            this.m_AlwaysOnTop.Checked = ConfigHelper.Instance.AlwaysOnTop;
            this.m_GetPrices.Checked = ConfigHelper.Instance.GetPrices;
            this.m_Highlight.Checked = ConfigHelper.Instance.Highlight;
        }

        private void m_ButtonOk_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void m_AlwaysOnTop_CheckedChanged(object sender, EventArgs e) {
            ConfigHelper.Instance.AlwaysOnTop = m_AlwaysOnTop.Checked;
        }

        private void m_GetPrices_CheckedChanged(object sender, EventArgs e) {
            ConfigHelper.Instance.GetPrices = m_GetPrices.Checked;
        }

        private void m_Highlight_CheckedChanged(object sender, EventArgs e) {
            ConfigHelper.Instance.Highlight = m_Highlight.Checked;
        }

    }
}
