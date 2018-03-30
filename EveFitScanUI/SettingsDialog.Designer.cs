namespace EveFitScanUI
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.m_ButtonOk = new System.Windows.Forms.Button();
            this.m_AlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.m_GetPrices = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_HighlightNothing = new System.Windows.Forms.RadioButton();
            this.m_HighlightFullTank = new System.Windows.Forms.RadioButton();
            this.m_HighlightFullFit = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ButtonOk
            // 
            this.m_ButtonOk.Location = new System.Drawing.Point(104, 224);
            this.m_ButtonOk.Name = "m_ButtonOk";
            this.m_ButtonOk.Size = new System.Drawing.Size(80, 23);
            this.m_ButtonOk.TabIndex = 0;
            this.m_ButtonOk.Text = "Ok";
            this.m_ButtonOk.UseVisualStyleBackColor = true;
            this.m_ButtonOk.Click += new System.EventHandler(this.m_ButtonOk_Click);
            // 
            // m_AlwaysOnTop
            // 
            this.m_AlwaysOnTop.AutoSize = true;
            this.m_AlwaysOnTop.Location = new System.Drawing.Point(32, 24);
            this.m_AlwaysOnTop.Name = "m_AlwaysOnTop";
            this.m_AlwaysOnTop.Size = new System.Drawing.Size(127, 17);
            this.m_AlwaysOnTop.TabIndex = 1;
            this.m_AlwaysOnTop.Text = "Toggle always on top";
            this.m_AlwaysOnTop.UseVisualStyleBackColor = true;
            this.m_AlwaysOnTop.CheckedChanged += new System.EventHandler(this.m_AlwaysOnTop_CheckedChanged);
            // 
            // m_GetPrices
            // 
            this.m_GetPrices.AutoSize = true;
            this.m_GetPrices.Checked = true;
            this.m_GetPrices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_GetPrices.Location = new System.Drawing.Point(32, 64);
            this.m_GetPrices.Name = "m_GetPrices";
            this.m_GetPrices.Size = new System.Drawing.Size(74, 17);
            this.m_GetPrices.TabIndex = 2;
            this.m_GetPrices.Text = "Get prices";
            this.m_GetPrices.UseVisualStyleBackColor = true;
            this.m_GetPrices.CheckedChanged += new System.EventHandler(this.m_GetPrices_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_HighlightFullFit);
            this.groupBox1.Controls.Add(this.m_HighlightFullTank);
            this.groupBox1.Controls.Add(this.m_HighlightNothing);
            this.groupBox1.Location = new System.Drawing.Point(16, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // m_HighlightNothing
            // 
            this.m_HighlightNothing.AutoSize = true;
            this.m_HighlightNothing.Location = new System.Drawing.Point(16, 24);
            this.m_HighlightNothing.Name = "m_HighlightNothing";
            this.m_HighlightNothing.Size = new System.Drawing.Size(104, 17);
            this.m_HighlightNothing.TabIndex = 0;
            this.m_HighlightNothing.Text = "Highlight nothing";
            this.m_HighlightNothing.UseVisualStyleBackColor = true;
            this.m_HighlightNothing.CheckedChanged += new System.EventHandler(this.m_HighlightNothing_CheckedChanged);
            // 
            // m_HighlightFullTank
            // 
            this.m_HighlightFullTank.AutoSize = true;
            this.m_HighlightFullTank.Checked = true;
            this.m_HighlightFullTank.Location = new System.Drawing.Point(16, 48);
            this.m_HighlightFullTank.Name = "m_HighlightFullTank";
            this.m_HighlightFullTank.Size = new System.Drawing.Size(106, 17);
            this.m_HighlightFullTank.TabIndex = 1;
            this.m_HighlightFullTank.TabStop = true;
            this.m_HighlightFullTank.Text = "Highlight full tank";
            this.m_HighlightFullTank.UseVisualStyleBackColor = true;
            this.m_HighlightFullTank.CheckedChanged += new System.EventHandler(this.m_HighlightFullTank_CheckedChanged);
            // 
            // m_HighlightFullFit
            // 
            this.m_HighlightFullFit.AutoSize = true;
            this.m_HighlightFullFit.Location = new System.Drawing.Point(16, 72);
            this.m_HighlightFullFit.Name = "m_HighlightFullFit";
            this.m_HighlightFullFit.Size = new System.Drawing.Size(93, 17);
            this.m_HighlightFullFit.TabIndex = 2;
            this.m_HighlightFullFit.Text = "Highlight full fit";
            this.m_HighlightFullFit.UseVisualStyleBackColor = true;
            this.m_HighlightFullFit.CheckedChanged += new System.EventHandler(this.m_HighlightFullFit_CheckedChanged);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_GetPrices);
            this.Controls.Add(this.m_AlwaysOnTop);
            this.Controls.Add(this.m_ButtonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonOk;
        private System.Windows.Forms.CheckBox m_AlwaysOnTop;
        private System.Windows.Forms.CheckBox m_GetPrices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_HighlightFullFit;
        private System.Windows.Forms.RadioButton m_HighlightFullTank;
        private System.Windows.Forms.RadioButton m_HighlightNothing;
    }
}