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
            using(ServiceHost adminHost = new ServiceHost(typeof(AdminService)))
            {
                adminHost.Open();
                Console.WriteLine("Admin service is hostet on port 8001");
                Console.WriteLine("<Press enter to close server>\n");
                Console.ReadLine();
            }


        }
    }
}
