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

    }
}
