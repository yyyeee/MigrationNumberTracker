using System.Web.Hosting;
using System.Web.Http;
using MigrationNumberTracker.Common;
using MigrationNumberTracker.Data;

namespace MigrationNumberTracker.Server.Controllers
{
    public class MigrationNumbersController : ApiController
    {
        private readonly IMigrationNumberDataProvider _provider =
            new XmlMigrationNumberDataProvider(HostingEnvironment.MapPath("~/App_Data/data.xml"));

        [HttpPost]
        [Route("migrations/{type}/reserve")]
        public long ReserveMigrationNumber(MigrationType type)
        {
            return _provider.ReserveMigrationNumber(type);
        }

        [HttpGet]
        [Route("migrations/{type}")]
        public long MigrationNumber(MigrationType type)
        {
            return _provider.ReadMigrationNumber(type);
        }

        [HttpPost]
        [Route("migrations/{type}/{number}")]
        public string MigrationNumber(MigrationType type, long number)
        {
            _provider.UpdateMigrationNumber(type, number);
            return "ok";
        }
    }
}
