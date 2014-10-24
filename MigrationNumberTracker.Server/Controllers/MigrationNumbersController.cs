using System;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using MigrationNumberTracker.Common;
using MigrationNumberTracker.Data;
using MigrationNumberTracker.Logging;

namespace MigrationNumberTracker.Server.Controllers
{
    public class MigrationNumbersController : ApiController
    {
        private readonly IMigrationNumberDataProvider _provider =
            new XmlMigrationNumberDataProvider(HostingEnvironment.MapPath("~/App_Data"));
        private static readonly Log Log = new Log();

        [HttpPost]
        [Route("migrations/{encodedBranch}/{type}/reserve")]
        public long ReserveMigrationNumber(string encodedBranch, MigrationType type)
        {
            var branch = HttpUtility.UrlDecode(encodedBranch);
            try
            {
                return _provider.ReserveMigrationNumber(branch, type);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw HttpExceptionHelper.ServerError(e.Message);
            }
        }

        [HttpGet]
        [Route("migrations/{encodedBranch}/{type}")]
        public long MigrationNumber(string encodedBranch, MigrationType type)
        {
            var branch = HttpUtility.UrlDecode(encodedBranch);
            try
            {
                return _provider.ReadMigrationNumber(branch, type);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw HttpExceptionHelper.ServerError(e.Message);
            }
        }

        [HttpPost]
        [Route("migrations/{encodedBranch}/{type}/{number}")]
        public string MigrationNumber(string encodedBranch, MigrationType type, long number)
        {
            var branch = HttpUtility.UrlDecode(encodedBranch);
            try
            {
                _provider.UpdateMigrationNumber(branch, type, number);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw HttpExceptionHelper.ServerError(e.Message);
            }
            return "ok";
        }
    }
}
