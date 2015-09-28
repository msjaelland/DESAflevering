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

            foreach (Teacher t in persons)
            {
                teacherIdList.Add(t.Id);
            }
            return teacherIdList;
        }

        public List<string> GetTeacherInfo(int _id)
        {
            List<string> teacherInfo = new List<string>();

            var persons = from p in db.PersonSet select p;

            foreach (Teacher t in persons)
            {
                if (t.Id == _id)
                {
                    teacherInfo.Add(t.Id.ToString());
                    teacherInfo.Add(t.Name);
                    teacherInfo.Add(t.FamilyName);
                    teacherInfo.Add(t.Email);
                }
            }
            return teacherInfo;
        }

        public string GetTeacherName(int id)
        {
            var persons = from p in db.PersonSet select p;

            foreach (Teacher t in persons)
            {
                if (t.Id == id)
                {
                    return t.Name + t.FamilyName;
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

        public List<string> GetStudentByEmail(string email)
        {
            List<string> studentInfo = new List<string>();
            var students = from s in db.PersonSet select s;

            foreach (Student s in students)
            {
                if (s.Email == email)
                {
                    studentInfo.Add(s.Id.ToString());
                    studentInfo.Add(s.Name);
                    studentInfo.Add(s.FamilyName);
                    studentInfo.Add(s.Email);
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

        public List<string> GetCourseInfo(int _id)
        {
            List<string> courseInfo = new List<string>();

            var courses = from c in db.CourseSet select c;

            foreach (Course c in courses)
            {
                if (c.Id == _id)
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
