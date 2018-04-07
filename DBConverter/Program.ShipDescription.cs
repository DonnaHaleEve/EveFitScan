using System;
using System.IO;

namespace DBConverter
{
    partial class Program
    {
        struct ShipDescription
        {
            public ShipDescription(
                string Name,
                int TypeID,
                uint HighSlots,
                uint MedSlots,
                uint LowSlots,
                uint RigSlots,
                uint SubsystemSlots,
                float ShieldHP,
                float ShieldHPMultiplier,
                float ShieldResistEM,
                float ShieldResistThermal,
                float ShieldResistKinetic,
                float ShieldResistExplosive,
                float ArmorHP,
                float ArmorHPMultiplier,
                float ArmorResistEM,
                float ArmorResistThermal,
                float ArmorResistKinetic,
                float ArmorResistExplosive,
                float HullHP,
                float HullHPMultiplier,
                float HullResistEM,
                float HullResistThermal,
                float HullResistKinetic,
                float HullResistExplosive,
                float OverheatingBonus
            ) {
                m_Name = Name;
                m_TypeID = TypeID;

                m_HighSlots = HighSlots;
                m_MedSlots = MedSlots;
                m_LowSlots = LowSlots;
                m_RigSlots = RigSlots;
                m_SubsystemSlots = SubsystemSlots;

                m_ShieldHP = ShieldHP;
                m_ShieldHPMultiplier = ShieldHPMultiplier;
                m_ShieldResistEM = ShieldResistEM;
                m_ShieldResistThermal = ShieldResistThermal;
                m_ShieldResistKinetic = ShieldResistKinetic;
                m_ShieldResistExplosive = ShieldResistExplosive;

                m_ArmorHP = ArmorHP;
                m_ArmorHPMultiplier = ArmorHPMultiplier;
                m_ArmorResistEM = ArmorResistEM;
                m_ArmorResistThermal = ArmorResistThermal;
                m_ArmorResistKinetic = ArmorResistKinetic;
                m_ArmorResistExplosive = ArmorResistExplosive;

                m_HullHP = HullHP;
                m_HullHPMultiplier = HullHPMultiplier;
                m_HullResistEM = HullResistEM;
                m_HullResistThermal = HullResistThermal;
                m_HullResistKinetic = HullResistKinetic;
                m_HullResistExplosive = HullResistExplosive;

                m_OverheatingBonus = OverheatingBonus;
            }
            public string m_Name;
            public int m_TypeID;

            public uint m_HighSlots;
            public uint m_MedSlots;
            public uint m_LowSlots;
            public uint m_RigSlots;
            public uint m_SubsystemSlots;

            public float m_ShieldHP;
            public float m_ShieldHPMultiplier;
            public float m_ShieldResistEM;
            public float m_ShieldResistThermal;
            public float m_ShieldResistKinetic;
            public float m_ShieldResistExplosive;

            public float m_ArmorHP;
            public float m_ArmorHPMultiplier;
            public float m_ArmorResistEM;
            public float m_ArmorResistThermal;
            public float m_ArmorResistKinetic;
            public float m_ArmorResistExplosive;

            public float m_HullHP;
            public float m_HullHPMultiplier;
            public float m_HullResistEM;
            public float m_HullResistThermal;
            public float m_HullResistKinetic;
            public float m_HullResistExplosive;

            public float m_OverheatingBonus;

            public void Print(StreamWriter file)
            {
                file.WriteLine("          m_ShipDescriptions.Add(new ShipDescription(\"{0}\",{1},{2},{3},{4},{5},{6},{7:f4}f,{8:f4}f,{9:f4}f,{10:f4}f,{11:f4}f,{12:f4}f,{13:f4}f,{14:f4}f,{15:f4}f,{16:f4}f,{17:f4}f,{18:f4}f,{19:f4}f,{20:f4}f,{21:f4}f,{22:f4}f,{23:f4}f,{24:f4}f,{25:f4}f));",
                    m_Name, m_TypeID, m_HighSlots, m_MedSlots, m_LowSlots, m_RigSlots, m_SubsystemSlots,
                    m_ShieldHP, m_ShieldHPMultiplier, m_ShieldResistEM, m_ShieldResistThermal, m_ShieldResistKinetic, m_ShieldResistExplosive,
                    m_ArmorHP, m_ArmorHPMultiplier, m_ArmorResistEM, m_ArmorResistThermal, m_ArmorResistKinetic, m_ArmorResistExplosive,
                    m_HullHP, m_HullHPMultiplier, m_HullResistEM, m_HullResistThermal, m_HullResistKinetic, m_HullResistExplosive,
                    m_OverheatingBonus
                );
            }
        };
    }
}
