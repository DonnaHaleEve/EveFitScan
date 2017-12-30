﻿using System;
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
                int GroupID,
                MODULE_SLOT Slot,
                IReadOnlyDictionary<MODULE_ATTRIBUTES,Tuple<float,int>> Attributes
            )
            {
                m_Name = Name;
                m_TypeID = TypeID;
                m_GroupID = GroupID;
                m_Slot = Slot;
                m_Attributes = (Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>>)Attributes;
            }
            private string m_Name;
            private int m_TypeID;
            private int m_GroupID;
            private MODULE_SLOT m_Slot;
            private Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>> m_Attributes;

            public void Print(StreamWriter file)
            {
                //file.WriteLine("{0}", m_Name);
                //file.WriteLine("  slot = {0}", m_Slot);
                //file.WriteLine("  typeID = {0}", m_TypeID);
                //file.WriteLine("  groupID = {0}", m_GroupID);
                //file.WriteLine("");
                file.WriteLine("          m_ModuleDescriptions.Add((new ModuleDescription(\"{0}\",{1},{2})){3});", Escape(m_Name), m_TypeID, GetSlotName(m_Slot), StringifyAttributes());
            }

            private string StringifyAttributes() {
                string Result = "";

                Tuple<float, int> AttrValue;

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EM,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EM,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.THERMAL,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.THERMAL,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.KINETIC,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.KINETIC,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EXPLOSIVE,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.EXPLOSIVE,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EM,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EM,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.THERMAL,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.THERMAL,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.KINETIC,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.KINETIC,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EXPLOSIVE,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST_HEATED, out AttrValue))
                    {
                        Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.EXPLOSIVE,true,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                    }
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EM_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.EM,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_THERMAL_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.THERMAL,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_KINETIC_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.KINETIC,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EXPLOSIVE_RESIST, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.EXPLOSIVE,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.ADD,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.ADD,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.SHIELD,EFFECT.MULTIPLY,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.ARMOR,EFFECT.MULTIPLY,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }
                if (m_Attributes.TryGetValue(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_MULTIPLY, out AttrValue))
                {
                    Result = Result + String.Format(".AddEffect(LAYER.HULL,EFFECT.MULTIPLY,false,{0:f4}f,{1})", AttrValue.Item1, AttrValue.Item2);
                }

                return Result;
            }

            private string Escape(string S) {
                return S.Replace("\'", "\\\'");
            }

            private string GetSlotName(MODULE_SLOT Slot) {
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
                Debug.Assert(false,"unknown slot");
                return "";
            }
        };
    }
}
