using NLog;
using System;
using System.Collections.Concurrent;
using System.ServiceModel;

namespace LoggerHub
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoggerHubService : ILoggerHubService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public bool Echo(string input)
        {
            Console.WriteLine("Test: {0}", input);
            return true;
        }

        public void SendMessageQueue(string logPath, ConcurrentQueue<string> logQueue)
        {
            _ = new LoggerHub(logPath);

            while (!logQueue.IsEmpty)
            {
                logQueue.TryDequeue(out string entry);
                _logger.Info(entry);
            }
        }
    }
}