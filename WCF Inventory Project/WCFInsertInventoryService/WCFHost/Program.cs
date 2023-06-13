using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFInsertInventoryService;

namespace WCFHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFInsertService)))
            {
                host.Open();
                Console.WriteLine("Host has been started.");
                Console.ReadLine();
            }
        }
    }
}
