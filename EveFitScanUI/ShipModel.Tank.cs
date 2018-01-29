using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    partial class ShipModel
    {
        // ==============================================================================================================
        #region "tank data"

        public delegate void DelegateTankChanged();
        public event DelegateTankChanged EventTankChanged;

        public enum RESIST { EM, THERMAL, KINETIC, EXPLOSIVE };
        private Dictionary<LAYER, Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>> m_Tank = new Dictionary<LAYER, Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>>();

        // maps layer to tuple of { HP + resists + heated resists }
        public IReadOnlyDictionary<LAYER, Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>> Tank
        {
            get {
                return m_Tank;
            }
        }

        private bool m_bPassiveTank = true;
        public bool PassiveTank {
            get {
                return m_bPassiveTank;
            }
        }

        #endregion
        // ==============================================================================================================

        private void RecalculateTank() {
            if (!m_ValidFit || m_ShipTypeID < 0)
            {
                TankForInvalidFit();
            }
            else {
                int ShipIndex = -1;
                bool Ok = ShipTypeIDToIndex.TryGetValue(m_ShipTypeID, out ShipIndex);
                Debug.Assert(Ok && ShipIndex >= 0 && ShipIndex < ShipDescriptions.Count);
                ShipDescription SD = ShipDescriptions[ShipIndex];

                Dictionary<int, int> AllModuleIDs = new Dictionary<int, int>();
                foreach (SLOT Slot in Enum.GetValues(typeof(SLOT))) {
                    foreach (KeyValuePair<int,int> ModuleAndCount in m_Fit[Slot]) {
                        AllModuleIDs[ModuleAndCount.Key] = ModuleAndCount.Value;
                    }
                }
                List<Tuple<ModuleDescription, int>> AllModules = new List<Tuple<ModuleDescription, int>>();
                foreach (KeyValuePair<int,int> kvp in AllModuleIDs) {
                    int Index = -1;
                    Ok = ModuleTypeIDToIndex.TryGetValue(kvp.Key, out Index);
                    Debug.Assert(Ok);
                    AllModules.Add(new Tuple<ModuleDescription, int>(ModuleDescriptions[Index], kvp.Value));
                }

                m_Tank[LAYER.SHIELD] = GetLayerTank(SD.m_ShieldHP, SD.m_ShieldHPMultiplier, SD.m_ShieldResistEM, SD.m_ShieldResistThermal, SD.m_ShieldResistKinetic, SD.m_ShieldResistExplosive, LAYER.SHIELD, AllModules, SD.m_OverheatingBonus);
                m_Tank[LAYER.ARMOR] = GetLayerTank(SD.m_ArmorHP, SD.m_ArmorHPMultiplier, SD.m_ArmorResistEM, SD.m_ArmorResistThermal, SD.m_ArmorResistKinetic, SD.m_ArmorResistExplosive, LAYER.ARMOR, AllModules, SD.m_OverheatingBonus);
                m_Tank[LAYER.HULL] = GetLayerTank(SD.m_HullHP, SD.m_HullHPMultiplier, SD.m_HullResistEM, SD.m_HullResistThermal, SD.m_HullResistKinetic, SD.m_HullResistExplosive, LAYER.HULL, AllModules, SD.m_OverheatingBonus);
            }

            EventTankChanged();
        }

        private Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>
            GetLayerTank(float BaseHP, float LayerMultiplier, float ResistEM, float ResistThermal, float ResistKinetic, float ResistExplosive, LAYER Layer, IReadOnlyCollection<Tuple<ModuleDescription, int>> Modules, float ShipOverheatingBonus)
        {
            float FlatHPBonus = 0.0f;
            float HPMultiplier = LayerMultiplier;

            // resist => cold/hot => stacking_group => list of resist bonuses
            Dictionary<RESIST, Dictionary<bool, Dictionary<int, List<float>>>> ResistBonuses = new Dictionary<RESIST, Dictionary<bool, Dictionary<int, List<float>>>>();

            float SubsystemOverheatingBonus = 0.0f;
            foreach (Tuple<ModuleDescription, int> ModuleAndCount in Modules)
            {
                int Count = ModuleAndCount.Item2;
                if (ModuleAndCount.Item1.m_Effects.ContainsKey(Layer)) {
                    if (ModuleAndCount.Item1.m_Effects[Layer].ContainsKey(EFFECT.OVERHEATING)) {
                        Debug.Assert(Count == 1);
                        Debug.Assert(SubsystemOverheatingBonus <= 0.0f);
                        SubsystemOverheatingBonus = ModuleAndCount.Item1.m_Effects[Layer][EFFECT.OVERHEATING].Item1;
                        Debug.Assert(SubsystemOverheatingBonus > 0.0f);
                    }
                }
            }

            foreach (Tuple<ModuleDescription, int> ModuleAndCount in Modules) {
                int Count = ModuleAndCount.Item2;
                if (ModuleAndCount.Item1.m_Effects.ContainsKey(Layer)) {
                    foreach (EFFECT Effect in ModuleAndCount.Item1.m_Effects[Layer].Keys) {
                        Tuple<float, bool, int> EffectParams = ModuleAndCount.Item1.m_Effects[Layer][Effect];
                        switch (Effect) {
                            case EFFECT.ADD:
                                Debug.Assert(EffectParams.Item2 == false); // all flat shield/armor/hull bonuses belong to passive modules
                                Debug.Assert(EffectParams.Item3 == 1); // all flat shield/armor/hull bonuses have stacking group 1
                                FlatHPBonus += (EffectParams.Item1 * Count);
                                break;
                            case EFFECT.MULTIPLY:
                                Debug.Assert(EffectParams.Item2 == false); // all multiplicative shield/armor/hull bonuses belong to passive modules
                                Debug.Assert(EffectParams.Item3 == 1); // all multiplicative shield/armor/hull bonuses have stacking group 1
                                HPMultiplier *= (float)Math.Pow(EffectParams.Item1, Count);
                                break;
                            case EFFECT.EM:
                            case EFFECT.THERMAL:
                            case EFFECT.KINETIC:
                            case EFFECT.EXPLOSIVE:
                                RESIST Resist = EffectToResist(Effect);
                                if (!EffectParams.Item2) {
                                    // passive effect
                                    AddTo(ref ResistBonuses, Resist, false, EffectParams.Item3, EffectParams.Item1, Count);
                                    AddTo(ref ResistBonuses, Resist, true, EffectParams.Item3, EffectParams.Item1, Count);
                                }
                                else {
                                    // active effect
                                    if (!PassiveTank) {
                                        AddTo(ref ResistBonuses, Resist, false, EffectParams.Item3, EffectParams.Item1, Count);
                                        float OverloadBonus = ModuleAndCount.Item1.m_OverloadBonus;
                                        if (OverloadBonus > 0.01f) {
                                            float OverloadedResist = EffectParams.Item1 * (1.0f + OverloadBonus * (1.0f + ShipOverheatingBonus + SubsystemOverheatingBonus));
                                            AddTo(ref ResistBonuses, Resist, true, EffectParams.Item3, OverloadedResist, Count);
                                        }
                                        else {
                                            AddTo(ref ResistBonuses, Resist, true, EffectParams.Item3, EffectParams.Item1, Count);
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            float LayerHP = (BaseHP + FlatHPBonus) * HPMultiplier;
            LayerHP *= 1.25f; // Shield Management / Hull Upgrades / Mechanics

            Dictionary<RESIST, Dictionary<bool, float>> Resonances = new Dictionary<RESIST, Dictionary<bool, float>>();
            Resonances[RESIST.EM] = new Dictionary<bool, float>();
            Resonances[RESIST.THERMAL] = new Dictionary<bool, float>();
            Resonances[RESIST.KINETIC] = new Dictionary<bool, float>();
            Resonances[RESIST.EXPLOSIVE] = new Dictionary<bool, float>();

            foreach (RESIST Resist in ResistBonuses.Keys)
            {
                foreach (bool Hot in ResistBonuses[Resist].Keys)
                {
                    float ResonanceCombined = 1.0f;
                    foreach (int StackGroup in ResistBonuses[Resist][Hot].Keys)
                    {
                        List<float> ResistsGroup = ResistBonuses[Resist][Hot][StackGroup];
                        ResistsGroup.Sort(
                            delegate(float a, float b)
                            {
                                if (a < b)
                                    return 1;
                                if (a > b)
                                    return -1;
                                return 0;
                            }
                        );

                        float Resonance = 1.0f;
                        for (int i = 0; i < ResistsGroup.Count; ++i)
                        {
                            float pc = PenaltyCoeff(i);
                            Resonance *= (1.0f - ResistsGroup[i] * pc);
                        }

                        ResonanceCombined *= Resonance;
                    }
                    Resonances[Resist][Hot] = ResonanceCombined;
                }
            }

            Dictionary<RESIST, float> ResistsCold = new Dictionary<RESIST, float>();
            ResistsCold[RESIST.EM] = 1.0f - (1.0f - ResistEM) * GetResonance(Resonances, RESIST.EM, false);
            ResistsCold[RESIST.THERMAL] = 1.0f - (1.0f - ResistThermal) * GetResonance(Resonances, RESIST.THERMAL, false);
            ResistsCold[RESIST.KINETIC] = 1.0f - (1.0f - ResistKinetic) * GetResonance(Resonances, RESIST.KINETIC, false);
            ResistsCold[RESIST.EXPLOSIVE] = 1.0f - (1.0f - ResistExplosive) * GetResonance(Resonances, RESIST.EXPLOSIVE, false);

            Dictionary<RESIST, float> ResistsHot = new Dictionary<RESIST, float>();
            ResistsHot[RESIST.EM] = 1.0f - (1.0f - ResistEM) * GetResonance(Resonances, RESIST.EM, true);
            ResistsHot[RESIST.THERMAL] = 1.0f - (1.0f - ResistThermal) * GetResonance(Resonances, RESIST.THERMAL, true);
            ResistsHot[RESIST.KINETIC] = 1.0f - (1.0f - ResistKinetic) * GetResonance(Resonances, RESIST.KINETIC, true);
            ResistsHot[RESIST.EXPLOSIVE] = 1.0f - (1.0f - ResistExplosive) * GetResonance(Resonances, RESIST.EXPLOSIVE, true);

            return new Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>(LayerHP, ResistsCold, ResistsHot);
        }

        float GetResonance(IReadOnlyDictionary<RESIST, Dictionary<bool, float>> Resonances, RESIST Resist, bool Hot) {
            if (Resonances.ContainsKey(Resist))
            {
                if (Resonances[Resist].ContainsKey(Hot)) {
                    return Resonances[Resist][Hot];
                }
            }
            return 1.0f;
        }

        private float PenaltyCoeff(int i) {
            double n = (double)i;
            return (float)Math.Exp( -Math.Pow( n/2.67, 2.0) );
        }

        private void AddTo(ref Dictionary<RESIST, Dictionary<bool, Dictionary<int, List<float>>>> ResistBonuses, RESIST Resist, bool Hot, int StackGroup, float Value, int Count)
        {
            if (!ResistBonuses.ContainsKey(Resist))
                ResistBonuses.Add(Resist, new Dictionary<bool,Dictionary<int,List<float>>>());
            if (!ResistBonuses[Resist].ContainsKey(Hot))
                ResistBonuses[Resist].Add(Hot, new Dictionary<int,List<float>>());
            if (!ResistBonuses[Resist][Hot].ContainsKey(StackGroup))
                ResistBonuses[Resist][Hot].Add(StackGroup, new List<float>());
            for (int i = 0; i < Count; ++i) {
                ResistBonuses[Resist][Hot][StackGroup].Add(Value);
            }
        }

        private RESIST EffectToResist(EFFECT Effect) {
            if (Effect == EFFECT.EM)
                return RESIST.EM;
            if (Effect == EFFECT.THERMAL)
                return RESIST.THERMAL;
            if (Effect == EFFECT.KINETIC)
                return RESIST.KINETIC;
            if (Effect == EFFECT.EXPLOSIVE)
                return RESIST.EXPLOSIVE;
            Debug.Assert(true); // should never happen
            return RESIST.EM;
        }

        private void TankForInvalidFit() {
            Dictionary<RESIST, float> NoResists = new Dictionary<RESIST, float>();
            NoResists[RESIST.EM] = 0.0f;
            NoResists[RESIST.THERMAL] = 0.0f;
            NoResists[RESIST.KINETIC] = 0.0f;
            NoResists[RESIST.EXPLOSIVE] = 0.0f;
            Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>> NoLayerTank = new Tuple<float, Dictionary<RESIST, float>, Dictionary<RESIST, float>>(0.0f, NoResists, NoResists);
            m_Tank[LAYER.SHIELD] = NoLayerTank;
            m_Tank[LAYER.ARMOR] = NoLayerTank;
            m_Tank[LAYER.HULL] = NoLayerTank;
        }
    }
}