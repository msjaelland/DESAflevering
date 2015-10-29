using System;
using System.Collections.Generic;
using System.Linq;
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
                if(p is Teacher)
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
            return studentInfo; ;
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
            
            foreach(Course c in courses)
            {
                if(c.Id == courseId)
                {
                    studentList = c.Student.ToList();
                    foreach(Person p in studentList)
                    {
                        if(p is Student)
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
