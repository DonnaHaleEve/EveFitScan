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
        static void Main(string[] args)
        {
            string paramHost = "";
            string paramPort = "";
            string paramUser = "";
            string paramPassword = "";
            string paramDatabase = "";

            foreach (string arg in args) {
                if (arg.StartsWith("--host=")) {
                    paramHost = arg.Substring(7);
                }
                else if (arg.StartsWith("--port=")) {
                    paramPort = arg.Substring(7);
                }
                else if (arg.StartsWith("--user="))
                {
                    paramUser = arg.Substring(7);
                }
                else if (arg.StartsWith("--password="))
                {
                    paramPassword = arg.Substring(11);
                }
                else if (arg.StartsWith("--database="))
                {
                    paramDatabase = arg.Substring(11);
                }
            }
            if (paramHost.Length == 0 || paramUser.Length == 0 || paramPassword.Length == 0 || paramDatabase.Length == 0) {
                Console.WriteLine("usage:");
                Console.WriteLine("  dbconverter.exe [parameters]");
                Console.WriteLine("");
                Console.WriteLine("  parameters are:");
                Console.WriteLine("    --host=<host>");
                Console.WriteLine("    --port=<port>    (optional parameter)");
                Console.WriteLine("    --user=<db_user>");
                Console.WriteLine("    --password=<password>");
                Console.WriteLine("    --database=<database_name>");
                return;
            }

            using (StreamWriter fileShips = new StreamWriter("ShipModel.Ships.cs"))
            using (StreamWriter fileModules = new StreamWriter("ShipModel.Modules.cs"))
            {
                try
                {
                    string connectionString = String.Format("Server={0};User Id={1};Password={2};Database={3};", paramHost, paramUser, paramPassword, paramDatabase);
                    if (paramPort.Length > 0) {
                        connectionString = connectionString + "Port=" + paramPort + ";";
                    }
                    NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                    conn.Open();

                    #region ----------------------------- SHIPS -----------------------------
#if true
                    IReadOnlyCollection<Tuple<string,int>> shipNames = GetShips(conn);
                    
                    foreach (Tuple<string, int> ship in shipNames) {
                        Console.WriteLine("{0}: {1}", ship.Item2, ship.Item1);
                    }
#else

                    List<Tuple<string, int>> shipNames = new List<Tuple<string, int>>();
                    shipNames.Add(new Tuple<string, int>("Damnation", 22474));
                    shipNames.Add(new Tuple<string, int>("Drake", 24698));
                    shipNames.Add(new Tuple<string, int>("Ark", 28850));
                    shipNames.Add(new Tuple<string, int>("Rhea", 28844));
                    shipNames.Add(new Tuple<string, int>("Procurer", 17480));
#endif
                    Console.WriteLine("got {0} ships", shipNames.Count);

                    IReadOnlyCollection<ShipDescription> shipDescriptions = GetShipDescriptions(shipNames, conn);
                    PrintShipsHeader(fileShips);
                    foreach (ShipDescription desc in shipDescriptions) {
                        desc.Print(fileShips);
                    }
                    PrintShipsFooter(fileShips);
                    #endregion

                    #region ----------------------------- MODULES -----------------------------

                    // name, typeID, groupID
                    IReadOnlyCollection<Tuple<string, int, int, MODULE_SLOT>> moduleNames = GetModules(conn);
                    Console.WriteLine("got {0} modules", moduleNames.Count);

                    IReadOnlyCollection<ModuleDescription> moduleDescriptions = GetModuleDescriptions(moduleNames, conn);
                    PrintModulesHeader(fileModules);
                    foreach (ModuleDescription desc in moduleDescriptions) {
                        desc.Print(fileModules);
                    }
                    PrintModulesFooter(fileModules);

                    #endregion

                    conn.Close();
                }
                catch (Exception ex) {
                    Console.WriteLine("shit's fucked, yo ! : " + ex.Message);
                }
            }
        }

        static void PrintShipsHeader(StreamWriter fileShips)
        {
            fileShips.WriteLine("// =======================================================================");
            fileShips.WriteLine("// == AUTOGENERATED FILE =================================================");
            fileShips.WriteLine("// =======================================================================");
            fileShips.WriteLine("");
            fileShips.WriteLine("using System;");
            fileShips.WriteLine("using System.Collections.Generic;");
            fileShips.WriteLine("");
            fileShips.WriteLine("namespace EveFitScanUI");
            fileShips.WriteLine("{");
            fileShips.WriteLine("  partial class ShipModel");
            fileShips.WriteLine("  {");
            fileShips.WriteLine("    public class ShipDescription {");
            fileShips.WriteLine("      public ShipDescription( string Name, int TypeID, int HighSlots, int MedSlots, int LowSlots, int RigSlots,");
            fileShips.WriteLine("        float ShieldHP, float ShieldHPMultiplier, float ShieldResistEM, float ShieldResistThermal, float ShieldResistKinetic, float ShieldResistExplosive,");
            fileShips.WriteLine("        float ArmorHP, float ArmorHPMultiplier, float ArmorResistEM, float ArmorResistThermal, float ArmorResistKinetic, float ArmorResistExplosive,");
            fileShips.WriteLine("        float HullHP, float HullHPMultiplier, float HullResistEM, float HullResistThermal, float HullResistKinetic, float HullResistExplosive");
            fileShips.WriteLine("      ) {");
            fileShips.WriteLine("        m_Name = Name;");
            fileShips.WriteLine("        m_TypeID = TypeID;");
            fileShips.WriteLine("        m_HighSlots = HighSlots;");
            fileShips.WriteLine("        m_MedSlots = MedSlots;");
            fileShips.WriteLine("        m_LowSlots = LowSlots;");
            fileShips.WriteLine("        m_RigSlots = RigSlots;");
            fileShips.WriteLine("        m_ShieldHP = ShieldHP;");
            fileShips.WriteLine("        m_ShieldHPMultiplier = ShieldHPMultiplier;");
            fileShips.WriteLine("        m_ShieldResistEM = ShieldResistEM;");
            fileShips.WriteLine("        m_ShieldResistThermal = ShieldResistThermal;");
            fileShips.WriteLine("        m_ShieldResistKinetic = ShieldResistKinetic;");
            fileShips.WriteLine("        m_ShieldResistExplosive = ShieldResistExplosive;");
            fileShips.WriteLine("        m_ArmorHP = ArmorHP;");
            fileShips.WriteLine("        m_ArmorHPMultiplier = ArmorHPMultiplier;");
            fileShips.WriteLine("        m_ArmorResistEM = ArmorResistEM;");
            fileShips.WriteLine("        m_ArmorResistThermal = ArmorResistThermal;");
            fileShips.WriteLine("        m_ArmorResistKinetic = ArmorResistKinetic;");
            fileShips.WriteLine("        m_ArmorResistExplosive = ArmorResistExplosive;");
            fileShips.WriteLine("        m_HullHP = HullHP;");
            fileShips.WriteLine("        m_HullHPMultiplier = HullHPMultiplier;");
            fileShips.WriteLine("        m_HullResistEM = HullResistEM;");
            fileShips.WriteLine("        m_HullResistThermal = HullResistThermal;");
            fileShips.WriteLine("        m_HullResistKinetic = HullResistKinetic;");
            fileShips.WriteLine("        m_HullResistExplosive = HullResistExplosive;");
            fileShips.WriteLine("      }");
            fileShips.WriteLine("      public string m_Name;");
            fileShips.WriteLine("      public int m_TypeID;");
            fileShips.WriteLine("      public int m_HighSlots;");
            fileShips.WriteLine("      public int m_MedSlots;");
            fileShips.WriteLine("      public int m_LowSlots;");
            fileShips.WriteLine("      public int m_RigSlots;");
            fileShips.WriteLine("      public float m_ShieldHP;");
            fileShips.WriteLine("      public float m_ShieldHPMultiplier;");
            fileShips.WriteLine("      public float m_ShieldResistEM;");
            fileShips.WriteLine("      public float m_ShieldResistThermal;");
            fileShips.WriteLine("      public float m_ShieldResistKinetic;");
            fileShips.WriteLine("      public float m_ShieldResistExplosive;");
            fileShips.WriteLine("      public float m_ArmorHP;");
            fileShips.WriteLine("      public float m_ArmorHPMultiplier;");
            fileShips.WriteLine("      public float m_ArmorResistEM;");
            fileShips.WriteLine("      public float m_ArmorResistThermal;");
            fileShips.WriteLine("      public float m_ArmorResistKinetic;");
            fileShips.WriteLine("      public float m_ArmorResistExplosive;");
            fileShips.WriteLine("      public float m_HullHP;");
            fileShips.WriteLine("      public float m_HullHPMultiplier;");
            fileShips.WriteLine("      public float m_HullResistEM;");
            fileShips.WriteLine("      public float m_HullResistThermal;");
            fileShips.WriteLine("      public float m_HullResistKinetic;");
            fileShips.WriteLine("      public float m_HullResistExplosive;");
            fileShips.WriteLine("    }");
            fileShips.WriteLine("");
            fileShips.WriteLine("    private List<ShipDescription> m_ShipDescriptions = null;");
            fileShips.WriteLine("");
            fileShips.WriteLine("    public IReadOnlyList<ShipDescription> ShipDescriptions {");
            fileShips.WriteLine("      get {");
            fileShips.WriteLine("        if (m_ShipDescriptions == null) {");
            fileShips.WriteLine("          m_ShipDescriptions = new List<ShipDescription>();");
        }

        static void PrintShipsFooter(StreamWriter fileShips)
        {
            fileShips.WriteLine("        }");
            fileShips.WriteLine("        return m_ShipDescriptions;");
            fileShips.WriteLine("      }");
            fileShips.WriteLine("    }");
            fileShips.WriteLine("  }");
            fileShips.WriteLine("}");
        }

        static void PrintModulesHeader(StreamWriter fileModules)
        {
            fileModules.WriteLine("// =======================================================================");
            fileModules.WriteLine("// == AUTOGENERATED FILE =================================================");
            fileModules.WriteLine("// =======================================================================");
            fileModules.WriteLine("");
            fileModules.WriteLine("using System;");
            fileModules.WriteLine("using System.Collections.Generic;");
            fileModules.WriteLine("");
            fileModules.WriteLine("namespace EveFitScanUI");
            fileModules.WriteLine("{");
            fileModules.WriteLine("  partial class ShipModel");
            fileModules.WriteLine("  {");
            fileModules.WriteLine("    public enum SLOT { HIGH, MEDIUM, LOW, RIG };");
            fileModules.WriteLine("    public enum LAYER { SHIELD, ARMOR, HULL };");
            fileModules.WriteLine("    public enum EFFECT { EM, THERMAL, KINETIC, EXPLOSIVE, ADD, MULTIPLY };");
            fileModules.WriteLine("    public class ModuleDescription {");
            fileModules.WriteLine("      public ModuleDescription(string Name, int TypeID, SLOT Slot) {");
            fileModules.WriteLine("        m_Name = Name; m_TypeID = TypeID; m_Slot = Slot;");
            fileModules.WriteLine("      }");
            fileModules.WriteLine("      public ModuleDescription AddEffect(LAYER Layer, EFFECT Effect, bool Heated, float Value, int StackGroup) {");
            fileModules.WriteLine("        if(!m_Effects.ContainsKey(Layer))");
            fileModules.WriteLine("          m_Effects.Add(Layer, new Dictionary<EFFECT, Dictionary<bool, Tuple<float, int>>>());");
            fileModules.WriteLine("        if (!m_Effects[Layer].ContainsKey(Effect))");
            fileModules.WriteLine("          m_Effects[Layer].Add(Effect, new Dictionary<bool, Tuple<float, int>>());");
            fileModules.WriteLine("        Tuple<float, int> datum = Tuple.Create<float, int>(Value, StackGroup);");
            fileModules.WriteLine("        m_Effects[Layer][Effect][Heated] = datum;");
            fileModules.WriteLine("        return this;");
            fileModules.WriteLine("      }");
            fileModules.WriteLine("      public string m_Name;");
            fileModules.WriteLine("      public int m_TypeID;");
            fileModules.WriteLine("      public SLOT m_Slot;");
            fileModules.WriteLine("      public Dictionary<LAYER, Dictionary<EFFECT, Dictionary<bool, Tuple<float, int>>>> m_Effects = new Dictionary<LAYER, Dictionary<EFFECT, Dictionary<bool, Tuple<float, int>>>>();");
            fileModules.WriteLine("    }");
            fileModules.WriteLine("    private List<ModuleDescription> m_ModuleDescriptions = null;");
            fileModules.WriteLine("    public IReadOnlyList<ModuleDescription> ModuleDescriptions {");
            fileModules.WriteLine("      get {");
            fileModules.WriteLine("        if (m_ModuleDescriptions == null) {");
            fileModules.WriteLine("          m_ModuleDescriptions = new List<ModuleDescription>();");
        }

        static void PrintModulesFooter(StreamWriter fileModules)
        {
            fileModules.WriteLine("        }");
            fileModules.WriteLine("        return m_ModuleDescriptions;");
            fileModules.WriteLine("      }");
            fileModules.WriteLine("    }");
            fileModules.WriteLine("  }");
            fileModules.WriteLine("}");
        }

        static IReadOnlyCollection<ShipDescription> GetShipDescriptions(IReadOnlyCollection<Tuple<string, int>> shipNames, NpgsqlConnection conn)
        {
            List<ShipDescription> shipDescriptions = new List<ShipDescription>();

            foreach (Tuple<string, int> ship in shipNames)
            {
                shipDescriptions.Add(GetShipDescription(ship.Item1,ship.Item2, conn));
            }

            return shipDescriptions;
        }

        static ShipDescription GetShipDescription(string shipName, int typeID, NpgsqlConnection conn) {
            IReadOnlyDictionary<SHIP_ATTRIBUTES, float> shipAttributes = GetShipAttributes(typeID, conn);

            IReadOnlyDictionary<SHIP_TRAITS, float> shipTraits = GetShipTraits(typeID, conn);

            float traitShieldResists = 0.0f;
            if (!shipTraits.TryGetValue(SHIP_TRAITS.SHIP_TRAIT_SHIELD_RESISTS_PER_LEVEL, out traitShieldResists)) {
                traitShieldResists = 0.0f;
            }
            float traitShieldResonance = 1.0f - traitShieldResists * 5.0f * 0.01f; // 5 levels, percent value

            float traitArmorResists = 0.0f;
            if (!shipTraits.TryGetValue(SHIP_TRAITS.SHIP_TRAIT_ARMOR_RESISTS_PER_LEVEL, out traitArmorResists))
            {
                traitArmorResists = 0.0f;
            }
            float traitArmorResonance = 1.0f - traitArmorResists * 5.0f * 0.01f; // 5 levels, percent value

            float traitShieldHP = 0.0f;
            if (!shipTraits.TryGetValue(SHIP_TRAITS.SHIP_TRAIT_SHIELD_HP_PERCENT_PER_LEVEL, out traitShieldHP)) {
                traitShieldHP = 0.0f;
            }
            float traitShieldHPMultiplier = 1.0f + traitShieldHP * 5.0f * 0.01f; // 5 levels, percent value

            float traitArmorHP = 0.0f;
            if (!shipTraits.TryGetValue(SHIP_TRAITS.SHIP_TRAIT_ARMOR_HP_PERCENT_PER_LEVEL, out traitArmorHP))
            {
                traitArmorHP = 0.0f;
            }
            float traitArmorHPMultiplier = 1.0f + traitArmorHP * 5.0f * 0.01f; // 5 levels, percent value

            float traitHullHP = 0.0f;
            if (!shipTraits.TryGetValue(SHIP_TRAITS.SHIP_TRAIT_HULL_HP_PERCENT_PER_LEVEL, out traitHullHP))
            {
                traitHullHP = 0.0f;
            }
            float traitHullHPMultiplier = 1.0f + traitHullHP * 5.0f * 0.01f; // 5 levels, percent value

            return new ShipDescription(
                shipName,
                typeID,
                (int)(shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HIGH_SLOTS]),
                (int)(shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_MED_SLOTS]),
                (int)(shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_LOW_SLOTS]),
                (int)(shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_RIG_SLOTS]),
                shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_SHIELD_HP],
                traitShieldHPMultiplier,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_SHIELD_EM_RESONANCE] * traitShieldResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_SHIELD_THERM_RESONANCE] * traitShieldResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_SHIELD_KIN_RESONANCE] * traitShieldResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_SHIELD_EXPL_RESONANCE] * traitShieldResonance,
                shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_ARMOR_HP],
                traitArmorHPMultiplier,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_ARMOR_EM_RESONANCE] * traitArmorResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_ARMOR_THERM_RESONANCE] * traitArmorResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_ARMOR_KIN_RESONANCE] * traitArmorResonance,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_ARMOR_EXPL_RESONANCE] * traitArmorResonance,
                shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HULL_HP],
                traitHullHPMultiplier,
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HULL_EM_RESONANCE],
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HULL_THERM_RESONANCE],
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HULL_KIN_RESONANCE],
                1.0f - shipAttributes[SHIP_ATTRIBUTES.SHIP_ATTR_HULL_EXPL_RESONANCE]
            );
        }

        static IReadOnlyCollection<ModuleDescription> GetModuleDescriptions(IReadOnlyCollection<Tuple<string, int, int, MODULE_SLOT>> moduleNames, NpgsqlConnection conn)
        {
            List<ModuleDescription> moduleDescriptions = new List<ModuleDescription>();

            foreach (Tuple<string, int, int, MODULE_SLOT> module in moduleNames)
            {
                moduleDescriptions.Add(GetModuleDescription(module.Item1, module.Item2, module.Item3, module.Item4, conn));
            }

            return moduleDescriptions;
        }

        static ModuleDescription GetModuleDescription(string moduleName, int typeID, int groupID, MODULE_SLOT slot, NpgsqlConnection conn)
        {
            IReadOnlyDictionary<MODULE_ATTRIBUTES_DB, Tuple<bool,int,bool,float>> moduleAttributesDB = GetModuleAttributes(typeID, conn);

            // Tuple is : value + stacking group
            Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>> attributes = new Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>>();

            foreach (MODULE_ATTRIBUTES_DB attrDB in moduleAttributesDB.Keys)
            {
                float attrDBValue = GetValue(moduleAttributesDB[attrDB]);
                switch (attrDB) {
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_EM_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_THERMAL_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_KINETIC_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_EXPLOSIVE_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_EM_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_THERMAL_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_KINETIC_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_EXPLOSIVE_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_HULL_EM_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EM_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_HULL_THERMAL_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_THERMAL_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_HULL_KINETIC_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_KINETIC_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_HULL_EXPLOSIVE_RESONANCE:
                        attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_EXPLOSIVE_RESIST, new Tuple<float, int>(1.0f - attrDBValue, GetStackingGroup(groupID)));
                        break;
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_EM_RESIST_BONUS:
                        Debug.Assert(attrDBValue <= 0.0f);
                        if (attrDBValue < 0.0f)
                        {
                            if (groupID == 77 || groupID == 1700)
                            {
                                // active shield resist modules: Invulnerability Fields, Ward Fields, Flex Hardeners
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST_HEATED);
                            }
                            else if (groupID == 328 || groupID == 1699)
                            {
                                // active armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST_HEATED);
                            }
                            else if (groupID == 295)
                            {
                                // passive shield resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST_HEATED);
                            }
                            else if (groupID == 98 || groupID == 326)
                            {
                                // passive armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST_HEATED);
                            }
                            else if (groupID == 774)
                            {
                                // shield rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EM_RESIST_HEATED);
                            }
                            else if (groupID == 773)
                            {
                                // armor rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EM_RESIST_HEATED);
                            }
                            else
                            {
                                Console.WriteLine("Unknown EM resist module: {0}, groupID={1}", moduleName, groupID);
                            }
                        }
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_THERMAL_RESIST_BONUS:
                        Debug.Assert(attrDBValue <= 0.0f);
                        if (attrDBValue < 0.0f)
                        {
                            if (groupID == 77 || groupID == 1700)
                            {
                                // active shield resist modules: Invulnerability Fields, Ward Fields, Flex Hardeners
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST_HEATED);
                            }
                            else if (groupID == 328 || groupID == 1699)
                            {
                                // active armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST_HEATED);
                            }
                            else if (groupID == 295)
                            {
                                // passive shield resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST_HEATED);
                            }
                            else if (groupID == 98 || groupID == 326)
                            {
                                // passive armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST_HEATED);
                            }
                            else if (groupID == 774)
                            {
                                // shield rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_THERMAL_RESIST_HEATED);
                            }
                            else if (groupID == 773)
                            {
                                // armor rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_THERMAL_RESIST_HEATED);
                            }
                            else
                            {
                                Console.WriteLine("Unknown EM resist module: {0}, groupID={1}", moduleName, groupID);
                            }
                        }
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_KINETIC_RESIST_BONUS:
                        Debug.Assert(attrDBValue <= 0.0f);
                        if (attrDBValue < 0.0f)
                        {
                            if (groupID == 77 || groupID == 1700)
                            {
                                // active shield resist modules: Invulnerability Fields, Ward Fields, Flex Hardeners
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST_HEATED);
                            }
                            else if (groupID == 328 || groupID == 1699)
                            {
                                // active armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST_HEATED);
                            }
                            else if (groupID == 295)
                            {
                                // passive shield resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST_HEATED);
                            }
                            else if (groupID == 98 || groupID == 326)
                            {
                                // passive armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST_HEATED);
                            }
                            else if (groupID == 774)
                            {
                                // shield rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_KINETIC_RESIST_HEATED);
                            }
                            else if (groupID == 773)
                            {
                                // armor rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_KINETIC_RESIST_HEATED);
                            }
                            else
                            {
                                Console.WriteLine("Unknown EM resist module: {0}, groupID={1}", moduleName, groupID);
                            }
                        }
                        break;
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_EXPLOSIVE_RESIST_BONUS:
                        Debug.Assert(attrDBValue <= 0.0f);
                        if (attrDBValue < 0.0f)
                        {
                            if (groupID == 77 || groupID == 1700)
                            {
                                // active shield resist modules: Invulnerability Fields, Ward Fields, Flex Hardeners
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST_HEATED);
                            }
                            else if (groupID == 328 || groupID == 1699)
                            {
                                // active armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, true, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST_HEATED);
                            }
                            else if (groupID == 295)
                            {
                                // passive shield resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST_HEATED);
                            }
                            else if (groupID == 98 || groupID == 326)
                            {
                                // passive armor resist modules
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, false, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST_HEATED);
                            }
                            else if (groupID == 774)
                            {
                                // shield rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_EXPLOSIVE_RESIST_HEATED);
                            }
                            else if (groupID == 773)
                            {
                                // armor rigs
                                AddResitAttributesWithHeat(ref attributes, ref moduleAttributesDB, attrDBValue, false, true, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST, MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_EXPLOSIVE_RESIST_HEATED);
                            }
                            else
                            {
                                Console.WriteLine("Unknown EM resist module: {0}, groupID={1}", moduleName, groupID);
                            }
                        }
                        break;
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_OVERLOAD_HARDENING_BONUS:
                        // do nothing here
                        break;
                    //
                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_CAPACITY_MULTIPLIER:
                        {
                            // power diagnostic systems, reactor control units, shield flux coils 
                            float bonus = Math.Abs(attrDBValue - 1.0f);
                            if (bonus > 0.01f)
                            {
                                // filter out reactor control units, they have shield multiplier = 1
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY, new Tuple<float, int>(attrDBValue, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_MULTIPLIER:
                        {
                            float bonus = Math.Abs(attrDBValue - 1.0f);
                            if (bonus > 0.01f)
                            {
                                // filter out armor resist modules, they have armor multiplier = 1
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY, new Tuple<float, int>(attrDBValue, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_STRUCTURE_HP_MULTIPLIER:
                        {
                            // bulkheads, expanded cargoholds, nanofibers
                            float bonus = Math.Abs(attrDBValue - 1.0f);
                            if (bonus > 0.01f)
                            {
                                // filter out nanofibers, they have hull multiplier = 1
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_MULTIPLY, new Tuple<float, int>(attrDBValue, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_BONUS_ADD:
                        {
                            float bonus = Math.Abs(attrDBValue);
                            if (bonus > 0.01f)
                            {
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_ADD, new Tuple<float, int>(attrDBValue, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_CAPACITY_BONUS:
                        {
                            float bonus = Math.Abs(attrDBValue);
                            if (bonus > 0.01f)
                            {
                                // filter out shield resist amplifiers, they have shield bonus = 0
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_ADD, new Tuple<float, int>(attrDBValue, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_SHIELD_CAPACITY_BONUS:
                        if (groupID == 774) // shield rigs only
                        {
                            float bonus = Math.Abs(attrDBValue);
                            if (bonus > 0.01f)
                            {
                                // shield % bonus
                                bonus = 1.0f + 0.01f * bonus;
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY, new Tuple<float, int>(bonus, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_ARMOR_HP_BONUS:
                        if (groupID == 773) // armor/hull rigs only
                        {
                            float bonus = Math.Abs(attrDBValue);
                            if (bonus > 0.01f)
                            {
                                // armor % bonus
                                bonus = 1.0f + 0.01f * bonus;
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY, new Tuple<float, int>(bonus, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_HULL_HP_BONUS:
                        if (groupID == 773) // armor/hull rigs only
                        {
                            float bonus = Math.Abs(attrDBValue);
                            if (bonus > 0.01f)
                            {
                                // hull % bonus
                                bonus = 1.0f + 0.01f * bonus;
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_HULL_BONUS_MULTIPLY, new Tuple<float, int>(bonus, 1));
                            }
                        }
                        break;

                    case MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_DRAWBACK:
                        if (Math.Abs(attrDBValue) > 0.0f)
                        {
                            float drawback = 0.5f * attrDBValue; // rig drawback can be halved by training appropriate rigging skill
                            drawback = 1.0f + 0.01f * drawback;

                            if (
                                moduleName.Contains("Inverted Signal Field Projector") ||
                                moduleName.Contains("Particle Dispersion Augmentor") ||
                                moduleName.Contains("Particle Dispersion Projector") ||
                                moduleName.Contains("Targeting Systems Stabilizer") ||
                                moduleName.Contains("Tracking Diagnostics Subroutines") ||
                                moduleName.Contains("Signal Focusing Kit") ||
                                moduleName.Contains("Ionic Field Projector") ||
                                moduleName.Contains("Targeting System Subcontroller")
                            ) {
                                Debug.Assert(drawback < 1.0f);
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_SHIELD_BONUS_MULTIPLY, new Tuple<float, int>(drawback, 1));
                            }
                            else if
                            (
                                moduleName.Contains("Auxiliary Thrusters") ||
                                moduleName.Contains("Cargohold Optimization") ||
                                moduleName.Contains("Dynamic Fuel Valve") ||
                                moduleName.Contains("Engine Thermal Shielding") ||
                                moduleName.Contains("Low Friction Nozzle Joints") ||
                                moduleName.Contains("Polycarbon Engine Housing")
                            ) {
                                Debug.Assert(drawback < 1.0f);
                                attributes.Add(MODULE_ATTRIBUTES.MODULE_ATTRIBUTE_ARMOR_BONUS_MULTIPLY, new Tuple<float, int>(drawback, 1));
                            }
                        }
                        break;
                }
            }

            return new ModuleDescription(
                moduleName,
                typeID,
                groupID,
                slot,
                attributes
            );
        }

        static void AddResitAttributesWithHeat(ref Dictionary<MODULE_ATTRIBUTES, Tuple<float, int>> attributes, ref IReadOnlyDictionary<MODULE_ATTRIBUTES_DB, Tuple<bool, int, bool, float>> moduleAttributesDB, float resistValueDB, bool bActiveModule, bool bRig, MODULE_ATTRIBUTES attribute, MODULE_ATTRIBUTES attributeHeated)
        {
            Debug.Assert(!(bActiveModule && bRig));
            Debug.Assert(resistValueDB < 0.0f);

            float resistCold = -(0.01f * resistValueDB);
            if (!bActiveModule && !bRig)
            {
                resistCold *= 1.25f; // compensation skill bonus
            }
            attributes.Add(attribute, new Tuple<float, int>(resistCold, 1));

            if (bActiveModule)
            {
                Tuple<bool, int, bool, float> overheatBonus;
                if (moduleAttributesDB.TryGetValue(MODULE_ATTRIBUTES_DB.MODULE_ATTR_DB_OVERLOAD_HARDENING_BONUS, out overheatBonus))
                {
                    float overheatBonusPercent = GetValue(overheatBonus);
                    float overheatBonusFloat = 1.0f + 0.01f * overheatBonusPercent;
                    float resistHot = -(0.01f * resistValueDB * overheatBonusFloat);
                    attributes.Add(attributeHeated, new Tuple<float, int>(resistHot, 1));
                }
            }
        }

        #region --------------------- aux methods --------------------

        static float GetValue(Tuple<bool, int, bool, float> data)
        {
            if (data.Item3)
                return data.Item4;
            Debug.Assert(data.Item1);
            return (float)data.Item2;
        }

        static int GetStackingGroup(int groupID) {
            if (
                groupID == 60 // damage controls
                || groupID == 1150 // reactive armor hardener
            ) {
                return 2;
            }
            return 1;
        }
        
        #endregion

    }
}
