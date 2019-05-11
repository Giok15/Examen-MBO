using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
   static class BoekDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// boek aanmaken en de boekenvoorraad
        /// </summary>
        /// <param name="data">data = object van entity class boek</param>
        /// <param name="voorraad">voorraad = object van entity class boekvoorraad</param>
        public static void aanmaken(Boek data, Boekvoorraad voorraad)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Boek VALUES(@isbn_nummer, @titel, @auteur, @beschrijving, @genre, @prijs, @uitgeversector_naam, @zichtbaar)";
            cmd.Parameters.AddWithValue("@isbn_nummer", data.isbn_nummer);
            cmd.Parameters.AddWithValue("@titel", data.titel);
            cmd.Parameters.AddWithValue("@auteur", data.auteur);
            cmd.Parameters.AddWithValue("@beschrijving", data.beschrijving);
            cmd.Parameters.AddWithValue("@genre", data.genre);
            cmd.Parameters.AddWithValue("@prijs", data.prijs);
            cmd.Parameters.AddWithValue("@uitgeversector_naam", data.uitgeversector_naam);
            cmd.Parameters.AddWithValue("@zichtbaar", 1);
            cmd.ExecuteNonQuery();

            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Boekvoorraad VALUES(@boek_isbn_nummer, @aantal)";
            cmd.Parameters.AddWithValue("@boek_isbn_nummer", voorraad.boek_isbn_nummer);
            cmd.Parameters.AddWithValue("@aantal", voorraad.aantal);
            cmd.ExecuteNonQuery();

            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// boek wijzigen en de boekenvooraad
        /// </summary>
        /// <param name="data">data = object van entity class boek</param>
        /// <param name="voorraad">voorraad = object van entity class boekvoorraad</param>
        public static void wijzigen(Boek data, Boekvoorraad voorraad)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Boek SET isbn_nummer =@isbn_nummer, titel =@titel, auteur =@auteur, beschrijving =@beschrijving, genre =@genre, zichtbaar =@zichtbaar WHERE isbn_nummer = '" + data.isbn_nummer + "'";
            cmd.Parameters.AddWithValue("@isbn_nummer", data.isbn_nummer);
            cmd.Parameters.AddWithValue("@titel", data.titel);
            cmd.Parameters.AddWithValue("@auteur", data.auteur);
            cmd.Parameters.AddWithValue("@beschrijving", data.beschrijving);
            cmd.Parameters.AddWithValue("@genre", data.genre);
            cmd.Parameters.AddWithValue("@zichtbaar", 1);
            cmd.ExecuteNonQuery();

            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Boekvoorraad SET boek_isbn_nummer =@boek_isbn_nummer, aantal =@aantal WHERE boek_isbn_nummer = '" + voorraad.boek_isbn_nummer + "'";
            cmd.Parameters.AddWithValue("@boek_isbn_nummer", voorraad.boek_isbn_nummer);
            cmd.Parameters.AddWithValue("@aantal", voorraad.aantal);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// verwijder een boek (zet zichtbaar op nul)
        /// </summary>
        /// <param name="data">data = object van entityclass boek</param>
        public static void verwijderen(Boek data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Boek SET zichtbaar =@zichtbaar Where isbn_nummer =" + data.isbn_nummer;
            cmd.Parameters.AddWithValue("@zichtbaar", 0);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// haal een boek op van boek id
        /// </summary>
        /// <param name="data">data = object van entity class boek</param>
        /// <returns>vult de variabel data met alle gegevens</returns>
        public static Boek ophalen(Boek data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Boek WHERE isbn_nummer ='" + data.isbn_nummer + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.titel = (dr["titel"].ToString());
                data.auteur = (dr["auteur"].ToString());
                data.beschrijving = (dr["beschrijving"].ToString());
                data.genre = (dr["genre"].ToString());
                data.prijs = (Convert.ToDecimal(dr["prijs"].ToString()));
                data.uitgeversector_naam = (dr["uitgeversector_naam"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }

        /// <summary>
        /// overzicht van alle boeken
        /// </summary>
        /// <returns>datatable waar alle boeken inzitten</returns>
        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van de boeken in een bestelling
        /// </summary>
        /// <returns>datatable waar de boeken van een bestelling inzitten</returns>
        public static DataTable overzichtBestelling()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT b.isbn_nummer, b.Titel, b.Auteur, bv.aantal as Voorraad, b.Prijs as Prijs_Een FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van alle boeken in de sectoren van medewerker
        /// </summary>
        /// <param name="data">data = where class waar de uitgeversnamen inzitten</param>
        /// <returns>datatable waar de boeken van de bepaalde sectoren inzitten</returns>
        public static DataTable overzichtSectoren(string data)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.uitgeversector u ON b.uitgeversector_naam = u.naam JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer" + data;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        /// <summary>
        /// overzicht van alle boeken van een sector
        /// </summary>
        /// <param name="naam">naam van uitgeverssector</param>
        /// <returns>datatable waar boeken van een sector inzitten</returns>
        public static DataTable overzichtSector(string naam)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.uitgeversector u ON b.uitgeversector_naam = u.naam JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE u.naam ='" + naam + "'";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }
    }
}
