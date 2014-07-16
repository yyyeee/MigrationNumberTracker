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
            this.SuspendLayout();
            // 
            // grbxMigrations
            // 
            this.grbxMigrations.Location = new System.Drawing.Point(12, 12);
            this.grbxMigrations.Name = "grbxMigrations";
            this.grbxMigrations.Size = new System.Drawing.Size(363, 246);
            this.grbxMigrations.TabIndex = 0;
            this.grbxMigrations.TabStop = false;
            this.grbxMigrations.Text = "Update LAST USED migration numbers";
            // 
            // ManageManuallyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 270);
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

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxMigrations;
    }
}