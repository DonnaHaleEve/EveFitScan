using System;

namespace DBConverter
{
    partial class Program
    {
        enum SHIP_TRAITS
        {
            SHIP_TRAIT_SHIELD_RESISTS_PER_LEVEL    = 1,
            SHIP_TRAIT_ARMOR_RESISTS_PER_LEVEL     = 2,
            SHIP_TRAIT_HULL_RESISTS_PER_LEVEL      = 3, // no ship has this atm

            SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL = 4,
            SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL  = 5,
            SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL   = 6
        };
    }
}