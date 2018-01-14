using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    partial class FitScanProcessor
    {
        public void NewPaste(string Data) {
            int ShipTypeID = 0;
            List<int> ModuleTypeIDs = new List<int>();
            if (CODEFitScanURL(Data, ref ShipTypeID, ref ModuleTypeIDs))
            {
                m_ShipModel.SetShipAndModules(ShipTypeID, ModuleTypeIDs);
            }
            else if (EFTBlock(Data, ref ShipTypeID, ref ModuleTypeIDs))
            {
                m_ShipModel.SetShipAndModules(ShipTypeID, ModuleTypeIDs);
            }
            else if (ListOfModules(Data, ref ModuleTypeIDs))
            {
                m_ShipModel.AddMoreModules(ModuleTypeIDs);
            }
        }

        private bool ListOfModules(string Data, ref List<int> ModuleTypeIDs)
        {
            char[] Separators = {'\r', '\n'};
            string[] Lines = Data.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            if (Lines.Length < 1)
                return false;

            ModuleTypeIDs.Clear();
            foreach (string Line in Lines) {
                string TrimmedLine = Line.Trim();
                if (TrimmedLine.Length == 0)
                    continue;
                if (!Model.ModuleNameToIndex.ContainsKey(TrimmedLine))
                    continue; // skip any non-module:  scripts, ammo, etc.
                int ModuleTypeID = Model.ModuleDescriptions[Model.ModuleNameToIndex[TrimmedLine]].m_TypeID;
                ModuleTypeIDs.Add(ModuleTypeID);
            }

            return (ModuleTypeIDs.Count > 0);
        }

        private bool EFTBlock(string Data, ref int ShipTypeID, ref List<int> ModuleTypeIDs)
        {
            char[] Separators = { '\r', '\n' };
            string[] Lines = Data.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            if (Lines.Length < 1)
                return false;

            bool Success = false;
            do {
                if (!EFTBlockFirstLine(Lines[0], ref ShipTypeID))
                    break;

                bool ModulesOK = true;
                ModuleTypeIDs.Clear();
                for (int i = 1; i < Lines.Length; ++i) {
                    string LineLowcase = Lines[i].Trim().ToLower();
                    if (LineLowcase.Length == 0)
                        continue;

                    if (LineLowcase.Length >= 16) { // "[empty XXX slot]"
                        if (LineLowcase.StartsWith("[empty ") && LineLowcase.EndsWith("slot]")) {
                            continue;
                        }
                    }

                    int CommaPosition = Lines[i].IndexOf(',');
                    string ModuleName = (CommaPosition < 0) ? Lines[i]: Lines[i].Substring(0,CommaPosition);
                    ModuleName = ModuleName.Trim();
                    if (!Model.ModuleNameToIndex.ContainsKey(ModuleName))
                    {
                        ModulesOK = false;
                        break;
                    }
                    int ModuleTypeID = Model.ModuleDescriptions[Model.ModuleNameToIndex[ModuleName]].m_TypeID;
                    ModuleTypeIDs.Add(ModuleTypeID);
                
                }
                if (!ModulesOK)
                    break;

                Success = true;
            } while(false);

            return Success;
        }

        private bool EFTBlockFirstLine(string Line, ref int ShipTypeID) {
            string TrimmedLine = Line.Trim();
            bool Success = false;
            do
            {
                if (TrimmedLine.Length < 3)
                    break;
                if (TrimmedLine[0] != '[' || TrimmedLine[TrimmedLine.Length - 1] != ']')
                    break;
                string ShipName = TrimmedLine.Substring(1, TrimmedLine.Length - 2);
                int CommaPos = ShipName.IndexOf(',');
                if (CommaPos > 0) {
                    ShipName = ShipName.Substring(0,CommaPos);
                }

                int Index = -1;
                if (!Model.ShipNameToIndex.TryGetValue(ShipName, out Index))
                    break;
                Debug.Assert(Index >= 0);

                ShipTypeID = Model.ShipDescriptions[Index].m_TypeID;

                Success = true;
            } while (false);

            return Success;
        }

        private bool CODEFitScanURL(string Data, ref int ShipTypeID, ref List<int> ModuleTypeIDs)
        {
            Data = Data.Trim();

            bool Success = false;
            do {
                string Prefix = "http://halaimacode.byethost8.com/fitscan.html#";
                if (!Data.StartsWith(Prefix))
                    break;
                string FitString = Data.Substring(Prefix.Length);

                int ColonPosition = FitString.IndexOf(':');
                if (ColonPosition < 0)
                    break;
                string ShipTypeID_str = FitString.Substring(0,ColonPosition);
                if (!Int32.TryParse(ShipTypeID_str, out ShipTypeID))
                    break;
                if (!Model.ShipTypeIDToIndex.ContainsKey(ShipTypeID))
                    break;
                FitString = FitString.Substring(ColonPosition + 1);

                ModuleTypeIDs.Clear();
                bool ModulesOK = true;
                for (; ; )
                {
                    ColonPosition = FitString.IndexOf(':');
                    if (ColonPosition < 0) {
                        ModulesOK = false;
                        break;
                    }
                    if (ColonPosition == 0)
                        break;
                    string ModuleBlock = FitString.Substring(0, ColonPosition);
                    FitString = FitString.Substring(ColonPosition + 1);

                    int SemicolonPosition = ModuleBlock.IndexOf(';');
                    if (SemicolonPosition < 1) {
                        ModulesOK = false;
                        break;
                    }
                    string ModuleID_str = ModuleBlock.Substring(0,SemicolonPosition);
                    int ModuleTypeID = 0;
                    if (!Int32.TryParse(ModuleID_str, out ModuleTypeID)) {
                        ModulesOK = false;
                        break;
                    }
                    if (!Model.ModuleTypeIDToIndex.ContainsKey(ModuleTypeID)) {
                        ModulesOK = false;
                        break;
                    }

                    string ModuleCount_str = ModuleBlock.Substring(SemicolonPosition+1);
                    if (ModuleCount_str.Length < 1) {
                        ModulesOK = false;
                        break;
                    }
                    int ModuleCount = 0;
                    if (!Int32.TryParse(ModuleCount_str, out ModuleCount)) {
                        ModulesOK = false;
                        break;
                    }
                    if (ModuleCount < 0 || ModuleCount > 8) {
                        ModulesOK = false;
                        break;
                    }
                    for (int i = 0; i < ModuleCount; ++i )
                        ModuleTypeIDs.Add(ModuleTypeID);
                }
                if (!ModulesOK)
                    break;

                Success = true;
            } while(false);

            return Success;
        }

    }
}