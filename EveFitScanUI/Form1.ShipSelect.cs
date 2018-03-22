using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {
        private List<string> m_ComboBoxItems = new List<string>();
        private BindingSource m_BindingSource = new BindingSource();

        private void m_ComboBoxShipType_TextUpdate(object sender, EventArgs e)
        {
            string Text = m_ComboBoxShipType.Text;
            if (Text.Length >= 3)
            {
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
            if (m_ComboBoxShipType.SelectedIndex >= 0)
            {
                string Text = m_ComboBoxShipType.Text;
                m_FitScanProcessor.SetShipName(Text, m_checkBoxPassive.Checked, m_checkBoxADCActive.Checked);
            }
        }
    }
}
