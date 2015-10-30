using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentGUI.Facade
{
    class NetworkFacade
    {

        ChannelFactory<IStudentService> channelFactory = new ChannelFactory<IStudentService>("StudentServiceEndpoint");
        IStudentService proxy;

        public NetworkFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public void Register(String name, String familyName, String email)
        {
            proxy.Register(name, familyName, email);
            SignUpForCourse();
        }

        public void SignUpForCourse()
        {
            proxy.SignUpForCourse(3, 1);
        }
    }
}
