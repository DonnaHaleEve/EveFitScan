using System;
using System.Collections.Generic;
using System.Configuration;

namespace EveFitScanUI
{
    class ConfigHelper
    {
        private static ConfigHelper m_Instance = null;


        public static ConfigHelper Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ConfigHelper();
                    m_Instance.Load();
                }
                return m_Instance;
            }
        }

        public int WindowPositionX
        {
            get
            {
                return Properties.Settings.Default.WindowPositionX;
            }
            set
            {
                Properties.Settings.Default.WindowPositionX = value;
                Properties.Settings.Default.Save();
            }
        }

        public int WindowPositionY
        {
            get
            {
                return Properties.Settings.Default.WindowPositionY;
            }
            set
            {
                Properties.Settings.Default.WindowPositionY = value;
                Properties.Settings.Default.Save();
            }
        }

        public int WindowWidth
        {
            get
            {
                return Properties.Settings.Default.WindowWidth;
            }
            set
            {
                Properties.Settings.Default.WindowWidth = value;
                Properties.Settings.Default.Save();
            }
        }

        public int WindowHeight
        {
            get
            {
                return Properties.Settings.Default.WindowHeight;
            }
            set
            {
                Properties.Settings.Default.WindowHeight = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool AlwaysOnTop {
            get {
                return Properties.Settings.Default.AlwaysOnTop;
            }
            set {
                Properties.Settings.Default.AlwaysOnTop = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool PassiveTank
        {
            get
            {
                return Properties.Settings.Default.PassiveTank;
            }
            set
            {
                Properties.Settings.Default.PassiveTank = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool STK
        {
            get
            {
                return Properties.Settings.Default.STK;
            }
            set
            {
                Properties.Settings.Default.STK = value;
                Properties.Settings.Default.Save();
            }
        }

        public int SysSecurity
        {
            get
            {
                return Properties.Settings.Default.SysSecurity;
            }
            set
            {
                Properties.Settings.Default.SysSecurity = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool ADCActive {
            get {
                return Properties.Settings.Default.ADCActive;
            }
            set {
                Properties.Settings.Default.ADCActive = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool GetPrices {
            get {
                return Properties.Settings.Default.GetPrices;
            }
            set {
                Properties.Settings.Default.GetPrices = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool Highlight {
            get {
                return Properties.Settings.Default.Highlight;
            }
            set {
                Properties.Settings.Default.Highlight = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool ActivateOnFitUpdate {
            get {
                return Properties.Settings.Default.ActivateOnFitUpdate;
            }
            set {
                Properties.Settings.Default.ActivateOnFitUpdate = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Mjolnir
        {
            get
            {
                return Properties.Settings.Default.DPS_Mjolnir;
            }
            set
            {
                Properties.Settings.Default.DPS_Mjolnir = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Nova
        {
            get
            {
                return Properties.Settings.Default.DPS_Nova;
            }
            set
            {
                Properties.Settings.Default.DPS_Nova = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Antimatter
        {
            get
            {
                return Properties.Settings.Default.DPS_Antimatter;
            }
            set
            {
                Properties.Settings.Default.DPS_Antimatter = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Void
        {
            get
            {
                return Properties.Settings.Default.DPS_Void;
            }
            set
            {
                Properties.Settings.Default.DPS_Void = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_VoidL
        {
            get
            {
                return Properties.Settings.Default.DPS_VoidL;
            }
            set
            {
                Properties.Settings.Default.DPS_VoidL = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Multifrequency
        {
            get
            {
                return Properties.Settings.Default.DPS_Multifrequency;
            }
            set
            {
                Properties.Settings.Default.DPS_Multifrequency = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_EMP
        {
            get
            {
                return Properties.Settings.Default.DPS_EMP;
            }
            set
            {
                Properties.Settings.Default.DPS_EMP = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Phased_Plasma
        {
            get
            {
                return Properties.Settings.Default.DPS_Phased_Plasma;
            }
            set
            {
                Properties.Settings.Default.DPS_Phased_Plasma = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Fusion
        {
            get
            {
                return Properties.Settings.Default.DPS_Fusion;
            }
            set
            {
                Properties.Settings.Default.DPS_Fusion = value;
                Properties.Settings.Default.Save();
            }
        }

        public int DPS_Hail
        {
            get
            {
                return Properties.Settings.Default.DPS_Hail;
            }
            set
            {
                Properties.Settings.Default.DPS_Hail = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Mjolnir
        {
            get
            {
                return Properties.Settings.Default.RoF_Mjolnir;
            }
            set
            {
                Properties.Settings.Default.RoF_Mjolnir = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Nova
        {
            get
            {
                return Properties.Settings.Default.RoF_Nova;
            }
            set
            {
                Properties.Settings.Default.RoF_Nova = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Antimatter
        {
            get
            {
                return Properties.Settings.Default.RoF_Antimatter;
            }
            set
            {
                Properties.Settings.Default.RoF_Antimatter = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Void
        {
            get
            {
                return Properties.Settings.Default.RoF_Void;
            }
            set
            {
                Properties.Settings.Default.RoF_Void = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_VoidL
        {
            get
            {
                return Properties.Settings.Default.RoF_VoidL;
            }
            set
            {
                Properties.Settings.Default.RoF_VoidL = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Multifrequency
        {
            get
            {
                return Properties.Settings.Default.RoF_Multifrequency;
            }
            set
            {
                Properties.Settings.Default.RoF_Multifrequency = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_EMP
        {
            get
            {
                return Properties.Settings.Default.RoF_EMP;
            }
            set
            {
                Properties.Settings.Default.RoF_EMP = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Phased_Plasma
        {
            get
            {
                return Properties.Settings.Default.RoF_Phased_Plasma;
            }
            set
            {
                Properties.Settings.Default.RoF_Phased_Plasma = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Fusion
        {
            get
            {
                return Properties.Settings.Default.RoF_Fusion;
            }
            set
            {
                Properties.Settings.Default.RoF_Fusion = value;
                Properties.Settings.Default.Save();
            }
        }

        public double RoF_Hail
        {
            get
            {
                return Properties.Settings.Default.RoF_Hail;
            }
            set
            {
                Properties.Settings.Default.RoF_Hail = value;
                Properties.Settings.Default.Save();
            }
        }

        public String PassiveColdHot
        {
            get
            {
                return Properties.Settings.Default.PassiveColdHot;
            }
            set
            {
                Properties.Settings.Default.PassiveColdHot = value;
                Properties.Settings.Default.Save();
            }
        }

        private void Load() {
            //TODO
        }

        private ConfigHelper() {}
    }
}
