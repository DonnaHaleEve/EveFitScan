using System;
using System.Collections.Generic;

namespace EveFitScanUI
{
    partial class FitScanProcessor
    {
        public delegate void DelegateNewItemsWithUnknownPrices();
        public event DelegateNewItemsWithUnknownPrices EventNewItemsWithUnknownPrices;

        public delegate void DelegateFitValueChanged();
        public event DelegateFitValueChanged EventFitValueChanged;
        
        private Dictionary<string, float> m_ItemPrices = new Dictionary<string, float>();

        public void ConsumeNewPrices(IReadOnlyDictionary<string,double> Prices) {
            int qq = 666;
            // update m_ItemPrices
            foreach (KeyValuePair<string, double> kvp in Prices) {
                if (m_ItemPrices.ContainsKey(kvp.Key)) {
                    m_ItemPrices[kvp.Key] = (float)kvp.Value;
                }
                else {
                    m_ItemPrices.Add(kvp.Key, (float)kvp.Value);
                }
            }

            // Update m_ItemsWithUnknownPrices : remove items that have prices now.
            Dictionary<string, int> Tmp = new Dictionary<string, int>();
            foreach (string Item in m_ItemsWithUnknownPrices) {
                if (!m_ItemPrices.ContainsKey(Item)) {
                    Tmp.Add(Item, 1);
                }
            }
            m_ItemsWithUnknownPrices = new List<string>(Tmp.Keys);

            RecalculateFitValue();
        }

        private List<string> m_ItemsWithUnknownPrices = new List<string>();
        public IEnumerable<string> ItemsWithUnknownPrices {
            get {
                return m_ItemsWithUnknownPrices;
            }
        }

        private void UpdateItemListForPricing(IEnumerable<string> Items) {
            Dictionary<string, int> Tmp = new Dictionary<string, int>();
            foreach (string Item in m_ItemsWithUnknownPrices) {
                if (!m_ItemPrices.ContainsKey(Item) && !Tmp.ContainsKey(Item)) {
                    Tmp.Add(Item, 1);
                }
            }
            foreach (string Item in Items) {
                if (!m_ItemPrices.ContainsKey(Item) && !Tmp.ContainsKey(Item)) {
                    Tmp.Add(Item, 1);
                }
            }
            m_ItemsWithUnknownPrices = new List<string>(Tmp.Keys);
            if (m_ItemsWithUnknownPrices.Count > 0) {
                EventNewItemsWithUnknownPrices();
            }
        }

        private void RecalculateFitValue() {
            m_ValueShip = 0.0f;
            if (m_ItemPrices.ContainsKey(m_ShipName)) {
                m_ValueShip = m_ItemPrices[m_ShipName];
            }

            m_ValueRigs = 0.0f;
            foreach (string Rig in m_Rigs) {
                if (m_ItemPrices.ContainsKey(Rig)) {
                    m_ValueRigs += m_ItemPrices[Rig];
                }
            }

            m_ValueSubsystems = 0.0f;
            foreach (string Subsystem in m_SubsystemModules) {
                if (m_ItemPrices.ContainsKey(Subsystem)) {
                    m_ValueSubsystems += m_ItemPrices[Subsystem];
                }
            }

            m_ValueModules = 0.0f;
            foreach (string Module in m_HighPowerModules) {
                if (m_ItemPrices.ContainsKey(Module)) {
                    m_ValueModules += m_ItemPrices[Module];
                }
            }
            foreach (string Module in m_MediumPowerModules) {
                if (m_ItemPrices.ContainsKey(Module)) {
                    m_ValueModules += m_ItemPrices[Module];
                }
            }
            foreach (string Module in m_LowPowerModules) {
                if (m_ItemPrices.ContainsKey(Module)) {
                    m_ValueModules += m_ItemPrices[Module];
                }
            }

            EventFitValueChanged();
        }
    }
}