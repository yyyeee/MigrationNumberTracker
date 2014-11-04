using MigrationNumberTracker.Common;
using MigrationNumberTracker.Data;
using NUnit.Framework;

namespace MigrationNumberTracker.Tests.Data
{
    [TestFixture]
    public class DataAdhoc
    {
        private IMigrationNumberDataProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new XmlMigrationNumberDataProvider(@"Data");
        }

        [Test]
        public void Foo()
        {
            //arrange

            // act
            _provider.UpdateMigrationNumber("testdata", MigrationType.Client, 500);
            var result = _provider.ReadMigrationNumber("testdata", MigrationType.Client);

            // assert
            Assert.That(result, Is.EqualTo(500));
        }
    }
}
