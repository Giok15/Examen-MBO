using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class BestellingDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// Bestelling aanmaken
        /// </summary>
        /// <param name="data">data = object van entity bestelling</param>
        public static void aanmaken(Bestelling data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Bestelling VALUES(@besteldatum, @leverdatum, @status, @factuur, @klant_id)";
            cmd.Parameters.AddWithValue("@besteldatum", data.besteldatum);
            cmd.Parameters.AddWithValue("@leverdatum", data.leverdatum);
            cmd.Parameters.AddWithValue("@status", data.status);
            cmd.Parameters.AddWithValue("@factuur", "");
            cmd.Parameters.AddWithValue("@klant_id", data.klant_id);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// Bestelling wijzigen
        /// </summary>
        /// <param name="data">data = object van entity bestelling</param>
        public static void wijzigen(Bestelling data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Bestelling SET leverdatum =@leverdatum, status =@status, factuur =@factuur, klant_id =@klant_id WHERE id =" + data.id;
            cmd.Parameters.AddWithValue("@besteldatum", data.besteldatum);
            cmd.Parameters.AddWithValue("@leverdatum", data.leverdatum);
            cmd.Parameters.AddWithValue("@status", data.status);
            cmd.Parameters.AddWithValue("@factuur", data.factuur);
            cmd.Parameters.AddWithValue("@klant_id", data.klant_id);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// bestelling verwijderen
        /// </summary>
        /// <param name="data">data = object van entity bestelling</param>
        public static void verwijderen(Bestelling data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Bestelling WHERE id =" + data.id;
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// een bestelling via id ophalen
        /// </summary>
        /// <param name="data">data = object van entity bestelling</param>
        /// <returns></returns>
        public static Bestelling ophalen(Bestelling data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Bestelling WHERE id ='" + data.id + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.besteldatum = (Convert.ToDateTime((dr["besteldatum"].ToString())));
                data.leverdatum = (Convert.ToDateTime((dr["leverdatum"].ToString())));
                data.status = (dr["status"].ToString());
                data.factuur = (dr["factuur"].ToString());
                data.klant_id = (Convert.ToInt32(dr["klant_id"].ToString()));
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// overzicht van alle bestellingen
        /// </summary>
        /// <returns>datable waar alle bestellingen inzitten</returns>
        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id as Bestelnummer, Besteldatum, Leverdatum, Status FROM dbo.Bestelling ORDER BY ID DESC";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van alle bestellingen voor een klant
        /// </summary>
        /// <param name="id">id van een klant waar je de bestellingen van wilt zien</param>
        /// <returns>datatable waar de bestellingen van een klant inzitten</returns>
        public static DataTable overzichtKlant(int id)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id as Bestelnummer, Besteldatum, Leverdatum, Status FROM dbo.Bestelling Where klant_id =" + id;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// krijg de laatste aangemaakte bestelling
        /// </summary>
        /// <returns>int = id van de laatste bestelling</returns>
        public static int GetLaatsteBestelling()
        {
            int id = 0;
            DatabaseCon.CONN.Open();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT TOP 1 * FROM dbo.Bestelling ORDER BY ID DESC";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id = (Convert.ToInt32(dr["id"]));
            }

            DatabaseCon.CONN.Close();
            return id;
        }
    }
}
