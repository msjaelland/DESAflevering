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

        public List<string> GetCourseInfo(int id)
        {
            return proxy.GetCourseInfo(id);
        }

        public List<int> GetListOfCourseId()
        {
            return proxy.GetListOfCourseId();
        }

        public void CreateCourse(string name, int instance, int instanceYear, string description, int ects)
        {
            proxy.CreateCourse(name, instance, instanceYear, description, ects);
        }
        public List<int> GetListOfTeacherId()
        {
            return proxy.GetListOfTeacherId();
        }

        public List<string> GetTeacherInfo(int id)
        {
            return proxy.GetTeacherInfo(id);
        }

        public void CreateTeacher(string name, string familyName, string email)
        {
            proxy.CreateTeacher(name, familyName, email);
        }
    }
}
