using System;
using System.Collections.Generic;

namespace EveFitScanUI
{
    partial class FitScanProcessor {

        public void SetShipName(string ShipName) {
            int Index = -1;
            if (Model.ShipNameToIndex.TryGetValue(ShipName, out Index)) {
                int ShipTypeID = Model.ShipDescriptions[Index].m_TypeID;
                Model.SetShip(ShipTypeID);
            }
        }

        public void ResetFit() {
            Model.SetShipAndModules(Model.ShipTypeID, new List<int>());
        }

        public IReadOnlyCollection<string> SuggestNames(string Prefix) {
            if (Prefix.Length >= 3)
            {
                return Model.SuggestNames(Prefix);
            }
            return new List<string>();
        }

        private ShipModel m_ShipModel = null;
        private ShipModel Model {
            get {
                if (m_ShipModel == null) {
                    m_ShipModel = new ShipModel();
                    m_ShipModel.EventFitChanged += new ShipModel.DelegateFitChanged(OnFitChanged);
                    m_ShipModel.EventTankChanged += new ShipModel.DelegateTankChanged(OnTankChanged);
                }
                return m_ShipModel;
            }
        }

        private void OnFitChanged() {
            m_ShipName = Model.GetShipName(Model.ShipTypeID);

            IReadOnlyDictionary<ShipModel.SLOT, Dictionary<int, int>> ShipFit = Model.Fit;

            m_HighPowerModules.Clear();
            if (ShipFit.ContainsKey(ShipModel.SLOT.HIGH))
            {
                foreach (KeyValuePair<int, int> ModuleTypeIDAndCount in ShipFit[ShipModel.SLOT.HIGH]) {
                    string ModuleName = Model.GetModuleName(ModuleTypeIDAndCount.Key);
                    for (int i = 0; i < ModuleTypeIDAndCount.Value; ++i) {
                        m_HighPowerModules.Add(ModuleName);
                    }
                }
            }

            m_MediumPowerModules.Clear();
            if (ShipFit.ContainsKey(ShipModel.SLOT.MEDIUM))
            {
                foreach (KeyValuePair<int, int> ModuleTypeIDAndCount in ShipFit[ShipModel.SLOT.MEDIUM])
                {
                    string ModuleName = Model.GetModuleName(ModuleTypeIDAndCount.Key);
                    for (int i = 0; i < ModuleTypeIDAndCount.Value; ++i)
                    {
                        m_MediumPowerModules.Add(ModuleName);
                    }
                }
            }

            m_LowPowerModules.Clear();
            if (ShipFit.ContainsKey(ShipModel.SLOT.LOW))
            {
                foreach (KeyValuePair<int, int> ModuleTypeIDAndCount in ShipFit[ShipModel.SLOT.LOW])
                {
                    string ModuleName = Model.GetModuleName(ModuleTypeIDAndCount.Key);
                    for (int i = 0; i < ModuleTypeIDAndCount.Value; ++i)
                    {
                        m_LowPowerModules.Add(ModuleName);
                    }
                }
            }

            m_Rigs.Clear();
            if (ShipFit.ContainsKey(ShipModel.SLOT.RIG))
            {
                foreach (KeyValuePair<int, int> ModuleTypeIDAndCount in ShipFit[ShipModel.SLOT.RIG])
                {
                    string ModuleName = Model.GetModuleName(ModuleTypeIDAndCount.Key);
                    for (int i = 0; i < ModuleTypeIDAndCount.Value; ++i)
                    {
                        m_Rigs.Add(ModuleName);
                    }
                }
            }

            GenerateCODEToolURL();
            GenerateEFTFit();

            EventShipFitChanged();
        }

        private void GenerateCODEToolURL() {
            m_CODEToolURL = "http://halaimacode.byethost8.com/fitscan.html#";
            m_CODEToolURL += Model.ShipTypeID.ToString() + ":";
            foreach (KeyValuePair<ShipModel.SLOT, Dictionary<int, int>> kvp in Model.Fit)
            {
                foreach (KeyValuePair<int,int> Modules in kvp.Value) {
                    m_CODEToolURL += Modules.Key.ToString() + ';' + Modules.Value.ToString() + ':';
                }
            }
            m_CODEToolURL += ":";
        }

