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
            ServiceHost adminHost = new ServiceHost(typeof(AdminService));
            ServiceHost teacherHost = new ServiceHost(typeof(TeacherService));

            adminHost.Open();
            Console.WriteLine("Admin service is hostet on port 8001");
            teacherHost.Open();
            Console.WriteLine("Teacher service is hostet on port 8002");

            Console.WriteLine("<Press enter to close server>\n");
            Console.ReadLine();
        }
    }
}
