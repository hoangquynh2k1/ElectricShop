using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class DataHelper
    {
        string stcon = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        public DataHelper(string stcon)
        {
            this.stcon = stcon;
            con = new SqlConnection(stcon);
        }
        public DataHelper()
        {
            con = new SqlConnection(stcon);
        }
        public string Open()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            string st = Open();
            if (st != "")
                throw new Exception(st);
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            return cm.ExecuteReader();
        }
        public SqlDataReader StoreReader(string storename, params object[] giatri)
        {
            SqlCommand cm; Open();
            try
            {
                cm = new SqlCommand(storename, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 0; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch { return null; }
        }
        public string ExecuteNonQuery(string sql)
        {
            try
            {   
                Open();
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                Close();
                return "";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public DataTable FillDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string sql)
        {
                //Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
                da.Fill(dt);
                //Close();
                return dt;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < values.Length; i++)
            {
                dr[i] = values[i];
            }
            dt.Rows.Add(dr);
        }
        //"MaSV","001","TenSV","dsghdsbgdsh"
        public void InsertRow1(DataTable dt, params object[] Fields_values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < Fields_values.Length; i += 2)
            {
                dr[Fields_values[i].ToString()] = Fields_values[i + 1].ToString();
            }
        }
    }
}
