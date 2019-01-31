﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EveFitScanUI
{
    public partial class Form1 : Form
    {

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsDialog dlg = new SettingsDialog();
            DialogResult res = dlg.ShowDialog(this);
            dlg.Dispose();
            if (res == DialogResult.OK) {
                this.TopMost = ConfigHelper.Instance.AlwaysOnTop;
            }
            HighlightFit();
        }

        private void m_checkBoxPassive_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper.Instance.PassiveTank = m_checkBoxPassive.Checked;
            m_FitScanProcessor.SetPassive(m_checkBoxPassive.Checked);
            if (m_checkBoxPassive.Checked) {
                m_checkBoxADCActive.Enabled = false;
            }
            else {
                m_checkBoxADCActive.Enabled = true;
            }
        }

        private static int m_coldLeft = 528;
        private static int m_coldLeftSTK = m_coldLeft - 55;
        private static int m_hotLeft = 768;
        private static int m_hotLeftSTK = m_hotLeft + 55;

        private void m_checkBoxSTK_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper.Instance.STK = m_checkBoxSTK.Checked;
            m_FitScanProcessor.SetSTK(m_checkBoxSTK.Checked);
            ConfigSTKDisplay();
            m_FitScanProcessor.SetSTK(m_checkBoxSTK.Checked);
        }

        private void ConfigSTKDisplay()
        {
            if (m_checkBoxSTK.Checked)
            {
                this.label10.Text = "Multifreq.";
                this.label13.Text = "Phased Pl.";

                m_TextBoxArmorResistsHot.Text = "500";
                m_TextBoxHullResistsHot.Text = "2.7";

                m_TextBoxEHPAntimatterHot.Left = m_hotLeftSTK;
                m_TextBoxEHPEMPHot.Left = m_hotLeftSTK;
                m_TextBoxEHPFusionHot.Left = m_hotLeftSTK;
                m_TextBoxEHPHailHot.Left = m_hotLeftSTK;
                m_TextBoxEHPMjolnirHot.Left = m_hotLeftSTK;
                m_TextBoxEHPMultifreqHot.Left = m_hotLeftSTK;
                m_TextBoxEHPNovaHot.Left = m_hotLeftSTK;
                m_TextBoxEHPPhasedPlasmaHot.Left = m_hotLeftSTK;
                m_TextBoxEHPVoidHot.Left = m_hotLeftSTK;

                m_TextBoxEHPAntimatterCold.Left = m_coldLeftSTK;
                m_TextBoxEHPEMPCold.Left = m_coldLeftSTK;
                m_TextBoxEHPFusionCold.Left = m_coldLeftSTK;
                m_TextBoxEHPHailCold.Left = m_coldLeftSTK;
                m_TextBoxEHPMjolnirCold.Left = m_coldLeftSTK;
                m_TextBoxEHPMultifreqCold.Left = m_coldLeftSTK;
                m_TextBoxEHPNovaCold.Left = m_coldLeftSTK;
                m_TextBoxEHPPhasedPlasmaCold.Left = m_coldLeftSTK;
                m_TextBoxEHPVoidCold.Left = m_coldLeftSTK;

                m_comboBoxSysSecurity.Visible = true;
                this.labelSysSecurity.Visible = true;
                this.labelDPS.Visible = true;
                this.labelRoF.Visible = true;
                this.labelSTK.Visible = true;
                m_textBox_DPS_Mjolnir.Visible = true;
                m_textBox_DPS_Nova.Visible = true;
                m_textBox_DPS_Antimatter.Visible = true;
                m_textBox_DPS_Void.Visible = true;
                m_textBox_DPS_EMP.Visible = true;
                m_textBox_DPS_Fusion.Visible = true;
                m_textBox_DPS_Phased_Plasma.Visible = true;
                m_textBox_DPS_Hail.Visible = true;

                m_textBox_RoF_Mjolnir.Visible = true;
                m_textBox_RoF_Nova.Visible = true;
                m_textBox_RoF_Antimatter.Visible = true;
                m_textBox_RoF_Void.Visible = true;
                m_textBox_RoF_EMP.Visible = true;
                m_textBox_RoF_Fusion.Visible = true;
                m_textBox_RoF_Phased_Plasma.Visible = true;
                m_textBox_RoF_Hail.Visible = true;

                m_TextBoxArmorResistsHot.Visible = false;
                m_TextBoxHullResistsHot.Visible = false;
                m_TextBoxShieldResistsHot.Visible = false;
                this.label5.Visible = false;
            }
            else
            {
                this.label10.Text = "Multifrequency";
                this.label13.Text = "Phased Plasma";

                m_TextBoxEHPAntimatterHot.Left = m_hotLeft;
                m_TextBoxEHPEMPHot.Left = m_hotLeft;
                m_TextBoxEHPFusionHot.Left = m_hotLeft;
                m_TextBoxEHPHailHot.Left = m_hotLeft;
                m_TextBoxEHPMjolnirHot.Left = m_hotLeft;
                m_TextBoxEHPMultifreqHot.Left = m_hotLeft;
                m_TextBoxEHPNovaHot.Left = m_hotLeft;
                m_TextBoxEHPPhasedPlasmaHot.Left = m_hotLeft;
                m_TextBoxEHPVoidHot.Left = m_hotLeft;

                m_TextBoxEHPAntimatterCold.Left = m_coldLeft;
                m_TextBoxEHPEMPCold.Left = m_coldLeft;
                m_TextBoxEHPFusionCold.Left = m_coldLeft;
                m_TextBoxEHPHailCold.Left = m_coldLeft;
                m_TextBoxEHPMjolnirCold.Left = m_coldLeft;
                m_TextBoxEHPMultifreqCold.Left = m_coldLeft;
                m_TextBoxEHPNovaCold.Left = m_coldLeft;
                m_TextBoxEHPPhasedPlasmaCold.Left = m_coldLeft;
                m_TextBoxEHPVoidCold.Left = m_coldLeft;

                m_comboBoxSysSecurity.Visible = false;
                this.labelSysSecurity.Visible = false;
                this.labelDPS.Visible = false;
                this.labelRoF.Visible = false;
                this.labelSTK.Visible = false;
                m_textBox_DPS_Mjolnir.Visible = false;
                m_textBox_DPS_Nova.Visible = false;
                m_textBox_DPS_Antimatter.Visible = false;
                m_textBox_DPS_Void.Visible = false;
                m_textBox_DPS_EMP.Visible = false;
                m_textBox_DPS_Fusion.Visible = false;
                m_textBox_DPS_Phased_Plasma.Visible = false;
                m_textBox_DPS_Hail.Visible = false;

                m_textBox_RoF_Mjolnir.Visible = false;
                m_textBox_RoF_Nova.Visible = false;
                m_textBox_RoF_Antimatter.Visible = false;
                m_textBox_RoF_Void.Visible = false;
                m_textBox_RoF_EMP.Visible = false;
                m_textBox_RoF_Fusion.Visible = false;
                m_textBox_RoF_Phased_Plasma.Visible = false;
                m_textBox_RoF_Hail.Visible = false;

                m_TextBoxArmorResistsHot.Visible = true;
                m_TextBoxHullResistsHot.Visible = true;
                m_TextBoxShieldResistsHot.Visible = true;
                this.label5.Visible = true;
            }

        }

        private void m_checkBoxADCActive_CheckedChanged(object sender, EventArgs e) {
            ConfigHelper.Instance.ADCActive = m_checkBoxADCActive.Checked;
            m_FitScanProcessor.SetADCActive(m_checkBoxADCActive.Checked);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetDPSRoFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_gankShips.ResetDpsRoF();
            Load_DPS_RoF();
            m_FitScanProcessor.SetSTK(true);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "EveFitScan Version " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() + @"
2017 Donna Hale <donna.hale.eve@gmail.com>

Comments/Suggestions/Complaints can be posted in the appropriate 
thread on the Goonfleet Forums or sent to me via Jabber.";

            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = @"EveFitScan (C) 2017 Donna Hale <donna.hale.eve@gmail.com>

Ships to Kill mod by Vulkyn (C) 2019.

EVE Online and the EVE logo are the registered trademarks of CCP hf.
All rights are reserved worldwide. All other trademarks are the
property of their respective owners. EVE Online, the EVE logo, EVE
and all associated logos and designs are the intellectual property
of CCP hf. All artwork, screenshots, characters, vehicles,
storylines, world facts or other recognizable features of the
intellectual property relating to these trademarks are likewise the
intellectual property of CCP hf. CCP hf. does not endorse, and is
not in any way affiliated with, this software. CCP is in no way
responsible for the content or functioning of this software, nor
can it be liable for any damage arising from the use of this software.

A non-exclusive, non-transferrable, limited time license to use this
software and associated source code, has been granted to you as a 
member of one of the following organizations or its allies:

* Goonswarm
* Miniluv

This license exists only for as long as you continue to be a member
of one of these groups or its allies, and will terminate at the time
you are no longer a member of those entities and/or its allies.

This license may also be terminated at any time for any and/or no
reason by any or all of the copyright holders.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY
KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR  OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.";

            MessageBox.Show(message, "License", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bitbucket.org/Donna_Hale_Eve/fitscan_eve/overview");
        }

        private void m_ButtonResetFit_Click(object sender, EventArgs e)
        {
            m_FitScanProcessor.ResetFit(m_checkBoxPassive.Checked, m_checkBoxADCActive.Checked);
        }

        private void m_ButtonCopyCODE_Click(object sender, EventArgs e)
        {
            bool prevClipboard = m_bCaptureClipboard;

            m_bCaptureClipboard = false;

            Clipboard.SetText(m_FitScanProcessor.CODEToolURL);

            m_bCaptureClipboard = prevClipboard;
        }

        private void m_ButtonCopyEFT_Click(object sender, EventArgs e)
        {
            bool prevClipboard = m_bCaptureClipboard;

            m_bCaptureClipboard = false;

            Clipboard.SetText(m_FitScanProcessor.EFTFit);

            m_bCaptureClipboard = prevClipboard;
        }
    }
}
