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
            ConfigHelper.Instance.DPS_Mjolnir = 691;
            ConfigHelper.Instance.DPS_Nova = 691;
            ConfigHelper.Instance.DPS_Antimatter = 422;
            ConfigHelper.Instance.DPS_Void = 643;
            ConfigHelper.Instance.DPS_VoidL = 1543;
            ConfigHelper.Instance.DPS_Multifrequency = 293;
            ConfigHelper.Instance.DPS_EMP = 464;
            ConfigHelper.Instance.DPS_Fusion = 464;
            ConfigHelper.Instance.DPS_Phased_Plasma = 464;
            ConfigHelper.Instance.DPS_Hail = 518;

            ConfigHelper.Instance.RoF_Mjolnir = 5.94;
            ConfigHelper.Instance.RoF_Nova = 5.94;
            ConfigHelper.Instance.RoF_Antimatter = 1.97;
            ConfigHelper.Instance.RoF_Void = 1.6;
            ConfigHelper.Instance.RoF_VoidL = 4.16;
            ConfigHelper.Instance.RoF_Multifrequency = 2.5;
            ConfigHelper.Instance.RoF_EMP = 2.07;
            ConfigHelper.Instance.RoF_Fusion = 2.07;
            ConfigHelper.Instance.RoF_Phased_Plasma = 2.07;
            ConfigHelper.Instance.RoF_Hail = 2.07;
        }

        public void RepairDpsRoF()
        {
            if (ConfigHelper.Instance.DPS_Mjolnir == 0) ConfigHelper.Instance.DPS_Mjolnir = 574;
            if (ConfigHelper.Instance.DPS_Nova == 0) ConfigHelper.Instance.DPS_Nova = 574;
            if (ConfigHelper.Instance.DPS_Antimatter == 0) ConfigHelper.Instance.DPS_Antimatter = 383;
            if (ConfigHelper.Instance.DPS_Void == 0) ConfigHelper.Instance.DPS_Void = 573;
            if (ConfigHelper.Instance.DPS_VoidL == 0) ConfigHelper.Instance.DPS_VoidL = 1324;
            if (ConfigHelper.Instance.DPS_Multifrequency == 0) ConfigHelper.Instance.DPS_Multifrequency = 255;
            if (ConfigHelper.Instance.DPS_EMP == 0) ConfigHelper.Instance.DPS_EMP = 352;
            if (ConfigHelper.Instance.DPS_Fusion == 0) ConfigHelper.Instance.DPS_Fusion = 352;
            if (ConfigHelper.Instance.DPS_Phased_Plasma == 0) ConfigHelper.Instance.DPS_Phased_Plasma = 352;
            if (ConfigHelper.Instance.DPS_Hail == 0) ConfigHelper.Instance.DPS_Hail = 393;

            if (ConfigHelper.Instance.RoF_Mjolnir == 0.0) ConfigHelper.Instance.RoF_Mjolnir = 6.42;
            if (ConfigHelper.Instance.RoF_Nova == 0.0) ConfigHelper.Instance.RoF_Nova = 6.42;
            if (ConfigHelper.Instance.RoF_Antimatter == 0.0) ConfigHelper.Instance.RoF_Antimatter = 2.11;
            if (ConfigHelper.Instance.RoF_Void == 0.0) ConfigHelper.Instance.RoF_Void = 1.72;
            if (ConfigHelper.Instance.RoF_VoidL == 0.0) ConfigHelper.Instance.RoF_VoidL = 4.37;
            if (ConfigHelper.Instance.RoF_Multifrequency == 0.0) ConfigHelper.Instance.RoF_Multifrequency = 2.68;
            if (ConfigHelper.Instance.RoF_EMP == 0.0) ConfigHelper.Instance.RoF_EMP = 2.22;
            if (ConfigHelper.Instance.RoF_Fusion == 0.0) ConfigHelper.Instance.RoF_Fusion = 2.22;
            if (ConfigHelper.Instance.RoF_Phased_Plasma == 0.0) ConfigHelper.Instance.RoF_Phased_Plasma = 2.22;
            if (ConfigHelper.Instance.RoF_Hail == 0.0) ConfigHelper.Instance.RoF_Hail = 2.22;
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
