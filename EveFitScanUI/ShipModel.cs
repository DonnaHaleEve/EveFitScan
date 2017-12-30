using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    partial class ShipModel
    {
        // ==============================================================================================================
        #region "ship/module database"
        private Dictionary<string, int> m_ShipNameToIndex = null;
        public IReadOnlyDictionary<string, int> ShipNameToIndex {
            get {
                if (m_ShipNameToIndex == null) {
                    m_ShipNameToIndex = new Dictionary<string, int>();
                    for (int i = 0; i < ShipDescriptions.Count; ++i)
                    {
                        m_ShipNameToIndex.Add(ShipDescriptions[i].m_Name, i);
                    }
                }
                return m_ShipNameToIndex;
            }
        }

        private Dictionary<int, int> m_ShipTypeIDToIndex = null;
        public IReadOnlyDictionary<int, int> ShipTypeIDToIndex
        {
            get
            {
                if (m_ShipTypeIDToIndex == null)
                {
                    m_ShipTypeIDToIndex = new Dictionary<int, int>();
                    for (int i = 0; i < ShipDescriptions.Count; ++i)
                    {
                        m_ShipTypeIDToIndex.Add(ShipDescriptions[i].m_TypeID, i);
                    }
                }
                return m_ShipTypeIDToIndex;
            }
        }

        private Dictionary<string, int> m_ModuleNameToIndex = null;
        public IReadOnlyDictionary<string, int> ModuleNameToIndex
        {
            get
            {
                if (m_ModuleNameToIndex == null)
                {
                    m_ModuleNameToIndex = new Dictionary<string, int>();
                    for (int i = 0; i < ModuleDescriptions.Count; ++i)
                    {
                        m_ModuleNameToIndex.Add(ModuleDescriptions[i].m_Name, i);
                    }
                }
                return m_ModuleNameToIndex;
            }
        }
        
        
        private Dictionary<int, int> m_ModuleTypeIDToIndex = null;
        public IReadOnlyDictionary<int, int> ModuleTypeIDToIndex
        {
            get
            {
                if (m_ModuleTypeIDToIndex == null)
                {
                    m_ModuleTypeIDToIndex = new Dictionary<int, int>();
                    for (int i = 0; i < ModuleDescriptions.Count; ++i)
                    {
                        m_ModuleTypeIDToIndex.Add(ModuleDescriptions[i].m_TypeID, i);
                    }
                }
                return m_ModuleTypeIDToIndex;
            }
        }
        #endregion
        // ==============================================================================================================


        // ==============================================================================================================
        #region "conversions"
        public string GetShipName(int ShipTypeID)
        {
            if (ShipTypeID >= 0)
            {
                int Index = -1;
                bool Ok = ShipTypeIDToIndex.TryGetValue(ShipTypeID, out Index);
                Debug.Assert(Index >= 0 && Index < ShipDescriptions.Count);
                return ShipDescriptions[Index].m_Name;
            }
            else {
                return "unknown";
            }
        }
        public int GetShipTypeID(string ShipName)
        {
            int Index = -1;
            bool Ok = ShipNameToIndex.TryGetValue(ShipName, out Index);
            Debug.Assert(Index >= 0 && Index < ShipDescriptions.Count);
            return ShipDescriptions[Index].m_TypeID;
        }
        public string GetModuleName(int ModuleTypeID)
        {
            int Index = -1;
            bool Ok = ModuleTypeIDToIndex.TryGetValue(ModuleTypeID, out Index);
            Debug.Assert(Index >= 0 && Index < ModuleDescriptions.Count);
            return ModuleDescriptions[Index].m_Name;
        }
        public int GetModuleTypeID(string ModuleName)
        {
            int Index = -1;
            bool Ok = ModuleNameToIndex.TryGetValue(ModuleName, out Index);
            Debug.Assert(Index >= 0 && Index < ModuleDescriptions.Count);
            return ModuleDescriptions[Index].m_TypeID;
        }
        #endregion
        // ==============================================================================================================


        // ==============================================================================================================
        #region "ship name suggection"

        private List<Tuple<string,int>> m_ShipNamesSorted = null;
        private List<Tuple<string, int>> ShipNamesSorted
        {
            get {
                if (m_ShipNamesSorted == null) {
                    m_ShipNamesSorted = new List<Tuple<string, int>>();
                    for (int i = 0; i < ShipDescriptions.Count; ++i) {
                        string ShipNameLowercase = ShipDescriptions[i].m_Name.ToLower();
                        m_ShipNamesSorted.Add(new Tuple<string, int>(ShipNameLowercase, i));
                    }
                    m_ShipNamesSorted.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                }
                return m_ShipNamesSorted;
            }
        }

        public IReadOnlyCollection<string> SuggestNames(string Prefix) {
            Prefix = Prefix.ToLower();
            int qq = ShipNamesSorted.Count;

            int Index = 0;
            int PrefixPos = 0;
            for (PrefixPos = 0; PrefixPos < Prefix.Length; ++PrefixPos)
            {
                for (; Index < ShipNamesSorted.Count && ShipNamesSorted[Index].Item1[PrefixPos] < Prefix[PrefixPos]; Index++) { }
                if (ShipNamesSorted[Index].Item1[PrefixPos] > Prefix[PrefixPos]) {
                    break;
                }
            }

            List<string> Result = new List<string>();

            for (; Index < ShipNamesSorted.Count && ShipNamesSorted[Index].Item1.StartsWith(Prefix); Index++)
            {
                Result.Add(ShipDescriptions[ShipNamesSorted[Index].Item2].m_Name);
            }

            return Result;
        }

        #endregion
        // ==============================================================================================================

        public ShipModel()
        {
            CleanFit(-1);
        }

    }
}
