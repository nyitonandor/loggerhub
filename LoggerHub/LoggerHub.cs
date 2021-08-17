using NLog;
using NLog.Config;
using NLog.Targets;

namespace LoggerHub
{
    public class LoggerHub
    {
        public LoggerHub(string logPath)
        {
            InitLoggerHub(logPath);
        }

        private void InitLoggerHub(string logPath)
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget
            {
                Name = "file",
                FileName = logPath,
                Layout = "${message} ${exception:format=tostring}",
                KeepFileOpen = true,
                ConcurrentWrites = true,
            };

            var rule = new LoggingRule("*", LogLevel.Debug, LogLevel.Fatal, fileTarget);

            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;
        }
    }
}
