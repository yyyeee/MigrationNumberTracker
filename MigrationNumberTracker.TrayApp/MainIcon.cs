using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MigrationNumberTracker.Client;
using MigrationNumberTracker.Common;
using MigrationNumberTracker.GitIntegration;
using MigrationNumberTracker.Logging;
using MigrationNumberTracker.TrayApp.Properties;

namespace MigrationNumberTracker.TrayApp
{
    public class MainIcon : IDisposable
    {
        private readonly NotifyIcon _mainIcon;
        private readonly ContextMenuStrip _leftClickContextMenuStrip;
        private readonly ContextMenuStrip _rightClickContextMenuStrip;
        private readonly MigrationNumberTrackerClient _migrationNumberTrackerClient;
        private ToolStripMenuItem _undoToolStripMenuItem;
        private SettingsWindow _settingsWindow;
        private ManageManuallyWindow _manageManuallyWindow;
        private static readonly Log Log = new Log();
        public readonly BranchProvider _branchProvider;
        private ToolStripMenuItem _branchesMenuItem;

        public MainIcon()
        {
            _mainIcon = new NotifyIcon
            {
                Visible = true,
                Text = "ECB migration number tray utility",
                BalloonTipIcon = ToolTipIcon.Info,
                Icon = Resources.MainIcon,
            };
            _mainIcon.MouseClick += MainIconClick;

            if (string.IsNullOrWhiteSpace(Settings.Default.SolutionDir))
            {
                ShowSettings(this, new EventArgs());
            }

            _branchProvider = new BranchProvider
            {
                SolutionDir = Settings.Default.SolutionDir,
            };

            _migrationNumberTrackerClient = new MigrationNumberTrackerClient
            {
                Url = Settings.Default.ServerUrl,
            };

            _leftClickContextMenuStrip = GenerateLeftClickMenu();
            _rightClickContextMenuStrip = GenerateRightClickMenu();
        }

        private void MainIconClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _mainIcon.ContextMenuStrip = _leftClickContextMenuStrip;
                    _mainIcon.ShowContextMenuForced();
                    break;
                case MouseButtons.Right:
                    _mainIcon.ContextMenuStrip = _rightClickContextMenuStrip;
                    _mainIcon.ShowContextMenuForced();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _mainIcon.Dispose();
        }

        private ContextMenuStrip GenerateLeftClickMenu()
        {
            var menu = new ContextMenuStrip();

            menu.Items.Add(CreateMigrationItem("Reserve && copy for &host", MigrationType.Host));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(CreateMigrationItem("Reserve && copy for &client", MigrationType.Client));
            return menu;
        }

        private void ReserveMigrationNumber(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            ReserveMigrationNumber((MigrationType) item.Tag);
        }

