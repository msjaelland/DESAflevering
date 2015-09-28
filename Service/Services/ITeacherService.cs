using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Types;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeacherService" in both code and config file together.
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        List<string> GetStudentsForCourse();

        [OperationContract]
        void CreateExam();

        [OperationContract]
        List<string> GetExams();

        [OperationContract]
        void GradeExam(int studentId, int examId, int grade);

        [OperationContract]
        List<string> GetGrades();

        [OperationContract]
        List<string> GetCourses();
    }
}
