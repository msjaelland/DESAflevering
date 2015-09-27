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

        public void CreateTeacher(Teacher _teacher)
        {
            db.PersonSet.Add(_teacher);
            db.SaveChanges();
        }

        public List<int> GetListOfTeacherId()
        {
            List<int> _teacherIdList = new List<int>();

            var persons = from p in db.PersonSet select p;

            foreach (Teacher t in persons)
            {
                _teacherIdList.Add(t.Id);
            }
            return _teacherIdList;
        }

        public List<string> GetTeacherInfo(int _id)
        {
            List<string> _teacherInfo = new List<string>();

            var _persons = from p in db.PersonSet select p;

            foreach (Teacher t in _persons)
            {
                if (t.Id == _id)
                {
                    _teacherInfo.Add(t.Id.ToString());
                    _teacherInfo.Add(t.Name);
                    _teacherInfo.Add(t.FamilyName);
                    _teacherInfo.Add(t.Email);
                }
            }
            return _teacherInfo;
        }

        public string GetTeacherName(int _id)
        {
            var _persons = from p in db.PersonSet select p;

            foreach (Teacher t in _persons)
            {
                if (t.Id == _id)
                {
                    return t.Name + t.FamilyName;
                }
            }
            return null;
        }

        public void AssignTeacher(int _teacherId, int _courseId)
        {
            var _courses = from c in db.CourseSet select c;

            foreach (Course c in _courses)
            {
                if (c.Id == _courseId)
                {
                    c.TeacherId = _teacherId;
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region Student stuff

        public void CreateStudent(Student _student)
        {
            db.PersonSet.Add(_student);
            db.SaveChanges();
        }

        public List<string> GetStudentByEmail(string _email)
        {
            List<string> _studentInfo = new List<string>();
            var _students = from s in db.PersonSet select s;

            foreach (Student s in _students)
            {
                if (s.Email == _email)
                {
                    _studentInfo.Add(s.Id.ToString());
                    _studentInfo.Add(s.Name);
                    _studentInfo.Add(s.FamilyName);
                    _studentInfo.Add(s.Email);
                }
            }
            return _studentInfo; ;
        }
        #endregion

        #region Course stuff

        public void CreateCourse(Course _course)
        {
            db.CourseSet.Add(_course);
            db.SaveChanges();
        }

        public List<int> GetListOfCourseId()
        {
            var _courses = from c in db.CourseSet select c.Id;

            return _courses.ToList<int>();
        }

        public List<string> GetCourseInfo(int _id)
        {
            List<string> _courseInfo = new List<string>();

            var _courses = from c in db.CourseSet select c;

            foreach (Course c in _courses)
            {
                if (c.Id == _id)
                {
                    _courseInfo.Add(c.Id.ToString());
                    _courseInfo.Add(c.Name);
                    _courseInfo.Add(c.Instance.ToString() + " " + c.InstanceYear.ToString());
                    _courseInfo.Add(c.Description);
                    _courseInfo.Add(c.ECTS.ToString());
                    _courseInfo.Add(c.TeacherId.ToString());
                    _courseInfo.Add(GetTeacherName(c.TeacherId));

                    return _courseInfo;
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
