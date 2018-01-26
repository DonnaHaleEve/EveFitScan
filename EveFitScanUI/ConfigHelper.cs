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

        public bool GetPrices {
            get {
                return Properties.Settings.Default.GetPrices;
            }
            set {
                Properties.Settings.Default.GetPrices = value;
                Properties.Settings.Default.Save();
            }
        }

        private void Load() {
            //TODO
        }

        private ConfigHelper() {}
    }
}
