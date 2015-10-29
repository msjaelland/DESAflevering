using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Service.Facade;
using Types;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in both code and config file together.
    public class StudentService : IStudentService
    {

        DomainFacade df;
        private Student student; 

        public StudentService()
        {
            df = new DomainFacade(); 
        }

        public void Register(String name, String familyName, String email)
        {
            df.CreateStudent(name, familyName, email);
        }

        public void SignUpForCourse(int StudentID, int CourseID)
        {
            throw new NotImplementedException();
        }

        public void SignUpForExam(int StudentID, int ExamID)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromCourse(int StudentID, int CourseID)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> ViewAllMyGrades(int StudentID)
        {
            throw new NotImplementedException();
        }

        public void ViewCourseSchedule()
        {
            throw new NotImplementedException();
        }

        public int ViewMyGrade(int ExamID)
        {
            throw new NotImplementedException();
        }
    }
}
