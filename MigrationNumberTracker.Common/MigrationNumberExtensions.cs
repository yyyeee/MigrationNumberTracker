using System.Globalization;

namespace MigrationNumberTracker.Common
{
    public static class MigrationNumberExtensions
    {
        public static string ToMigrationPrefix(this long migrationNumber)
        {
            var migrationNumberString = migrationNumber.ToString(CultureInfo.InvariantCulture);
            if (migrationNumberString.Length <= 3)
            {
                migrationNumberString = migrationNumber.ToString("d3");
            }
            return string.Format("M{0}_", migrationNumberString);
        }
    }
}