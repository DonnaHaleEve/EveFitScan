using System;

namespace DBConverter
{
    partial class Program
    {
        enum MODULE_ATTRIBUTES_DB
        {
            MODULE_ATTR_DB_CAPACITOR_NEEDED = 6,

            MODULE_ATTR_DB_DURATION = 73,

            MODULE_ATTR_DB_SHIELD_EM_RESONANCE = 271,
            MODULE_ATTR_DB_SHIELD_THERMAL_RESONANCE = 274,
            MODULE_ATTR_DB_SHIELD_KINETIC_RESONANCE = 273,
            MODULE_ATTR_DB_SHIELD_EXPLOSIVE_RESONANCE = 272,

            MODULE_ATTR_DB_ARMOR_EM_RESONANCE = 267,
            MODULE_ATTR_DB_ARMOR_THERMAL_RESONANCE = 270,
            MODULE_ATTR_DB_ARMOR_KINETIC_RESONANCE = 269,
            MODULE_ATTR_DB_ARMOR_EXPLOSIVE_RESONANCE = 268,

            MODULE_ATTR_DB_HULL_EM_RESONANCE = 974,
            MODULE_ATTR_DB_HULL_THERMAL_RESONANCE = 977,
            MODULE_ATTR_DB_HULL_KINETIC_RESONANCE = 976,
            MODULE_ATTR_DB_HULL_EXPLOSIVE_RESONANCE = 975,

            MODULE_ATTR_DB_EM_RESIST_BONUS = 984, // Unknown layer (shield/armor/hull).
            MODULE_ATTR_DB_THERMAL_RESIST_BONUS = 987, // Unknown layer (shield/armor/hull).
            MODULE_ATTR_DB_KINETIC_RESIST_BONUS = 986, // Unknown layer (shield/armor/hull).
            MODULE_ATTR_DB_EXPLOSIVE_RESIST_BONUS = 985, // Unknown layer (shield/armor/hull).

            MODULE_ATTR_DB_ALL_RESONANCES = 2746, // all layers, found on assault damage controls

            MODULE_ATTR_DB_OVERLOAD_HARDENING_BONUS = 1208,

            MODULE_ATTR_DB_SHIELD_CAPACITY_MULTIPLIER = 146, // shield %
            MODULE_ATTR_DB_ARMOR_HP_MULTIPLIER = 148, // hull HP %
            MODULE_ATTR_DB_STRUCTURE_HP_MULTIPLIER = 150, // hull HP %

            MODULE_ATTR_DB_ARMOR_HP_BONUS_ADD = 1159, // armor HP
            MODULE_ATTR_DB_CAPACITY_BONUS = 72, // shield HP
            MODULE_ATTR_DB_SHIELD_CAPACITY = 263, // shield HP, on t3 subsystems
            MODULE_ATTR_DB_STRUCTURE_HP_BONUS_ADD = 2688, // hull HP, on t3 subsystems

            MODULE_ATTR_DB_SHIELD_CAPACITY_BONUS = 337, // shield %, rigs
            MODULE_ATTR_DB_ARMOR_HP_BONUS = 335, // armor %, rigs
            MODULE_ATTR_DB_HULL_HP_BONUS = 327, // hull %, rigs

            MODULE_ATTR_DB_DRAWBACK = 1138, // rigs

            MODULE_ATTR_DB_SHIP_TYPE = 1380, // on t3 subsystems, tells what ship this sub is for
            MODULE_ATTR_DB_HIGH_SLOTS = 1374, // on t3 subsystems
            MODULE_ATTR_DB_MEDIUM_SLOTS = 1375, // on t3 subsystems
            MODULE_ATTR_DB_LOW_SLOTS = 1376, // on t3 subsystems
        };
    }
}