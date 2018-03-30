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
            int HL = ConfigHelper.Instance.Highlight;
            if (HL < 0 || HL > 2) {
                HL = 1;
            }
            m_HighlightNothing.Checked = (HL == 0);
            m_HighlightFullTank.Checked = (HL == 1);
            m_HighlightFullFit.Checked = (HL == 2);
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

        private void m_HighlightNothing_CheckedChanged(object sender, EventArgs e) {
            if (m_HighlightNothing.Checked) {
                ConfigHelper.Instance.Highlight = 0;
            }
        }

        private void m_HighlightFullTank_CheckedChanged(object sender, EventArgs e) {
            if (m_HighlightFullTank.Checked) {
                ConfigHelper.Instance.Highlight = 1;
            }
        }

        private void m_HighlightFullFit_CheckedChanged(object sender, EventArgs e) {
            if (m_HighlightFullFit.Checked) {
                ConfigHelper.Instance.Highlight = 2;
            }
        }

    }
}
