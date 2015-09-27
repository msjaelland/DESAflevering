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
        public List<int> GetListOfTeacherId()
        {
            return proxy.GetListOfTeacherId();
        }

        public List<string> GetTeacherInfo(int _id)
        {
            return proxy.GetTeacherInfo(_id);
        }

        public void CreateTeacher(string _name, string _familyName, string _email)
        {
            proxy.CreateTeacher(_name, _familyName, _email);
        }
    }
}
