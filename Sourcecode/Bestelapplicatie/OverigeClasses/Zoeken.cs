using Bestelapplicatie.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.OverigeClasses
{
    static class Zoeken
    {
        static SqlCommand cmd;
        public static DataTable zoeken(string objectNaam, string zoekEigenschap, string zoekterm, bool is_bestelling = false)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();

            String selectCommand = "";

            //bestelling
            if (objectNaam == "Bestelling")
            {
                if (zoekEigenschap == "Bestelnummer") { zoekEigenschap = "id"; }
                selectCommand = "SELECT id as Bestelnummer, Besteldatum, Leverdatum, Status FROM dbo.Bestelling WHERE " + zoekEigenschap + " LIKE '%" + zoekterm + "%'";
            }

            //boek
            if (objectNaam == "Boek")
            {
                selectCommand = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1 And " + zoekEigenschap + " LIKE '%" + zoekterm + "%'";
            }

            //klant
            if (objectNaam == "Klant")
            {
                selectCommand = "SELECT Id, Voornaam, Achternaam, Adres, Postcode, Woonplaats, Email, Telefoon FROM dbo.klant  WHERE zichtbaar = 1 And " + zoekEigenschap + " LIKE '%" + zoekterm + "%' ORDER BY ID DESC";
            }

            //logging
            if (objectNaam == "Logging")
            {
                selectCommand = "SELECT id, Onderwerp, Handeling, Datum FROM dbo.Logging WHERE " + zoekEigenschap + " LIKE '%" + zoekterm + "%' ORDER BY ID DESC";
            }

            //medewerker
            if (objectNaam == "Medewerker")
            {
                selectCommand = "SELECT id, Voornaam, Achternaam, Gebruikersnaam, Rechten FROM dbo.Medewerker WHERE zichtbaar = 1 And " + zoekEigenschap + " LIKE '%" + zoekterm + "%' ORDER BY ID DESC";
            }

            if (objectNaam == "Boek" && is_bestelling)
            {
                selectCommand = "SELECT b.isbn_nummer, b.Titel, b.Auteur, bv.aantal as Voorraad, b.Prijs as Prijs_Een FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1 AND " + zoekEigenschap + " LIKE '%" + zoekterm + "%'";
            }

          // selectCommand = "SELECT * FROM dbo." + objectNaam + " Where " + zoekEigenschap + " LIKE '%" + zoekterm + "%'";


            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, DatabaseCon.CONNSTRING);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }

        public static DataTable zoekenSelectie(string objectNaam, string zoekEigenschap, string zoekterm, string eigenschapNaam, string id)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();

            String selectCommand = "";

            //bestelling
            if (objectNaam == "Bestelling")
            {
                if (zoekEigenschap == "Bestelnummer") { zoekEigenschap = "id"; }
                selectCommand = "SELECT id as Bestelnummer, Besteldatum, Leverdatum, Status FROM dbo.Bestelling WHERE " + zoekEigenschap + " LIKE '%" + zoekterm + "%' AND " + eigenschapNaam + " = " + id;
            }

            //boek
            if (objectNaam == "Boek")
            {
                selectCommand = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer WHERE b.zichtbaar = 1 And " + zoekEigenschap + " LIKE '%" + zoekterm + "%' AND " + eigenschapNaam + " = '" + id + "'";
            }

            //klant
            if (objectNaam == "Klant")
            {
                selectCommand = "SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.Woonplaats, k.Email, k.Telefoon FROM dbo.klant k JOIN dbo.Bestelling b on b.klant_id = k.id WHERE k." + zoekEigenschap + " LIKE '%" + zoekterm + "%'  AND b." + eigenschapNaam + " = " + id + " ORDER BY ID DESC";
            }

            //logging
            if (objectNaam == "Logging")
            {
                selectCommand = "SELECT id, Onderwerp, Handeling, Datum FROM dbo.Logging WHERE " + zoekEigenschap + " LIKE '%" + zoekterm + "%'  AND " + eigenschapNaam + " = " + id + " ORDER BY ID DESC";
            }

            //medewerker
            if (objectNaam == "Medewerker")
            {
                selectCommand = "SELECT m.id, m.Voornaam, m.Achternaam, m.Gebruikersnaam, m.Rechten FROM dbo.Medewerker m Join dbo.logging l on l.medewerker_id = m.id WHERE m." + zoekEigenschap + " LIKE '%" + zoekterm + "%'  AND l." + eigenschapNaam + " = " + id + " ORDER BY ID DESC";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, DatabaseCon.CONNSTRING);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }

        public static DataTable zoekenRestrictie(string zoekEigenschap, string zoekterm, string data)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();

            String selectCommand;

            selectCommand = "SELECT b.isbn_nummer, b.Titel, b.Auteur, b.Genre, bv.aantal as Voorraad, b.Prijs FROM dbo.Boek b JOIN dbo.Boekvoorraad bv ON bv.boek_isbn_nummer = b.isbn_nummer Where " + zoekEigenschap + " LIKE '%" + zoekterm + "%'" + data;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, DatabaseCon.CONNSTRING);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            DatabaseCon.CONN.Close();
            return table;
        }
    }
}
