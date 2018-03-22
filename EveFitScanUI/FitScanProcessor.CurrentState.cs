using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EveFitScanUI
{
    partial class FitScanProcessor
    {
        public delegate void DelegateShipFitChanged();
        public event DelegateShipFitChanged EventShipFitChanged;

        public delegate void DelegateShipTankChanged();
        public event DelegateShipTankChanged EventShipTankChanged;

        // -----------------------------------------------------------------------------------------------------------------------

        public bool StateOk {
            get {
                return m_ShipModel.ValidFit;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private string m_EFTFit = "";
        public string EFTFit {
            get
            {
                return m_EFTFit;
            }
        }

        private string m_CODEToolURL = "";
        public string CODEToolURL
        {
            get
            {
                return m_CODEToolURL;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private float m_ValueShip = 0.0f;
        private float m_ValueRigs = 0.0f;
        private float m_ValueSubsystems = 0.0f;
        private float m_ValueModules = 0.0f;
        // fit value is: hull, fit, total, can drop
        public Tuple<float, float, float, float> FitValue {
            get {
                return new Tuple<float, float, float, float>(
                    m_ValueShip,
                    m_ValueRigs + m_ValueSubsystems + m_ValueModules,
                    m_ValueShip + m_ValueRigs + m_ValueSubsystems + m_ValueModules,
                    m_ValueModules
                );
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private string m_ShipName = "Drake";

        public string ShipName {
            get {
                return m_ShipName;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public int SubsystemSlots
        {
            get
            {
                int SSSlots = Model.CoreSlots + Model.DefensiveSlots + Model.OffensiveSlots + Model.PropulsionSlots;
                Debug.Assert(SSSlots == 0 || SSSlots == 4);
                return SSSlots;
            }
        }

        private List<string> m_SubsystemModules = new List<string>();
        public IReadOnlyList<string> SubsystemModules
        {
            get
            {
                return m_SubsystemModules;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public int HighSlots {
            get {
                return Model.HighSlots;
            }
        }

        private List<string> m_HighPowerModules = new List<string>();
        public IReadOnlyList<string> HighPowerModules {
            get {
                return m_HighPowerModules;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public int MediumSlots
        {
            get
            {
                return Model.MediumSlots;
            }
        }

        private List<string> m_MediumPowerModules = new List<string>();
        public IReadOnlyList<string> MediumPowerModules
        {
            get
            {
                return m_MediumPowerModules;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public int LowSlots
        {
            get
            {
                return Model.LowSlots;
            }
        }

        private List<string> m_LowPowerModules = new List<string>();
        public IReadOnlyList<string> LowPowerModules
        {
            get
            {
                return m_LowPowerModules;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public int RigSlots
        {
            get
            {
                return Model.RigSlots;
            }
        }

        private List<string> m_Rigs = new List<string>();
        public IReadOnlyList<string> Rigs
        {
            get
            {
                return m_Rigs;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private string m_TankText = "";
        public string TankText {
            get {
                return m_TankText;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        public bool PassiveTank
        {
            get
            {
                return Model.PassiveTank;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private float m_ShieldHP = 0.0f;
        public float ShieldHP
        {
            get
            {
                return m_ShieldHP;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_ShieldResists = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> ShieldResists
        {
            get {
                return m_ShieldResists;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_ShieldResistsHeated = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> ShieldResistsHeated
        {
            get
            {
                return m_ShieldResistsHeated;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private float m_ArmorHP = 0.0f;
        public float ArmorHP
        {
            get
            {
                return m_ArmorHP;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_ArmorResists = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> ArmorResists
        {
            get
            {
                return m_ArmorResists;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_ArmorResistsHeated = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> ArmorResistsHeated
        {
            get
            {
                return m_ArmorResistsHeated;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        private float m_HullHP = 0.0f;
        public float HullHP
        {
            get
            {
                return m_HullHP;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_HullResists = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> HullResists
        {
            get
            {
                return m_HullResists;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_HullResistsHeated = new Dictionary<ShipModel.RESIST, float>();
        public Dictionary<ShipModel.RESIST, float> HullResistsHeated
        {
            get
            {
                return m_HullResistsHeated;
            }
        }
    }
}