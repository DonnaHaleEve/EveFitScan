using System;
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

        private void m_checkBoxADCActive_CheckedChanged(object sender, EventArgs e) {
            ConfigHelper.Instance.ADCActive = m_checkBoxADCActive.Checked;
            m_FitScanProcessor.SetADCActive(m_checkBoxADCActive.Checked);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
