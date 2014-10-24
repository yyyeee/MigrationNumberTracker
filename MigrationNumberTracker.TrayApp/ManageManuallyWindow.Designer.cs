namespace MigrationNumberTracker.TrayApp
{
    partial class ManageManuallyWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageManuallyWindow));
            this.grbxMigrations = new System.Windows.Forms.GroupBox();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grbxMigrations
            // 
            this.grbxMigrations.Location = new System.Drawing.Point(12, 39);
            this.grbxMigrations.Name = "grbxMigrations";
            this.grbxMigrations.Size = new System.Drawing.Size(363, 239);
            this.grbxMigrations.TabIndex = 0;
            this.grbxMigrations.TabStop = false;
            this.grbxMigrations.Text = "Update LAST USED migration numbers";
            // 
            // cbBranches
            // 
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(70, 12);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(305, 21);
            this.cbBranches.TabIndex = 6;
            this.cbBranches.SelectedIndexChanged += new System.EventHandler(this.BranchesSelectedIndexChanged);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(12, 12);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(44, 13);
            this.lblBranch.TabIndex = 5;
            this.lblBranch.Text = "Branch:";
            // 
            // ManageManuallyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 289);
            this.Controls.Add(this.cbBranches);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.grbxMigrations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageManuallyWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage manually";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.ManageManuallyWindowActivated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxMigrations;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.Label lblBranch;
    }
}