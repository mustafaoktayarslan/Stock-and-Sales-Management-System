using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSystem
{
    internal class DBConnect
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        private string connectionstring;
        
        public string myConnection()
        {
            connectionstring = @"Data Source=.;Initial Catalog=MarketDB;Integrated Security=True";
            return connectionstring;
        }

        public DataTable getTable (string qury)
        {
            con.ConnectionString=myConnection();
            cmd= new SqlCommand(qury,con);
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void ExecuteQuery(String sql)
        {
            try
            {
                con.ConnectionString = myConnection();
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public String getPassword(string username)
        {
            string password = "";
            con.ConnectionString = myConnection();
            con.Open();
            cmd = new SqlCommand("SELECT password FROM tbUser WHERE username = '" + username + "'", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }
            dr.Close();
            con.Close();
            return password;
        }

        public double ExtractData(string sql)
        {

            con = new SqlConnection();
            con.ConnectionString = myConnection();
            con.Open();
            cmd = new SqlCommand(sql, con);
            double data = double.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return data;

        }
    }
}
