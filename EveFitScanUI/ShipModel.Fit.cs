using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    partial class ShipModel
    {
        // ==============================================================================================================
        #region "fit data"

        public delegate void DelegateFitChanged();
        public event DelegateFitChanged EventFitChanged;

        private bool m_ValidFit = true;
        public bool ValidFit
        {
            get
            {
                return m_ValidFit;
            }
        }

        private int m_ShipTypeID = -1;
        public int ShipTypeID {
            get {
                return m_ShipTypeID;
            }
        }

        private Dictionary<SLOT, int> m_Slots = new Dictionary<SLOT, int>();
        public int HighSlots {
            get {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.HIGH, out Slots)) {
                    return Slots;
                }
                return 0;
            }
        }
        public int MediumSlots {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.MEDIUM, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }
        public int LowSlots {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.LOW, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }
        public int RigSlots {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.RIG, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }

        // slot => { ModuleTypeID => count }
        private Dictionary<SLOT, Dictionary<int, int>> m_Fit = new Dictionary<SLOT, Dictionary<int, int>>();
        public IReadOnlyDictionary<SLOT, Dictionary<int, int>> Fit {
            get {
                return m_Fit;
            }
        }

        #endregion
        // ==============================================================================================================

        // ==============================================================================================================

        public void SetShipAndModules(int ShipTypeID, IReadOnlyCollection<int> ModuleTypeIDs)
        {
            Debug.Assert(ShipTypeID < 0 || ShipTypeIDToIndex.ContainsKey(ShipTypeID));
            foreach (int ModuleTypeID in ModuleTypeIDs) {
                Debug.Assert(ModuleTypeIDToIndex.ContainsKey(ModuleTypeID));
            }
            CleanFit(ShipTypeID);
            DoAddMoreModules(ModuleTypeIDs);
            CheckFitValid();
            EventFitChanged();

            RecalculateTank();
        }

        public void AddMoreModules(IReadOnlyCollection<int> ModuleTypeIDs)
        {
            DoAddMoreModules(ModuleTypeIDs);
            CheckFitValid();
            EventFitChanged();

            RecalculateTank();
        }

        public void SetShip(int ShipTypeID)
        {
            Debug.Assert(ShipTypeID < 0 || ShipTypeIDToIndex.ContainsKey(ShipTypeID));
            SetShipTypeID(ShipTypeID);
            CheckFitValid();
            EventFitChanged();

            RecalculateTank();
        }

        public void ResetFit()
        {
            CleanFit(m_ShipTypeID);
            CheckFitValid();
            EventFitChanged();

            RecalculateTank();
        }

        // ==============================================================================================================

        private void DoAddMoreModules(IReadOnlyCollection<int> ModuleTypeIDs)
        {
            Dictionary<int, int> NewModules = new Dictionary<int, int>();
            foreach (int ModuleTypeID in ModuleTypeIDs) {
                if (NewModules.ContainsKey(ModuleTypeID)) {
                    NewModules[ModuleTypeID]++;
                }
                else {
                    NewModules[ModuleTypeID] = 1;
                }
            }
            foreach (KeyValuePair<int,int> kvp in NewModules) {
                int ModuleTypeID = kvp.Key;
                int ModuleCount = kvp.Value;
                int Index = -1;
                bool Ok = ModuleTypeIDToIndex.TryGetValue(ModuleTypeID, out Index);
                Debug.Assert(Ok && Index > 0);
                ModuleDescription MD = ModuleDescriptions[Index];
                if (m_Fit[MD.m_Slot].ContainsKey(ModuleTypeID)) {
                    m_Fit[MD.m_Slot][ModuleTypeID] = Math.Max(m_Fit[MD.m_Slot][ModuleTypeID], ModuleCount);
                }
                else {
                    m_Fit[MD.m_Slot][ModuleTypeID] = ModuleCount;
                }
            }
        }

        private void CheckFitValid()
        {
            m_ValidFit = true;
            foreach (SLOT Slot in Enum.GetValues(typeof(SLOT)))
            {
                Debug.Assert(m_Fit.ContainsKey(Slot));
                int ModuleCount = 0;
                foreach (KeyValuePair<int,int> M in m_Fit[Slot]) {
                    ModuleCount += M.Value;
                }
                if (ModuleCount > m_Slots[Slot]) {
                    m_ValidFit = false;
                    break;
                }
            }
        }

        private void SetShipTypeID(int ShipTypeID)
        {
            int Index = -1;
            if (ShipTypeIDToIndex.TryGetValue(ShipTypeID, out Index))
            {
                Debug.Assert(Index >= 0);
                m_ShipTypeID = ShipTypeID;
                ShipDescription SD = ShipDescriptions[Index];
                m_Slots[SLOT.HIGH] = SD.m_HighSlots;
                m_Slots[SLOT.MEDIUM] = SD.m_MedSlots;
                m_Slots[SLOT.LOW] = SD.m_LowSlots;
                m_Slots[SLOT.RIG] = SD.m_RigSlots;
            }
            else
            {
                m_ShipTypeID = -1;
                m_Slots[SLOT.HIGH] = 8;
                m_Slots[SLOT.MEDIUM] = 8;
                m_Slots[SLOT.LOW] = 8;
                m_Slots[SLOT.RIG] = 3;
            }
        }

        private void CleanFit(int ShipTypeID)
        {
            SetShipTypeID(ShipTypeID);
            m_Fit[SLOT.HIGH] = new Dictionary<int, int>();
            m_Fit[SLOT.MEDIUM] = new Dictionary<int, int>();
            m_Fit[SLOT.LOW] = new Dictionary<int, int>();
            m_Fit[SLOT.RIG] = new Dictionary<int, int>();
        }

    }
}
