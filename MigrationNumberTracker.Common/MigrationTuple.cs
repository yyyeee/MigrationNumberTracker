using System;
using System.Configuration;

namespace MigrationNumberTracker.Common
{
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class MigrationTuple
    {
        public MigrationType MigrationType { get; set; }
        public long Number { get; set; }

        public override string ToString()
        {
            return string.Format("'{0}' ({1})", Number.ToMigrationPrefix(), MigrationType);
        }
    }
}