using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class KlantDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// klant aanmaken 
        /// </summary>
        /// <param name="data">data = object van entity class klant</param>
        public static void aanmaken(Klant data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Klant VALUES(@voornaam, @achternaam, @adres, @postcode, @woonplaats, @email, @telefoon, @zichtbaar)";
            cmd.Parameters.AddWithValue("@voornaam", data.voornaam);
            cmd.Parameters.AddWithValue("@achternaam", data.achternaam);
            cmd.Parameters.AddWithValue("@adres", data.adres);
            cmd.Parameters.AddWithValue("@postcode", data.postcode);
            cmd.Parameters.AddWithValue("@woonplaats", data.woonplaats);
            cmd.Parameters.AddWithValue("@email", data.email);
            cmd.Parameters.AddWithValue("@telefoon", data.telefoon);
            cmd.Parameters.AddWithValue("@zichtbaar", 1);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// klant wijzigen
        /// </summary>
        /// <param name="data">data = object van entity class klant</param>
        public static void wijzigen(Klant data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Klant SET voornaam =@voornaam, achternaam =@achternaam, adres =@adres, postcode =@postcode, woonplaats =@woonplaats, email =@email, telefoon =@telefoon Where id =" + data.id;     
            cmd.Parameters.AddWithValue("@voornaam", data.voornaam);
            cmd.Parameters.AddWithValue("@achternaam", data.achternaam);
            cmd.Parameters.AddWithValue("@adres", data.adres);
            cmd.Parameters.AddWithValue("@postcode", data.postcode);
            cmd.Parameters.AddWithValue("@woonplaats", data.woonplaats);
            cmd.Parameters.AddWithValue("@email", data.email);
            cmd.Parameters.AddWithValue("@telefoon", data.telefoon);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// klant verwijderen (zichtbaar = 0)
        /// </summary>
        /// <param name="data">data = object van entity class klant</param>
        public static void verwijderen(Klant data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Klant SET zichtbaar =@zichtbaar Where id =" + data.id;
            cmd.Parameters.AddWithValue("@zichtbaar", 0);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// klant ophalen met id
        /// </summary>
        /// <param name="data">data = object van entity class klant</param>
        /// <returns>het object data met alle gegevens</returns>
        public static Klant ophalen(Klant data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Klant WHERE id ='" + data.id + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.id = (Convert.ToInt32(dr["id"]));
                data.voornaam = (dr["voornaam"].ToString());
                data.achternaam = (dr["achternaam"].ToString());
                data.adres = (dr["adres"].ToString());
                data.postcode = (dr["postcode"].ToString());
                data.woonplaats = (dr["woonplaats"].ToString());
                data.email = (dr["email"].ToString());
                data.telefoon = (dr["telefoon"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// overzicht van alle klanten
        /// </summary>
        /// <returns>datatable waar alle klanten inzitten</returns>
        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT Id, Voornaam, Achternaam, Adres, Postcode, Woonplaats, Email, Telefoon FROM dbo.klant  WHERE zichtbaar = 1 ORDER BY ID DESC";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzciht van alle klanten van een bestelling
        /// </summary>
        /// <param name="id">id van een bestelling waar je de klant van wilt</param>
        /// <returns>datatable waar de klant inzit van de bestelling</returns>
        public static DataTable overzichtBestelling(int id)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode,k. Woonplaats, k.Email, k.Telefoon FROM dbo.klant k join dbo.Bestelling b on k.id = b.klant_id where b.id =" + id;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// krijg de laatste klant die gemaakt is
        /// </summary>
        /// <returns>int met id van de laatste klant</returns>
        public static int GetLaatsteKlant()
        {
            int id = 0;
            DatabaseCon.CONN.Open();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT TOP 1 * FROM dbo.Klant ORDER BY ID DESC";
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
