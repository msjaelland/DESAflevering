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

        public List<string> GetCourseInfo(int id)
        {
            return df.GetCourseInfo(id);
        }

        public void SignUpForCourse(int StudentID, int CourseID)
        {
            df.AssignStudentToCourse(StudentID, CourseID);
        }

        public int GetStudentIdByEmail(string email)
        {
            return df.GetStudentIdByEmail(email);
        }

        public string GetStudentName(int id)
        {
            return df.GetStudentName(id);
        }

        public List<int> GetListOfCourseId()
        {
            return df.GetListOfCourseId();
        }

        public List<string> GetStudentByEmail(string email)
        {
            return df.GetStudentByEmail(email);
        }

        public void SignUpForExam(int StudentID, int ExamID)
        {
            df.AssignStudenToExam(StudentID, ExamID);
        }

        public void UnregisterFromCourse(int StudentID, int CourseID)
        {
            df.UnregisterStudentFromCourse(StudentID, CourseID);
        }

        public Dictionary<String, int> GetAllExamGrades(int StudentID)
        {
            return df.GetAllExamGrades(StudentID);
        }

        public List<String> GetCourseSchedule(int StudentID)
        {
            return df.GetStudentCourseSchedule(StudentID);
        }

        public int GetExamGrade(int StudentID, int examID)
        {
            return df.GetExamGrade(StudentID, examID);
        }

        public Dictionary<string, int> getAvailableExams()
        {
            Dictionary<string, int> availbableExams = new Dictionary<string, int>();
            if(student.Exam!=null)
                foreach (var i in student.Course)
                {

                    foreach (var j in i.Exam)
                    {
                     availbableExams.Add(i.Name, j.Id);
                    }
             }
            return availbableExams;
        }

        public List<int> GetCourseIDsForStudent(int StudentID)
        {
            return df.GetCourseIDsForStudent(StudentID); 
        }
    }
}
