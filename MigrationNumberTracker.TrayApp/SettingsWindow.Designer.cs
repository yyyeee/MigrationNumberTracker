namespace MigrationNumberTracker.TrayApp
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.grbxGeneral = new System.Windows.Forms.GroupBox();
            this.btnBrowseSolutionDir = new System.Windows.Forms.Button();
            this.lblSolutionDir = new System.Windows.Forms.Label();
            this.txtSolutionDir = new System.Windows.Forms.TextBox();
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.solutionDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grbxGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxGeneral
            // 
            this.grbxGeneral.Controls.Add(this.btnBrowseSolutionDir);
            this.grbxGeneral.Controls.Add(this.lblSolutionDir);
            this.grbxGeneral.Controls.Add(this.txtSolutionDir);
            this.grbxGeneral.Controls.Add(this.lblServerUrl);
            this.grbxGeneral.Controls.Add(this.txtServerUrl);
            this.grbxGeneral.Location = new System.Drawing.Point(12, 12);
            this.grbxGeneral.Name = "grbxGeneral";
            this.grbxGeneral.Size = new System.Drawing.Size(384, 73);
            this.grbxGeneral.TabIndex = 1;
            this.grbxGeneral.TabStop = false;
            this.grbxGeneral.Text = "General (required)";
            // 
            // btnBrowseSolutionDir
            // 
            this.btnBrowseSolutionDir.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseSolutionDir.Image")));
            this.btnBrowseSolutionDir.Location = new System.Drawing.Point(339, 46);
            this.btnBrowseSolutionDir.Name = "btnBrowseSolutionDir";
            this.btnBrowseSolutionDir.Size = new System.Drawing.Size(39, 22);
            this.btnBrowseSolutionDir.TabIndex = 4;
            this.btnBrowseSolutionDir.UseVisualStyleBackColor = true;
            this.btnBrowseSolutionDir.Click += new System.EventHandler(this.BrowseSolutionDirClick);
            // 
            // lblSolutionDir
            // 
            this.lblSolutionDir.AutoSize = true;
            this.lblSolutionDir.Location = new System.Drawing.Point(6, 50);
            this.lblSolutionDir.Name = "lblSolutionDir";
            this.lblSolutionDir.Size = new System.Drawing.Size(64, 13);
            this.lblSolutionDir.TabIndex = 3;
            this.lblSolutionDir.Text = "Solution Dir:";
            // 
            // txtSolutionDir
            // 
            this.txtSolutionDir.Location = new System.Drawing.Point(76, 47);
            this.txtSolutionDir.Name = "txtSolutionDir";
            this.txtSolutionDir.Size = new System.Drawing.Size(263, 20);
            this.txtSolutionDir.TabIndex = 2;
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(6, 24);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(57, 13);
            this.lblServerUrl.TabIndex = 1;
            this.lblServerUrl.Text = "Server Url:";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(76, 21);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(302, 20);
            this.txtServerUrl.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(240, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 121);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbxGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.grbxGeneral.ResumeLayout(false);
            this.grbxGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxGeneral;
        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSolutionDir;
        private System.Windows.Forms.TextBox txtSolutionDir;
        private System.Windows.Forms.FolderBrowserDialog solutionDirDialog;
        private System.Windows.Forms.Button btnBrowseSolutionDir;
    }
}