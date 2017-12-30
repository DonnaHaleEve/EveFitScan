using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {
        private void OnShipFitChanged()
        {
            //this.m_FitText.Text = m_FitScanProcessor.EFTFit;
            m_FitText.Clear();
            if (!m_FitScanProcessor.StateOk) {
                m_FitText.AppendText("INVALID FIT" + System.Environment.NewLine + System.Environment.NewLine);
                int end = m_FitText.TextLength;
                m_FitText.SelectAll();
                m_FitText.SelectionColor = Color.Red;
                m_FitText.SelectionLength = 0;
            }
            m_FitText.AppendText(m_FitScanProcessor.EFTFit);

            m_FitText.AppendText(System.Environment.NewLine);
            m_FitText.AppendText(System.Environment.NewLine);
            m_FitText.AppendText(m_FitScanProcessor.CODEToolURL);
        }

        private void OnShipTankChanged()
        {
            m_TextBoxShieldHP.Text = String.Format("{0}", m_FitScanProcessor.ShieldHP);
            m_TextBoxArmorHP.Text = String.Format("{0}", m_FitScanProcessor.ArmorHP);
            m_TextBoxHullHP.Text = String.Format("{0}", m_FitScanProcessor.HullHP);

            FormatResists(m_TextBoxShieldResistsCold, m_FitScanProcessor.ShieldResists);
            FormatResists(m_TextBoxShieldResistsHot, m_FitScanProcessor.ShieldResistsHeated);

            FormatResists(m_TextBoxArmorResistsCold, m_FitScanProcessor.ArmorResists);
            FormatResists(m_TextBoxArmorResistsHot, m_FitScanProcessor.ArmorResistsHeated);

            FormatResists(m_TextBoxHullResistsCold, m_FitScanProcessor.HullResists);
            FormatResists(m_TextBoxHullResistsHot, m_FitScanProcessor.HullResistsHeated);

            FormatEHP(m_TextBoxEHPMjolnirCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMjolnir));
            FormatEHP(m_TextBoxEHPMjolnirHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMjolnir));

            FormatEHP(m_TextBoxEHPNovaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoNova));
            FormatEHP(m_TextBoxEHPNovaHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoNova));

            FormatEHP(m_TextBoxEHPAntimatterCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoAntimatter));
            FormatEHP(m_TextBoxEHPAntimatterHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoAntimatter));

            FormatEHP(m_TextBoxEHPVoidCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoVoid));
            FormatEHP(m_TextBoxEHPVoidHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoVoid));

            FormatEHP(m_TextBoxEHPMultifreqCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMultifreq));
            FormatEHP(m_TextBoxEHPMultifreqHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMultifreq));

            FormatEHP(m_TextBoxEHPEMPCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoEMP));
            FormatEHP(m_TextBoxEHPEMPHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoEMP));

            FormatEHP(m_TextBoxEHPFusionCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoFusion));
            FormatEHP(m_TextBoxEHPFusionHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoFusion));

            FormatEHP(m_TextBoxEHPPhasedPlasmaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoPhasedPlasma));
            FormatEHP(m_TextBoxEHPPhasedPlasmaHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoPhasedPlasma));

            FormatEHP(m_TextBoxEHPHailCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoHail));
            FormatEHP(m_TextBoxEHPHailHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoHail));
        }

        private void FormatResists(RichTextBox box, Dictionary<ShipModel.RESIST, float> Resists) {
            box.Clear();
            AppendText(box, String.Format("{0:0.0}%", Resists[ShipModel.RESIST.EM] * 100.0f), Color.Blue);
            AppendText(box, " / ", Color.Empty);
            AppendText(box, String.Format("{0:0.0}%", Resists[ShipModel.RESIST.THERMAL] * 100.0f), Color.Red);
            AppendText(box, " / ", Color.Empty);
            AppendText(box, String.Format("{0:0.0}%", Resists[ShipModel.RESIST.KINETIC] * 100.0f), Color.DarkGray);
            AppendText(box, " / ", Color.Empty);
            AppendText(box, String.Format("{0:0.0}%", Resists[ShipModel.RESIST.EXPLOSIVE] * 100.0f), Color.Orange);
            box.SelectAll();
            box.SelectionAlignment = HorizontalAlignment.Center;
            box.SelectionLength = 0;
        }

        private void FormatEHP(RichTextBox box, float EHP) {
            box.Clear();
            box.AppendText(String.Format("{0:N0}", EHP));
            box.SelectAll();
            box.SelectionAlignment = HorizontalAlignment.Right;
            box.SelectionLength = 0;
        }

        private void AppendText(RichTextBox box, string text, Color color) {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            box.Select(start, end - start);
            box.SelectionColor = color;
            box.SelectionLength = 0; // clear
        }

        private float GetEHP(
            float ShieldHP, Dictionary<ShipModel.RESIST, float> ShieldResists,
            float ArmorHP, Dictionary<ShipModel.RESIST, float> ArmorResists,
            float HullHP, Dictionary<ShipModel.RESIST, float> HullResists,
            Dictionary<ShipModel.RESIST, float> Ammo)
        {
            return GetLayerEHP(ShieldHP, ShieldResists, Ammo) + GetLayerEHP(ArmorHP, ArmorResists, Ammo) + GetLayerEHP(HullHP, HullResists, Ammo);
        }

        private float GetLayerEHP(float LayerHP, Dictionary<ShipModel.RESIST, float> LayerResists, Dictionary<ShipModel.RESIST, float> Ammo)
        {
            float FullAmmoDamage = 0.0f;
            float AppliedDamage = 0.0f;
            foreach (ShipModel.RESIST Resist in Enum.GetValues(typeof(ShipModel.RESIST))) {
                FullAmmoDamage += Ammo[Resist];
                AppliedDamage += Ammo[Resist] * (1.0f - LayerResists[Resist]);
            }
            return LayerHP * FullAmmoDamage / AppliedDamage;
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoMjolnir = null;
        private Dictionary<ShipModel.RESIST, float> AmmoMjolnir {
            get {
                if (m_AmmoMjolnir == null) {
                    m_AmmoMjolnir = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoMjolnir[ShipModel.RESIST.EM] = 100.0f;
                    m_AmmoMjolnir[ShipModel.RESIST.THERMAL] = 0.0f;
                    m_AmmoMjolnir[ShipModel.RESIST.KINETIC] = 0.0f;
                    m_AmmoMjolnir[ShipModel.RESIST.EXPLOSIVE] = 0.0f;
                }
                return m_AmmoMjolnir;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoNova = null;
        private Dictionary<ShipModel.RESIST, float> AmmoNova
        {
            get
            {
                if (m_AmmoNova == null)
                {
                    m_AmmoNova = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoNova[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoNova[ShipModel.RESIST.THERMAL] = 0.0f;
                    m_AmmoNova[ShipModel.RESIST.KINETIC] = 0.0f;
                    m_AmmoNova[ShipModel.RESIST.EXPLOSIVE] = 100.0f;
                }
                return m_AmmoNova;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoAntimatter = null;
        private Dictionary<ShipModel.RESIST, float> AmmoAntimatter
        {
            get
            {
                if (m_AmmoAntimatter == null)
                {
                    m_AmmoAntimatter = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoAntimatter[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoAntimatter[ShipModel.RESIST.THERMAL] = 5.0f;
                    m_AmmoAntimatter[ShipModel.RESIST.KINETIC] = 7.0f;
                    m_AmmoAntimatter[ShipModel.RESIST.EXPLOSIVE] = 0.0f;
                }
                return m_AmmoAntimatter;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoVoid = null;
        private Dictionary<ShipModel.RESIST, float> AmmoVoid
        {
            get
            {
                if (m_AmmoVoid == null)
                {
                    m_AmmoVoid = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoVoid[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoVoid[ShipModel.RESIST.THERMAL] = 7.7f;
                    m_AmmoVoid[ShipModel.RESIST.KINETIC] = 7.7f;
                    m_AmmoVoid[ShipModel.RESIST.EXPLOSIVE] = 0.0f;
                }
                return m_AmmoVoid;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoMultifreq = null;
        private Dictionary<ShipModel.RESIST, float> AmmoMultifreq
        {
            get
            {
                if (m_AmmoMultifreq == null)
                {
                    m_AmmoMultifreq = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoMultifreq[ShipModel.RESIST.EM] = 7.0f;
                    m_AmmoMultifreq[ShipModel.RESIST.THERMAL] = 5.0f;
                    m_AmmoMultifreq[ShipModel.RESIST.KINETIC] = 0.0f;
                    m_AmmoMultifreq[ShipModel.RESIST.EXPLOSIVE] = 0.0f;
                }
                return m_AmmoMultifreq;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoEMP = null;
        private Dictionary<ShipModel.RESIST, float> AmmoEMP
        {
            get
            {
                if (m_AmmoEMP == null)
                {
                    m_AmmoEMP = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoEMP[ShipModel.RESIST.EM] = 9.0f;
                    m_AmmoEMP[ShipModel.RESIST.THERMAL] = 0.0f;
                    m_AmmoEMP[ShipModel.RESIST.KINETIC] = 1.0f;
                    m_AmmoEMP[ShipModel.RESIST.EXPLOSIVE] = 2.0f;
                }
                return m_AmmoEMP;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoFusion = null;
        private Dictionary<ShipModel.RESIST, float> AmmoFusion
        {
            get
            {
                if (m_AmmoFusion == null)
                {
                    m_AmmoFusion = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoFusion[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoFusion[ShipModel.RESIST.THERMAL] = 0.0f;
                    m_AmmoFusion[ShipModel.RESIST.KINETIC] = 2.0f;
                    m_AmmoFusion[ShipModel.RESIST.EXPLOSIVE] = 10.0f;
                }
                return m_AmmoFusion;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoPhasedPlasma = null;
        private Dictionary<ShipModel.RESIST, float> AmmoPhasedPlasma
        {
            get
            {
                if (m_AmmoPhasedPlasma == null)
                {
                    m_AmmoPhasedPlasma = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoPhasedPlasma[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoPhasedPlasma[ShipModel.RESIST.THERMAL] = 10.0f;
                    m_AmmoPhasedPlasma[ShipModel.RESIST.KINETIC] = 2.0f;
                    m_AmmoPhasedPlasma[ShipModel.RESIST.EXPLOSIVE] = 0.0f;
                }
                return m_AmmoPhasedPlasma;
            }
        }

        private Dictionary<ShipModel.RESIST, float> m_AmmoHail = null;
        private Dictionary<ShipModel.RESIST, float> AmmoHail
        {
            get
            {
                if (m_AmmoHail == null)
                {
                    m_AmmoHail = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoHail[ShipModel.RESIST.EM] = 0.0f;
                    m_AmmoHail[ShipModel.RESIST.THERMAL] = 0.0f;
                    m_AmmoHail[ShipModel.RESIST.KINETIC] = 3.3f;
                    m_AmmoHail[ShipModel.RESIST.EXPLOSIVE] = 12.1f;
                }
                return m_AmmoHail;
            }
        }
    }
}