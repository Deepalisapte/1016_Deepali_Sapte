using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public static class AccountManager
    {
        public static bool validate(string uname, string pass)
        {
            return AccountDAL.Validate(uname, pass);
        }

        public static bool register(int sid, string name, string password)
        {
            return AccountDAL.Register(sid, name, password);
        }

        public static bool update(int sid, string name, string password)
        {
            return AccountDAL.Update(sid, name, password);
        }

        public static bool registerEmployee(Employee e)
        {
            return AccountDAL.registerEmployee(e);
        }

        public static List<Student> GetStudents()
        {
            return AccountDAL.getStudents();
        }
    }
}
