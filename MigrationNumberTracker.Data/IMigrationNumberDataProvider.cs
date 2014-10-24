using System.Collections.Generic;
using MigrationNumberTracker.Common;

namespace MigrationNumberTracker.Data
{
    public interface IMigrationNumberDataProvider
    {
        long ReserveMigrationNumber(string branch, MigrationType type);
        long ReadMigrationNumber(string branch, MigrationType type);
        void UpdateMigrationNumber(string branch, MigrationType type, long number);
        void CreateBranchInfo(string branch);
        void RemoveBranchInfo(string branch);
        IEnumerable<string> GetAllBranches();
    }
}