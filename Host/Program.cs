using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(AdminService)))
            {
                host.Open();
                Console.WriteLine("Admin server is open on port 8001\n<Press enter to close server>");
                Console.ReadLine();
            }
        }
    }
}
