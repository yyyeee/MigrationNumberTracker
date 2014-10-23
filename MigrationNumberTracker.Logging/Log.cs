using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MigrationNumberTracker.Logging
{
    public class Log
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Error(Exception e)
        {
            Logger.Error(string.Empty, e);
        }
    }
}
