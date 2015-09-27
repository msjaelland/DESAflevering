using Service.Services;
using System.Collections.Generic;
using System.ServiceModel;

namespace AdminGUI.Facade
{
    class NetworkFacade
    {
        ChannelFactory<IAdminService> channelFactory = new ChannelFactory<IAdminService>("AdminServiceEndpoint");
        IAdminService proxy;

        public NetworkFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public List<string> GetCourseInfo(int _id)
        {
            return proxy.GetCourseInfo(_id);
        }

        public List<int> GetListOfCourseId()
        {
            return proxy.GetListOfCourseId();
        }

        public void CreateCourse(string _name, int _instance, int _instanceYear, string _description, int _ects)
        {
            proxy.CreateCourse(_name, _instance, _instanceYear, _description, _ects);
        }
    }
}
