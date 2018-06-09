using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Npgsql;

namespace DBConverter
{
    partial class Program
    {
        private static IReadOnlyDictionary<int, ModuleDescription> CreateAbyssalModules(NpgsqlConnection conn) {
            Dictionary<int, ModuleDescription> result = new Dictionary<int, ModuleDescription>();

            {
                ModuleDescription md = CreateAbyssalModule("Small Abyssal Shield Extender", new string[] { "Ship Equipment", "Shield", "Shield Extenders", "Small" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_CAPACITY_BONUS, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, MODULE_SLOT.MEDIUM_POWER, conn);
                result[md.TypeID] = md;
            }
            {
                ModuleDescription md = CreateAbyssalModule("Medium Abyssal Shield Extender", new string[] { "Ship Equipment", "Shield", "Shield Extenders", "Medium" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_CAPACITY_BONUS, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, MODULE_SLOT.MEDIUM_POWER, conn);
                result[md.TypeID] = md;
            }
            {
                ModuleDescription md = CreateAbyssalModule("Large Abyssal Shield Extender", new string[] { "Ship Equipment", "Shield", "Shield Extenders", "Large" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_CAPACITY_BONUS, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, MODULE_SLOT.MEDIUM_POWER, conn);
                result[md.TypeID] = md;
            }

            {
                ModuleDescription md = CreateAbyssalModule("Small Abyssal Armor Plates", new string[] { "Ship Equipment", "Armor", "Armor Plates", "200mm Armor Plate" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_BONUS_ADD, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, MODULE_SLOT.LOW_POWER, conn);
                result[md.TypeID] = md;
            }
            {
                ModuleDescription md = CreateAbyssalModule("Medium Abyssal Armor Plates", new string[] { "Ship Equipment", "Armor", "Armor Plates", "800mm Armor Plate" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_BONUS_ADD, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, MODULE_SLOT.LOW_POWER, conn);
                result[md.TypeID] = md;
            }
            {
                ModuleDescription md = CreateAbyssalModule("Large Abyssal Armor Plates", new string[] { "Ship Equipment", "Armor", "Armor Plates", "1600mm Armor Plate" }, MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_BONUS_ADD, 1.3f, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, MODULE_SLOT.LOW_POWER, conn);
                result[md.TypeID] = md;
            }

            return result;
        }

        private static ModuleDescription CreateAbyssalModule(string ModuleName, string[] MarketGroups, MODULE_ATTRIBUTES_DB dbAttribute, float bonus, MODULE_ATTRIBUTES attribute, MODULE_SLOT slot, NpgsqlConnection conn) {
            int typeID = GetTypeIDByName(ModuleName, conn);
            float value = GetMaxAttributeValueForMarketGroup(MarketGroups, dbAttribute, conn);
            Dictionary<MODULE_ATTRIBUTES, Dictionary<MODULE_ACTIVE, Tuple<float, int>>> attributes = new Dictionary<MODULE_ATTRIBUTES, Dictionary<MODULE_ACTIVE, Tuple<float, int>>>();
            attributes.Add(
                attribute,
                new Dictionary<MODULE_ACTIVE, Tuple<float, int>> { { MODULE_ACTIVE.PASSIVE, new Tuple<float, int>(value * bonus, 1) } }
            );
            ModuleDescription result = new ModuleDescription(
                ModuleName,
                typeID,
                slot,
                attributes,
                0.0f,
                -1
            );

            return result;
        }

    }
}