
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Entities;

namespace WebApplication2.Models
{
    public class BaseData
    {
        MySqlConnection connection;
        Client client = new Client();
        Invoices_detail invoice = new Invoices_detail();

        public BaseData()
        {
            connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=; database = factura1; SSLMode = none");
        }
        public string ejecutarSql(string sql)
        {
            string result = "";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();

                if (rows > -1)
                {
                    result = "Correcto";
                }
                else
                {
                    result = "Incorrecto";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

    }
}
