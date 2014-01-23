using System;
using System.ServiceModel;

namespace Artech.BatchingHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var hosts = new ServiceHostCollection())
            {
                foreach (var host in hosts)
                {
                    host.Opened += (sender, arg) => Console.WriteLine("服务{0}开始监听", (sender as ServiceHost).Description.ServiceType);
                }
                hosts.Open();
                Console.Read();
            }
        }
    }
}
