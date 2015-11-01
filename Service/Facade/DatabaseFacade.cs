using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Service.Facade
{
    class DatabaseFacade
    {
        DataModelContainer db;

        public DatabaseFacade()
        {
            db = new DataModelContainer();
        }

        #region Teacher stuff

        public void CreateTeacher(Teacher teacher)
        {
            db.PersonSet.Add(teacher);
            db.SaveChanges();
        }
        //Returns list of all teacher IDs
        public List<int> GetListOfTeacherId()
        {
            List<int> teacherIdList = new List<int>();

            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p is Teacher)
                {
                    teacherIdList.Add(p.Id);
                }
            }
            return teacherIdList;
        }

        public List<string> GetTeacherInfo(int _id)
        {
            List<string> teacherInfo = new List<string>();

            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Id == _id && p is Teacher)
                {
                    teacherInfo.Add(p.Id.ToString());
                    teacherInfo.Add(p.Name);
                    teacherInfo.Add(p.FamilyName);
                    teacherInfo.Add(p.Email);
                }
            }
            return teacherInfo;
        }

        //Returns all courses (by ID) for given student
        public List<int> GetCourseIDsForStudent(int StudentID)
        {
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == StudentID) as Student;

            var courses = from c in student.Course select c.Id;
          
            Console.WriteLine("Returning courseIDs");
            return courses.ToList<int>();
        }

        //Returns name of a teacher by id
        public string GetTeacherName(int id)
        {
            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Id == id && p is Teacher)
                {
                    return p.Name + p.FamilyName;
                }
            }
            return null;
        }

        public void AssignTeacher(int teacherId, int courseId)
        {
            var courses = from c in db.CourseSet select c;

            foreach (Course c in courses)
            {
                if (c.Id == courseId)
                {
                    c.TeacherId = teacherId;
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region Student stuff
        //Returns Dictionary<examID(int), grade(Grade)
        public Dictionary<int, Grade> GetAllExamGrades(int StudentID)
        {
            Dictionary<int, Grade> examGrades = new Dictionary<int, Grade>();
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == StudentID) as Student;

            var exams = from e in student.Exam select e;
            foreach (Exam e in exams)
            {
                examGrades.Add(e.Id, e.Grade);
            }

            return examGrades;
        }
        //TODO: Don't return fail if no exam is found!
        public Grade GetExamGrade(int studentID, int examID)
        {
            Grade grade = Grade.Fail; 
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == studentID) as Student;

            var exams = from e in student.Exam select e;
            foreach (Exam e in exams)
            {
                if (e.Id == examID)
                {
                    grade = e.Grade;
                }
            }
            return grade;

        }
        
        //Not testet since calenderentries have not been implemented
        //TODO: Make this method better/more effecient!
        public List<String> GetStudentCourseSchedule(int studentID)
        {
            List<String> courseSchedule = new List<String>();
            List<int> studentCourses = GetCourseIDsForStudent(studentID);
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == studentID) as Student;
            
            var calenderEntries = from c in db.CalendarEntrySet select c;

            foreach (CalendarEntry c in calenderEntries)
            {
                foreach (int i in studentCourses)
                {
                    if (c.CourseId == i){
                        courseSchedule.Add("Day: "+c.Day.ToString()+" StartHour: "+c.StartHour+" EndHour: "+c.EndHour+c.Day);
                    }
                }
            }
            return courseSchedule; ; 
        } 
        //Assigns a student to an exam by adding a realtion to table StudentExam
        public void AssignStudentToExam(int studentID, int examID)
        {
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == studentID) as Student;
            Exam exam = db.ExamSet.FirstOrDefault(c => c.Id == examID);

            if (student != null && exam != null)
            {
                student.Exam.Add(exam);
                db.SaveChanges();
            }
            else
            {
                throw new System.InvalidOperationException();
                Console.WriteLine("Student or exam is null!");
            }
        }
        //Unregisters a student from a course by removing the relation from table StudentCourse
        public void UnregisterStudentFromCourse(int studentID, int CourseID)
        {
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == studentID) as Student;
            Course course = db.CourseSet.FirstOrDefault(c => c.Id == CourseID);

            if (student != null && course != null)
            {
                student.Course.Remove(course);
                db.SaveChanges();
            }
            else
            {
                throw new System.InvalidOperationException("Student or course is null!");
            }
        }
        //Assigns a student to a course by adding a relation to tabe StudentCourse
        public void AssignStudentToCourse(int studentID, int courseID)
        {
            Student student = db.PersonSet.FirstOrDefault(s => s.Id == studentID) as Student;
            Course course = db.CourseSet.FirstOrDefault(c => c.Id == courseID);

            if (student != null && course != null)
            {
                student.Course.Add(course);
                db.SaveChanges();
            }
            else
            {
                throw new System.InvalidOperationException("Student or course is null!");

            }
        }

        public void CreateStudent(Student student)
        {
            db.PersonSet.Add(student);
            db.SaveChanges();

        }

        public List<string> GetStudentInfo(int id)
        {
            List<string> studentInfo = new List<string>();
            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Id == id && p is Teacher)
                {
                    studentInfo.Add(p.Id.ToString());
                    studentInfo.Add(p.Name);
                    studentInfo.Add(p.FamilyName);
                    studentInfo.Add(p.Email);
                }
            }
            return studentInfo;
        }

        public string GetStudentName(int id)
        {
            string studentName;
            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Id == id && p is Student)
                {
                    return studentName = p.Name + " " + p.FamilyName;
                }

            }
            return "Uknown User";
        }

        public int GetStudentIdByEmail(string email)
        {
            db.SaveChanges();
            int studentId;
            var persons = from p in db.PersonSet select p;
            Console.WriteLine(email);
            foreach (Person p in persons)
            {
                if (p.Email == email && p is Student)
                {
                    studentId = p.Id;
                    return studentId;
                }
            }

            return 0;
        }

        public List<string> GetStudentByEmail(string email)
        {
            List<string> studentInfo = new List<string>();
            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Email == email && p is Student)
                {
                    studentInfo.Add(p.Id.ToString());
                    studentInfo.Add(p.Name);
                    studentInfo.Add(p.FamilyName);
                    studentInfo.Add(p.Email);
                }
            }
            return studentInfo;
        }


        #endregion

        #region Course stuff

        public void CreateCourse(Course course)
        {
            db.CourseSet.Add(course);
            db.SaveChanges();
        }

        public List<int> GetListOfCourseId()
        {
            var courses = from c in db.CourseSet select c.Id;
            return courses.ToList<int>();
        }

        public List<string> GetCourseInfo(int id)
        {
            List<string> courseInfo = new List<string>();

            var courses = from c in db.CourseSet select c;

            foreach (Course c in courses)
            {
                if (c.Id == id)
                {
                    courseInfo.Add(c.Id.ToString());
                    courseInfo.Add(c.Name);
                    courseInfo.Add(c.Instance.ToString() + " " + c.InstanceYear.ToString());
                    courseInfo.Add(c.Description);
                    courseInfo.Add(c.ECTS.ToString());
                    courseInfo.Add(c.TeacherId.ToString());
                    courseInfo.Add(GetTeacherName(c.TeacherId));

                    return courseInfo;
                }
            }
            return null;
        }

        public List<int> GetStudentIdsForCourse(int courseId)
        {
            List<Student> studentList = new List<Student>();
            List<int> studentIds = new List<int>();

            var courses = from c in db.CourseSet select c;

            foreach (Course c in courses)
            {
                if (c.Id == courseId)
                {
                    studentList = c.Student.ToList();
                    foreach (Person p in studentList)
                    {
                        if (p is Student)
                        {
                            studentIds.Add(p.Id);
                        }
                    }
                }
            }
            return studentIds;
        }
        #endregion

        #region Calender entry stuff

        public void AddCalendarEntry(CalendarEntry _calendarEntry)
        {
            db.CalendarEntrySet.Add(_calendarEntry);
            db.SaveChanges();
        }
        #endregion
    }
}
