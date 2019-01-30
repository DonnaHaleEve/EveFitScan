using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    class HistoryManager
    {
        const int MAX_HISTORY_LINES = 20;

        private List<HistoryItem> m_HistoryItems = new List<HistoryItem>();

        public int Count {
            get {
                return m_HistoryItems.Count;
            }
        }

        public string GetSummaryAt(int i) {
            Debug.Assert(i >= 0 && i < m_HistoryItems.Count);
            return m_HistoryItems[i].Summary;
        }

        public string GetFitAt(int i) {
            Debug.Assert(i>=0 && i<m_HistoryItems.Count);
            return m_HistoryItems[i].Fit;
        }

        public void OnFitChanged(
            string shipName,
            uint highSlotCount,
            IReadOnlyList<string> highSlotModules,
            uint mediumSlotCount,
            IReadOnlyList<string> mediumSlotModules,
            uint lowSlotCount,
            IReadOnlyList<string> lowSlotModules,
            uint rigSlotCount,
            IReadOnlyList<string> rigModules,
            uint subsystemSlotCount,
            IReadOnlyList<string> subsystemModules
        ) {
            Debug.Assert(highSlotCount >= highSlotModules.Count);
            Debug.Assert(mediumSlotCount >= mediumSlotModules.Count);
            Debug.Assert(lowSlotCount >= lowSlotModules.Count);
            Debug.Assert(rigSlotCount >= rigModules.Count);
            Debug.Assert(subsystemSlotCount >= subsystemModules.Count);

            HistoryItem item = new HistoryItem(
                shipName,
                highSlotCount,
                highSlotModules,
                mediumSlotCount,
                mediumSlotModules,
                lowSlotCount,
                lowSlotModules,
                rigSlotCount,
                rigModules,
                subsystemSlotCount,
                subsystemModules
            );

            if (m_HistoryItems.Count == 0) {
                m_HistoryItems.Add(item);
            }
            else {
                if (item.IsUpgradeTo(m_HistoryItems[0])) {
                    m_HistoryItems[0] = item;
                }
                else {
                    if (m_HistoryItems.Count >= MAX_HISTORY_LINES) {
                        m_HistoryItems.RemoveAt(m_HistoryItems.Count - 1);
                    }
                    m_HistoryItems.Insert(0, item);
                }
            }
        }

        public void OnPriceChanged(float price) {
            if (m_HistoryItems.Count > 0) {
                m_HistoryItems[0].Price = price;
            }
        }

        public void OnEHPChanged(float EHP) {
            if (m_HistoryItems.Count > 0) {
                m_HistoryItems[0].EHP = EHP;
            }
        }

        private class HistoryItem {
            public HistoryItem(
                string shipName,
                uint highSlotCount,
                IReadOnlyList<string> highSlotModules,
                uint mediumSlotCount,
                IReadOnlyList<string> mediumSlotModules,
                uint lowSlotCount,
                IReadOnlyList<string> lowSlotModules,
                uint rigSlotCount,
                IReadOnlyList<string> rigModules,
                uint subsystemSlotCount,
                IReadOnlyList<string> subsystemModules
            ) {
                m_ShipName = shipName;
                m_HighSlotCount = highSlotCount;
                m_HighSlotModules = ProcessModules(highSlotModules);
                m_MediumSlotCount = mediumSlotCount;
                m_MediumSlotModules = ProcessModules(mediumSlotModules);
                m_LowSlotCount = lowSlotCount;
                m_LowSlotModules = ProcessModules(lowSlotModules);
                m_RigSlotCount = rigSlotCount;
                m_Rigs = ProcessModules(rigModules);
                m_SubsystemSlotCount = subsystemSlotCount;
                m_Subsystems = ProcessModules(subsystemModules);

                uint nSlots = m_HighSlotCount + m_MediumSlotCount + m_LowSlotCount + m_RigSlotCount + m_SubsystemSlotCount;
                if (nSlots == 0) {
                    m_ModulePercentile = 0.0f;
                }
                else {
                    uint nModules = CountModules(m_HighSlotModules) + CountModules(m_MediumSlotModules) + CountModules(m_LowSlotModules) + CountModules(m_Rigs) + CountModules(m_Subsystems);
                    m_ModulePercentile = ((float)nModules) / ((float)nSlots);
                }

                m_EHP = 0.0f;
                m_Price = 0.0f;
            }
            public string m_ShipName;
            //
            public uint m_HighSlotCount;
            public Dictionary<string, uint> m_HighSlotModules;
            //
            public uint m_MediumSlotCount;
            public Dictionary<string, uint> m_MediumSlotModules;
            //
            public uint m_LowSlotCount;
            public Dictionary<string, uint> m_LowSlotModules;
            //
            public uint m_RigSlotCount;
            public Dictionary<string, uint> m_Rigs;
            //
            public uint m_SubsystemSlotCount;
            public Dictionary<string, uint> m_Subsystems;
            //
            public float m_ModulePercentile;
            //
            private float m_EHP;
            public float EHP {
                get {
                    return m_EHP;
                }
                set {
                    m_EHP = value;
                    m_SummaryString = GenerateSummaryString();
                }
            }
            //
            private float m_Price;
            public float Price {
                get {
                    return m_Price;
                }
                set {
                    m_Price = value;
                    m_SummaryString = GenerateSummaryString();
                }
            }

            private uint CountModules(Dictionary<string, uint> modules) {
                uint result = 0;
                foreach (KeyValuePair<string, uint> kvp in modules) {
                    result += kvp.Value;
                }
                return result;
            }

            private static Dictionary<string, uint> ProcessModules(IReadOnlyList<string> modules) {
                Dictionary<string, uint> Result = new Dictionary<string, uint>();
                foreach (string ModuleName in modules) {
                    if (Result.ContainsKey(ModuleName)) {
                        Result[ModuleName]++;
                    }
                    else {
                        Result[ModuleName] = 1;
                    }
                }
                return Result;
            }

            public bool IsUpgradeTo(HistoryItem other) {
                // name
                if (m_ShipName != other.m_ShipName)
                    return false;
                // slots
                if (m_HighSlotCount != other.m_HighSlotCount)
                    return false;
                if (m_MediumSlotCount != other.m_MediumSlotCount)
                    return false;
                if (m_LowSlotCount != other.m_LowSlotCount)
                    return false;
                if (m_RigSlotCount!= other.m_RigSlotCount)
                    return false;
                if (m_SubsystemSlotCount!= other.m_SubsystemSlotCount)
                    return false;
                // high slot modules
                foreach (KeyValuePair<string, uint> kvp in other.m_HighSlotModules) {
                    if (!m_HighSlotModules.ContainsKey(kvp.Key))
                        return false;
                    if (m_HighSlotModules[kvp.Key] < kvp.Value)
                        return false;
                }
                // medium slot modules
                foreach (KeyValuePair<string, uint> kvp in other.m_MediumSlotModules) {
                    if (!m_MediumSlotModules.ContainsKey(kvp.Key))
                        return false;
                    if (m_MediumSlotModules[kvp.Key] < kvp.Value)
                        return false;
                }
                // low slot modules
                foreach (KeyValuePair<string, uint> kvp in other.m_LowSlotModules) {
                    if (!m_LowSlotModules.ContainsKey(kvp.Key))
                        return false;
                    if (m_LowSlotModules[kvp.Key] < kvp.Value)
                        return false;
                }
                // rigs
                foreach (KeyValuePair<string, uint> kvp in other.m_Rigs) {
                    if (!m_Rigs.ContainsKey(kvp.Key))
                        return false;
                    if (m_Rigs[kvp.Key] < kvp.Value)
                        return false;
                }
                // subsystems
                foreach (KeyValuePair<string, uint> kvp in other.m_Subsystems) {
                    if (!m_Subsystems.ContainsKey(kvp.Key))
                        return false;
                    if (m_Subsystems[kvp.Key] < kvp.Value)
                        return false;
                }
                return true;
            }

            private string m_SummaryString = null;
            public string Summary {
                get {
                    if (m_SummaryString == null) {
                        m_SummaryString = GenerateSummaryString();
                    }
                    return m_SummaryString;
                }
            }

            private string GenerateSummaryString() {
                return String.Format("{0}, {1}% fit, {2}, {3}", m_ShipName, (int)(100.0f*m_ModulePercentile), GetEHPString(), GetPriceString());
            }

            private string GetEHPString() {
                if (m_EHP < 1000.0f) {
                    return String.Format("{0:f0} EHP", m_EHP);
                }
                else if (m_EHP < 1000000.0f) {
                    return String.Format("{0:f0}k EHP", m_EHP / 1000.0f);
                }
                else {
                    return String.Format("{0:f0}M EHP", m_EHP / 1000000.0f);
                }
            }

            private string GetPriceString() {
                if (m_Price < 1000.0f) {
                    return String.Format("{0:f0} isk", m_Price);
                }
                else if (m_Price < 1000000.0f) {
                    return String.Format("{0:f0} k", m_Price / 1000.0f);
                }
                else if (m_Price < 1000000000.0f) {
                    return String.Format("{0:f0} M", m_Price / 1000000.0f);
                }
                else {
                    return String.Format("{0:f1} B", m_Price / 1000000000.0f);
                }
            }

            private string m_FitString = null;
            public string Fit {
                get {
                    if (m_FitString == null) {
                        m_FitString = GenerateFitString();
                    }
                    return m_FitString;
                }
            }

            private string GenerateFitString() {
                string Result = "[" + m_ShipName + ", scanned fit]" + System.Environment.NewLine;

                if (m_SubsystemSlotCount> 0) {
                    Result += System.Environment.NewLine;
                }
                foreach (KeyValuePair<string,uint> kvp in m_Subsystems) {
                    Debug.Assert(kvp.Value == 1);
                    Result += (kvp.Key + System.Environment.NewLine);
                }
                for (int i = m_Subsystems.Count; i < m_SubsystemSlotCount; ++i) {
                    Result += ("[empty subsystem slot]" + System.Environment.NewLine);
                }

                if (m_HighSlotCount > 0) {
                    Result += System.Environment.NewLine;
                    uint nModules = 0;
                    foreach (KeyValuePair<string, uint> kvp in m_HighSlotModules) {
                        nModules += kvp.Value;
                        for (uint i = 0; i < kvp.Value; ++i) {
                            Result += (kvp.Key + System.Environment.NewLine);
                        }
                    }
                    for (uint i = nModules; i < m_HighSlotCount; ++i) {
                        Result += ("[empty high slot]" + System.Environment.NewLine);
                    }
                }

                if (m_MediumSlotCount > 0) {
                    Result += System.Environment.NewLine;
                    uint nModules = 0;
                    foreach (KeyValuePair<string, uint> kvp in m_MediumSlotModules) {
                        nModules += kvp.Value;
                        for (uint i = 0; i < kvp.Value; ++i) {
                            Result += (kvp.Key + System.Environment.NewLine);
                        }
                    }
                    for (uint i = nModules; i < m_MediumSlotCount; ++i) {
                        Result += ("[empty medium slot]" + System.Environment.NewLine);
                    }
                }

                if (m_LowSlotCount > 0) {
                    Result += System.Environment.NewLine;
                    uint nModules = 0;
                    foreach (KeyValuePair<string, uint> kvp in m_LowSlotModules) {
                        nModules += kvp.Value;
                        for (uint i = 0; i < kvp.Value; ++i) {
                            Result += (kvp.Key + System.Environment.NewLine);
                        }
                    }
                    for (uint i = nModules; i < m_LowSlotCount; ++i) {
                        Result += ("[empty low slot]" + System.Environment.NewLine);
                    }
                }

                if (m_RigSlotCount> 0) {
                    Result += System.Environment.NewLine;
                    uint nModules = 0;
                    foreach (KeyValuePair<string, uint> kvp in m_Rigs) {
                        nModules += kvp.Value;
                        for (uint i = 0; i < kvp.Value; ++i) {
                            Result += (kvp.Key + System.Environment.NewLine);
                        }
                    }
                    for (uint i = nModules; i < m_RigSlotCount; ++i) {
                        Result += ("[empty high slot]" + System.Environment.NewLine);
                    }
                }

                return Result;
            }

        };
    }
}
