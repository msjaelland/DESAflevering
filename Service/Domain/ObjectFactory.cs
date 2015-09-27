using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Service.Domain
{
    class ObjectFactory
    {
        #region Singleton
        private static ObjectFactory instance = null;

        private ObjectFactory() { }

        public static ObjectFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectFactory();
                }
                return instance;
            }
        }
        #endregion

        public Student CreateStudent(string _name, string _familyName, string _email)
        {
            Student s = new Student();

            s.Name = _name;
            s.FamilyName = _familyName;
            s.Email = _email;

            return s;
        }

        public CalendarEntry CreateCalendarEntry(int _day, string _startHour, string _endhour, int _courseId)
        {
            CalendarEntry c = new CalendarEntry();

            if(_day == 1)
            {
                c.Day = Day.Monday;
            }
            else if(_day == 2)
            {
                c.Day = Day.Tuesday;
            }
            else if (_day == 3)
            {
                c.Day = Day.Wednesday;
            }
            else if (_day == 4)
            {
                c.Day = Day.Thursday;
            }
            else if (_day == 5)
            {
                c.Day = Day.Friday;
            }
            else if (_day == 6)
            {
                c.Day = Day.Saturday;
            }
            else if (_day == 7)
            {
                c.Day = Day.Sunday;
            }
            c.StartHour = _startHour;
            c.EndHour = _endhour;
            c.CourseId = _courseId;

            return c;
        }

        public Course CreateCourse(string _name, int _instance, int _instanceYear, string _description, int _ects)
        {
            Course c = new Course();

            c.Name = _name;
            if(_instance == 1)
            {
                c.Instance = CourseInstance.Spring;
            }
            else if(_instance == 2)
            {
                c.Instance = CourseInstance.Fall;
            }
            c.InstanceYear = _instanceYear;
            c.Description = _description;
            c.ECTS = _ects;

            return c;
        }

        public Teacher CreateTeacher(string _name, string _familyName, string _email)
        {
            Teacher t = new Teacher();

            t.Name = _name;
            t.FamilyName = _familyName;
            t.Email = _email;

            return t;
        }
    }
}
