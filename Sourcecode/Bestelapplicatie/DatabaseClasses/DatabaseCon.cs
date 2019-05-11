using System;
using System.Data.SqlClient;

namespace Bestelapplicatie.DatabaseClasses
{
    public static class DatabaseCon
    {
        public static SqlConnection CONN = new SqlConnection();

        public static string CONNSTRING = @"Server = WIN-8EDIT8UPK0L\SQLEXPRESS;Database=HetBoekjeDB;User Id = HetBoekjeAdmin;password= root";
       // public static string CONNSTRING = @"Data Source = GIO-PC\SQLEXPRESS;Initial Catalog = HetBoekjeDB; Integrated Security = True; Pooling=False";

        /// <summary>
        /// kijkt of de connstring connectie is
        /// </summary>
        /// <returns>boolean of de connectie goed is of niet</returns>
        public static Boolean getConnectieString()
        {
            try
            {
                CONN.ConnectionString = CONNSTRING;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
