using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var wcfService = new WCFService();
            wcfService.ConfigureService("net.tcp://localhost:5475/LogService");

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();

            LogManager.Shutdown();
            wcfService.Dispose();
        }
    }
}
