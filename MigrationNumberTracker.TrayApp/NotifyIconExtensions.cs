using System.Reflection;
using System.Windows.Forms;

namespace MigrationNumberTracker.TrayApp
{
    public static class NotifyIconExtensions
    {
        public static void ShowContextMenuForced(this NotifyIcon @this)
        {
            typeof (NotifyIcon).GetMethod("ShowContextMenu",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(@this, null);
        }
    }
}