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

        public Dictionary<String,int> GetAllExamGrades(int studentID)
        {
            throw new NotImplementedException();
        } 

        public int GetExamGrade(int studentID, int examID)
        {
            throw new NotImplementedException();
        }

        public List<String> GetStudentCourseSchedule(int studentID)
        {
            throw new NotImplementedException();
        } 

        public void AssignStudenToExam(int studentID, int examID)
        {
            throw new NotImplementedException();
        }

        public void UnregisterStudentFromCourse(int studentID, int CourseID)
        {
            throw  new NotImplementedException();
        }

        public void AssignStudentToCourse(int studentID, int courseID)
        {
            Student student1 = (Student) db.PersonSet.FirstOrDefault(s => s.Id == studentID && s is Student);
            Course course1 = db.CourseSet.FirstOrDefault(c => c.Id == courseID);

            student1.Course.Add(course1);

            //Student student = (Student)db.PersonSet.Where(p => p.Id == studentID && p is Student);
            //Student stu = db.PersonSet.Where(s => s is Student && s.Id == studentID);
            //Person person = (Person)db.PersonSet.Where(p => p.Id == studentID && p is Student);
            //Course course = (Course) db.CourseSet.Where(c => c.Id == courseID);

            //Student student = (Student) person;
            //student.Course.Add(course);
            //db.SaveChanges();
            /*
            Student student = null;
            Course course = null; 
            var persons = from p in db.PersonSet select p;
                
                foreach (Person p in persons)
                {
                    if (p.Id == studentID && p is Student)
                    {
                        Console.WriteLine("Finding students" + p.Id.ToString());
                        student = (Student) p;
                        break;
                    }
                }

            var courses = from c in db.CourseSet select c;
            foreach (Course c in courses)
            {
                if (c.Id == courseID)
                {
                    Console.WriteLine("Finding courses"+c.Id.ToString());
                    course = c;
                    break;
                }
            }
            if (student == null || course == null)
            {
                Console.WriteLine("Student og course is null!");
            }
            
            student.Course.Add(course);
            db.SaveChanges();
            */
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

        public int GetStudentIdByEmail(string email)
        {
            int studentId;
            var persons = from p in db.PersonSet select p;

            foreach (Person p in persons)
            {
                if (p.Email == email && p is Student)
                {
                    studentId = p.Id;
                    return studentId;
                }
                else
                {
                    throw new System.InvalidOperationException("There are no users with that e-mail");
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
