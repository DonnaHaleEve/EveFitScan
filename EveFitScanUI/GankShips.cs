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
                    m_ConcordResponseTimes.Add("Jitap", 10);
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

        public String GetSeconds(String sysSecStatus)
        {
            return ConcordResponseTimes[sysSecStatus] + "s";
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
            ConfigHelper.Instance.DPS_Mjolnir = 1019;
            ConfigHelper.Instance.RoF_Mjolnir = 6.26;

            ConfigHelper.Instance.DPS_Nova = 1019;
            ConfigHelper.Instance.RoF_Nova = 6.26;

            ConfigHelper.Instance.DPS_Antimatter = 448;
            ConfigHelper.Instance.RoF_Antimatter = 1.91;

            ConfigHelper.Instance.DPS_Void = 818;
            ConfigHelper.Instance.RoF_Void = 1.87;

            ConfigHelper.Instance.DPS_VoidL = 1773;
            ConfigHelper.Instance.RoF_VoidL = 4.16;

            ConfigHelper.Instance.DPS_Multifrequency = 312;
            ConfigHelper.Instance.RoF_Multifrequency = 2.4;

            ConfigHelper.Instance.DPS_EMP = 387;
            ConfigHelper.Instance.RoF_EMP = 2.11;

            ConfigHelper.Instance.DPS_Fusion = 387;
            ConfigHelper.Instance.RoF_Fusion = 2.11;

            ConfigHelper.Instance.DPS_Phased_Plasma = 387;
            ConfigHelper.Instance.RoF_Phased_Plasma = 2.11;

            ConfigHelper.Instance.DPS_Hail = 596;
            ConfigHelper.Instance.RoF_Hail = 2.07;
        }

        public void RepairDpsRoF()
        {
            if (ConfigHelper.Instance.DPS_Mjolnir == 0) ConfigHelper.Instance.DPS_Mjolnir = 846;
            if (ConfigHelper.Instance.RoF_Mjolnir == 0.0) ConfigHelper.Instance.RoF_Mjolnir = 6.77;

            if (ConfigHelper.Instance.DPS_Nova == 0) ConfigHelper.Instance.DPS_Nova = 846;
            if (ConfigHelper.Instance.RoF_Nova == 0.0) ConfigHelper.Instance.RoF_Nova = 6.77;

            if (ConfigHelper.Instance.DPS_Antimatter == 0) ConfigHelper.Instance.DPS_Antimatter = 390;
            if (ConfigHelper.Instance.RoF_Antimatter == 0.0) ConfigHelper.Instance.RoF_Antimatter = 2.05;

            if (ConfigHelper.Instance.DPS_Void == 0) ConfigHelper.Instance.DPS_Void = 731;
            if (ConfigHelper.Instance.RoF_Void == 0.0) ConfigHelper.Instance.RoF_Void = 1.96;

            if (ConfigHelper.Instance.DPS_VoidL == 0) ConfigHelper.Instance.DPS_VoidL = 1521;
            if (ConfigHelper.Instance.RoF_VoidL == 0.0) ConfigHelper.Instance.RoF_VoidL = 4.37;

            if (ConfigHelper.Instance.DPS_Multifrequency == 0) ConfigHelper.Instance.DPS_Multifrequency = 272;
            if (ConfigHelper.Instance.RoF_Multifrequency == 0.0) ConfigHelper.Instance.RoF_Multifrequency = 2.58;

            if (ConfigHelper.Instance.DPS_EMP == 0) ConfigHelper.Instance.DPS_EMP = 331;
            if (ConfigHelper.Instance.RoF_EMP == 0.0) ConfigHelper.Instance.RoF_EMP = 2.21;

            if (ConfigHelper.Instance.DPS_Fusion == 0) ConfigHelper.Instance.DPS_Fusion = 331;
            if (ConfigHelper.Instance.RoF_Fusion == 0.0) ConfigHelper.Instance.RoF_Fusion = 2.21;

            if (ConfigHelper.Instance.DPS_Phased_Plasma == 0) ConfigHelper.Instance.DPS_Phased_Plasma = 331;
            if (ConfigHelper.Instance.RoF_Phased_Plasma == 0.0) ConfigHelper.Instance.RoF_Phased_Plasma = 2.21;

            if (ConfigHelper.Instance.DPS_Hail == 0) ConfigHelper.Instance.DPS_Hail = 511;
            if (ConfigHelper.Instance.RoF_Hail == 0.0) ConfigHelper.Instance.RoF_Hail = 2.17;
        }

        public void ResetDpsRoFScrub()
        {
            ConfigHelper.Instance.DPS_Mjolnir = 0;
            ConfigHelper.Instance.DPS_Nova = 0;
            ConfigHelper.Instance.DPS_Antimatter = 0;
            ConfigHelper.Instance.DPS_Void = 0;
            ConfigHelper.Instance.DPS_VoidL = 0;
            ConfigHelper.Instance.DPS_Multifrequency = 0;
            ConfigHelper.Instance.DPS_EMP = 0;
            ConfigHelper.Instance.DPS_Fusion = 0;
            ConfigHelper.Instance.DPS_Phased_Plasma = 0;
            ConfigHelper.Instance.DPS_Hail = 0;

            ConfigHelper.Instance.RoF_Mjolnir = 0.0;
            ConfigHelper.Instance.RoF_Nova = 0.0;
            ConfigHelper.Instance.RoF_Antimatter = 0.0;
            ConfigHelper.Instance.RoF_Void = 0.0;
            ConfigHelper.Instance.RoF_VoidL = 0.0;
            ConfigHelper.Instance.RoF_Multifrequency = 0.0;
            ConfigHelper.Instance.RoF_EMP = 0.0;
            ConfigHelper.Instance.RoF_Fusion = 0.0;
            ConfigHelper.Instance.RoF_Phased_Plasma = 0.0;
            ConfigHelper.Instance.RoF_Hail = 0.0;

            RepairDpsRoF();
        }

        public GankShips()
        {
            RepairDpsRoF();
        }
    }
}
