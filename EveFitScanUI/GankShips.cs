using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveFitScanUI
{
    class GankShips
    {
        // lookup for system security status to number of seconds Concord response time
        private Dictionary<string, int> m_ConcordResponseTimes = null;
        private IReadOnlyDictionary<string, int> ConcordResponseTimes
        {
            get
            {
                if (m_ConcordResponseTimes == null)
                {
                    m_ConcordResponseTimes = new Dictionary<string, int>();
                    m_ConcordResponseTimes.Add("Jita", 4);
                    m_ConcordResponseTimes.Add("Jitap", 4);
                    m_ConcordResponseTimes.Add("1.0", 6);
                    m_ConcordResponseTimes.Add("1.0p", 12);
                    m_ConcordResponseTimes.Add("0.9", 6);
                    m_ConcordResponseTimes.Add("0.9p", 12);
                    m_ConcordResponseTimes.Add("0.8", 7);
                    m_ConcordResponseTimes.Add("0.8p", 13);
                    m_ConcordResponseTimes.Add("0.7", 10);
                    m_ConcordResponseTimes.Add("0.7p", 16);
                    m_ConcordResponseTimes.Add("0.6", 14);
                    m_ConcordResponseTimes.Add("0.6p", 20);
                    m_ConcordResponseTimes.Add("0.5", 19);
                    m_ConcordResponseTimes.Add("0.5p", 25);
                }
                return m_ConcordResponseTimes;
            }
        }

        // returns number of ships required to kill
        // returns a string so close calls can be flagged in the furture (max skill hitting exact DPS on exact vollet limit...)
        public String NumShipToKill(String sysSecStatus, int DPS, double RoF, double targetEHP)
        {
            if (!ConcordResponseTimes.ContainsKey(sysSecStatus))
                return "Bad sys security";

            String numShips = String.Empty;

            //if people are being shit about RoF, we need to pure DPS this
            if (RoF > 0)
                numShips = NumShipToKillRoF(sysSecStatus, DPS, RoF, targetEHP).ToString();
            else
                numShips = NumShipToKillPureDps(sysSecStatus, DPS, targetEHP).ToString();

            return numShips;
        }

        private int NumShipToKillRoF(String sysSecStatus, int DPS, double RoF, double targetEHP)
        {
            double numSecondsToShoot = (double)ConcordResponseTimes[sysSecStatus] - 0.5; // what code tool does -- should avoid dodgy "volley = 10s, 10s condord" which should be a single volley
            double volleyDmg = DPS * RoF;
            int numVolleys = Convert.ToInt32(numSecondsToShoot / RoF) + 1; //+1 as always get initial volley that makes you Criminal
            int totalDamage = Convert.ToInt32(numVolleys * volleyDmg);
            int numShips = ((int)targetEHP / totalDamage) + 1; //+1 as it rounds down, and if you happend to have exact damage, you need an extra ship
            return numShips;
        }

        private int NumShipToKillPureDps(String sysSecStatus, int DPS, double EHP)
        {
            int numSecondsToShoot = ConcordResponseTimes[sysSecStatus];
            int totalDamage = DPS * numSecondsToShoot;
            int numShips = 1 + ((int)EHP / totalDamage); //if you need 4.7 ships (rounds down) you need 5 ships. If you need exactly 4 ships without rounding: bring 5.
            return numShips;
        }

        public void ResetDpsRoF()
        {
            ConfigHelper.Instance.DPS_Mjolnir = 0;
            ConfigHelper.Instance.DPS_Nova = 0;
            ConfigHelper.Instance.DPS_Antimatter = 0;
            ConfigHelper.Instance.DPS_Void = 0;
            ConfigHelper.Instance.DPS_Multifrequency = 0;
            ConfigHelper.Instance.DPS_EMP = 0;
            ConfigHelper.Instance.DPS_Fusion = 0;
            ConfigHelper.Instance.DPS_Phased_Plasma = 0;
            ConfigHelper.Instance.DPS_Hail = 0;

            ConfigHelper.Instance.RoF_Mjolnir = 0.0;
            ConfigHelper.Instance.RoF_Nova = 0.0;
            ConfigHelper.Instance.RoF_Antimatter = 0.0;
            ConfigHelper.Instance.RoF_Void = 0.0;
            ConfigHelper.Instance.RoF_Multifrequency = 0.0;
            ConfigHelper.Instance.RoF_EMP = 0.0;
            ConfigHelper.Instance.RoF_Fusion = 0.0;
            ConfigHelper.Instance.RoF_Phased_Plasma = 0.0;
            ConfigHelper.Instance.RoF_Hail = 0.0;

            RepairDpsRoF();
        }

        public void RepairDpsRoF()
        {
            if(ConfigHelper.Instance.DPS_Mjolnir == 0) ConfigHelper.Instance.DPS_Mjolnir = 775;
            if (ConfigHelper.Instance.DPS_Nova == 0) ConfigHelper.Instance.DPS_Nova = 775;
            if (ConfigHelper.Instance.DPS_Antimatter == 0) ConfigHelper.Instance.DPS_Antimatter = 350;
            if (ConfigHelper.Instance.DPS_Void == 0) ConfigHelper.Instance.DPS_Void = 600;
            if (ConfigHelper.Instance.DPS_Multifrequency == 0) ConfigHelper.Instance.DPS_Multifrequency = 300;
            if (ConfigHelper.Instance.DPS_EMP == 0) ConfigHelper.Instance.DPS_EMP = 300;
            if (ConfigHelper.Instance.DPS_Fusion == 0) ConfigHelper.Instance.DPS_Fusion = 300;
            if (ConfigHelper.Instance.DPS_Phased_Plasma == 0) ConfigHelper.Instance.DPS_Phased_Plasma = 300;
            if (ConfigHelper.Instance.DPS_Hail == 0) ConfigHelper.Instance.DPS_Hail = 400;

            if(ConfigHelper.Instance.RoF_Mjolnir == 0.0) ConfigHelper.Instance.RoF_Mjolnir = 10.5;
            if (ConfigHelper.Instance.RoF_Nova == 0.0) ConfigHelper.Instance.RoF_Nova = 10.4;
            if (ConfigHelper.Instance.RoF_Antimatter == 0.0) ConfigHelper.Instance.RoF_Antimatter = 2.7;
            if (ConfigHelper.Instance.RoF_Void == 0.0) ConfigHelper.Instance.RoF_Void = 2.9;
            if (ConfigHelper.Instance.RoF_Multifrequency == 0.0) ConfigHelper.Instance.RoF_Multifrequency = 3.8;
            if (ConfigHelper.Instance.RoF_EMP == 0.0) ConfigHelper.Instance.RoF_EMP = 3.5;
            if (ConfigHelper.Instance.RoF_Fusion == 0.0) ConfigHelper.Instance.RoF_Fusion = 3.5;
            if (ConfigHelper.Instance.RoF_Phased_Plasma == 0.0) ConfigHelper.Instance.RoF_Phased_Plasma = 3.5;
            if (ConfigHelper.Instance.RoF_Hail == 0.0) ConfigHelper.Instance.RoF_Hail = 4.2;
        }

        public GankShips()
        {
            RepairDpsRoF();
        }
    }
}
