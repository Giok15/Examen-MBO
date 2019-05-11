using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class LoggingDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// de logging aanmaken
        /// </summary>
        /// <param name="data">data = object van entity class logging</param>
        public static void aanmaken(Logging data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Logging VALUES(@onderwerp, @handeling, @datum, @medewerker_id, @boek_isbn_nummer, @bestelling_id, @klant_id)";
            cmd.Parameters.AddWithValue("@onderwerp", data.onderwerp);
            cmd.Parameters.AddWithValue("@handeling", data.handeling);
            cmd.Parameters.AddWithValue("@datum", data.datum);
            cmd.Parameters.AddWithValue("@medewerker_id", data.medewerker_id);
            cmd.Parameters.AddWithValue("@boek_isbn_nummer", data.boek_isbn_nummer);
            cmd.Parameters.AddWithValue("@bestelling_id", data.bestelling_id);
            cmd.Parameters.AddWithValue("@klant_id", data.klant_id);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// de logging via een id ophalen
        /// </summary>
        /// <param name="data">data = object van entity class logging</param>
        /// <returns>het object data met alle gegevens ingevuld</returns>
        public static Logging ophalen(Logging data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Logging WHERE id =" + data.id;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.onderwerp = (dr["onderwerp"].ToString());
                data.handeling = (dr["handeling"].ToString());
                data.datum = (Convert.ToDateTime(dr["datum"].ToString()));
                data.boek_isbn_nummer = (dr["boek_isbn_nummer"].ToString());
                data.bestelling_id = (Convert.ToInt32(dr["bestelling_id"]));
                data.klant_id = (Convert.ToInt32(dr["klant_id"]));
                data.medewerker_id = ((Convert.ToInt32(dr["medewerker_id"].ToString())));
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// overzicht van alle loggings
        /// </summary>
        /// <returns>datatable waar de loggings inzitten</returns>
        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id, Onderwerp, Handeling, Datum FROM dbo.Logging ORDER BY ID DESC";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van alle loggings van een medewerker
        /// </summary>
        /// <param name="id">id van de medewerker waar je de loggign van wilt terugkrijgen</param>
        /// <returns>datatable waar de loggings van de medewerkers inzitten</returns>
        public static DataTable overzichtMedewerker(int id)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id, Onderwerp, Handeling, Datum FROM dbo.Logging WHERE medewerker_id =" + id;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }
    }
}
