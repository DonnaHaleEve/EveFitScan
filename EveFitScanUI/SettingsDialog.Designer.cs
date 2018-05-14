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
            this.m_Highlight = new System.Windows.Forms.CheckBox();
            this.m_ActivateOnFitUpdate = new System.Windows.Forms.CheckBox();
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
            this.m_AlwaysOnTop.Location = new System.Drawing.Point(32, 32);
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
            this.m_GetPrices.Location = new System.Drawing.Point(32, 72);
            this.m_GetPrices.Name = "m_GetPrices";
            this.m_GetPrices.Size = new System.Drawing.Size(74, 17);
            this.m_GetPrices.TabIndex = 2;
            this.m_GetPrices.Text = "Get prices";
            this.m_GetPrices.UseVisualStyleBackColor = true;
            this.m_GetPrices.CheckedChanged += new System.EventHandler(this.m_GetPrices_CheckedChanged);
            // 
            // m_Highlight
            // 
            this.m_Highlight.AutoSize = true;
            this.m_Highlight.Checked = true;
            this.m_Highlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_Highlight.Location = new System.Drawing.Point(32, 112);
            this.m_Highlight.Name = "m_Highlight";
            this.m_Highlight.Size = new System.Drawing.Size(126, 17);
            this.m_Highlight.TabIndex = 4;
            this.m_Highlight.Text = "Highlight full tank / fit";
            this.m_Highlight.UseVisualStyleBackColor = true;
            this.m_Highlight.CheckedChanged += new System.EventHandler(this.m_Highlight_CheckedChanged);
            // 
            // m_ActivateOnFitUpdate
            // 
            this.m_ActivateOnFitUpdate.AutoSize = true;
            this.m_ActivateOnFitUpdate.Checked = true;
            this.m_ActivateOnFitUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ActivateOnFitUpdate.Location = new System.Drawing.Point(32, 152);
            this.m_ActivateOnFitUpdate.Name = "m_ActivateOnFitUpdate";
            this.m_ActivateOnFitUpdate.Size = new System.Drawing.Size(166, 17);
            this.m_ActivateOnFitUpdate.TabIndex = 5;
            this.m_ActivateOnFitUpdate.Text = "Activate window on fit update";
            this.m_ActivateOnFitUpdate.UseVisualStyleBackColor = true;
            this.m_ActivateOnFitUpdate.CheckedChanged += new System.EventHandler(this.m_ActivateOnFitUpdate_CheckedChanged);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.m_ActivateOnFitUpdate);
            this.Controls.Add(this.m_Highlight);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonOk;
        private System.Windows.Forms.CheckBox m_AlwaysOnTop;
        private System.Windows.Forms.CheckBox m_GetPrices;
        private System.Windows.Forms.CheckBox m_Highlight;
        private System.Windows.Forms.CheckBox m_ActivateOnFitUpdate;
    }
}