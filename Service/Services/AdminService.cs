using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Types;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in both code and config file together.
    public class AdminService : IAdminService
    {
        DomainFacade df;

        public AdminService()
        {
            df = new DomainFacade();
        }

        public Student GetStudent(string _name)
        {
            return df.GetStudent(_name);
        }

        public void CreateStudent(string _name, string _familyName, string _email)
        {
            df.CreateStudent(_name, _familyName, _email);
        }
    }
}
