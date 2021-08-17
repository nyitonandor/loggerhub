using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace LoggerHub
{
    public class WCFService : IDisposable
    {
        private ServiceHost _host = null;
        private readonly long _messageSize = 32 * 1024 * 1024;
        private TimeSpan _sendTimeout = TimeSpan.FromSeconds(15);
        private TimeSpan _receiveTimeout = TimeSpan.FromDays(20);

        public void ConfigureService(string uri)
        {
            try
            {
                Uri baseAddress = new Uri(uri);

                _host = new ServiceHost(typeof(LoggerHubService), baseAddress);
                _host.AddServiceEndpoint(typeof(ILoggerHubService), CreateNetTcpBinding(), uri);

                _host.Open();

            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }

        private NetTcpBinding CreateNetTcpBinding()
        {
            return new NetTcpBinding(SecurityMode.None)
            {
                MaxReceivedMessageSize = _messageSize,
                SendTimeout = _sendTimeout,
                ReceiveTimeout = _receiveTimeout
            };
        }

        public void Dispose()
        {
            if (_host != null)
            {
                _host.Close();
                _host = null;
            }
        }
    }
}
