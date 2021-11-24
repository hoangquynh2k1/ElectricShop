using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJB
{
    public class User
    {
        public string Username;
        public string Password;
        public User(string us,string pw)
        {
            this.Username = us;
            this.Password = pw;
        }
    }
}
