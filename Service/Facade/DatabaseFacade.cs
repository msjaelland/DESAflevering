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

        public string[] GetStudentByEmail(string _email)
        {
            string[] studentArray = new string[4];
            var students = from s in db.PersonSet select s;

            foreach(Student s in students)
            {
                if(s.Email == _email)
                {
                    studentArray[0] = s.Id.ToString();
                    studentArray[1] = s.Name;
                    studentArray[2] = s.FamilyName;
                    studentArray[3] = s.Email;
                }
            }
            return studentArray; ;
        }

        public void CreateStudent(Student _student)
        {
            db.PersonSet.Add(_student);
            db.SaveChanges();
        }

        public void AddCalendarEntry(CalendarEntry _calendarEntry)
        {
            db.CalendarEntrySet.Add(_calendarEntry);
            db.SaveChanges();
        }

        public void AssignTeacher(int _teacherId, int _courseId)
        {
            var courses = from c in db.CourseSet select c;

            foreach(Course c in courses)
            {
                if(c.Id == _courseId)
                {
                    c.TeacherId = _teacherId;
                    db.SaveChanges();
                }
            }
        }

        public void CreateCourse(Course _course)
        {
            db.CourseSet.Add(_course);
            db.SaveChanges();
        }

        public List<string> GetCourseInfo(int _id)
        {
            List<string> course = new List<string>();

            var courses = from c in db.CourseSet select c;

            foreach(Course c in courses)
            {
                if(c.Id == _id)
                {
                    course.Add(c.Id.ToString());
                    course.Add(c.Name);
                    course.Add(c.Instance.ToString() + " " + c.InstanceYear.ToString());
                    course.Add(c.Description);
                    course.Add(c.ECTS.ToString());
                    course.Add(c.TeacherId.ToString());
                    course.Add(GetTeacherName(c.TeacherId));

                    return course;
                }
            }
            return null;
        }

        public string GetTeacherName(int _id)
        {
            var persons = from p in db.PersonSet select p;

            foreach(Teacher t in persons)
            {
                if(t.Id == _id)
                {
                    return t.Name + t.FamilyName;
                }
            }
            return null;
        }

        public List<int> GetListOfCourseId()
        {
            var courses = from c in db.CourseSet select c.Id;

            return courses.ToList<int>();
        }
    }
}
