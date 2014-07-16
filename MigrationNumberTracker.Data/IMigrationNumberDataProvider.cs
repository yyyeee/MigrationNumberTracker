using MigrationNumberTracker.Common;

namespace MigrationNumberTracker.Data
{
    public interface IMigrationNumberDataProvider
    {
        long ReserveMigrationNumber(MigrationType type);
        long ReadMigrationNumber(MigrationType type);
        void UpdateMigrationNumber(MigrationType type, long number);
    }
}