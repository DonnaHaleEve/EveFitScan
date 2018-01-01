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

        public int CoreSlots {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.SUB_CORE, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }
        public int DefensiveSlots
        {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.SUB_DEFENSIVE, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }
        public int OffensiveSlots
        {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.SUB_OFFENSIVE, out Slots))
                {
                    return Slots;
                }
                return 0;
            }
        }
        public int PropulsionSlots
        {
            get
            {
                int Slots = 0;
                if (m_Slots.TryGetValue(SLOT.SUB_PROPULSION, out Slots))
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

            if (m_ShipTypeID > 0) {
                int Index = -1;
                if (ShipTypeIDToIndex.TryGetValue(ShipTypeID, out Index)) {
                    ShipDescription SD = ShipDescriptions[Index];
                    if (SD.m_SubsystemSlots > 0) {
                        // recalc slot layout for t3 cruisers

                        int HS = SD.m_HighSlots;
                        int MS = SD.m_MedSlots;
                        int LS = SD.m_LowSlots;

                        foreach (SLOT Slot in new SLOT[] { SLOT.SUB_CORE, SLOT.SUB_DEFENSIVE, SLOT.SUB_OFFENSIVE, SLOT.SUB_PROPULSION })
                        {
                            foreach (KeyValuePair<int, int> kvp in m_Fit[Slot])
                            {
                                int ModuleTypeID = kvp.Key;
                                Index = -1;
                                bool Ok = ModuleTypeIDToIndex.TryGetValue(ModuleTypeID, out Index);
                                Debug.Assert(Ok && Index > 0);
                                ModuleDescription MD = ModuleDescriptions[Index];
                                if (MD.m_ShipTypeID == m_ShipTypeID) {
                                    if (MD.m_Effects.ContainsKey(LAYER.NONE)) {
                                        foreach (KeyValuePair<EFFECT, Tuple<float, int>> effect in MD.m_Effects[LAYER.NONE]) {
                                            switch (effect.Key) {
                                                case EFFECT.HIGH_SLOTS:
                                                    HS += (int)effect.Value.Item1;
                                                    break;
                                                case EFFECT.MEDIUM_SLOTS:
                                                    MS += (int)effect.Value.Item1;
                                                    break;
                                                case EFFECT.LOW_SLOTS:
                                                    LS += (int)effect.Value.Item1;
                                                    break;
                                            }
                                        }
                                    }
                                }

                                break; // only process first module. If there is more than one, fit is invalid anyway.
                            }
                        }
                        m_Slots[SLOT.HIGH] = HS;
                        m_Slots[SLOT.MEDIUM] = MS;
                        m_Slots[SLOT.LOW] = LS;
                    }
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
            if (m_ValidFit) {
                if (m_ShipTypeID > 0) {
                    int Index = -1;
                    if (ShipTypeIDToIndex.TryGetValue(ShipTypeID, out Index)) {
                        ShipDescription SD = ShipDescriptions[Index];
                        if (SD.m_SubsystemSlots > 0) {
                            //TODO: check that subsystems belong to current t3 hull
                            //TODO: check that all 4 subsystems are filled

                            foreach (SLOT Slot in new SLOT[] { SLOT.SUB_CORE, SLOT.SUB_DEFENSIVE, SLOT.SUB_OFFENSIVE, SLOT.SUB_PROPULSION }) {
                                if (m_Fit[Slot].Count != 1) {
                                    m_ValidFit = false;
                                    break;
                                }
                                foreach (KeyValuePair<int, int> kvp in m_Fit[Slot])
                                {
                                }
                            }
                        
                        
                        }
                    }
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
                if (SD.m_SubsystemSlots > 0) {
                    Debug.Assert(SD.m_SubsystemSlots == 4);
                    m_Slots[SLOT.SUB_CORE] = 1;
                    m_Slots[SLOT.SUB_DEFENSIVE] = 1;
                    m_Slots[SLOT.SUB_OFFENSIVE] = 1;
                    m_Slots[SLOT.SUB_PROPULSION] = 1;
                }
                else {
                    m_Slots[SLOT.SUB_CORE] = 0;
                    m_Slots[SLOT.SUB_DEFENSIVE] = 0;
                    m_Slots[SLOT.SUB_OFFENSIVE] = 0;
                    m_Slots[SLOT.SUB_PROPULSION] = 0;
                }
            }
            else
            {
                m_ShipTypeID = -1;
                m_Slots[SLOT.HIGH] = 8;
                m_Slots[SLOT.MEDIUM] = 8;
                m_Slots[SLOT.LOW] = 8;
                m_Slots[SLOT.RIG] = 3;
                m_Slots[SLOT.SUB_CORE] = 1;
                m_Slots[SLOT.SUB_DEFENSIVE] = 1;
                m_Slots[SLOT.SUB_OFFENSIVE] = 1;
                m_Slots[SLOT.SUB_PROPULSION] = 1;
            }
        }

        private void CleanFit(int ShipTypeID)
        {
            SetShipTypeID(ShipTypeID);
            m_Fit[SLOT.HIGH] = new Dictionary<int, int>();
            m_Fit[SLOT.MEDIUM] = new Dictionary<int, int>();
            m_Fit[SLOT.LOW] = new Dictionary<int, int>();
            m_Fit[SLOT.RIG] = new Dictionary<int, int>();
            m_Fit[SLOT.SUB_CORE] = new Dictionary<int, int>();
            m_Fit[SLOT.SUB_DEFENSIVE] = new Dictionary<int, int>();
            m_Fit[SLOT.SUB_OFFENSIVE] = new Dictionary<int, int>();
            m_Fit[SLOT.SUB_PROPULSION] = new Dictionary<int, int>();
        }

    }
}
