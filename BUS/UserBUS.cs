using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using OJB;

namespace BUS
{
    public class UserBUS
    {
        UserDAO UserDAO = new UserDAO();
        public User GetUser(string us,string pw)
        {
            return UserDAO.GetUser(us, pw);
        }
    }
}
