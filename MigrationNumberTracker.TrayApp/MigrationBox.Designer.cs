namespace MigrationNumberTracker.TrayApp
{
    partial class MigrationBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMigrationType = new System.Windows.Forms.Label();
            this.nudMigrationNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSend = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMigrationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMigrationType
            // 
            this.lblMigrationType.AutoSize = true;
            this.lblMigrationType.Location = new System.Drawing.Point(15, 13);
            this.lblMigrationType.Name = "lblMigrationType";
            this.lblMigrationType.Size = new System.Drawing.Size(87, 13);
            this.lblMigrationType.TabIndex = 0;
            this.lblMigrationType.Text = "lblMigrationType:";
            // 
            // nudMigrationNumber
            // 
            this.nudMigrationNumber.Location = new System.Drawing.Point(126, 11);
            this.nudMigrationNumber.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMigrationNumber.Name = "nudMigrationNumber";
            this.nudMigrationNumber.Size = new System.Drawing.Size(102, 20);
            this.nudMigrationNumber.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(234, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.SendClick);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(315, 3);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(32, 32);
            this.pbStatus.TabIndex = 3;
            this.pbStatus.TabStop = false;
            // 
            // MigrationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.nudMigrationNumber);
            this.Controls.Add(this.lblMigrationType);
            this.Name = "MigrationBox";
            this.Size = new System.Drawing.Size(351, 40);
            ((System.ComponentModel.ISupportInitialize)(this.nudMigrationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMigrationType;
        private System.Windows.Forms.NumericUpDown nudMigrationNumber;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.PictureBox pbStatus;
    }
}
