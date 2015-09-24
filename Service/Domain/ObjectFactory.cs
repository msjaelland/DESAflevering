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
        private static ObjectFactory instance = null;

        private ObjectFactory() { }

        #region Singleton
        public static ObjectFactory Instance
        {
            get
            {
                if(instance == null)
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
    }
}
