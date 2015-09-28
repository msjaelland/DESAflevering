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

        public void AddCalendarEntry(int day, string starthour, string endhour, int courseId)
        {
            dbf.AddCalendarEntry(ObjectFactory.Instance.CreateCalendarEntry(day, starthour, endhour, courseId));
        }

        public void AssignTeacher(int teacherId, int courseId)
        {
            dbf.AssignTeacher(teacherId, courseId);
        }

        public void CreateCourse(string name, int instance, int instanceYear, string description, int ects)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay + ": Created course with course name " + name);
            dbf.CreateCourse(ObjectFactory.Instance.CreateCourse(name, instance, instanceYear, description, ects));
        }

        public List<string> GetCourseInfo(int id)
        {
            return dbf.GetCourseInfo(id);
        }

        public List<int> GetListOfCourseId()
        {
            return dbf.GetListOfCourseId();
        }

        public List<int> GetListOfTeacherId()
        {
            return dbf.GetListOfTeacherId();
        }

        public List<string> GetTeacherInfo(int id)
        {
            return dbf.GetTeacherInfo(id);
        }

        public void CreateTeacher(string name, string familyName, string email)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay + ": Created teacher with name " + name + " " + familyName);
            dbf.CreateTeacher(ObjectFactory.Instance.CreateTeacher(name, familyName, email));
        }
    }
}
