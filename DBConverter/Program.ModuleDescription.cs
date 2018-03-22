using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DBConverter
{
    partial class Program
    {
        struct ModuleDescription
        {
            public ModuleDescription(
                string Name,
                int TypeID,
                MODULE_SLOT Slot,
                Dictionary<MODULE_ATTRIBUTES, Dictionary<MODULE_ACTIVE, Tuple<float, int>>> Attributes,
                float OverloadBonus,
                int ShipTypeID
            )
            {
                m_Name = Name;
                m_TypeID = TypeID;
                m_Slot = Slot;
                m_Attributes = Attributes;
                m_OverloadBonus = OverloadBonus;
                m_ShipTypeID = ShipTypeID;
            }
            private string m_Name;
            private int m_TypeID;
            private MODULE_SLOT m_Slot;
            private Dictionary<MODULE_ATTRIBUTES, Dictionary<MODULE_ACTIVE, Tuple<float, int>>> m_Attributes;
            private float m_OverloadBonus;
            private int m_ShipTypeID;

            public void Print(StreamWriter file)
            {
                file.WriteLine("          m_ModuleDescriptions.Add((new ModuleDescription(\"{0}\",{1},{2},{3:f1}f,{4})){5});", Escape(m_Name), m_TypeID, GetSlotName(m_Slot, m_Name), m_OverloadBonus, m_ShipTypeID, StringifyAttributes());
            }

            private string StringifyAttributes() {
                string Result = "";

                foreach (MODULE_ATTRIBUTES Attr in m_Attributes.Keys) {
                    foreach (MODULE_ACTIVE Active in m_Attributes[Attr].Keys) {
                        float AttributeValue = m_Attributes[Attr][Active].Item1;
                        int StackGroup = m_Attributes[Attr][Active].Item2;

                        Result = Result + String.Format(".AddEffect({0},{1:f4}f,{2},{3})", AttributeToString[Attr], AttributeValue, GetActiveName(Active), StackGroup);
                    }
                }

                return Result;
            }

            private static Dictionary<MODULE_ATTRIBUTES, string> m_AttributeToString = null;
            private static IReadOnlyDictionary<MODULE_ATTRIBUTES, string> AttributeToString {
                get {
                    if (m_AttributeToString == null) {
                        m_AttributeToString = new Dictionary<MODULE_ATTRIBUTES, string> {
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, "LAYER.SHIELD,EFFECT.EM"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST,"LAYER.SHIELD,EFFECT.THERMAL"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST,"LAYER.SHIELD,EFFECT.KINETIC"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST,"LAYER.SHIELD,EFFECT.EXPLOSIVE"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST,"LAYER.ARMOR,EFFECT.EM"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST,"LAYER.ARMOR,EFFECT.THERMAL"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST,"LAYER.ARMOR,EFFECT.KINETIC"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST,"LAYER.ARMOR,EFFECT.EXPLOSIVE"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EM_RESIST,"LAYER.HULL,EFFECT.EM"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_THERMAL_RESIST,"LAYER.HULL,EFFECT.THERMAL"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_KINETIC_RESIST,"LAYER.HULL,EFFECT.KINETIC"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EXPLOSIVE_RESIST,"LAYER.HULL,EFFECT.EXPLOSIVE"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD,"LAYER.SHIELD,EFFECT.ADD"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD,"LAYER.ARMOR,EFFECT.ADD"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_ADD,"LAYER.HULL,EFFECT.ADD"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY,"LAYER.SHIELD,EFFECT.MULTIPLY"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY,"LAYER.ARMOR,EFFECT.MULTIPLY"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_MULTIPLY,"LAYER.HULL,EFFECT.MULTIPLY"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HIGH_SLOTS,"LAYER.NONE,EFFECT.HIGH_SLOTS"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_MEDIUM_SLOTS,"LAYER.NONE,EFFECT.MEDIUM_SLOTS"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_LOW_SLOTS,"LAYER.NONE,EFFECT.LOW_SLOTS"},

                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_HARDENERS_OVERLOAD_BONUS,"LAYER.SHIELD,EFFECT.OVERHEATING"},
                            {MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_HARDENERS_OVERLOAD_BONUS,"LAYER.ARMOR,EFFECT.OVERHEATING"}
                        };
                    }
                    return m_AttributeToString;
                }
            }

            private string Escape(string S) {
                return S.Replace("\'", "\\\'");
            }

            private string GetActiveName(MODULE_ACTIVE Active) {
                if (Active == MODULE_ACTIVE.PASSIVE) {
                    return "ACTIVE.PASSIVE";
                } else if (Active == MODULE_ACTIVE.ACTIVE) {
                    return "ACTIVE.ACTIVE";
                } else if (Active == MODULE_ACTIVE.ASSAULT_PASSIVE) {
                    return "ACTIVE.ASSAULT_PASSIVE";
                } else if (Active == MODULE_ACTIVE.ASSAULT_ACTIVE) {
                    return "ACTIVE.ASSAULT_ACTIVE";
                }
                else {
                    return "FAIL_COMPILATION";
                }
            }

            private string GetSlotName(MODULE_SLOT Slot, string ModuleName) {
                if (Slot == MODULE_SLOT.HIGH_POWER) {
                    return "SLOT.HIGH";
                }
                else if (Slot == MODULE_SLOT.MEDIUM_POWER) {
                    return "SLOT.MEDIUM";
                }
                else if (Slot == MODULE_SLOT.LOW_POWER)
                {
                    return "SLOT.LOW";
                }
                else if (Slot == MODULE_SLOT.RIG)
                {
                    return "SLOT.RIG";
                }
                else if (Slot == MODULE_SLOT.SUBSYSTEM)
                {
                    if (ModuleName.Contains(" Core - ")) {
                        return "SLOT.SUB_CORE";
                    }
                    else if (ModuleName.Contains(" Defensive - ")) {
                        return "SLOT.SUB_DEFENSIVE";
                    }
                    else if (ModuleName.Contains(" Offensive - "))
                    {
                        return "SLOT.SUB_OFFENSIVE";
                    }
                    else if (ModuleName.Contains(" Propulsion - "))
                    {
                        return "SLOT.SUB_PROPULSION";
                    }
                }
                Debug.Assert(false, "unknown slot");
                return "";
            }
        };
    }
}
