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

        private DataModelContainer db;

        public DatabaseFacade()
        {
            db = new DataModelContainer();
        }

        public void CreateStudent(Student _student)
        {
            db.PersonSet.Add(_student);
            db.SaveChanges();
        }
    }
}
