using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service.Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
	[ServiceContract]
	public interface IStudentService
	{
	    [OperationContract]
	    void Register(String name, String familyName, String email);

        [OperationContract]
        void SignUpForCourse(int StudentID, int CourseID);

        [OperationContract]
        void UnregisterFromCourse(int StudentID, int CourseID);

        [OperationContract]
        void ViewCourseSchedule();

        [OperationContract]
        void SignUpForExam(int StudentID, int ExamID);

        [OperationContract]
        int ViewMyGrade(int ExamID);

        [OperationContract]
        Dictionary<int, int> ViewAllMyGrades(int StudentID);
    }
}
