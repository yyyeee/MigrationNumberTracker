using System;
using System.Linq;
using System.Windows.Forms;
using MigrationNumberTracker.Client;
using MigrationNumberTracker.Common;

namespace MigrationNumberTracker.TrayApp
{
    public partial class ManageManuallyWindow : Form
    {
        public ManageManuallyWindow(MigrationNumberTrackerClient client, MainIcon icon)
        {
            InitializeComponent();

            const int initialTop = 20;
            const int migrationBoxHeight = 40;
            const int initialLeft = 10;

            var migrationTypes =
                Enum.GetValues(typeof (MigrationType)).Cast<MigrationType>().Except(new[] {MigrationType.None}).ToList();

            for (int i = 0; i < migrationTypes.Count; ++i)
            {
                MigrationType migrationType = migrationTypes[i];
                grbxMigrations.Controls.Add(new MigrationBox(icon, client, migrationType)
                {
                    Top = initialTop + migrationBoxHeight * i,
                    Left = initialLeft,
                });
            }
        }

        private void ManageManuallyWindowActivated(object sender, EventArgs e)
        {
            foreach (MigrationBox migrationBox in grbxMigrations.Controls)
            {
                migrationBox.RefreshData();
            }
        }
    }
}