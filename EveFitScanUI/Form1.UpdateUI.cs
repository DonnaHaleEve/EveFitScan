using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {
        private void OnFitValueChanged() {
            Tuple<float, float, float, float> Value = m_FitScanProcessor.FitValue;

            m_ValueHullText.Clear();
            m_ValueHullText.AppendText(String.Format("{0:N0}", Value.Item1));
            m_ValueHullText.SelectAll();
            m_ValueHullText.SelectionAlignment = HorizontalAlignment.Right;
            m_ValueHullText.SelectionLength = 0;

            m_ValueFittingsText.Clear();
            m_ValueFittingsText.AppendText(String.Format("{0:N0}", Value.Item2));
            m_ValueFittingsText.SelectAll();
            m_ValueFittingsText.SelectionAlignment = HorizontalAlignment.Right;
            m_ValueFittingsText.SelectionLength = 0;

            m_ValueTotalText.Clear();
            m_ValueTotalText.AppendText(String.Format("{0:N0}", Value.Item3));
            m_ValueTotalText.SelectAll();
            m_ValueTotalText.SelectionAlignment = HorizontalAlignment.Right;
            m_ValueTotalText.SelectionLength = 0;

            m_ValueCanDropText.Clear();
            m_ValueCanDropText.AppendText(String.Format("{0:N0}", Value.Item4));
            m_ValueCanDropText.SelectAll();
            m_ValueCanDropText.SelectionAlignment = HorizontalAlignment.Right;
            m_ValueCanDropText.SelectionLength = 0;

            UpdateHistoryPrice(Value.Item3);
        }

        private void OnShipFitChanged()
        {
            m_FitText.Clear();
            if (!m_FitScanProcessor.ValidFit) {
                m_FitText.AppendText("INVALID FIT" + System.Environment.NewLine + System.Environment.NewLine);
                int end = m_FitText.TextLength;
                m_FitText.SelectAll();
                m_FitText.SelectionColor = Color.Red;
                m_FitText.SelectionLength = 0;
            }
            m_FitText.AppendText(m_FitScanProcessor.EFTFit);

            HighlightFit();

            if (!m_bInsideIndexChange) {
                UpdateHistoryFit();
            }

            if (ConfigHelper.Instance.ActivateOnFitUpdate && !this.TopMost) {
                this.Activate();
            }
        }

        private void HighlightFit() {
            if (ConfigHelper.Instance.Highlight && m_FitScanProcessor.FullFitKnown) {
                m_FitText.BackColor = Color.LightGreen;
            }
            else if (ConfigHelper.Instance.Highlight && m_FitScanProcessor.FullTankKnown) {
                m_FitText.BackColor = Color.Yellow;
            }
            else {
                m_FitText.BackColor = Color.White;
            }
        }

        private void OnShipTankChanged()
        {
            if (m_checkBoxSTK.Checked)
                OnShipTankChangedSTK();
            else
                OnShipTankChangedHotCold();

            float EHP = GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoUniform);
            UpdateHistoryTank(EHP);
        }

        private void OnShipTankChangedSTK()
        {
            if(m_radioHot.Checked)
            {
                FormatResists(m_TextBoxShieldResistsCold, m_FitScanProcessor.ShieldResistsHeated);
                FormatResists(m_TextBoxArmorResistsCold, m_FitScanProcessor.ArmorResistsHeated);
                FormatResists(m_TextBoxHullResistsCold, m_FitScanProcessor.HullResistsHeated);
                FormatEHP(m_TextBoxEHPMjolnirCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMjolnir));
                FormatEHP(m_TextBoxEHPNovaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoNova));
                FormatEHP(m_TextBoxEHPAntimatterCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoAntimatter));
                FormatEHP(m_TextBoxEHPVoidCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoVoid));
                FormatEHP(m_TextBoxEHPVoidLCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoVoid));
                FormatEHP(m_TextBoxEHPMultifreqCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMultifreq));
                FormatEHP(m_TextBoxEHPEMPCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoEMP));
                FormatEHP(m_TextBoxEHPFusionCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoFusion));
                FormatEHP(m_TextBoxEHPPhasedPlasmaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoPhasedPlasma));
                FormatEHP(m_TextBoxEHPHailCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoHail));
            }
            else
            {
                FormatResists(m_TextBoxShieldResistsCold, m_FitScanProcessor.ShieldResists);
                FormatResists(m_TextBoxArmorResistsCold, m_FitScanProcessor.ArmorResists);
                FormatResists(m_TextBoxHullResistsCold, m_FitScanProcessor.HullResists);
                FormatEHP(m_TextBoxEHPMjolnirCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMjolnir));
                FormatEHP(m_TextBoxEHPNovaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoNova));
                FormatEHP(m_TextBoxEHPAntimatterCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoAntimatter));
                FormatEHP(m_TextBoxEHPVoidCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoVoid));
                FormatEHP(m_TextBoxEHPVoidLCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoVoid));
                FormatEHP(m_TextBoxEHPMultifreqCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMultifreq));
                FormatEHP(m_TextBoxEHPEMPCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoEMP));
                FormatEHP(m_TextBoxEHPFusionCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoFusion));
                FormatEHP(m_TextBoxEHPPhasedPlasmaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoPhasedPlasma));
                FormatEHP(m_TextBoxEHPHailCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoHail));
            }

            String sysSec = m_comboBoxSysSecurity.Text;
            FormatEHP(m_TextBoxEHPMjolnirHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Mjolnir, ConfigHelper.Instance.RoF_Mjolnir, Int32.Parse(m_TextBoxEHPMjolnirCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPNovaHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Nova, ConfigHelper.Instance.RoF_Nova, Int32.Parse(m_TextBoxEHPNovaCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPAntimatterHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Antimatter, ConfigHelper.Instance.RoF_Antimatter, Int32.Parse(m_TextBoxEHPAntimatterCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPVoidHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Void, ConfigHelper.Instance.RoF_Void, Int32.Parse(m_TextBoxEHPVoidCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPVoidLHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_VoidL, ConfigHelper.Instance.RoF_VoidL, Int32.Parse(m_TextBoxEHPVoidLCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPMultifreqHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Multifrequency, ConfigHelper.Instance.RoF_Multifrequency, Int32.Parse(m_TextBoxEHPMultifreqCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPEMPHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_EMP, ConfigHelper.Instance.RoF_EMP, Int32.Parse(m_TextBoxEHPEMPCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPFusionHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Fusion, ConfigHelper.Instance.RoF_Fusion, Int32.Parse(m_TextBoxEHPFusionCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPPhasedPlasmaHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Phased_Plasma, ConfigHelper.Instance.RoF_Phased_Plasma, Int32.Parse(m_TextBoxEHPPhasedPlasmaCold.Text, NumberStyles.AllowThousands))));
            FormatEHP(m_TextBoxEHPHailHot, Int32.Parse(m_gankShips.NumShipToKill(sysSec, ConfigHelper.Instance.DPS_Hail, ConfigHelper.Instance.RoF_Hail, Int32.Parse(m_TextBoxEHPHailCold.Text, NumberStyles.AllowThousands))));
        }

        private void OnShipTankChangedHotCold()
        {
            m_TextBoxShieldHP.Text = String.Format("{0}", m_FitScanProcessor.ShieldHP);
            m_TextBoxArmorHP.Text = String.Format("{0}", m_FitScanProcessor.ArmorHP);
            m_TextBoxHullHP.Text = String.Format("{0}", m_FitScanProcessor.HullHP);

            FormatResists(m_TextBoxShieldResistsCold, m_FitScanProcessor.ShieldResists);
            FormatResists(m_TextBoxArmorResistsCold, m_FitScanProcessor.ArmorResists);
            FormatResists(m_TextBoxHullResistsCold, m_FitScanProcessor.HullResists);
            FormatEHP(m_TextBoxEHPMjolnirCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMjolnir));
            FormatEHP(m_TextBoxEHPNovaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoNova));
            FormatEHP(m_TextBoxEHPAntimatterCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoAntimatter));
            FormatEHP(m_TextBoxEHPVoidCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoVoid));
            FormatEHP(m_TextBoxEHPMultifreqCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoMultifreq));
            FormatEHP(m_TextBoxEHPEMPCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoEMP));
            FormatEHP(m_TextBoxEHPFusionCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoFusion));
            FormatEHP(m_TextBoxEHPPhasedPlasmaCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoPhasedPlasma));
            FormatEHP(m_TextBoxEHPHailCold, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResists, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResists, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResists, AmmoHail));

            if (m_FitScanProcessor.PassiveTank)
            {

                m_TextBoxShieldResistsHot.Clear();
                m_TextBoxArmorResistsHot.Clear();
                m_TextBoxHullResistsHot.Clear();
                m_TextBoxEHPMjolnirHot.Clear();
                m_TextBoxEHPNovaHot.Clear();
                m_TextBoxEHPAntimatterHot.Clear();
                m_TextBoxEHPVoidHot.Clear();
                m_TextBoxEHPMultifreqHot.Clear();
                m_TextBoxEHPEMPHot.Clear();
                m_TextBoxEHPFusionHot.Clear();
                m_TextBoxEHPPhasedPlasmaHot.Clear();
                m_TextBoxEHPHailHot.Clear();
            }
            else
            {
                m_TextBoxShieldResistsHot.Enabled = true;
                m_TextBoxArmorResistsHot.Enabled = true;
                m_TextBoxHullResistsHot.Enabled = true;
                m_TextBoxEHPMjolnirHot.Enabled = true;
                m_TextBoxEHPNovaHot.Enabled = true;
                m_TextBoxEHPAntimatterHot.Enabled = true;
                m_TextBoxEHPVoidHot.Enabled = true;
                m_TextBoxEHPMultifreqHot.Enabled = true;
                m_TextBoxEHPEMPHot.Enabled = true;
                m_TextBoxEHPFusionHot.Enabled = true;
                m_TextBoxEHPPhasedPlasmaHot.Enabled = true;
                m_TextBoxEHPHailHot.Enabled = true;
                FormatResists(m_TextBoxShieldResistsHot, m_FitScanProcessor.ShieldResistsHeated);
                FormatResists(m_TextBoxArmorResistsHot, m_FitScanProcessor.ArmorResistsHeated);
                FormatResists(m_TextBoxHullResistsHot, m_FitScanProcessor.HullResistsHeated);
                FormatEHP(m_TextBoxEHPMjolnirHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMjolnir));
                FormatEHP(m_TextBoxEHPNovaHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoNova));
                FormatEHP(m_TextBoxEHPAntimatterHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoAntimatter));
                FormatEHP(m_TextBoxEHPVoidHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoVoid));
                FormatEHP(m_TextBoxEHPMultifreqHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoMultifreq));
                FormatEHP(m_TextBoxEHPEMPHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoEMP));
                FormatEHP(m_TextBoxEHPFusionHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoFusion));
                FormatEHP(m_TextBoxEHPPhasedPlasmaHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoPhasedPlasma));
                FormatEHP(m_TextBoxEHPHailHot, GetEHP(m_FitScanProcessor.ShieldHP, m_FitScanProcessor.ShieldResistsHeated, m_FitScanProcessor.ArmorHP, m_FitScanProcessor.ArmorResistsHeated, m_FitScanProcessor.HullHP, m_FitScanProcessor.HullResistsHeated, AmmoHail));
            }
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

        private Dictionary<ShipModel.RESIST, float> m_AmmoUniform = null;
        private Dictionary<ShipModel.RESIST, float> AmmoUniform {
            get {
                if (m_AmmoUniform == null) {
                    m_AmmoUniform = new Dictionary<ShipModel.RESIST, float>();
                    m_AmmoUniform[ShipModel.RESIST.EM] = 10.0f;
                    m_AmmoUniform[ShipModel.RESIST.THERMAL] = 10.0f;
                    m_AmmoUniform[ShipModel.RESIST.KINETIC] = 10.0f;
                    m_AmmoUniform[ShipModel.RESIST.EXPLOSIVE] = 10.0f;
                }
                return m_AmmoUniform;
            }
        }
    }
}