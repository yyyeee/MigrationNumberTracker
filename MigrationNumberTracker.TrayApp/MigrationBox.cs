using System;
using System.Drawing;
using System.Windows.Forms;
using MigrationNumberTracker.Client;
using MigrationNumberTracker.Common;
using MigrationNumberTracker.TrayApp.Properties;

namespace MigrationNumberTracker.TrayApp
{
    public partial class MigrationBox : UserControl
    {
        private readonly MainIcon _icon;
        private readonly MigrationNumberTrackerClient _client;
        private readonly MigrationType _type;
        private string _branch;
        private Timer _timer;
        public MigrationBox(MainIcon icon, MigrationNumberTrackerClient client, MigrationType type, string branch)
        {
            _icon = icon;
            _client = client;
            _type = type;
            InitializeComponent();
            lblMigrationType.Text = type + ":";
            Branch = branch;
            RefreshData();
            _timer = new Timer {Interval = 3000};
            _timer.Tick += TimerTick;
        }

        public string Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }

        public void RefreshData()
        {
            try
            {
                nudMigrationNumber.Value = _client.ReadMigrationNumber(Branch, _type);
            }
            catch (Exception e)
            {
                _icon.HandleException(e);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            pbStatus.Image = null;
        }

        private void SendClick(object sender, EventArgs e)
        {
            Send();
        }

        private void Send()
        {
            try
            {
                _client.UpdateMigrationNumber(Branch, _type, (long)nudMigrationNumber.Value);
                pbStatus.Image = Resources.Success;
            }
            catch (Exception e)
            {
                pbStatus.Image = Resources.Failure;
                _icon.HandleException(e);
            }

            Settings.Default.LastResrevedMigration = null;
            Settings.Default.Save();
            _icon.DisableUndo();

            _timer.Start();
        }
    }
}
