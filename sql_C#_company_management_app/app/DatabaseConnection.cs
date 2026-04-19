using System;
using System.Data.SqlClient;


namespace PlaceHolder
{
    public class DatabaseConnection
    {
        public SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = localhost\\SQLEXPRESS;"
                + "Initial Catalog = CanEle;"
                + "Integrated Security = True;");
        }


        public bool verifySGBDConnection()
        {
            SqlConnection conn = getSGBDConnection();
            try
            {
                conn.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
