using System;

namespace DBConverter
{
    partial class Program
    {
        enum SHIP_ATTRIBUTES
        {
            SHIP_ATTR_HIGH_SLOTS              = 14,
            SHIP_ATTR_MED_SLOTS               = 13,
            SHIP_ATTR_LOW_SLOTS               = 12,
            SHIP_ATTR_RIG_SLOTS               = 1154,

            SHIP_ATTR_SHIELD_HP               = 263,
            SHIP_ATTR_SHIELD_EM_RESONANCE     = 271,
            SHIP_ATTR_SHIELD_THERM_RESONANCE  = 274,
            SHIP_ATTR_SHIELD_KIN_RESONANCE    = 273,
            SHIP_ATTR_SHIELD_EXPL_RESONANCE   = 272,

            SHIP_ATTR_ARMOR_HP                = 265,
            SHIP_ATTR_ARMOR_EM_RESONANCE      = 267,
            SHIP_ATTR_ARMOR_THERM_RESONANCE   = 270,
            SHIP_ATTR_ARMOR_KIN_RESONANCE     = 269,
            SHIP_ATTR_ARMOR_EXPL_RESONANCE    = 268,

            SHIP_ATTR_HULL_HP                 = 9,
            SHIP_ATTR_HULL_EM_RESONANCE       = 113,
            SHIP_ATTR_HULL_THERM_RESONANCE    = 110,
            SHIP_ATTR_HULL_KIN_RESONANCE      = 109,
            SHIP_ATTR_HULL_EXPL_RESONANCE     = 111,

            SHIP_ATTR_TECH_LEVEL              = 422,
            SHIP_ATTR_SUBSYSTEM_HOLD_CAPACITY = 2675
        };
    }
}