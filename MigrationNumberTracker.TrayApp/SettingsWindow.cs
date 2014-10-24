using System;
using System.Windows.Forms;
using MigrationNumberTracker.TrayApp.Properties;

namespace MigrationNumberTracker.TrayApp
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            txtServerUrl.Text = Settings.Default.ServerUrl;
            txtSolutionDir.Text = Settings.Default.SolutionDir;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            Settings.Default.ServerUrl = txtServerUrl.Text;
            Settings.Default.SolutionDir = txtSolutionDir.Text;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BrowseSolutionDirClick(object sender, EventArgs e)
        {
            var result = solutionDirDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSolutionDir.Text = solutionDirDialog.SelectedPath;
            }
        }
    }
}
