using System;
using System.IO;
using log4net;

namespace crawlerStudy
{
    public class LogHelper
    {
        private static string loggerName = "message";//默认值
        private static ILog _log;
        private static ILog log
        {
            get
            {
                if (_log == null || _log.Logger.Name != loggerName)
                {
                    log4net.Config.XmlConfigurator.Configure(new FileInfo(String.Format("{0}\\log4net.config", AppDomain.CurrentDomain.BaseDirectory)));
                    _log = log4net.LogManager.GetLogger(loggerName);
                }
                return _log;
            }
        }

        public static void Log(object message, int level = 1)
        {
            loggerName = "message";
            if (message != null)
            {
                switch (level)
                {
                    case 1:
                        log.Info(message);
                        break;
                    case 2:
                        log.Warn(message);
                        break;
                    case 3:
                        log.Error(message);
                        break;
                    case 4:
                        log.Fatal(message);
                        break;
                }
                System.Console.WriteLine(message.ToString());
            }
        }
    }
}