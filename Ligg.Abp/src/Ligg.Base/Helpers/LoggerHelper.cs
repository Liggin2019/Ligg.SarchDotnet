using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

namespace Ligg.Base.Helpers
{
    public static class LoggerHelper
    {
        private static readonly ILoggerRepository Repository = LogManager.CreateRepository("NETCoreRepository");
        private static readonly ILog Log = LogManager.GetLogger(Repository.Name, "NETCorelog4net");

        static LoggerHelper()
        {
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        }


        public static void WriteToFile(string message)
        {
            Log.Info(message);
        }

        public static void WriteToFile(string message, Exception ex)
        {
            if (string.IsNullOrEmpty(message))
                message = ex.Message;

            Log.Error(message, ex);
        }
    }
}