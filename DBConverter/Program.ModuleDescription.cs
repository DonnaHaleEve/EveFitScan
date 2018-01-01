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
                IReadOnlyDictionary<MODULE_ATTRIBUTES,Tuple<float,int>> Attributes,
                float OverloadBonus,
                int ShipTypeID
            )
            {
                m_Name = Name;
                m_TypeID = TypeID;
                m_Slot = Slot;
                m_Attributes = (Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>>)Attributes;
                m_OverloadBonus = OverloadBonus;
                m_ShipTypeID = ShipTypeID;
            }
            private string m_Name;
            private int m_TypeID;
            private MODULE_SLOT m_Slot;
            private Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>> m_Attributes;
            private float m_OverloadBonus;
            private int m_ShipTypeID;

            public void Print(StreamWriter file)
            {
                file.WriteLine("          m_ModuleDescriptions.Add((new ModuleDescription(\"{0}\",{1},{2},{3:f1}f,{4})){5});", Escape(m_Name), m_TypeID, GetSlotName(m_Slot, m_Name), m_OverloadBonus, m_ShipTypeID, StringifyAttributes());
            }

            private string StringifyAttributes() {
                string Result = "";

                Tuple<float, int> AttrValue;

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EM,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.THERMAL,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.KINETIC,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EXPLOSIVE,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EM,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.THERMAL,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.KINETIC,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EXPLOSIVE,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.EM,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.THERMAL,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.KINETIC,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.EXPLOSIVE,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.ADD,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.ADD,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_ADD, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.ADD,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.MULTIPLY,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.MULTIPLY,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.MULTIPLY,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HIGH_SLOTS, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.NONE,EFFECT.HIGH_SLOTS,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_MEDIUM_SLOTS, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.NONE,EFFECT.MEDIUM_SLOTS,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_LOW_SLOTS, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.NONE,EFFECT.LOW_SLOTS,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_HARDENERS_OVERLOAD_BONUS, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.OVERHEATING,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_HARDENERS_OVERLOAD_BONUS, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.OVERHEATING,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                return Result;
            }

            private string Escape(string S) {
                return S.Replace("\'", "\\\'");
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
