using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {
        private bool m_InsideUpdate = false;
        private void UpdateHistoryFit() {
            if (m_InsideUpdate)
                return;

            m_InsideUpdate = true;
            if (m_FitScanProcessor.ValidFit) {
                m_HistoryManager.OnFitChanged(
                    m_FitScanProcessor.ShipName,
                    m_FitScanProcessor.HighSlots,
                    m_FitScanProcessor.HighPowerModules,
                    m_FitScanProcessor.MediumSlots,
                    m_FitScanProcessor.MediumPowerModules,
                    m_FitScanProcessor.LowSlots,
                    m_FitScanProcessor.LowPowerModules,
                    m_FitScanProcessor.RigSlots,
                    m_FitScanProcessor.Rigs,
                    m_FitScanProcessor.SubsystemSlots,
                    m_FitScanProcessor.SubsystemModules
                );
                UpdateHistoryList();
            }
            m_InsideUpdate = false;
        }

        private void UpdateHistoryTank(float EHP) {
            if (m_FitScanProcessor.ValidFit) {
                if (m_History.SelectedIndex == 0) {
                    m_HistoryManager.OnEHPChanged(EHP);
                    UpdateHistoryList();
                }
            }
        }

        private void UpdateHistoryPrice(float price) {
            if (m_FitScanProcessor.ValidFit) {
                if (m_History.SelectedIndex == 0) {
                    m_HistoryManager.OnPriceChanged(price);
                    UpdateHistoryList();
                }
            }
        }

        private bool m_bIgnoreIndexChanges = false;
        private bool m_bInsideIndexChange = false;

        private void m_History_SelectedIndexChanged(object sender, EventArgs e) {
            if (m_bIgnoreIndexChanges) {
                return;
            }

            m_bInsideIndexChange = true;

            m_FitScanProcessor.NewPaste(
                m_HistoryManager.GetFitAt(m_History.SelectedIndex),
                m_checkBoxPassive.Checked,
                m_checkBoxADCActive.Checked
            );

            m_bInsideIndexChange = false;
        }

        private void UpdateHistoryList() {
            List<string> Summaries = new List<string>();
            for (int i = 0; i < m_HistoryManager.Count; ++i) {
                Summaries.Add(m_HistoryManager.GetSummaryAt(i));
            }

            m_bIgnoreIndexChanges = true;

            m_History.Items.Clear();
            m_History.Items.AddRange(Summaries.ToArray());
            if (Summaries.Count > 0) {
                m_History.SelectedIndex = 0;
            }

            m_bIgnoreIndexChanges = false;
        }
    }
}