        private void ReserveMigrationNumber(MigrationType type)
        {
            try
            {
                var migrationNumber = _migrationNumberTrackerClient.ReserveMigrationNumber(Settings.Default.CurrentBranch, type);
                var migrationTuple = new MigrationTuple
                    {
                        MigrationType = type,
                        Number = migrationNumber,
                    };

                Settings.Default.LastResrevedMigration = migrationTuple;

                Settings.Default.Save();
                Clipboard.SetText(migrationNumber.ToMigrationPrefix());

                EnableUndo(migrationTuple);

                _mainIcon.ShowBalloonTip(2000,
                    "Migration reserved successfully!",
                    string.Format("Migration {0} reserved and copied to clipboard.", migrationTuple),
                    ToolTipIcon.Info);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        public void HandleException(Exception e)
        {
            Log.Error(e);
            Clipboard.SetText(GetExceptionDetails(e));
            _mainIcon.ShowBalloonTip(60000, "Log updated", "Exception details also copied to clipboard", ToolTipIcon.Error);
        }

        private string GetExceptionDetails(Exception e)
        {
            var details = new StringBuilder();
            details.AppendLine(e.Message);
            details.AppendLine(e.StackTrace);

            if (e.InnerException != null)
            {
                details.AppendFormat("Inner exception: {0}", e.InnerException.Message);
                details.AppendLine(e.InnerException.StackTrace);
            }

            return details.ToString();
        }

        private ContextMenuStrip GenerateRightClickMenu()
        {
            var menu = new ContextMenuStrip();

            var currentBranch = Settings.Default.CurrentBranch;
            _branchesMenuItem = new ToolStripMenuItem(string.Format("[{0}]", currentBranch), Resources.Branch);

            foreach (var branch in _branchProvider.GetAllRemoteBranches())
            {
                _branchesMenuItem.DropDownItems.Add(new ToolStripMenuItem(branch, null, ChangeBranchClick) { Tag = branch });
            }

            menu.Items.Add(_branchesMenuItem);
            menu.Items.Add(new ToolStripSeparator());

            _undoToolStripMenuItem = new ToolStripMenuItem(Resources.Undo);
            var lastReservedMigration = Settings.Default.LastResrevedMigration;
            if (lastReservedMigration == null
                || lastReservedMigration.MigrationType == MigrationType.None)
            {
                DisableUndo();
            }
            else
            {
                EnableUndo(lastReservedMigration);
            }
            _undoToolStripMenuItem.Click += UndoClick;

            menu.Items.Add(_undoToolStripMenuItem);

            var addMigrationMenu = new ToolStripMenuItem("Reserve && copy for", Resources.AddMigration);

            foreach (MigrationType enumValue in Enum.GetValues(typeof (MigrationType)))
            {
                if (enumValue == MigrationType.None)
                {
                    continue;
                }

                addMigrationMenu.DropDownItems.Add(CreateMigrationItem(enumValue));
            }

            menu.Items.Add(addMigrationMenu);
            menu.Items.Add("Manage manually...", Resources.ChangeManually, ShowManageManually);
            menu.Items.Add("&Settings...", Resources.Settings, ShowSettings);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("&Exit", Resources.Exit, (sender, args) => Application.Exit());
            return menu;
        }

        private void ChangeBranchClick(object sender, EventArgs e)
        {
            Settings.Default.CurrentBranch = ((ToolStripMenuItem) sender).Tag.ToString();
            Settings.Default.Save();
            _branchesMenuItem.Text = Settings.Default.CurrentBranch;
        }

        private void ShowManageManually(object sender, EventArgs e)
        {
            if (_manageManuallyWindow == null)
            {
                _manageManuallyWindow = new ManageManuallyWindow(_migrationNumberTrackerClient, this);
            }

            if (!_manageManuallyWindow.Visible)
            {
                _manageManuallyWindow.ShowDialog();
            }

            _manageManuallyWindow.Focus();
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            if (_settingsWindow == null)
            {
                _settingsWindow = new SettingsWindow();
            }

            if (!_settingsWindow.Visible)
            {
                var result = _settingsWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (_branchProvider != null)
                    {
                        _branchProvider.SolutionDir = Settings.Default.SolutionDir;
                    }

                    if (_migrationNumberTrackerClient != null)
                    {
                        _migrationNumberTrackerClient.Url = Settings.Default.ServerUrl;
                    }
                }
            }
            _settingsWindow.Focus();
        }

        private void UndoClick(object sender, EventArgs e)
        {
            TryUndo();
        }

        private void TryUndo()
        {
            try
            {
                var lastReservedMigration = Settings.Default.LastResrevedMigration;
                var currentBranch = Settings.Default.CurrentBranch;
                var currentReservedMigrationNumber =
                    _migrationNumberTrackerClient.ReadMigrationNumber(currentBranch, lastReservedMigration.MigrationType);
                if (currentReservedMigrationNumber == lastReservedMigration.Number)
                {
                    _migrationNumberTrackerClient.UpdateMigrationNumber(currentBranch, lastReservedMigration.MigrationType,
                        --lastReservedMigration.Number);
                    Settings.Default.LastResrevedMigration = null;
                    Settings.Default.Save();
                    DisableUndo();
                    _mainIcon.ShowBalloonTip(2000,
                        "Migration reservation undone successfully!",
                        "Migration reservation undone successfully.",
                        ToolTipIcon.Info);
                }
                else
                {
                    _mainIcon.ShowBalloonTip(2000,
                        "Migration reservation undo impossible.",
                        "Migration reservation undo is impossible, because other migrations was reserved after yours.",
                        ToolTipIcon.Warning);
                    Settings.Default.LastResrevedMigration = null;
                    Settings.Default.Save();
                    DisableUndo();
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        private void EnableUndo(MigrationTuple migration)
        {
            _undoToolStripMenuItem.Text = string.Format("Undo migration {0}", migration);
            _undoToolStripMenuItem.Enabled = true;
        }

        public void DisableUndo()
        {
            _undoToolStripMenuItem.Text = "(nothing to undo)";
            _undoToolStripMenuItem.Enabled = false;
        }

        private ToolStripItem CreateMigrationItem(MigrationType type)
        {
            return new ToolStripMenuItem(type.ToString(), Resources.CSharpTransparent, ReserveMigrationNumber) { Tag = type };
        }

        private ToolStripItem CreateMigrationItem(string text, MigrationType type)
        {
            return new ToolStripMenuItem(text, Resources.CSharpTransparent, ReserveMigrationNumber) {Tag = type};
        }
    }
}