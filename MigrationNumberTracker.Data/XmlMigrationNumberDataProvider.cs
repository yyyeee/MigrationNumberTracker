using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MigrationNumberTracker.Common;

namespace MigrationNumberTracker.Data
{
    public class XmlMigrationNumberDataProvider : IMigrationNumberDataProvider
    {
        private const long DefaultMigrationNumber = 0;
        private const string DefaultBranchName = "master";
        private const string DataFileFormat = "{0}.xml";
        private readonly string _dataFolder;

        public XmlMigrationNumberDataProvider(string dataFolder)
        {
            _dataFolder = dataFolder;
        }

        public long ReserveMigrationNumber(string branch, MigrationType type)
        {
            var data = ReadData(branch);

            if (data.ContainsKey(type))
            {
                ++data[type];
            }
            else
            {
                data.Add(type, DefaultMigrationNumber);
            }

            WriteData(branch, data);

            return data[type];
        }

        public long ReadMigrationNumber(string branch, MigrationType type)
        {
            var data = ReadData(branch);

            return data.ContainsKey(type) ? data[type] : DefaultMigrationNumber;
        }

        public void UpdateMigrationNumber(string branch, MigrationType type, long number)
        {
            var data = ReadData(branch);

            if (data.ContainsKey(type))
            {
                data[type] = number;
            }
            else
            {
                data.Add(type, number);
            }

            WriteData(branch, data);
        }

        private Dictionary<MigrationType, long> ReadData(string branch)
        {
            List<MigrationTuple> data;

            using (var reader = new XmlTextReader(GetDataFileFullName(branch)))
            {
                var serializer = new XmlSerializer(typeof(List<MigrationTuple>));
                if (serializer.CanDeserialize(reader))
                {
                    data = (List<MigrationTuple>) serializer.Deserialize(reader);
                }
                else
                {
                    return new Dictionary<MigrationType, long>();
                }

            }

            return data.ToDictionary(tuple => tuple.MigrationType,
                                     tuple => tuple.Number);
        }

        private void WriteData(string branch, Dictionary<MigrationType, long> data)
        {
            using (var writer = new XmlTextWriter(GetDataFileFullName(branch), Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(List<MigrationTuple>));
                serializer.Serialize(writer,
                    data.Select(pair =>
                        new MigrationTuple
                        {
                            MigrationType = pair.Key,
                            Number = pair.Value,
                        }).ToList());

            }
        }

        private string GetDataFileFullName(string branch)
        {
            var fullname = Path.Combine(_dataFolder, GetDataFileName(branch));
            return File.Exists(fullname)
                    ? fullname
                    : Path.Combine(_dataFolder, GetDataFileName(DefaultBranchName));
        }

        private string GetDataFileName(string branch)
        {
            return string.Format(DataFileFormat, branch);
        }

        public void CreateBranchInfo(string branch)
        {
            if (branch == DefaultBranchName)
            {
                throw new InvalidOperationException(string.Format("Cannot remove default branch configuration: [{0}].", DefaultBranchName));
            }

            if (branch == DefaultBranchName)
            {
                throw new InvalidOperationException(string.Format("Configuration for branch [{0}] already exist.", branch));
            }

            var defaultBranchData = Path.Combine(_dataFolder, GetDataFileName(DefaultBranchName));
            var newBranchData = Path.Combine(_dataFolder, GetDataFileName(branch));
            File.Copy(defaultBranchData, newBranchData);
        }

        public void RemoveBranchInfo(string branch)
        {
            if (branch == DefaultBranchName)
            {
                throw new InvalidOperationException(string.Format("Cannot remove default branch configuration: [{0}].", DefaultBranchName));
            }

            var fullname = Path.Combine(_dataFolder, GetDataFileName(branch));

            if (File.Exists(fullname))
            {
                File.Delete(fullname);
            }
        }

        public IEnumerable<string> GetAllBranches()
        {
            return Directory.GetFiles(_dataFolder).Select(Path.GetFileNameWithoutExtension);
        }
    }
}