        private void GenerateEFTFit() {
            m_EFTFit = ("[" + m_ShipName + "]" + System.Environment.NewLine + System.Environment.NewLine);

            if (m_HighPowerModules.Count > 0)
            {
                m_EFTFit += System.Environment.NewLine;
            }
            foreach (string Name in m_HighPowerModules)
            {
                m_EFTFit += (Name + System.Environment.NewLine);
            }
            for (int i = m_HighPowerModules.Count; i < HighSlots; ++i)
            {
                m_EFTFit += ("[empty high slot]" + System.Environment.NewLine);
            }

            if (m_MediumPowerModules.Count > 0)
            {
                m_EFTFit += System.Environment.NewLine;
            }
            foreach (string Name in m_MediumPowerModules)
            {
                m_EFTFit += (Name + System.Environment.NewLine);
            }
            for (int i = m_MediumPowerModules.Count; i < MediumSlots; ++i)
            {
                m_EFTFit += ("[empty mid slot]" + System.Environment.NewLine);
            }

            if (m_LowPowerModules.Count > 0)
            {
                m_EFTFit += System.Environment.NewLine;
            }
            foreach (string Name in m_LowPowerModules)
            {
                m_EFTFit += (Name + System.Environment.NewLine);
            }
            for (int i = m_LowPowerModules.Count; i < LowSlots; ++i)
            {
                m_EFTFit += ("[empty low slot]" + System.Environment.NewLine);
            }

            if (m_Rigs.Count > 0)
            {
                m_EFTFit += System.Environment.NewLine;
            }
            foreach (string Name in m_Rigs)
            {
                m_EFTFit += (Name + System.Environment.NewLine);
            }
            for (int i = m_Rigs.Count; i < RigSlots; ++i)
            {
                m_EFTFit += ("[empty rig slot]" + System.Environment.NewLine);
            }
        }

        private void OnTankChanged()
        {
            IReadOnlyDictionary<ShipModel.LAYER, Tuple<float, Dictionary<ShipModel.RESIST, float>, Dictionary<ShipModel.RESIST, float>>> Tank = Model.Tank;

            m_ShieldHP = Tank[ShipModel.LAYER.SHIELD].Item1;
            m_ShieldResists = Tank[ShipModel.LAYER.SHIELD].Item2;
            m_ShieldResistsHeated = Tank[ShipModel.LAYER.SHIELD].Item3;

            m_ArmorHP = Tank[ShipModel.LAYER.ARMOR].Item1;
            m_ArmorResists = Tank[ShipModel.LAYER.ARMOR].Item2;
            m_ArmorResistsHeated = Tank[ShipModel.LAYER.ARMOR].Item3;

            m_HullHP = Tank[ShipModel.LAYER.HULL].Item1;
            m_HullResists = Tank[ShipModel.LAYER.HULL].Item2;
            m_HullResistsHeated = Tank[ShipModel.LAYER.HULL].Item3;

            m_TankText = "";
            m_TankText += (String.Format("ShieldHP : {0}", m_ShieldHP) + System.Environment.NewLine);
            m_TankText += (String.Format("Shield resists:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_ShieldResists[ShipModel.RESIST.EM] * 100.0f, m_ShieldResists[ShipModel.RESIST.THERMAL] * 100.0f, m_ShieldResists[ShipModel.RESIST.KINETIC] * 100.0f, m_ShieldResists[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);
            m_TankText += (String.Format("Shield resists heated:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_ShieldResistsHeated[ShipModel.RESIST.EM] * 100.0f, m_ShieldResistsHeated[ShipModel.RESIST.THERMAL] * 100.0f, m_ShieldResistsHeated[ShipModel.RESIST.KINETIC] * 100.0f, m_ShieldResistsHeated[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);
            m_TankText += System.Environment.NewLine;
            m_TankText += (String.Format("ArmorHP : {0}", m_ArmorHP) + System.Environment.NewLine);
            m_TankText += (String.Format("Armor resists:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_ArmorResists[ShipModel.RESIST.EM] * 100.0f, m_ArmorResists[ShipModel.RESIST.THERMAL] * 100.0f, m_ArmorResists[ShipModel.RESIST.KINETIC] * 100.0f, m_ArmorResists[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);
            m_TankText += (String.Format("Armor resists heated:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_ArmorResistsHeated[ShipModel.RESIST.EM] * 100.0f, m_ArmorResistsHeated[ShipModel.RESIST.THERMAL] * 100.0f, m_ArmorResistsHeated[ShipModel.RESIST.KINETIC] * 100.0f, m_ArmorResistsHeated[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);
            m_TankText += System.Environment.NewLine;
            m_TankText += (String.Format("HullHP : {0}", m_HullHP) + System.Environment.NewLine);
            m_TankText += (String.Format("Hull resists:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_HullResists[ShipModel.RESIST.EM] * 100.0f, m_HullResists[ShipModel.RESIST.THERMAL] * 100.0f, m_HullResists[ShipModel.RESIST.KINETIC] * 100.0f, m_HullResists[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);
            m_TankText += (String.Format("Hull resists heated:  EM={0:f}%, Therm={1:f}%, Kin={2:f}%, Expl={3:f}%", m_HullResistsHeated[ShipModel.RESIST.EM] * 100.0f, m_HullResistsHeated[ShipModel.RESIST.THERMAL] * 100.0f, m_HullResistsHeated[ShipModel.RESIST.KINETIC] * 100.0f, m_HullResistsHeated[ShipModel.RESIST.EXPLOSIVE] * 100.0f) + System.Environment.NewLine);

            EventShipTankChanged();
        }

    }
}