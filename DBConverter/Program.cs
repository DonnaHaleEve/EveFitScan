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
                    
                    //foreach (Tuple<string, int> ship in shipNames) {
                    //    Console.WriteLine("{0}: {1}", ship.Item2, ship.Item1);
                    //}
#else

                    List<Tuple<string, int>> shipNames = new List<Tuple<string, int>>();
                    shipNames.Add(new Tuple<string, int>("Broadsword", 12013));
                    //shipNames.Add(new Tuple<string, int>("Damnation", 22474));
                    //shipNames.Add(new Tuple<string, int>("Drake", 24698));
                    //shipNames.Add(new Tuple<string, int>("Ark", 28850));
                    //shipNames.Add(new Tuple<string, int>("Rhea", 28844));
                    //shipNames.Add(new Tuple<string, int>("Procurer", 17480));
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

                    // name, typeID, groupID, slot
                    IReadOnlyCollection<Tuple<string, int, int, MODULE_SLOT>> moduleNames = GetModules(conn);
                    Console.WriteLine("got {0} modules", moduleNames.Count);

                    IReadOnlyDictionary<int, ModuleDescription> abyssalModules = CreateAbyssalModules(conn);

                    IReadOnlyCollection<ModuleDescription> moduleDescriptions = GetModuleDescriptions(moduleNames, abyssalModules, conn);
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

    }
}
