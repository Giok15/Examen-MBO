using System;
using System.Data.SqlClient;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class BestellingregelDB
    {
        static SqlCommand cmd;

        /// <summary>
        /// Bestellingsregel aanmaken
        /// </summary>
        /// <param name="data">data = object van entity bestellingregel</param>
        public static void aanmaken(Bestellingregel data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Bestellingregel VALUES(@boek_isbn_nummer, @bestelling_id, @aantal)";
            cmd.Parameters.AddWithValue("@boek_isbn_nummer", data.boek_isbn_nummer);
            cmd.Parameters.AddWithValue("@bestelling_id", data.bestelling_id);
            cmd.Parameters.AddWithValue("@aantal", data.aantal);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// Bestellingsregel verwijderen
        /// </summary>
        /// <param name="data">data = object van entity class bestellingsregel</param>
        /// <returns></returns>       
        public static void verwijderen(Bestellingregel data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Bestellingregel WHERE bestelling_id =" + data.bestelling_id;
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

       /// <summary>
       /// overzicht van alle bestelregels
       /// </summary>
       /// <param name="data">data = object van entity class bestellingregels</param>
       /// <returns>datatable waar alle bestellingen inzitten</returns>
        public static DataTable overzicht(Bestellingregel data)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT * FROM dbo.Bestellingregel WHERE bestelling_id =" + data.bestelling_id;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzciht van alle bestelregels van een bestelling
        /// </summary>
        /// <param name="data">data = object van entity bestelregels</param>
        /// <returns>datatable waar de bestellingregels van de bestelling inzitten</returns>
        public static DataTable overzichtBestelling(Bestellingregel data)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT b.isbn_nummer, b.Titel, b.Auteur, bv.aantal as Voorraad, b.Prijs as Prijs_Een FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1 and b.isbn_nummer ='" + data.boek_isbn_nummer + "'";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
            

        }
    }
}
