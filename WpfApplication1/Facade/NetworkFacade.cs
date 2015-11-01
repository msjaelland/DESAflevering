using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Types;

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

        public void SignUpForCourse(int StudentID, int CourseId)
        {
            proxy.SignUpForCourse(StudentID, CourseId);
        }

        public List<string> GetCourseInfo(int id)
        {
            return proxy.GetCourseInfo(id);
        }

        public string GetStudentName(int id)
        {
            return proxy.GetStudentName(id);
        }


        public int GetStudentIdByEmail(string email)
        {
            return proxy.GetStudentIdByEmail(email);
        }

        public List<string> GetStudentByEmail(string email)
        {
            return proxy.GetStudentByEmail(email);
        }

        public void SignUpForExam(int StudentID, int ExamID)
        {
            proxy.SignUpForExam(StudentID, ExamID);
        }

        public void UnregisterFromCourse(int StudentID, int CourseID)
        {
            proxy.UnregisterFromCourse(StudentID, CourseID);
        }

        public Dictionary<int, Grade> GetAllExamGrades(int StudentID)
        {
            return proxy.GetAllExamGrades(StudentID);
        }
        
        public List<String> GetCourseSchedule(int StudentID)
        {
            return proxy.GetCourseSchedule(StudentID);
        }

        public Grade GetExamGrade(int StudentID, int ExamID)
        {
            return proxy.GetExamGrade(StudentID, ExamID);
        }
        

        public List<int> GetListOfCourseId()
        {
            return proxy.GetListOfCourseId();
        }

        public List<int> GetCourseIDsForStudent(int StudentID)
        {
            return proxy.GetCourseIDsForStudent(StudentID);
        }

    }
}
