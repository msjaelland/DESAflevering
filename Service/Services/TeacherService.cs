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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TeacherService" in both code and config file together.
    public class TeacherService : ITeacherService
    {
        DomainFacade df;

        public TeacherService()
        {
            df = new DomainFacade();
        }

        public void CreateExam()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCourseInfo(int id)
        {
            return df.GetCourseInfo(id);
        }

        public List<string> GetCourses()
        {
            throw new NotImplementedException();
        }

        public List<string> GetExams()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGrades()
        {
            throw new NotImplementedException();
        }

        public List<int> GetListOfCourseId()
        {
            return df.GetListOfCourseId();
        }

        public List<int> GetStudentIdsForCourse(int courseId)
        {
            return df.GetStudentIdsForCourse(courseId);
        }

        public void GradeExam(int studentId, int examId, int grade)
        {
            throw new NotImplementedException();
        }

        public List<string> GetStudentInfo(int id)
        {
            return df.GetStudentInfo(id);
        }
    }
}
