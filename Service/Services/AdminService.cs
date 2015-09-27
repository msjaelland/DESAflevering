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

        public void AddCalendarEntry(Day _day, string _starthour, string _endhour, int _courseId)
        {
            df.AddCalendarEntry(_day, _starthour, _endhour, _courseId);
        }

        public void AssignTeacher(int _teacherId, int _courseId)
        {
            df.AssignTeacher(_teacherId, _courseId);
        }

        public void CreateCourse(string _name, int _instance, int _instanceYear, string _description, int _ects)
        {
            df.CreateCourse(_name, _instance, _instanceYear, _description, _ects);
        }

        public List<string> GetCourseInfo(int _id)
        {
            return df.GetCourseInfo(_id);
        }

        public List<int> GetListOfCourseId()
        {
            return df.GetListOfCourseId();
        }
    }
}
