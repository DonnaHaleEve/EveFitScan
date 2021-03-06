﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Npgsql;

namespace DBConverter
{
    partial class Program
    {
        static private Dictionary<int, int> m_AttributesOfInterest = null;
        static private Dictionary<int, int> AttributesOfInterest {
            get {
                if (m_AttributesOfInterest == null) {
                    m_AttributesOfInterest = new Dictionary<int, int>();
                    foreach (MODULE_ATTRIBUTES_DB attr in Enum.GetValues(typeof(MODULE_ATTRIBUTES_DB)))
                    {
                        m_AttributesOfInterest[(int)attr] = 1;
                    }
                }
                return m_AttributesOfInterest;
            }
        }

        //================================================================================================================================================================================================================================

        private static IReadOnlyCollection<Tuple<string, int>> GetShips(NpgsqlConnection conn)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"marketGroupID\" FROM \"invMarketGroups\" WHERE \"marketGroupName\" = \'Ships\' AND \"parentGroupID\" IS NULL", conn);
            int rootShipsMarketGroupID = 0;
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                dr.Read();
                rootShipsMarketGroupID = Int32.Parse(dr["marketGroupID"].ToString());
                //Console.WriteLine("root ships market group ID = {0}", rootShipsMarketGroupID);
            }

            List<int> shipMarketGroups = new List<int>();
            GetShipMarketGroupsRecursive(ref shipMarketGroups, rootShipsMarketGroupID, conn);
            //Console.WriteLine("got {0} ship market groups", shipMarketGroups.Count);

            List<Tuple<string, int>> ships = new List<Tuple<string, int>>();
            foreach (int groupID in shipMarketGroups) {
                NpgsqlCommand cmd2 = new NpgsqlCommand(String.Format("SELECT \"typeName\", \"typeID\" FROM \"invTypes\" WHERE \"marketGroupID\" = {0} AND published = TRUE", groupID), conn);
                using (NpgsqlDataReader dr2 = cmd2.ExecuteReader()) {
                    while (dr2.Read()) {
                        string typeName = dr2["typeName"].ToString();
                        int typeID = Int32.Parse(dr2["typeID"].ToString());
                        ships.Add(new Tuple<string, int>(typeName, typeID));
                    }
                }
            }
            //Console.WriteLine("got {0} ships", ships.Count);
            return ships;
        }

        private static void GetShipMarketGroupsRecursive(ref List<int> shipMarketGroups, int marketGroupID, NpgsqlConnection conn)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(String.Format("SELECT \"marketGroupID\", \"marketGroupName\", \"hasTypes\" FROM \"invMarketGroups\" WHERE \"parentGroupID\" = {0}", marketGroupID), conn);
            List<int> newMarketGroups = new List<int>();
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    int newMarketGroup = Int32.Parse(dr["marketGroupID"].ToString());
                    bool hasTypes = Boolean.Parse(dr["hasTypes"].ToString());
                    if (hasTypes)
                    {
                        shipMarketGroups.Add(newMarketGroup);
                    }
                    newMarketGroups.Add(newMarketGroup);
                }
            }

            foreach (int grpID in newMarketGroups) {
                GetShipMarketGroupsRecursive(ref shipMarketGroups, grpID, conn);
            }
        }

        private static IReadOnlyDictionary<SHIP_ATTRIBUTES, float> GetShipAttributes(int typeID, NpgsqlConnection conn)
        {
            Dictionary<SHIP_ATTRIBUTES, float> shipAttributes = new Dictionary<SHIP_ATTRIBUTES, float>();
            foreach (SHIP_ATTRIBUTES attr in Enum.GetValues(typeof(SHIP_ATTRIBUTES)))
            {
                shipAttributes[attr] = 0.0f;
            }

            NpgsqlCommand cmd = new NpgsqlCommand(
                String.Format("SELECT \"attributeID\", \"valueInt\", \"valueFloat\" FROM \"dgmTypeAttributes\" JOIN \"dgmAttributeTypes\" USING (\"attributeID\") WHERE \"published\" = TRUE AND \"typeID\" = {0}", typeID),
                conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    int attributeID = Int32.Parse(dr["attributeID"].ToString());
                    if (shipAttributes.ContainsKey((SHIP_ATTRIBUTES)attributeID))
                    {
                        object valueFloat = dr["valueFloat"];
                        string valueFloatStr = valueFloat.ToString();
                        float value = (valueFloatStr.Length == 0) ? (float)Int32.Parse(dr["valueInt"].ToString()) : (float)Double.Parse(valueFloatStr);
                        shipAttributes[(SHIP_ATTRIBUTES)attributeID] = value;
                    }
                }
            }

            return shipAttributes;
        }

        private static IReadOnlyDictionary<SHIP_TRAITS, float> GetShipTraits(int typeID, NpgsqlConnection conn)
        {
            Dictionary<SHIP_TRAITS, float> shipTraits = new Dictionary<SHIP_TRAITS, float>();

            NpgsqlCommand cmd = new NpgsqlCommand(
                String.Format("SELECT \"bonus\", \"bonusText\", \"skillID\" FROM \"invTraits\" WHERE \"typeID\" = {0}", typeID),
                conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string bonusText = dr["bonusText"].ToString();
                    string bonusString = dr["bonus"].ToString();
                    float bonus = (bonusString.Length > 0) ? (float)Double.Parse(bonusString) : 0.0f;
                    string skillID_str = dr["skillID"].ToString();
                    int skillID = Int32.Parse(skillID_str);

                    // fuck CCP
                    if (String.Compare(bonusText, "bonus to ship shield hitpoints", true) == 0)
                    {
                        Debug.Assert(skillID > 0);
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship armor hitpoints", true) == 0)
                    {
                        Debug.Assert(skillID > 0);
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship shield and hull hitpoints", true) == 0)
                    {
                        Debug.Assert(skillID > 0);
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship armor and hull hitpoints", true) == 0)
                    {
                        Debug.Assert(skillID > 0);
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to all shield resistances", true) == 0)
                    {
                        if (skillID > 0) {
                            shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_RESISTS_PER_LEVEL] = bonus;
                        }
                        else {
                            shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_RESISTS_ROLE] = bonus;
                        }
                    }
                    else if (String.Compare(bonusText, "bonus to all armor resistances", true) == 0)
                    {
                        if (skillID > 0) {
                            shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_RESISTS_PER_LEVEL] = bonus;
                        }
                        else {
                            shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_RESISTS_ROLE] = bonus;
                        }
                    }
                    else if (bonusText.StartsWith("bonus to the benefits of overheating "))
                    {
                        Debug.Assert(skillID < 0);
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_OVERHEATING_BONUS_PERCENT] = bonus;
                    }
                }
            }

            return shipTraits;
        }

        //================================================================================================================================================================================================================================

        private static IReadOnlyCollection<Tuple<string, int, int, MODULE_SLOT>> GetModules(NpgsqlConnection conn)
        {
            List<Tuple<string, int, int, MODULE_SLOT>> modules = new List<Tuple<string, int, int, MODULE_SLOT>>();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"typeID\", \"typeName\", \"groupID\", \"effectID\" FROM \"invTypes\" JOIN \"dgmTypeEffects\" USING (\"typeID\") WHERE \"published\" = TRUE AND \"effectID\" IN (11,12,13,2663,3772)", conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string typeName = dr["typeName"].ToString();
                    if (!typeName.StartsWith("Standup "))
                    {
                        int typeID = Int32.Parse(dr["typeID"].ToString());
                        int groupID = Int32.Parse(dr["groupID"].ToString());
                        MODULE_SLOT slot = (MODULE_SLOT)Int32.Parse(dr["effectID"].ToString());
                        modules.Add(new Tuple<string, int, int, MODULE_SLOT>(typeName, typeID, groupID, slot));
                    }
                }
            }

            return modules;
        }

        private static IReadOnlyDictionary<MODULE_ATTRIBUTES_DB, Tuple<bool, int, bool, float>> GetModuleAttributes(int typeID, NpgsqlConnection conn)
        {
            Dictionary<MODULE_ATTRIBUTES_DB, Tuple<bool, int, bool, float>> moduleAttributes = new Dictionary<MODULE_ATTRIBUTES_DB, Tuple<bool, int, bool, float>>();

            NpgsqlCommand cmd = new NpgsqlCommand(
                String.Format("SELECT \"attributeID\", \"valueInt\", \"valueFloat\" FROM \"dgmTypeAttributes\" JOIN \"dgmAttributeTypes\" USING (\"attributeID\") WHERE \"published\" = TRUE AND \"typeID\" = {0}", typeID),
                conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    int attributeID = Int32.Parse(dr["attributeID"].ToString());
                    if (AttributesOfInterest.ContainsKey(attributeID))
                    {
                        string valueIntStr = dr["valueInt"].ToString();
                        bool hasInt = valueIntStr.Length > 0;
                        string valueFloatStr = dr["valueFloat"].ToString();
                        bool hasFloat = valueFloatStr.Length > 0;

                        moduleAttributes.Add(
                            (MODULE_ATTRIBUTES_DB)attributeID,
                            new Tuple<bool, int, bool, float>(
                                hasInt,
                                hasInt ? Int32.Parse(valueIntStr) : 0,
                                hasFloat,
                                hasFloat ? (float)Double.Parse(valueFloatStr) : 0.0f
                            )
                        );
                    }
                }
            }

            return moduleAttributes;
        }

        private static IReadOnlyDictionary<MODULE_TRAITS, float> GetModuleTraits(int typeID, NpgsqlConnection conn)
        {
            Dictionary<MODULE_TRAITS, float> moduleTraits = new Dictionary<MODULE_TRAITS, float>();

            NpgsqlCommand cmd = new NpgsqlCommand(
                String.Format("SELECT \"bonus\", \"bonusText\" FROM \"invTraits\" WHERE \"typeID\" = {0} AND \"skillID\" > 0", typeID),
                conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string bonusText = dr["bonusText"].ToString();
                    string bonusString = dr["bonus"].ToString();
                    float bonus = (bonusString.Length > 0) ? (float)Double.Parse(bonusString) : 0.0f;

                    // fuck CCP
                    if (String.Compare(bonusText, "bonus to all shield hitpoints", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to all armor hitpoints", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to all armor and shield hitpoints", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to the benefits of overheating shield hardeners", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_SHIELD_HARDENERS_OVERHEATING_BONUS] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to the benefits of overheating armor hardeners", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_ARMOR_HARDENERS_OVERHEATING_BONUS] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to the benefits of overheating armor and shield hardeners", true) == 0)
                    {
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_ARMOR_HARDENERS_OVERHEATING_BONUS] = bonus;
                        moduleTraits[MODULE_TRAITS.MODULE_TRAIT_SHIELD_HARDENERS_OVERHEATING_BONUS] = bonus;
                    }
                }
            }

            return moduleTraits;
        }

        private static float GetMaxAttributeValueForMarketGroup(string[] Group, MODULE_ATTRIBUTES_DB Attribute, NpgsqlConnection conn) {
            int marketGroupID = GetMarketGroupID(Group, conn);
            NpgsqlCommand cmd = new NpgsqlCommand(
                String.Format("SELECT \"valueInt\", \"valueFloat\" FROM \"dgmTypeAttributes\" JOIN \"invTypes\" USING (\"typeID\") WHERE \"marketGroupID\" = {0} AND \"attributeID\" = {1} ORDER BY \"valueFloat\" DESC", marketGroupID, (int)Attribute),
                conn
            );
            float value = 0.0f;
            using (NpgsqlDataReader dr = cmd.ExecuteReader()) {
                while (dr.Read()) {
                    double ddd = 0.0;
                    if (Double.TryParse(dr["valueFloat"].ToString(), out ddd)) {
                        if (value < ((float)ddd)) {
                            value = (float)ddd;
                        }
                    }
                    else {
                        int iii = Int32.Parse(dr["valueInt"].ToString());
                        if (value < ((float)iii)) {
                            value = (float)iii;
                        }
                    }
                }
            }
            return value;
        }

        //================================================================================================================================================================================================================================

        private static int GetTypeIDByName(string Name, NpgsqlConnection conn) {
            NpgsqlCommand cmd = new NpgsqlCommand(String.Format("SELECT \"typeID\" FROM \"invTypes\" WHERE \"typeName\" = \'{0}'", Name), conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader()) {
                if (dr.Read()) {
                    string typeID_str = dr["typeID"].ToString();
                    int typeID = Int32.Parse(typeID_str);
                    return typeID;
                }
            }
            Debug.Assert(false);
            return 0;
        }

        private static int GetMarketGroupID(string[] Group, NpgsqlConnection conn) {
            Debug.Assert(Group.Length > 0);

            int marketGroupID = 0;
            using (NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder()) {

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"marketGroupID\" FROM \"invMarketGroups\" WHERE \"marketGroupName\" = @mg AND \"parentGroupID\" IS NULL", conn);
                cmd.Parameters.Add("mg", NpgsqlTypes.NpgsqlDbType.Varchar);
                cmd.Prepare();

                cmd.Parameters[0].Value = Group[0];
                cmd.ExecuteNonQuery();

                using (NpgsqlDataReader dr = cmd.ExecuteReader()) {
                    dr.Read();
                    marketGroupID = Int32.Parse(dr["marketGroupID"].ToString());
                    Debug.Assert(marketGroupID > 0);
                }

                for (int i = 1; i < Group.Length; i++) {
                    //NpgsqlCommand cmd2 = new NpgsqlCommand(String.Format("SELECT \"marketGroupID\" FROM \"invMarketGroups\" WHERE \"marketGroupName\" = \'{0}\' AND \"parentGroupID\" = {1}", Group[i], marketGroupID), conn);
                    NpgsqlCommand cmd2 = new NpgsqlCommand(String.Format("SELECT \"marketGroupID\" FROM \"invMarketGroups\" WHERE \"marketGroupName\" LIKE @mg AND \"parentGroupID\" = @pg", Group[i], marketGroupID), conn);
                    cmd2.Parameters.Add("mg", NpgsqlTypes.NpgsqlDbType.Varchar);
                    cmd2.Parameters.Add("pg", NpgsqlTypes.NpgsqlDbType.Integer);
                    cmd2.Prepare();

                    cmd2.Parameters[0].Value = "%" + Group[i] + "%";
                    cmd2.Parameters[1].Value = marketGroupID;
                    cmd2.ExecuteNonQuery();

                    using (NpgsqlDataReader dr = cmd2.ExecuteReader()) {
                        dr.Read();
                        int nextMarketGroupID = Int32.Parse(dr["marketGroupID"].ToString());
                        Debug.Assert(nextMarketGroupID > 0);
                        marketGroupID = nextMarketGroupID;
                    }
                }
            }

            return marketGroupID;
        }
    }
}