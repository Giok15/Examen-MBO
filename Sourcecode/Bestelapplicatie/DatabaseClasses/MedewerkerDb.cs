using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class MedewerkerDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// medewerker aanmaken
        /// </summary>
        /// <param name="data">data = object van entity class medewerker</param>
        public static void aanmaken(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Medewerker values(@voornaam, @achternaam, @gebruikersnaam, @wachtwoord, @rechten, @zichtbaar)";
            cmd.Parameters.AddWithValue("@voornaam", data.voornaam);
            cmd.Parameters.AddWithValue("@achternaam", data.achternaam);
            cmd.Parameters.AddWithValue("@gebruikersnaam", data.gebruikersnaam);
            cmd.Parameters.AddWithValue("@wachtwoord", data.wachtwoord);
            cmd.Parameters.AddWithValue("@rechten", data.rechten);
            cmd.Parameters.AddWithValue("@zichtbaar", 1);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// medewerker wijzigen
        /// </summary>
        /// <param name="data">data = object van entity class medewerker</param>
        public static void wijzigen(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Medewerker set voornaam =@voornaam, achternaam =@achternaam, gebruikersnaam =@gebruikersnaam, wachtwoord =@wachtwoord, rechten =@rechten, zichtbaar =@zichtbaar Where id =" + data.id;
            cmd.Parameters.AddWithValue("@voornaam", data.voornaam);
            cmd.Parameters.AddWithValue("@achternaam", data.achternaam);
            cmd.Parameters.AddWithValue("@gebruikersnaam", data.gebruikersnaam);
            cmd.Parameters.AddWithValue("@wachtwoord", data.wachtwoord);
            cmd.Parameters.AddWithValue("@rechten", data.rechten);
            cmd.Parameters.AddWithValue("@zichtbaar", 1);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// medewerker verwijderen (zichtbaar op null)
        /// </summary>
        /// <param name="data">data = object van entity class medewerker</param>
        public static void verwijderen(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Medewerker SET zichtbaar =@zichtbaar Where id =" + data.id;
            cmd.Parameters.AddWithValue("@zichtbaar", 0);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// medewerker ophalen via id
        /// </summary>
        /// <param name="data">data = object van entity class medewerker</param>
        /// <returns>data met alle gegevens van de medewerker</returns>
        public static Medewerker ophalen(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.medewerker WHERE id ='" + data.id + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.id = (Convert.ToInt32(dr["id"]));
                data.voornaam = (dr["voornaam"].ToString());
                data.achternaam = (dr["achternaam"].ToString());
                data.gebruikersnaam = (dr["gebruikersnaam"].ToString());
                data.wachtwoord = (dr["wachtwoord"].ToString());
                data.rechten = (dr["rechten"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// medewerker ophalen via gebruikersnaam
        /// </summary>
        /// <param name="data">data = object van entity class medewerker</param>
        /// <returns>data met daarin de medewerker gegevens</returns>
        public static Medewerker ophalenGebruikersnaam(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.medewerker WHERE gebruikersnaam ='" + data.gebruikersnaam + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.id = (Convert.ToInt32(dr[("id")]));
                data.voornaam = (dr["voornaam"].ToString());
                data.achternaam = (dr["achternaam"].ToString());
                data.gebruikersnaam = (dr["gebruikersnaam"].ToString());
                data.wachtwoord = (dr["wachtwoord"].ToString());
                data.rechten = (dr["rechten"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// check op account werkt door te kijken of je medewerker terug krijgt
        /// </summary>
        /// <param name="gebruikersnaam">de gebruikersnaam van de medewerker als input heeft gezet</param>
        /// <param name="wachtwoord">het wachtwoord van de medewerker als input heeft gezet</param>
        /// <returns>een volle of lege medewerker</returns>
        public static Medewerker accountOphalen(string gebruikersnaam, string wachtwoord)
        {
            try
            {
                Medewerker data = new Medewerker();
                DatabaseCon.CONN.Open();
                cmd = DatabaseCon.CONN.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Medewerker WHERE gebruikersnaam ='" + gebruikersnaam + "'" + " and wachtwoord = '" + wachtwoord + "' And zichtbaar = 1";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        data.id = (Convert.ToInt32(dr["id"]));
                        data.voornaam = (dr["voornaam"].ToString());
                        data.achternaam = (dr["achternaam"].ToString());
                        data.gebruikersnaam = (dr["gebruikersnaam"].ToString());
                        data.wachtwoord = (dr["wachtwoord"].ToString());
                        data.rechten = (dr["rechten"].ToString());
                    }
                    cmd.ExecuteNonQuery();
                    DatabaseCon.CONN.Close();
                    return data;
                }
                catch
                {
                    DatabaseCon.CONN.Close();
                    return data;
                }
            }
            catch
            {
                MessageBox.Show("Database connectie werkt niet, neem contact op met de programmeur.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); System.Windows.Forms.Application.Exit();
                Medewerker medewerker = new Medewerker();
                return medewerker;
               
            }
            
        }

        /// <summary>
        /// overzicht van alle medewerkers
        /// </summary>
        /// <returns>datatable waar alle medewerkers inzitten</returns>
        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id, Voornaam, Achternaam, Gebruikersnaam, Rechten FROM dbo.Medewerker WHERE zichtbaar = 1 ORDER BY ID DESC";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van de medewerker die bij de logging hoort
        /// </summary>
        /// <param name="id">id van de logging</param>
        /// <returns>datatable waar alle loggings van een medewerker inzitten</returns>
        public static DataTable overzichtLogging(int id)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT m.id, m.Voornaam, m.Achternaam, m.Gebruikersnaam, m.rechten FROM dbo.Medewerker m join dbo.Logging l on l.medewerker_id = m.id WHERE l.id = " + id;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }
    }
}
