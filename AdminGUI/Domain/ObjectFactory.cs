using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace AdminGUI.Domain
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

        public Course CreateCourse(string _name, CourseInstance _instance, int _instanceYear, string _description, int _ects)
        {
            Course c = new Course();

            c.Name = _name;
            c.Instance = _instance;
            c.InstanceYear = _instanceYear;
            c.Description = _description;
            c.ECTS = _ects;

            return c;
        }
    }
}
