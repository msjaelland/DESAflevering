using Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Service.Facade
{
    class DomainFacade
    {
        DatabaseFacade dbf;

        public DomainFacade()
        {
            dbf = new DatabaseFacade();
        }

        public Student GetStudent(string _name)
        {
            return null;
        }

        public void CreateStudent(string _name, string _familyName, string _email)
        {
            dbf.CreateStudent(ObjectFactory.Instance.CreateStudent(_name, _familyName, _email));
        }
    }
}
