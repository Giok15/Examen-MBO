using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    static class UitgeversectorDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// aanmaken van een sectorgroep
        /// </summary>
        /// <param name="data"></param>
        public static void aanmakenSectorgroep(Sectorgroep data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Sectorgroep values(@medewerker_id, @uitgeversector_naam)";
            cmd.Parameters.AddWithValue("@medewerker_id", data.medewerker_id);
            cmd.Parameters.AddWithValue("@uitgeversector_naam", data.uitgeversector_naam);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        public static void verwijderenSectorgroep(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Sectorgroep WHERE medewerker_id =" + data.id;
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        public static DataTable ophalen(Medewerker data)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT naam as Uitgeversector FROM dbo.uitgeversector u JOIN dbo.sectorgroep s ON u.naam = s.uitgeversector_naam  WHERE s.medewerker_id ='" + data.id + "'";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        public static DataTable overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT naam as Uitgeversector FROM dbo.Uitgeversector";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        public static DataTable overzichtUitgever(string isbn_nummer)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT naam as Uitgeversector FROM dbo.Uitgeversector u Join dbo.Boek b on b.uitgeversector_naam = u.naam  WHERE b.isbn_nummer ='" + isbn_nummer + "'";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter1.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }
    }
}
