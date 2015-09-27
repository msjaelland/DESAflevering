using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Types;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        List<string> GetCourseInfo(int _id);

        [OperationContract]
        List<int> GetListOfCourseId();

        [OperationContract]
        void CreateCourse(string _name, int _instance, int _instanceYear, string _description, int _ects);

        [OperationContract]
        void AssignTeacher(int _teacherId, int _courseId);

        [OperationContract]
        void AddCalendarEntry(Day _day, string _starthour, string _endhour, int _courseId);
    }
}
