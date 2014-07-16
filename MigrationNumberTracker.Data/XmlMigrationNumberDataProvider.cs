using System.Collections.Generic;
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
        private readonly string _filename;

        public XmlMigrationNumberDataProvider(string filename)
        {
            _filename = filename;
        }

        public long ReserveMigrationNumber(MigrationType type)
        {
            var data = ReadData();

            if (data.ContainsKey(type))
            {
                ++data[type];
            }
            else
            {
                data.Add(type, DefaultMigrationNumber);
            }

            WriteData(data);

            return data[type];
        }

        public long ReadMigrationNumber(MigrationType type)
        {
            var data = ReadData();

            return data.ContainsKey(type) ? data[type] : DefaultMigrationNumber;
        }

        public void UpdateMigrationNumber(MigrationType type, long number)
        {
            var data = ReadData();

            if (data.ContainsKey(type))
            {
                data[type] = number;
            }
            else
            {
                data.Add(type, number);
            }

            WriteData(data);
        }

        private Dictionary<MigrationType, long> ReadData()
        {
            List<MigrationTuple> data;

            using (var reader = new XmlTextReader(_filename))
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

        private void WriteData(Dictionary<MigrationType, long> data)
        {
            using (var writer = new XmlTextWriter(_filename, Encoding.UTF8))
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
    }
}