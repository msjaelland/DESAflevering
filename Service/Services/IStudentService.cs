﻿using System;
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
        List<string> GetCourseInfo(int id);

        [OperationContract]
        void SignUpForCourse(int StudentID, int CourseID);

        [OperationContract]
        int GetStudentIdByEmail(string email);

        [OperationContract]
        List<int> GetListOfCourseId();

        [OperationContract]
        string GetStudentName(int id);
        
        [OperationContract]
        List<string> GetStudentByEmail(string email);
        
        [OperationContract]
        void UnregisterFromCourse(int StudentID, int CourseID);

        [OperationContract]
        List<String> GetCourseSchedule(int StudentID);

        [OperationContract]
        void SignUpForExam(int StudentID, int ExamID);

        [OperationContract]
        int GetExamGrade(int StudentID, int ExamID);

        [OperationContract]
        Dictionary<String, int> GetAllExamGrades(int StudentID);

	    [OperationContract]
	    Dictionary<string, int> getAvailableExams();
	}
}
