using System;
using System.Collections.Generic;
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

        private static IReadOnlyCollection<Tuple<string, int>> GetShips(NpgsqlConnection conn)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"marketGroupID\" FROM \"invMarketGroups\" WHERE \"marketGroupName\" = \'Ships\' AND \"parentGroupID\" IS NULL", conn);
            int rootShipsMarketGroupID = 0;
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                dr.Read();
                rootShipsMarketGroupID = Int32.Parse(dr["marketGroupID"].ToString());
                Console.WriteLine("root ships market group ID = {0}", rootShipsMarketGroupID);
            }

            List<int> shipMarketGroups = new List<int>();
            GetShipMarketGroupsRecursive(ref shipMarketGroups, rootShipsMarketGroupID, conn);
            Console.WriteLine("got {0} ship market groups", shipMarketGroups.Count);

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
            Console.WriteLine("got {0} ships", ships.Count);
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
                    string newMarketGroupName = dr["marketGroupName"].ToString();
                    //TODO: strategic cruisers
                    if (String.Compare(newMarketGroupName, "Strategic Cruisers", true) != 0) {
                        int newMarketGroup = Int32.Parse(dr["marketGroupID"].ToString());
                        bool hasTypes = Boolean.Parse(dr["hasTypes"].ToString());
                        if (hasTypes)
                        {
                            shipMarketGroups.Add(newMarketGroup);
                        }
                        newMarketGroups.Add(newMarketGroup);
                    }
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
                String.Format("SELECT \"bonus\", \"bonusText\" FROM \"invTraits\" WHERE \"typeID\" = {0}", typeID),
                conn);
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string bonusText = dr["bonusText"].ToString();
                    string bonusString = dr["bonus"].ToString();
                    float bonus = (bonusString.Length > 0) ? (float)Double.Parse(bonusString) : 0.0f;

                    // fuck CCP
                    if (String.Compare(bonusText, "bonus to ship shield hitpoints", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship armor hitpoints", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship shield and hull hitpoints", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL] = bonus;
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to ship armor and hull hitpoints", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL] = bonus;
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to all shield resistances", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_SHIELD_RESISTS_PER_LEVEL] = bonus;
                    }
                    else if (String.Compare(bonusText, "bonus to all armor resistances", true) == 0)
                    {
                        shipTraits[SHIP_TRAITS.SHIP_TRAIT_ARMOR_RESISTS_PER_LEVEL] = bonus;
                    }
                }
            }

            return shipTraits;
        }

        private static IReadOnlyCollection<Tuple<string, int, int, MODULE_SLOT>> GetModules(NpgsqlConnection conn)
        {
            List<Tuple<string, int, int, MODULE_SLOT>> modules = new List<Tuple<string, int, int, MODULE_SLOT>>();

            // TODO: effectID=3772 - "requires subsystem slot"
            //NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"typeID\", \"typeName\" FROM \"invTypes\" JOIN \"dgmTypeEffects\" USING (\"typeID\") WHERE \"effectID\" IN (11,12,13,2663,3772)", conn);
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"typeID\", \"typeName\", \"groupID\", \"effectID\" FROM \"invTypes\" JOIN \"dgmTypeEffects\" USING (\"typeID\") WHERE \"published\" = TRUE AND \"effectID\" IN (11,12,13,2663)", conn);
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
    }
}