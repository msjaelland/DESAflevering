using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentGUI.Facade
{
    class NetworkFacade
    {

        ChannelFactory<IStudentService> channelFactory = new ChannelFactory<IStudentService>("StudentServiceEndpoint");
        IStudentService proxy;

        public NetworkFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public void Register(String name, String familyName, String email)
        {
            proxy.Register(name, familyName, email);
        }
        

        public int GetStudentIdByEmail(string email)
        {
            return proxy.GetStudentIdByEmail(email);
        }

        public List<string> GetStudentByEmail(string email)
        {
            return proxy.GetStudentByEmail(email);
        }

        public void SignUpForCourse(int StudentID, int CourseID)
        {
            proxy.SignUpForCourse(StudentID, CourseID);
        }

        public void SignUpForExam(int StudentID, int ExamID)
        {
            proxy.SignUpForExam(StudentID, ExamID);
        }

        public void UnregisterFromCourse(int StudentID, int CourseID)
        {
            proxy.UnregisterFromCourse(StudentID, CourseID);
        }

        public Dictionary<String, int> ViewAllMyGrades(int StudentID)
        {
            return proxy.GetAllExamGrades(StudentID);
        }

        public List<String> GetCourseSchedule(int StudentID)
        {
            return proxy.GetCourseSchedule(StudentID);
        }

        public int ViewMyGrade(int StudentID, int ExamID)
        {
            return proxy.GetExamGrade(StudentID, ExamID);
        }

        public Dictionary<string, int> getAvailableExams()
        {
            proxy.getAvailableExams();
            Dictionary<string, int> availbableExams = new Dictionary<string, int>();
            //if (student.Exam != null)
            //    foreach (var i in student.Course)
            //    {

            //        foreach (var j in i.Exam)
            //        {
            //            availbableExams.Add(i.Name, j.Id);
            //        }
            //    }
            return availbableExams;
        //}
        
        }

        public List<int> GetListOfCourseId()
        {
            return GetListOfCourseId();
        }

    }
}
