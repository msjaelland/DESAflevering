using Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Service.Facade
{
    class DomainFacade
    {
        DatabaseFacade dbf;

        public DomainFacade()
        {
            dbf = new DatabaseFacade();
        }

        public void AddCalendarEntry(Day _day, string _starthour, string _endhour, int _courseId)
        {
            dbf.AddCalendarEntry(ObjectFactory.Instance.CreateCalendarEntry(_day, _starthour, _endhour, _courseId));
        }

        public void AssignTeacher(int _teacherId, int _courseId)
        {
            dbf.AssignTeacher(_teacherId, _courseId);
        }

        public void CreateCourse(string _name, CourseInstance _instance, int _instanceYear, string _description, int _ects)
        {
            dbf.CreateCourse(ObjectFactory.Instance.CreateCourse(_name, _instance, _instanceYear, _description, _ects));
        }

        public List<string> GetCourseInfo(int _id)
        {
            return dbf.GetCourseInfo(_id);
        }

        public List<int> GetListOfCourseId()
        {
            return dbf.GetListOfCourseId();
        }
    }
}
