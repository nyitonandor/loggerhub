using System.Collections.Concurrent;
using System.ServiceModel;

namespace LoggerHub
{
    [ServiceContract]
    public interface ILoggerHubService
    {
        [OperationContract]
        bool Echo(string input);

        [OperationContract]
        void SendMessageQueue(string logPath, ConcurrentQueue<string> queue);
    }
}