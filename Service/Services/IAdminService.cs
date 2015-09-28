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
        List<string> GetCourseInfo(int id);

        [OperationContract]
        List<int> GetListOfCourseId();

        [OperationContract]
        void CreateCourse(string name, int instance, int instanceYear, string description, int ects);

        [OperationContract]
        void AssignTeacher(int teacherId, int courseId);

        [OperationContract]
        void AddCalendarEntry(int day, string starthour, string endhour, int courseId);

        [OperationContract]
        List<string> GetTeacherInfo(int id);

        [OperationContract]
        List<int> GetListOfTeacherId();

        [OperationContract]
        void CreateTeacher(string name, string familyName, string email);
    }
}
