using System.Collections.Generic;

namespace AdminGUI.Facade
{
    class DomainFacade
    {
        NetworkFacade nf;

        public DomainFacade()
        {
            nf = new NetworkFacade();
        }

        public List<string> GetCourseInfo(int _id)
        {
            return nf.GetCourseInfo(_id);
        }

        public List<int> GetListOfCourseId()
        {
            return nf.GetListOfCourseId();
        }

        public void CreateCourse(string _name, int _instance, int _instanceYear, string _description, int _ects)
        {
            nf.CreateCourse(_name, _instance, _instanceYear, _description, _ects);
        }
    }
}
