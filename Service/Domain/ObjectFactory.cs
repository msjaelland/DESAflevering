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

        public Student CreateStudent(string name, string familyName, string email)
        {
            return new Student
            {
                Name = name,
                FamilyName = familyName,
                Email = email
            };
        }

        public CalendarEntry CreateCalendarEntry(int day, string startHour, string endhour, int courseId)
        {
            return new CalendarEntry
            {
                Day = (Day) day,
                StartHour = startHour,
                EndHour = endhour,
                CourseId = courseId
            };
        }

        public Course CreateCourse(string name, int instance, int instanceYear, string description, int ects)
        {
            return new Course
            {
                Name = name,
                Instance = (CourseInstance) instance,
                InstanceYear = instanceYear,
                Description = description,
                ECTS = ects
            };
        }

        public Teacher CreateTeacher(string name, string familyName, string email)
        {
            return new Teacher
            {
                Name = name,
                FamilyName = familyName,
                Email = email
            };
        }
    }
}
