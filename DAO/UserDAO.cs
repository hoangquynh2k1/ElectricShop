using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OJB;
using System.Data;

namespace DAO
{
    public class UserDAO
    {
        public User GetUser(string Username, string Passwork)
        {
            DataHelper dataHelper = new DataHelper();
            string sql = "select* from Users where Username = '"+Username+"' and Passwork = '"+ Passwork + "'";
            DataTable dataTable = dataHelper.FillDataTable(sql);
            if (dataTable.Rows.Count <= 0) return null;
            else
            {
                User user = new User(dataTable.Rows[0][0].ToString(), dataTable.Rows[0][1].ToString());
                return user;
            }    
        }
    }
}
