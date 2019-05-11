using Bestelapplicatie.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bestelapplicatie.OverigeClasses
{
    static class Validatie
    {
        public static bool is_null(List<string> userInputs)
        {
            foreach (string input in userInputs)
            {
                if (input == "")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool is_uniek(string input, string obj, string eigenschap, string eigenschapId = null, string id = null)
        {
            SqlCommand cmd;
            BindingSource bindingSource1 = new BindingSource();

            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();

            if (eigenschapId != null)
            {
                cmd.CommandText = "SELECT COUNT(*) FROM dbo." + obj + " WHERE " + eigenschap + " = '" + input + "'" + " AND NOT " + eigenschapId + " = " + id;
            }
            else
            {
                cmd.CommandText = "SELECT COUNT(*) FROM dbo." + obj + " WHERE " + eigenschap + " = '" + input + "'";
            }

            if ((int)cmd.ExecuteScalar() > 0)
            {
                DatabaseCon.CONN.Close();
                return false;
            }

            DatabaseCon.CONN.Close();
            return true;
        }

        public static bool is_int(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                return true;
            }
            return false;
        }

        public static bool is_date(string input)
        {
            DateTime value;
            if (DateTime.TryParse(input, out value))
            {
                return true;
            }
            return false;
        }

        public static bool is_postcode(string input)
        {
           input = input.Replace(" ", String.Empty);

            if (input.Length == 6)
            {
                string cijfers =  input.Substring(0,4);
                if (is_int(cijfers))
                {
                    if (Regex.IsMatch(input.Substring(4), @"^[a-zA-Z]+$"))
                    {
                        return true;
                    }
                }
            }
                

            return false;
        }

        public static bool is_email(string input)
        {
            string[] apenstaartje = input.Split('@');
            if (apenstaartje.Length == 2)
            {
                if (apenstaartje[1] != "")
                {
                    string[] punt = apenstaartje[1].Split('.');
                    if (punt.Length == 2)
                    {
                        if (punt[1] != "")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool is_isbn_nummer(string input)
        {
            input = input.Replace(" ", String.Empty);
            input = input.Replace("-", String.Empty);

            if (input.Length == 13)
            {
               string input1 = input.Substring(0, 6);
                if (is_int(input1))
                {
                    string input2 = input.Substring(6);
                    if (is_int(input2))
                    {
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool is_telefoon(string input)
        {
            input = input.Replace(" ", String.Empty);
            input = input.Replace("-", String.Empty);

            if (input[0].ToString() == "+")
            {
                input = input.Replace("+", String.Empty);
                if (is_int(input))
                {
                    if (input.Length == 11)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (is_int(input))
                {
                    if (input.Length == 10)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool is_wachtwoord(string input)
        {
            if (input.Length >= 8)
            {
                if (input.Any(char.IsUpper))
                {
                    if (input.Any(char.IsDigit))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool is_prijs(string input)
        {
            input = input.Replace(",", String.Empty);

            if (is_int(input))
            {
                return true;
            }

            return false;
        }

        public static void is_error(string input, Label lblError, string kolom = null)
        {
            lblError.Visible = true;
            switch (input)
            {
                case "null":
                    lblError.Text = "Niet alle velden zijn ingevuld.";
                    break;

                case "uniek":
                    lblError.Text = "Deze kolom(" + kolom + ") bestaat al.";
                    break;

                case "int":
                    lblError.Text =  kolom + " is geen getal.";
                    break;

                case "date":
                    lblError.Text = kolom + "is geen datum";
                    break;

                case "postcode":
                    lblError.Text = "De postcode is onjuist.";
                    break;

                case "email":
                    lblError.Text = "De email is onjuist.";
                    break;

                case "isbn":
                    lblError.Text = "Isbn-nummer is onjuist.";
                    break;

                case "telefoon":
                    lblError.Text = "Het telefoonnummer is onjuist.";
                    break;

                case "wachtwoord":
                    lblError.Text = "Dit is geen sterk wachtwoord";
                    break;

                case "prijs":
                    lblError.Text = "De prijs is onjuist";
                    break;

                
            }
        }
    }
}
