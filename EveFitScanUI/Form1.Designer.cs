using System.Windows.Forms;

namespace EveFitScanUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDPSRoFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ButtonResetFit = new System.Windows.Forms.Button();
            this.m_ComboBoxShipType = new System.Windows.Forms.ComboBox();
            this.m_ButtonCopyCODE = new System.Windows.Forms.Button();
            this.m_ButtonCopyEFT = new System.Windows.Forms.Button();
            this.m_TextBoxShieldHP = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_TextBoxArmorHP = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxHullHP = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxShieldResistsCold = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxShieldResistsHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxArmorResistsCold = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxArmorResistsHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxHullResistsCold = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxHullResistsHot = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPMjolnirCold = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPMjolnirHot = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPNovaHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPNovaCold = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPAntimatterHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPAntimatterCold = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPVoidHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPVoidCold = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPMultifreqHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPMultifreqCold = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPEMPHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPEMPCold = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPFusionHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPFusionCold = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPPhasedPlasmaHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPPhasedPlasmaCold = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPHailHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPHailCold = new System.Windows.Forms.RichTextBox();
            this.m_FitText = new System.Windows.Forms.RichTextBox();
            this.m_checkBoxPassive = new System.Windows.Forms.CheckBox();
            this.m_BackgroundWorkerPrices = new System.ComponentModel.BackgroundWorker();
            this.m_ValueHullText = new System.Windows.Forms.RichTextBox();
            this.m_ValueFittingsText = new System.Windows.Forms.RichTextBox();
            this.m_ValueTotalText = new System.Windows.Forms.RichTextBox();
            this.m_ValueCanDropText = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_BackgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.m_checkBoxADCActive = new System.Windows.Forms.CheckBox();
            this.m_History = new System.Windows.Forms.ComboBox();
            this.m_checkBoxSTK = new System.Windows.Forms.CheckBox();
            this.m_comboBoxSysSecurity = new System.Windows.Forms.ComboBox();
            this.labelSysSecurity = new System.Windows.Forms.Label();
            this.labelDPS = new System.Windows.Forms.Label();
            this.labelRoF = new System.Windows.Forms.Label();
            this.labelSTK = new System.Windows.Forms.Label();
            this.m_textBox_DPS_Mjolnir = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Mjolnir = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Nova = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Antimatter = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Void = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Multifrequency = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_EMP = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Fusion = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Phased_Plasma = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_Hail = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Nova = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Antimatter = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Void = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Multifrequency = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_EMP = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Fusion = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Phased_Plasma = new System.Windows.Forms.RichTextBox();
            this.m_textBox_RoF_Hail = new System.Windows.Forms.RichTextBox();
            this.m_radioPassive = new System.Windows.Forms.RadioButton();
            this.m_radioCold = new System.Windows.Forms.RadioButton();
            this.m_radioHot = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_textBox_RoF_VoidL = new System.Windows.Forms.RichTextBox();
            this.m_textBox_DPS_VoidL = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_TextBoxEHPVoidLHot = new System.Windows.Forms.RichTextBox();
            this.m_TextBoxEHPVoidLCold = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelBR = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.m_checkBoxManualEHP = new System.Windows.Forms.CheckBox();
            this.m_richTextBoxManualEHP = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(968, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem,
            this.resetDPSRoFToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetDPSRoFcanFlyThenAll4ToolStripMenuItem
            // 
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem.Name = "resetDPSRoFcanFlyThenAll4ToolStripMenuItem";
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem.Size = new System.Drawing.Size(370, 22);
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem.Text = "Reset DPS / RoF (default - can fly, lvl4 support, lvl3 spec)";
            this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem.Click += new System.EventHandler(this.resetDPSRoFcanFlyThenAll4ToolStripMenuItem_Click);
            // 
            // resetDPSRoFToolStripMenuItem
            // 
            this.resetDPSRoFToolStripMenuItem.Name = "resetDPSRoFToolStripMenuItem";
            this.resetDPSRoFToolStripMenuItem.Size = new System.Drawing.Size(370, 22);
            this.resetDPSRoFToolStripMenuItem.Text = "Reset DPS / RoF (all 5~~~)";
            this.resetDPSRoFToolStripMenuItem.Click += new System.EventHandler(this.resetDPSRoFToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(370, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.sourceToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.sourceToolStripMenuItem.Text = "Source Code (Opens in browser)";
            this.sourceToolStripMenuItem.Click += new System.EventHandler(this.sourceToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // m_ButtonResetFit
            // 
            this.m_ButtonResetFit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ButtonResetFit.Location = new System.Drawing.Point(280, 54);
            this.m_ButtonResetFit.Name = "m_ButtonResetFit";
            this.m_ButtonResetFit.Size = new System.Drawing.Size(112, 48);
            this.m_ButtonResetFit.TabIndex = 3;
            this.m_ButtonResetFit.Text = "Reset";
            this.m_ButtonResetFit.UseVisualStyleBackColor = true;
            this.m_ButtonResetFit.Click += new System.EventHandler(this.m_ButtonResetFit_Click);
            // 
            // m_ComboBoxShipType
            // 
            this.m_ComboBoxShipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ComboBoxShipType.FormattingEnabled = true;
            this.m_ComboBoxShipType.Location = new System.Drawing.Point(16, 64);
            this.m_ComboBoxShipType.Name = "m_ComboBoxShipType";
            this.m_ComboBoxShipType.Size = new System.Drawing.Size(248, 28);
            this.m_ComboBoxShipType.TabIndex = 4;
            this.m_ComboBoxShipType.SelectedIndexChanged += new System.EventHandler(this.m_ComboBoxShipType_SelectedIndexChanged);
            this.m_ComboBoxShipType.TextUpdate += new System.EventHandler(this.m_ComboBoxShipType_TextUpdate);
            // 
            // m_ButtonCopyCODE
            // 
            this.m_ButtonCopyCODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ButtonCopyCODE.Location = new System.Drawing.Point(8, 672);
            this.m_ButtonCopyCODE.Name = "m_ButtonCopyCODE";
            this.m_ButtonCopyCODE.Size = new System.Drawing.Size(144, 32);
            this.m_ButtonCopyCODE.TabIndex = 5;
            this.m_ButtonCopyCODE.Text = "Copy CODE tool URL";
            this.m_ButtonCopyCODE.UseVisualStyleBackColor = true;
            this.m_ButtonCopyCODE.Click += new System.EventHandler(this.m_ButtonCopyCODE_Click);
            // 
            // m_ButtonCopyEFT
            // 
            this.m_ButtonCopyEFT.Location = new System.Drawing.Point(168, 672);
            this.m_ButtonCopyEFT.Name = "m_ButtonCopyEFT";
            this.m_ButtonCopyEFT.Size = new System.Drawing.Size(144, 32);
            this.m_ButtonCopyEFT.TabIndex = 6;
            this.m_ButtonCopyEFT.Text = "Copy EFT fit";
            this.m_ButtonCopyEFT.UseVisualStyleBackColor = true;
            this.m_ButtonCopyEFT.Click += new System.EventHandler(this.m_ButtonCopyEFT_Click);
            // 
            // m_TextBoxShieldHP
            // 
            this.m_TextBoxShieldHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxShieldHP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_TextBoxShieldHP.Location = new System.Drawing.Point(376, 128);
            this.m_TextBoxShieldHP.Multiline = false;
            this.m_TextBoxShieldHP.Name = "m_TextBoxShieldHP";
            this.m_TextBoxShieldHP.ReadOnly = true;
            this.m_TextBoxShieldHP.Size = new System.Drawing.Size(80, 24);
            this.m_TextBoxShieldHP.TabIndex = 7;
            this.m_TextBoxShieldHP.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(328, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Shield";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(328, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Armor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(336, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hull";
            // 
            // m_TextBoxArmorHP
            // 
            this.m_TextBoxArmorHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxArmorHP.Location = new System.Drawing.Point(376, 160);
            this.m_TextBoxArmorHP.Multiline = false;
            this.m_TextBoxArmorHP.Name = "m_TextBoxArmorHP";
            this.m_TextBoxArmorHP.ReadOnly = true;
            this.m_TextBoxArmorHP.Size = new System.Drawing.Size(80, 24);
            this.m_TextBoxArmorHP.TabIndex = 11;
            this.m_TextBoxArmorHP.Text = "";
            // 
            // m_TextBoxHullHP
            // 
            this.m_TextBoxHullHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxHullHP.Location = new System.Drawing.Point(376, 192);
            this.m_TextBoxHullHP.Multiline = false;
            this.m_TextBoxHullHP.Name = "m_TextBoxHullHP";
            this.m_TextBoxHullHP.ReadOnly = true;
            this.m_TextBoxHullHP.Size = new System.Drawing.Size(80, 24);
            this.m_TextBoxHullHP.TabIndex = 12;
            this.m_TextBoxHullHP.Text = "";
            // 
            // m_TextBoxShieldResistsCold
            // 
            this.m_TextBoxShieldResistsCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxShieldResistsCold.Location = new System.Drawing.Point(472, 128);
            this.m_TextBoxShieldResistsCold.Multiline = false;
            this.m_TextBoxShieldResistsCold.Name = "m_TextBoxShieldResistsCold";
            this.m_TextBoxShieldResistsCold.ReadOnly = true;
            this.m_TextBoxShieldResistsCold.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxShieldResistsCold.TabIndex = 13;
            this.m_TextBoxShieldResistsCold.Text = "";
            // 
            // m_TextBoxShieldResistsHot
            // 
            this.m_TextBoxShieldResistsHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxShieldResistsHot.Location = new System.Drawing.Point(720, 128);
            this.m_TextBoxShieldResistsHot.Multiline = false;
            this.m_TextBoxShieldResistsHot.Name = "m_TextBoxShieldResistsHot";
            this.m_TextBoxShieldResistsHot.ReadOnly = true;
            this.m_TextBoxShieldResistsHot.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxShieldResistsHot.TabIndex = 14;
            this.m_TextBoxShieldResistsHot.Text = "";
            // 
            // m_TextBoxArmorResistsCold
            // 
            this.m_TextBoxArmorResistsCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxArmorResistsCold.Location = new System.Drawing.Point(472, 160);
            this.m_TextBoxArmorResistsCold.Multiline = false;
            this.m_TextBoxArmorResistsCold.Name = "m_TextBoxArmorResistsCold";
            this.m_TextBoxArmorResistsCold.ReadOnly = true;
            this.m_TextBoxArmorResistsCold.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxArmorResistsCold.TabIndex = 15;
            this.m_TextBoxArmorResistsCold.Text = "";
            // 
            // m_TextBoxArmorResistsHot
            // 
            this.m_TextBoxArmorResistsHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxArmorResistsHot.Location = new System.Drawing.Point(720, 160);
            this.m_TextBoxArmorResistsHot.Multiline = false;
            this.m_TextBoxArmorResistsHot.Name = "m_TextBoxArmorResistsHot";
            this.m_TextBoxArmorResistsHot.ReadOnly = true;
            this.m_TextBoxArmorResistsHot.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxArmorResistsHot.TabIndex = 16;
            this.m_TextBoxArmorResistsHot.Text = "";
            // 
            // m_TextBoxHullResistsCold
            // 
            this.m_TextBoxHullResistsCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxHullResistsCold.Location = new System.Drawing.Point(472, 192);
            this.m_TextBoxHullResistsCold.Multiline = false;
            this.m_TextBoxHullResistsCold.Name = "m_TextBoxHullResistsCold";
            this.m_TextBoxHullResistsCold.ReadOnly = true;
            this.m_TextBoxHullResistsCold.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxHullResistsCold.TabIndex = 17;
            this.m_TextBoxHullResistsCold.Text = "";
            // 
            // m_TextBoxHullResistsHot
            // 
            this.m_TextBoxHullResistsHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxHullResistsHot.Location = new System.Drawing.Point(720, 192);
            this.m_TextBoxHullResistsHot.Multiline = false;
            this.m_TextBoxHullResistsHot.Name = "m_TextBoxHullResistsHot";
            this.m_TextBoxHullResistsHot.ReadOnly = true;
            this.m_TextBoxHullResistsHot.Size = new System.Drawing.Size(232, 24);
            this.m_TextBoxHullResistsHot.TabIndex = 18;
            this.m_TextBoxHullResistsHot.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "------ COLD ------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "------ HOT ------";
            // 
            // m_TextBoxEHPMjolnirCold
            // 
            this.m_TextBoxEHPMjolnirCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPMjolnirCold.Location = new System.Drawing.Point(528, 260);
            this.m_TextBoxEHPMjolnirCold.Multiline = false;
            this.m_TextBoxEHPMjolnirCold.Name = "m_TextBoxEHPMjolnirCold";
            this.m_TextBoxEHPMjolnirCold.ReadOnly = true;
            this.m_TextBoxEHPMjolnirCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPMjolnirCold.TabIndex = 21;
            this.m_TextBoxEHPMjolnirCold.Text = "";
            // 
            // m_TextBoxEHPMjolnirHot
            // 
            this.m_TextBoxEHPMjolnirHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPMjolnirHot.Location = new System.Drawing.Point(768, 260);
            this.m_TextBoxEHPMjolnirHot.Multiline = false;
            this.m_TextBoxEHPMjolnirHot.Name = "m_TextBoxEHPMjolnirHot";
            this.m_TextBoxEHPMjolnirHot.ReadOnly = true;
            this.m_TextBoxEHPMjolnirHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPMjolnirHot.TabIndex = 22;
            this.m_TextBoxEHPMjolnirHot.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(360, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mjolnir";
            this.toolTip1.SetToolTip(this.label6, "Purifier");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(360, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Nova";
            this.toolTip1.SetToolTip(this.label7, "Hound");
            // 
            // m_TextBoxEHPNovaHot
            // 
            this.m_TextBoxEHPNovaHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPNovaHot.Location = new System.Drawing.Point(768, 292);
            this.m_TextBoxEHPNovaHot.Multiline = false;
            this.m_TextBoxEHPNovaHot.Name = "m_TextBoxEHPNovaHot";
            this.m_TextBoxEHPNovaHot.ReadOnly = true;
            this.m_TextBoxEHPNovaHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPNovaHot.TabIndex = 25;
            this.m_TextBoxEHPNovaHot.Text = "";
            // 
            // m_TextBoxEHPNovaCold
            // 
            this.m_TextBoxEHPNovaCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPNovaCold.Location = new System.Drawing.Point(528, 292);
            this.m_TextBoxEHPNovaCold.Multiline = false;
            this.m_TextBoxEHPNovaCold.Name = "m_TextBoxEHPNovaCold";
            this.m_TextBoxEHPNovaCold.ReadOnly = true;
            this.m_TextBoxEHPNovaCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPNovaCold.TabIndex = 24;
            this.m_TextBoxEHPNovaCold.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(360, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Antimatter";
            this.toolTip1.SetToolTip(this.label8, "T1 Cat");
            // 
            // m_TextBoxEHPAntimatterHot
            // 
            this.m_TextBoxEHPAntimatterHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPAntimatterHot.Location = new System.Drawing.Point(768, 332);
            this.m_TextBoxEHPAntimatterHot.Multiline = false;
            this.m_TextBoxEHPAntimatterHot.Name = "m_TextBoxEHPAntimatterHot";
            this.m_TextBoxEHPAntimatterHot.ReadOnly = true;
            this.m_TextBoxEHPAntimatterHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPAntimatterHot.TabIndex = 28;
            this.m_TextBoxEHPAntimatterHot.Text = "";
            // 
            // m_TextBoxEHPAntimatterCold
            // 
            this.m_TextBoxEHPAntimatterCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPAntimatterCold.Location = new System.Drawing.Point(528, 332);
            this.m_TextBoxEHPAntimatterCold.Multiline = false;
            this.m_TextBoxEHPAntimatterCold.Name = "m_TextBoxEHPAntimatterCold";
            this.m_TextBoxEHPAntimatterCold.ReadOnly = true;
            this.m_TextBoxEHPAntimatterCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPAntimatterCold.TabIndex = 27;
            this.m_TextBoxEHPAntimatterCold.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(360, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Void";
            this.toolTip1.SetToolTip(this.label9, "T2 Cat");
            // 
            // m_TextBoxEHPVoidHot
            // 
            this.m_TextBoxEHPVoidHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPVoidHot.Location = new System.Drawing.Point(768, 364);
            this.m_TextBoxEHPVoidHot.Multiline = false;
            this.m_TextBoxEHPVoidHot.Name = "m_TextBoxEHPVoidHot";
            this.m_TextBoxEHPVoidHot.ReadOnly = true;
            this.m_TextBoxEHPVoidHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPVoidHot.TabIndex = 31;
            this.m_TextBoxEHPVoidHot.Text = "";
            // 
            // m_TextBoxEHPVoidCold
            // 
            this.m_TextBoxEHPVoidCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPVoidCold.Location = new System.Drawing.Point(528, 364);
            this.m_TextBoxEHPVoidCold.Multiline = false;
            this.m_TextBoxEHPVoidCold.Name = "m_TextBoxEHPVoidCold";
            this.m_TextBoxEHPVoidCold.ReadOnly = true;
            this.m_TextBoxEHPVoidCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPVoidCold.TabIndex = 30;
            this.m_TextBoxEHPVoidCold.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(360, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Multifrequency";
            this.toolTip1.SetToolTip(this.label10, "Coercer");
            // 
            // m_TextBoxEHPMultifreqHot
            // 
            this.m_TextBoxEHPMultifreqHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPMultifreqHot.Location = new System.Drawing.Point(768, 404);
            this.m_TextBoxEHPMultifreqHot.Multiline = false;
            this.m_TextBoxEHPMultifreqHot.Name = "m_TextBoxEHPMultifreqHot";
            this.m_TextBoxEHPMultifreqHot.ReadOnly = true;
            this.m_TextBoxEHPMultifreqHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPMultifreqHot.TabIndex = 34;
            this.m_TextBoxEHPMultifreqHot.Text = "";
            // 
            // m_TextBoxEHPMultifreqCold
            // 
            this.m_TextBoxEHPMultifreqCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPMultifreqCold.Location = new System.Drawing.Point(528, 404);
            this.m_TextBoxEHPMultifreqCold.Multiline = false;
            this.m_TextBoxEHPMultifreqCold.Name = "m_TextBoxEHPMultifreqCold";
            this.m_TextBoxEHPMultifreqCold.ReadOnly = true;
            this.m_TextBoxEHPMultifreqCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPMultifreqCold.TabIndex = 33;
            this.m_TextBoxEHPMultifreqCold.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(360, 444);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "EMP";
            this.toolTip1.SetToolTip(this.label11, "Autocannon Thrasher");
            // 
            // m_TextBoxEHPEMPHot
            // 
            this.m_TextBoxEHPEMPHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPEMPHot.Location = new System.Drawing.Point(768, 444);
            this.m_TextBoxEHPEMPHot.Multiline = false;
            this.m_TextBoxEHPEMPHot.Name = "m_TextBoxEHPEMPHot";
            this.m_TextBoxEHPEMPHot.ReadOnly = true;
            this.m_TextBoxEHPEMPHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPEMPHot.TabIndex = 37;
            this.m_TextBoxEHPEMPHot.Text = "";
            // 
            // m_TextBoxEHPEMPCold
            // 
            this.m_TextBoxEHPEMPCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPEMPCold.Location = new System.Drawing.Point(528, 444);
            this.m_TextBoxEHPEMPCold.Multiline = false;
            this.m_TextBoxEHPEMPCold.Name = "m_TextBoxEHPEMPCold";
            this.m_TextBoxEHPEMPCold.ReadOnly = true;
            this.m_TextBoxEHPEMPCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPEMPCold.TabIndex = 36;
            this.m_TextBoxEHPEMPCold.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(360, 476);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = "Fusion";
            this.toolTip1.SetToolTip(this.label12, "Autocannon Thrasher");
            // 
            // m_TextBoxEHPFusionHot
            // 
            this.m_TextBoxEHPFusionHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPFusionHot.Location = new System.Drawing.Point(768, 476);
            this.m_TextBoxEHPFusionHot.Multiline = false;
            this.m_TextBoxEHPFusionHot.Name = "m_TextBoxEHPFusionHot";
            this.m_TextBoxEHPFusionHot.ReadOnly = true;
            this.m_TextBoxEHPFusionHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPFusionHot.TabIndex = 40;
            this.m_TextBoxEHPFusionHot.Text = "";
            // 
            // m_TextBoxEHPFusionCold
            // 
            this.m_TextBoxEHPFusionCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPFusionCold.Location = new System.Drawing.Point(528, 476);
            this.m_TextBoxEHPFusionCold.Multiline = false;
            this.m_TextBoxEHPFusionCold.Name = "m_TextBoxEHPFusionCold";
            this.m_TextBoxEHPFusionCold.ReadOnly = true;
            this.m_TextBoxEHPFusionCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPFusionCold.TabIndex = 39;
            this.m_TextBoxEHPFusionCold.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(360, 508);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 20);
            this.label13.TabIndex = 44;
            this.label13.Text = "Phased Plasma";
            this.toolTip1.SetToolTip(this.label13, "Autocannon Thrasher");
            // 
            // m_TextBoxEHPPhasedPlasmaHot
            // 
            this.m_TextBoxEHPPhasedPlasmaHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPPhasedPlasmaHot.Location = new System.Drawing.Point(768, 508);
            this.m_TextBoxEHPPhasedPlasmaHot.Multiline = false;
            this.m_TextBoxEHPPhasedPlasmaHot.Name = "m_TextBoxEHPPhasedPlasmaHot";
            this.m_TextBoxEHPPhasedPlasmaHot.ReadOnly = true;
            this.m_TextBoxEHPPhasedPlasmaHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPPhasedPlasmaHot.TabIndex = 43;
            this.m_TextBoxEHPPhasedPlasmaHot.Text = "";
            // 
            // m_TextBoxEHPPhasedPlasmaCold
            // 
            this.m_TextBoxEHPPhasedPlasmaCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPPhasedPlasmaCold.Location = new System.Drawing.Point(528, 508);
            this.m_TextBoxEHPPhasedPlasmaCold.Multiline = false;
            this.m_TextBoxEHPPhasedPlasmaCold.Name = "m_TextBoxEHPPhasedPlasmaCold";
            this.m_TextBoxEHPPhasedPlasmaCold.ReadOnly = true;
            this.m_TextBoxEHPPhasedPlasmaCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPPhasedPlasmaCold.TabIndex = 42;
            this.m_TextBoxEHPPhasedPlasmaCold.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(360, 540);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Hail";
            this.toolTip1.SetToolTip(this.label14, "Autocannon Thrasher");
            // 
            // m_TextBoxEHPHailHot
            // 
            this.m_TextBoxEHPHailHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPHailHot.Location = new System.Drawing.Point(768, 540);
            this.m_TextBoxEHPHailHot.Multiline = false;
            this.m_TextBoxEHPHailHot.Name = "m_TextBoxEHPHailHot";
            this.m_TextBoxEHPHailHot.ReadOnly = true;
            this.m_TextBoxEHPHailHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPHailHot.TabIndex = 46;
            this.m_TextBoxEHPHailHot.Text = "";
            // 
            // m_TextBoxEHPHailCold
            // 
            this.m_TextBoxEHPHailCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPHailCold.Location = new System.Drawing.Point(528, 540);
            this.m_TextBoxEHPHailCold.Multiline = false;
            this.m_TextBoxEHPHailCold.Name = "m_TextBoxEHPHailCold";
            this.m_TextBoxEHPHailCold.ReadOnly = true;
            this.m_TextBoxEHPHailCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPHailCold.TabIndex = 45;
            this.m_TextBoxEHPHailCold.Text = "";
            // 
            // m_FitText
            // 
            this.m_FitText.Location = new System.Drawing.Point(8, 128);
            this.m_FitText.Name = "m_FitText";
            this.m_FitText.ReadOnly = true;
            this.m_FitText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.m_FitText.Size = new System.Drawing.Size(304, 432);
            this.m_FitText.TabIndex = 48;
            this.m_FitText.Text = "";
            // 
            // m_checkBoxPassive
            // 
            this.m_checkBoxPassive.AutoSize = true;
            this.m_checkBoxPassive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_checkBoxPassive.Location = new System.Drawing.Point(364, 635);
            this.m_checkBoxPassive.Name = "m_checkBoxPassive";
            this.m_checkBoxPassive.Size = new System.Drawing.Size(89, 24);
            this.m_checkBoxPassive.TabIndex = 49;
            this.m_checkBoxPassive.Text = "Passive";
            this.m_checkBoxPassive.UseVisualStyleBackColor = true;
            this.m_checkBoxPassive.CheckedChanged += new System.EventHandler(this.m_checkBoxPassive_CheckedChanged);
            // 
            // m_BackgroundWorkerPrices
            // 
            this.m_BackgroundWorkerPrices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerPrices_DoWork);
            this.m_BackgroundWorkerPrices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerPrices_RunWorkerCompleted);
            // 
            // m_ValueHullText
            // 
            this.m_ValueHullText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ValueHullText.Location = new System.Drawing.Point(152, 568);
            this.m_ValueHullText.Name = "m_ValueHullText";
            this.m_ValueHullText.ReadOnly = true;
            this.m_ValueHullText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_ValueHullText.Size = new System.Drawing.Size(160, 24);
            this.m_ValueHullText.TabIndex = 51;
            this.m_ValueHullText.Text = "";
            // 
            // m_ValueFittingsText
            // 
            this.m_ValueFittingsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ValueFittingsText.Location = new System.Drawing.Point(152, 592);
            this.m_ValueFittingsText.Name = "m_ValueFittingsText";
            this.m_ValueFittingsText.ReadOnly = true;
            this.m_ValueFittingsText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_ValueFittingsText.Size = new System.Drawing.Size(160, 24);
            this.m_ValueFittingsText.TabIndex = 52;
            this.m_ValueFittingsText.Text = "";
            // 
            // m_ValueTotalText
            // 
            this.m_ValueTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ValueTotalText.Location = new System.Drawing.Point(152, 616);
            this.m_ValueTotalText.Name = "m_ValueTotalText";
            this.m_ValueTotalText.ReadOnly = true;
            this.m_ValueTotalText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_ValueTotalText.Size = new System.Drawing.Size(160, 24);
            this.m_ValueTotalText.TabIndex = 53;
            this.m_ValueTotalText.Text = "";
            // 
            // m_ValueCanDropText
            // 
            this.m_ValueCanDropText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_ValueCanDropText.Location = new System.Drawing.Point(152, 640);
            this.m_ValueCanDropText.Name = "m_ValueCanDropText";
            this.m_ValueCanDropText.ReadOnly = true;
            this.m_ValueCanDropText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_ValueCanDropText.Size = new System.Drawing.Size(160, 24);
            this.m_ValueCanDropText.TabIndex = 54;
            this.m_ValueCanDropText.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(72, 568);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 16);
            this.label15.TabIndex = 55;
            this.label15.Text = "Hull:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(72, 592);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 56;
            this.label16.Text = "Fittings:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(72, 616);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 57;
            this.label17.Text = "Total:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(72, 640);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 58;
            this.label18.Text = "Can drop:";
            // 
            // m_BackgroundWorkerUpdate
            // 
            this.m_BackgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerUpdate_DoWork);
            this.m_BackgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerUpdate_RunWorkerCompleted);
            // 
            // m_checkBoxADCActive
            // 
            this.m_checkBoxADCActive.AutoSize = true;
            this.m_checkBoxADCActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_checkBoxADCActive.Location = new System.Drawing.Point(365, 683);
            this.m_checkBoxADCActive.Name = "m_checkBoxADCActive";
            this.m_checkBoxADCActive.Size = new System.Drawing.Size(210, 24);
            this.m_checkBoxADCActive.TabIndex = 59;
            this.m_checkBoxADCActive.Text = "ADC active (if present)";
            this.m_checkBoxADCActive.UseVisualStyleBackColor = true;
            this.m_checkBoxADCActive.CheckedChanged += new System.EventHandler(this.m_checkBoxADCActive_CheckedChanged);
            // 
            // m_History
            // 
            this.m_History.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_History.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_History.FormattingEnabled = true;
            this.m_History.Location = new System.Drawing.Point(8, 728);
            this.m_History.Name = "m_History";
            this.m_History.Size = new System.Drawing.Size(944, 23);
            this.m_History.TabIndex = 60;
            this.m_History.SelectedIndexChanged += new System.EventHandler(this.m_History_SelectedIndexChanged);
            // 
            // m_checkBoxSTK
            // 
            this.m_checkBoxSTK.AutoSize = true;
            this.m_checkBoxSTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_checkBoxSTK.Location = new System.Drawing.Point(631, 635);
            this.m_checkBoxSTK.Name = "m_checkBoxSTK";
            this.m_checkBoxSTK.Size = new System.Drawing.Size(122, 24);
            this.m_checkBoxSTK.TabIndex = 61;
            this.m_checkBoxSTK.Text = "Ships to Kill";
            this.m_checkBoxSTK.UseVisualStyleBackColor = true;
            this.m_checkBoxSTK.CheckedChanged += new System.EventHandler(this.m_checkBoxSTK_CheckedChanged);
            // 
            // m_comboBoxSysSecurity
            // 
            this.m_comboBoxSysSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxSysSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_comboBoxSysSecurity.FormattingEnabled = true;
            this.m_comboBoxSysSecurity.Items.AddRange(new object[] {
            "0.5",
            "0.5p",
            "0.6",
            "0.6p",
            "0.7",
            "0.7p",
            "0.8",
            "0.8p",
            "0.9",
            "0.9p",
            "1.0",
            "1.0p",
            "Jita",
            "Jitap"});
            this.m_comboBoxSysSecurity.Location = new System.Drawing.Point(709, 681);
            this.m_comboBoxSysSecurity.Name = "m_comboBoxSysSecurity";
            this.m_comboBoxSysSecurity.Size = new System.Drawing.Size(83, 28);
            this.m_comboBoxSysSecurity.TabIndex = 62;
            this.m_comboBoxSysSecurity.SelectedIndexChanged += new System.EventHandler(this.m_ComboBoxSysSecurity_SelectedIndexChanged);
            // 
            // labelSysSecurity
            // 
            this.labelSysSecurity.AutoSize = true;
            this.labelSysSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSysSecurity.Location = new System.Drawing.Point(592, 685);
            this.labelSysSecurity.Name = "labelSysSecurity";
            this.labelSysSecurity.Size = new System.Drawing.Size(108, 20);
            this.labelSysSecurity.TabIndex = 63;
            this.labelSysSecurity.Text = "Sys Security";
            // 
            // labelDPS
            // 
            this.labelDPS.AutoSize = true;
            this.labelDPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDPS.Location = new System.Drawing.Point(798, 224);
            this.labelDPS.Name = "labelDPS";
            this.labelDPS.Size = new System.Drawing.Size(45, 20);
            this.labelDPS.TabIndex = 64;
            this.labelDPS.Text = "DPS";
            // 
            // labelRoF
            // 
            this.labelRoF.AutoSize = true;
            this.labelRoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRoF.Location = new System.Drawing.Point(889, 224);
            this.labelRoF.Name = "labelRoF";
            this.labelRoF.Size = new System.Drawing.Size(43, 20);
            this.labelRoF.TabIndex = 65;
            this.labelRoF.Text = "RoF";
            // 
            // labelSTK
            // 
            this.labelSTK.AutoSize = true;
            this.labelSTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSTK.Location = new System.Drawing.Point(636, 224);
            this.labelSTK.Name = "labelSTK";
            this.labelSTK.Size = new System.Drawing.Size(103, 20);
            this.labelSTK.TabIndex = 66;
            this.labelSTK.Text = "Ships to Kill";
            // 
            // m_textBox_DPS_Mjolnir
            // 
            this.m_textBox_DPS_Mjolnir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Mjolnir.Location = new System.Drawing.Point(785, 260);
            this.m_textBox_DPS_Mjolnir.Multiline = false;
            this.m_textBox_DPS_Mjolnir.Name = "m_textBox_DPS_Mjolnir";
            this.m_textBox_DPS_Mjolnir.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Mjolnir.TabIndex = 67;
            this.m_textBox_DPS_Mjolnir.Text = "";
            this.m_textBox_DPS_Mjolnir.TextChanged += new System.EventHandler(this.m_textBox_DPS_Mjolnir_ValueChanged);
            // 
            // m_textBox_RoF_Mjolnir
            // 
            this.m_textBox_RoF_Mjolnir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Mjolnir.Location = new System.Drawing.Point(878, 260);
            this.m_textBox_RoF_Mjolnir.Multiline = false;
            this.m_textBox_RoF_Mjolnir.Name = "m_textBox_RoF_Mjolnir";
            this.m_textBox_RoF_Mjolnir.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Mjolnir.TabIndex = 68;
            this.m_textBox_RoF_Mjolnir.Text = "";
            this.m_textBox_RoF_Mjolnir.TextChanged += new System.EventHandler(this.m_textBox_RoF_Mjolnir_ValueChanged);
            // 
            // m_textBox_DPS_Nova
            // 
            this.m_textBox_DPS_Nova.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Nova.Location = new System.Drawing.Point(785, 292);
            this.m_textBox_DPS_Nova.Multiline = false;
            this.m_textBox_DPS_Nova.Name = "m_textBox_DPS_Nova";
            this.m_textBox_DPS_Nova.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Nova.TabIndex = 69;
            this.m_textBox_DPS_Nova.Text = "";
            this.m_textBox_DPS_Nova.TextChanged += new System.EventHandler(this.m_textBox_DPS_Nova_ValueChanged);
            // 
            // m_textBox_DPS_Antimatter
            // 
            this.m_textBox_DPS_Antimatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Antimatter.Location = new System.Drawing.Point(785, 332);
            this.m_textBox_DPS_Antimatter.Multiline = false;
            this.m_textBox_DPS_Antimatter.Name = "m_textBox_DPS_Antimatter";
            this.m_textBox_DPS_Antimatter.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Antimatter.TabIndex = 70;
            this.m_textBox_DPS_Antimatter.Text = "";
            this.m_textBox_DPS_Antimatter.TextChanged += new System.EventHandler(this.m_textBox_DPS_Antimatter_ValueChanged);
            // 
            // m_textBox_DPS_Void
            // 
            this.m_textBox_DPS_Void.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Void.Location = new System.Drawing.Point(785, 364);
            this.m_textBox_DPS_Void.Multiline = false;
            this.m_textBox_DPS_Void.Name = "m_textBox_DPS_Void";
            this.m_textBox_DPS_Void.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Void.TabIndex = 71;
            this.m_textBox_DPS_Void.Text = "";
            this.m_textBox_DPS_Void.TextChanged += new System.EventHandler(this.m_textBox_DPS_Void_ValueChanged);
            // 
            // m_textBox_DPS_Multifrequency
            // 
            this.m_textBox_DPS_Multifrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Multifrequency.Location = new System.Drawing.Point(785, 404);
            this.m_textBox_DPS_Multifrequency.Multiline = false;
            this.m_textBox_DPS_Multifrequency.Name = "m_textBox_DPS_Multifrequency";
            this.m_textBox_DPS_Multifrequency.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Multifrequency.TabIndex = 72;
            this.m_textBox_DPS_Multifrequency.Text = "";
            this.m_textBox_DPS_Multifrequency.TextChanged += new System.EventHandler(this.m_textBox_DPS_Multifrequency_ValueChanged);
            // 
            // m_textBox_DPS_EMP
            // 
            this.m_textBox_DPS_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_EMP.Location = new System.Drawing.Point(785, 444);
            this.m_textBox_DPS_EMP.Multiline = false;
            this.m_textBox_DPS_EMP.Name = "m_textBox_DPS_EMP";
            this.m_textBox_DPS_EMP.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_EMP.TabIndex = 73;
            this.m_textBox_DPS_EMP.Text = "";
            this.m_textBox_DPS_EMP.TextChanged += new System.EventHandler(this.m_textBox_DPS_EMP_ValueChanged);
            // 
            // m_textBox_DPS_Fusion
            // 
            this.m_textBox_DPS_Fusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Fusion.Location = new System.Drawing.Point(785, 476);
            this.m_textBox_DPS_Fusion.Multiline = false;
            this.m_textBox_DPS_Fusion.Name = "m_textBox_DPS_Fusion";
            this.m_textBox_DPS_Fusion.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Fusion.TabIndex = 74;
            this.m_textBox_DPS_Fusion.Text = "";
            this.m_textBox_DPS_Fusion.TextChanged += new System.EventHandler(this.m_textBox_DPS_Fusion_ValueChanged);
            // 
            // m_textBox_DPS_Phased_Plasma
            // 
            this.m_textBox_DPS_Phased_Plasma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Phased_Plasma.Location = new System.Drawing.Point(785, 508);
            this.m_textBox_DPS_Phased_Plasma.Multiline = false;
            this.m_textBox_DPS_Phased_Plasma.Name = "m_textBox_DPS_Phased_Plasma";
            this.m_textBox_DPS_Phased_Plasma.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Phased_Plasma.TabIndex = 75;
            this.m_textBox_DPS_Phased_Plasma.Text = "";
            this.m_textBox_DPS_Phased_Plasma.TextChanged += new System.EventHandler(this.m_textBox_DPS_Phased_Plasma_ValueChanged);
            // 
            // m_textBox_DPS_Hail
            // 
            this.m_textBox_DPS_Hail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_Hail.Location = new System.Drawing.Point(785, 540);
            this.m_textBox_DPS_Hail.Multiline = false;
            this.m_textBox_DPS_Hail.Name = "m_textBox_DPS_Hail";
            this.m_textBox_DPS_Hail.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_Hail.TabIndex = 76;
            this.m_textBox_DPS_Hail.Text = "";
            this.m_textBox_DPS_Hail.TextChanged += new System.EventHandler(this.m_textBox_DPS_Hail_ValueChanged);
            // 
            // m_textBox_RoF_Nova
            // 
            this.m_textBox_RoF_Nova.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Nova.Location = new System.Drawing.Point(878, 292);
            this.m_textBox_RoF_Nova.Multiline = false;
            this.m_textBox_RoF_Nova.Name = "m_textBox_RoF_Nova";
            this.m_textBox_RoF_Nova.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Nova.TabIndex = 77;
            this.m_textBox_RoF_Nova.Text = "";
            this.m_textBox_RoF_Nova.TextChanged += new System.EventHandler(this.m_textBox_RoF_Nova_ValueChanged);
            // 
            // m_textBox_RoF_Antimatter
            // 
            this.m_textBox_RoF_Antimatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Antimatter.Location = new System.Drawing.Point(878, 332);
            this.m_textBox_RoF_Antimatter.Multiline = false;
            this.m_textBox_RoF_Antimatter.Name = "m_textBox_RoF_Antimatter";
            this.m_textBox_RoF_Antimatter.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Antimatter.TabIndex = 78;
            this.m_textBox_RoF_Antimatter.Text = "";
            this.m_textBox_RoF_Antimatter.TextChanged += new System.EventHandler(this.m_textBox_RoF_Antimatter_ValueChanged);
            // 
            // m_textBox_RoF_Void
            // 
            this.m_textBox_RoF_Void.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Void.Location = new System.Drawing.Point(878, 364);
            this.m_textBox_RoF_Void.Multiline = false;
            this.m_textBox_RoF_Void.Name = "m_textBox_RoF_Void";
            this.m_textBox_RoF_Void.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Void.TabIndex = 79;
            this.m_textBox_RoF_Void.Text = "";
            this.m_textBox_RoF_Void.TextChanged += new System.EventHandler(this.m_textBox_RoF_Void_ValueChanged);
            // 
            // m_textBox_RoF_Multifrequency
            // 
            this.m_textBox_RoF_Multifrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Multifrequency.Location = new System.Drawing.Point(878, 404);
            this.m_textBox_RoF_Multifrequency.Multiline = false;
            this.m_textBox_RoF_Multifrequency.Name = "m_textBox_RoF_Multifrequency";
            this.m_textBox_RoF_Multifrequency.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Multifrequency.TabIndex = 80;
            this.m_textBox_RoF_Multifrequency.Text = "";
            this.m_textBox_RoF_Multifrequency.TextChanged += new System.EventHandler(this.m_textBox_RoF_Multifrequency_ValueChanged);
            // 
            // m_textBox_RoF_EMP
            // 
            this.m_textBox_RoF_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_EMP.Location = new System.Drawing.Point(878, 444);
            this.m_textBox_RoF_EMP.Multiline = false;
            this.m_textBox_RoF_EMP.Name = "m_textBox_RoF_EMP";
            this.m_textBox_RoF_EMP.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_EMP.TabIndex = 81;
            this.m_textBox_RoF_EMP.Text = "";
            this.m_textBox_RoF_EMP.TextChanged += new System.EventHandler(this.m_textBox_RoF_EMP_ValueChanged);
            // 
            // m_textBox_RoF_Fusion
            // 
            this.m_textBox_RoF_Fusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Fusion.Location = new System.Drawing.Point(878, 476);
            this.m_textBox_RoF_Fusion.Multiline = false;
            this.m_textBox_RoF_Fusion.Name = "m_textBox_RoF_Fusion";
            this.m_textBox_RoF_Fusion.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Fusion.TabIndex = 82;
            this.m_textBox_RoF_Fusion.Text = "";
            this.m_textBox_RoF_Fusion.TextChanged += new System.EventHandler(this.m_textBox_RoF_Fusion_ValueChanged);
            // 
            // m_textBox_RoF_Phased_Plasma
            // 
            this.m_textBox_RoF_Phased_Plasma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Phased_Plasma.Location = new System.Drawing.Point(878, 508);
            this.m_textBox_RoF_Phased_Plasma.Multiline = false;
            this.m_textBox_RoF_Phased_Plasma.Name = "m_textBox_RoF_Phased_Plasma";
            this.m_textBox_RoF_Phased_Plasma.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Phased_Plasma.TabIndex = 83;
            this.m_textBox_RoF_Phased_Plasma.Text = "";
            this.m_textBox_RoF_Phased_Plasma.TextChanged += new System.EventHandler(this.m_textBox_RoF_Phased_Plasma_ValueChanged);
            // 
            // m_textBox_RoF_Hail
            // 
            this.m_textBox_RoF_Hail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_Hail.Location = new System.Drawing.Point(878, 540);
            this.m_textBox_RoF_Hail.Multiline = false;
            this.m_textBox_RoF_Hail.Name = "m_textBox_RoF_Hail";
            this.m_textBox_RoF_Hail.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_Hail.TabIndex = 84;
            this.m_textBox_RoF_Hail.Text = "";
            this.m_textBox_RoF_Hail.TextChanged += new System.EventHandler(this.m_textBox_RoF_Hail_ValueChanged);
            // 
            // m_radioPassive
            // 
            this.m_radioPassive.AutoSize = true;
            this.m_radioPassive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_radioPassive.Location = new System.Drawing.Point(365, 635);
            this.m_radioPassive.Margin = new System.Windows.Forms.Padding(2);
            this.m_radioPassive.Name = "m_radioPassive";
            this.m_radioPassive.Size = new System.Drawing.Size(88, 24);
            this.m_radioPassive.TabIndex = 85;
            this.m_radioPassive.Text = "Passive";
            this.m_radioPassive.UseVisualStyleBackColor = true;
            this.m_radioPassive.CheckedChanged += new System.EventHandler(this.m_radioPassive_CheckedChanged);
            // 
            // m_radioCold
            // 
            this.m_radioCold.AutoSize = true;
            this.m_radioCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_radioCold.Location = new System.Drawing.Point(453, 635);
            this.m_radioCold.Margin = new System.Windows.Forms.Padding(2);
            this.m_radioCold.Name = "m_radioCold";
            this.m_radioCold.Size = new System.Drawing.Size(63, 24);
            this.m_radioCold.TabIndex = 86;
            this.m_radioCold.Text = "Cold";
            this.m_radioCold.UseVisualStyleBackColor = true;
            this.m_radioCold.CheckedChanged += new System.EventHandler(this.m_radioPassive_CheckedChanged);
            // 
            // m_radioHot
            // 
            this.m_radioHot.AutoSize = true;
            this.m_radioHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_radioHot.Location = new System.Drawing.Point(518, 635);
            this.m_radioHot.Margin = new System.Windows.Forms.Padding(2);
            this.m_radioHot.Name = "m_radioHot";
            this.m_radioHot.Size = new System.Drawing.Size(56, 24);
            this.m_radioHot.TabIndex = 87;
            this.m_radioHot.Text = "Hot";
            this.m_radioHot.UseVisualStyleBackColor = true;
            this.m_radioHot.CheckedChanged += new System.EventHandler(this.m_radioPassive_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(350, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 114);
            this.panel1.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Location = new System.Drawing.Point(350, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 133);
            this.panel2.TabIndex = 91;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Location = new System.Drawing.Point(350, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 77);
            this.panel3.TabIndex = 91;
            // 
            // m_textBox_RoF_VoidL
            // 
            this.m_textBox_RoF_VoidL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_RoF_VoidL.Location = new System.Drawing.Point(878, 584);
            this.m_textBox_RoF_VoidL.Multiline = false;
            this.m_textBox_RoF_VoidL.Name = "m_textBox_RoF_VoidL";
            this.m_textBox_RoF_VoidL.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_RoF_VoidL.TabIndex = 96;
            this.m_textBox_RoF_VoidL.Text = "";
            this.m_textBox_RoF_VoidL.TextChanged += new System.EventHandler(this.m_textBox_RoF_VoidL_ValueChanged);
            // 
            // m_textBox_DPS_VoidL
            // 
            this.m_textBox_DPS_VoidL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox_DPS_VoidL.Location = new System.Drawing.Point(785, 584);
            this.m_textBox_DPS_VoidL.Multiline = false;
            this.m_textBox_DPS_VoidL.Name = "m_textBox_DPS_VoidL";
            this.m_textBox_DPS_VoidL.Size = new System.Drawing.Size(77, 24);
            this.m_textBox_DPS_VoidL.TabIndex = 95;
            this.m_textBox_DPS_VoidL.Text = "";
            this.m_textBox_DPS_VoidL.TextChanged += new System.EventHandler(this.m_textBox_DPS_VoidL_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(360, 586);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 20);
            this.label19.TabIndex = 94;
            this.label19.Text = "Void L";
            this.toolTip1.SetToolTip(this.label19, "Talos (no drones)");
            // 
            // m_TextBoxEHPVoidLHot
            // 
            this.m_TextBoxEHPVoidLHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPVoidLHot.Location = new System.Drawing.Point(768, 584);
            this.m_TextBoxEHPVoidLHot.Multiline = false;
            this.m_TextBoxEHPVoidLHot.Name = "m_TextBoxEHPVoidLHot";
            this.m_TextBoxEHPVoidLHot.ReadOnly = true;
            this.m_TextBoxEHPVoidLHot.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPVoidLHot.TabIndex = 93;
            this.m_TextBoxEHPVoidLHot.Text = "";
            // 
            // m_TextBoxEHPVoidLCold
            // 
            this.m_TextBoxEHPVoidLCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_TextBoxEHPVoidLCold.Location = new System.Drawing.Point(528, 584);
            this.m_TextBoxEHPVoidLCold.Multiline = false;
            this.m_TextBoxEHPVoidLCold.Name = "m_TextBoxEHPVoidLCold";
            this.m_TextBoxEHPVoidLCold.ReadOnly = true;
            this.m_TextBoxEHPVoidLCold.Size = new System.Drawing.Size(120, 24);
            this.m_TextBoxEHPVoidLCold.TabIndex = 92;
            this.m_TextBoxEHPVoidLCold.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.Location = new System.Drawing.Point(350, 570);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(618, 54);
            this.panel4.TabIndex = 91;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSeconds.Location = new System.Drawing.Point(798, 685);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(79, 20);
            this.labelSeconds.TabIndex = 97;
            this.labelSeconds.Text = "Seconds";
            // 
            // labelBR
            // 
            this.labelBR.AutoSize = true;
            this.labelBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelBR.Location = new System.Drawing.Point(13, 640);
            this.labelBR.Name = "labelBR";
            this.labelBR.Size = new System.Drawing.Size(29, 16);
            this.labelBR.TabIndex = 98;
            this.labelBR.Text = "BR";
            this.labelBR.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(475, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 29);
            this.button1.TabIndex = 99;
            this.button1.Text = "3 Exp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(559, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 29);
            this.button2.TabIndex = 100;
            this.button2.Text = "3 Bulk";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // m_checkBoxManualEHP
            // 
            this.m_checkBoxManualEHP.AutoSize = true;
            this.m_checkBoxManualEHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_checkBoxManualEHP.Location = new System.Drawing.Point(350, 222);
            this.m_checkBoxManualEHP.Name = "m_checkBoxManualEHP";
            this.m_checkBoxManualEHP.Size = new System.Drawing.Size(127, 24);
            this.m_checkBoxManualEHP.TabIndex = 101;
            this.m_checkBoxManualEHP.Text = "Manual EHP";
            this.m_checkBoxManualEHP.UseVisualStyleBackColor = true;
            this.m_checkBoxManualEHP.CheckedChanged += new System.EventHandler(this.m_checkBoxManualEHP_CheckedChanged);
            // 
            // m_richTextBoxManualEHP
            // 
            this.m_richTextBoxManualEHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_richTextBoxManualEHP.Location = new System.Drawing.Point(472, 221);
            this.m_richTextBoxManualEHP.Multiline = false;
            this.m_richTextBoxManualEHP.Name = "m_richTextBoxManualEHP";
            this.m_richTextBoxManualEHP.Size = new System.Drawing.Size(120, 24);
            this.m_richTextBoxManualEHP.TabIndex = 102;
            this.m_richTextBoxManualEHP.Text = "";
            this.m_richTextBoxManualEHP.SelectionAlignment = HorizontalAlignment.Right;
            this.m_richTextBoxManualEHP.TextChanged += new System.EventHandler(this.m_richTextBoxManualEHP_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(968, 772);
            this.Controls.Add(this.m_richTextBoxManualEHP);
            this.Controls.Add(this.m_checkBoxManualEHP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelBR);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.m_textBox_RoF_VoidL);
            this.Controls.Add(this.m_textBox_DPS_VoidL);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.m_TextBoxEHPVoidLHot);
            this.Controls.Add(this.m_TextBoxEHPVoidLCold);
            this.Controls.Add(this.m_checkBoxSTK);
            this.Controls.Add(this.m_radioHot);
            this.Controls.Add(this.m_radioCold);
            this.Controls.Add(this.m_radioPassive);
            this.Controls.Add(this.m_textBox_RoF_Hail);
            this.Controls.Add(this.m_textBox_RoF_Phased_Plasma);
            this.Controls.Add(this.m_textBox_RoF_Fusion);
            this.Controls.Add(this.m_textBox_RoF_EMP);
            this.Controls.Add(this.m_textBox_RoF_Multifrequency);
            this.Controls.Add(this.m_textBox_RoF_Void);
            this.Controls.Add(this.m_textBox_RoF_Antimatter);
            this.Controls.Add(this.m_textBox_RoF_Nova);
            this.Controls.Add(this.m_textBox_DPS_Hail);
            this.Controls.Add(this.m_textBox_DPS_Phased_Plasma);
            this.Controls.Add(this.m_textBox_DPS_Fusion);
            this.Controls.Add(this.m_textBox_DPS_EMP);
            this.Controls.Add(this.m_textBox_DPS_Multifrequency);
            this.Controls.Add(this.m_textBox_DPS_Void);
            this.Controls.Add(this.m_textBox_DPS_Antimatter);
            this.Controls.Add(this.m_textBox_DPS_Nova);
            this.Controls.Add(this.m_textBox_RoF_Mjolnir);
            this.Controls.Add(this.m_textBox_DPS_Mjolnir);
            this.Controls.Add(this.labelSTK);
            this.Controls.Add(this.labelRoF);
            this.Controls.Add(this.labelDPS);
            this.Controls.Add(this.labelSysSecurity);
            this.Controls.Add(this.m_comboBoxSysSecurity);
            this.Controls.Add(this.m_History);
            this.Controls.Add(this.m_checkBoxADCActive);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_ValueCanDropText);
            this.Controls.Add(this.m_ValueTotalText);
            this.Controls.Add(this.m_ValueFittingsText);
            this.Controls.Add(this.m_ValueHullText);
            this.Controls.Add(this.m_checkBoxPassive);
            this.Controls.Add(this.m_FitText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_TextBoxEHPHailHot);
            this.Controls.Add(this.m_TextBoxEHPHailCold);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_TextBoxEHPPhasedPlasmaHot);
            this.Controls.Add(this.m_TextBoxEHPPhasedPlasmaCold);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_TextBoxEHPFusionHot);
            this.Controls.Add(this.m_TextBoxEHPFusionCold);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_TextBoxEHPEMPHot);
            this.Controls.Add(this.m_TextBoxEHPEMPCold);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_TextBoxEHPMultifreqHot);
            this.Controls.Add(this.m_TextBoxEHPMultifreqCold);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_TextBoxEHPVoidHot);
            this.Controls.Add(this.m_TextBoxEHPVoidCold);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_TextBoxEHPAntimatterHot);
            this.Controls.Add(this.m_TextBoxEHPAntimatterCold);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_TextBoxEHPNovaHot);
            this.Controls.Add(this.m_TextBoxEHPNovaCold);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_TextBoxEHPMjolnirHot);
            this.Controls.Add(this.m_TextBoxEHPMjolnirCold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_TextBoxHullResistsHot);
            this.Controls.Add(this.m_TextBoxHullResistsCold);
            this.Controls.Add(this.m_TextBoxArmorResistsHot);
            this.Controls.Add(this.m_TextBoxArmorResistsCold);
            this.Controls.Add(this.m_TextBoxShieldResistsHot);
            this.Controls.Add(this.m_TextBoxShieldResistsCold);
            this.Controls.Add(this.m_TextBoxHullHP);
            this.Controls.Add(this.m_TextBoxArmorHP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_TextBoxShieldHP);
            this.Controls.Add(this.m_ButtonCopyEFT);
            this.Controls.Add(this.m_ButtonCopyCODE);
            this.Controls.Add(this.m_ComboBoxShipType);
            this.Controls.Add(this.m_ButtonResetFit);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(984, 580);
            this.Name = "Form1";
            this.Text = "Miniluv fit scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.Button m_ButtonResetFit;
        private System.Windows.Forms.ComboBox m_ComboBoxShipType;
        private System.Windows.Forms.Button m_ButtonCopyCODE;
        private System.Windows.Forms.Button m_ButtonCopyEFT;
        private System.Windows.Forms.RichTextBox m_TextBoxShieldHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox m_TextBoxArmorHP;
        private System.Windows.Forms.RichTextBox m_TextBoxHullHP;
        private System.Windows.Forms.RichTextBox m_TextBoxShieldResistsCold;
        private System.Windows.Forms.RichTextBox m_TextBoxShieldResistsHot;
        private System.Windows.Forms.RichTextBox m_TextBoxArmorResistsCold;
        private System.Windows.Forms.RichTextBox m_TextBoxArmorResistsHot;
        private System.Windows.Forms.RichTextBox m_TextBoxHullResistsCold;
        private System.Windows.Forms.RichTextBox m_TextBoxHullResistsHot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPMjolnirCold;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPMjolnirHot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPNovaHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPNovaCold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPAntimatterHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPAntimatterCold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPVoidHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPVoidCold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPMultifreqHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPMultifreqCold;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPEMPHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPEMPCold;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPFusionHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPFusionCold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPPhasedPlasmaHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPPhasedPlasmaCold;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPHailHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPHailCold;
        private System.Windows.Forms.RichTextBox m_FitText;
        private System.Windows.Forms.CheckBox m_checkBoxPassive;
        private System.ComponentModel.BackgroundWorker m_BackgroundWorkerPrices;
        private System.Windows.Forms.RichTextBox m_ValueHullText;
        private System.Windows.Forms.RichTextBox m_ValueFittingsText;
        private System.Windows.Forms.RichTextBox m_ValueTotalText;
        private System.Windows.Forms.RichTextBox m_ValueCanDropText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.ComponentModel.BackgroundWorker m_BackgroundWorkerUpdate;
        private System.Windows.Forms.CheckBox m_checkBoxADCActive;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox m_History;
        private System.Windows.Forms.CheckBox m_checkBoxSTK;
        private System.Windows.Forms.ComboBox m_comboBoxSysSecurity;
        private System.Windows.Forms.Label labelSysSecurity;
        private System.Windows.Forms.Label labelDPS;
        private System.Windows.Forms.Label labelRoF;
        private System.Windows.Forms.Label labelSTK;
        private System.Windows.Forms.ToolStripMenuItem resetDPSRoFToolStripMenuItem;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Mjolnir;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Mjolnir;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Nova;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Antimatter;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Void;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Multifrequency;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_EMP;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Fusion;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Phased_Plasma;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_Hail;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Nova;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Antimatter;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Void;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Multifrequency;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_EMP;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Fusion;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Phased_Plasma;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_Hail;
        private System.Windows.Forms.RadioButton m_radioPassive;
        private System.Windows.Forms.RadioButton m_radioCold;
        private System.Windows.Forms.RadioButton m_radioHot;
        private System.Windows.Forms.ToolStripMenuItem resetDPSRoFcanFlyThenAll4ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox m_textBox_RoF_VoidL;
        private System.Windows.Forms.RichTextBox m_textBox_DPS_VoidL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPVoidLHot;
        private System.Windows.Forms.RichTextBox m_TextBoxEHPVoidLCold;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelBR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox m_checkBoxManualEHP;
        private System.Windows.Forms.RichTextBox m_richTextBoxManualEHP;
    }
}

