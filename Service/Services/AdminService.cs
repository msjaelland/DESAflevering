using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Types;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in both code and config file together.
    public class AdminService : IAdminService
    {
        DomainFacade df;

        public AdminService()
        {
            df = new DomainFacade();
        }

        public void AddCalendarEntry(int day, string starthour, string endhour, int courseId)
        {
            df.AddCalendarEntry(day, starthour, endhour, courseId);
        }

        public void AssignTeacher(int teacherId, int courseId)
        {
            df.AssignTeacher(teacherId, courseId);
        }

        public void CreateCourse(string name, int instance, int instanceYear, string description, int ects)
        {
            df.CreateCourse(name, instance, instanceYear, description, ects);
        }

        public List<string> GetCourseInfo(int id)
        {
            return df.GetCourseInfo(id);
        }

        public List<int> GetListOfCourseId()
        {
            return df.GetListOfCourseId();
        }
        public List<int> GetListOfTeacherId()
        {
            return df.GetListOfTeacherId();
        }

        public List<string> GetTeacherInfo(int id)
        {
            return df.GetTeacherInfo(id);
        }

        public void CreateTeacher(string name, string familyName, string email)
        {
            df.CreateTeacher(name, familyName, email);
        }
    }
}
