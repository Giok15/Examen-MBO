using System;
using System.Data.SqlClient;
using System.Data;

using Bestelapplicatie.EntiteitClasses;

namespace Bestelapplicatie.DatabaseClasses
{
    class BoekvoorraadDb
    {
       static SqlCommand cmd;

        /// <summary>
        /// wijzig de boekenvoorraad
        /// </summary>
        /// <param name="data">data = object van entity class boekvoorraad</param>
        public static void wijzigen(Boekvoorraad data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Boekvoorraad SET boek_isbn_nummer =@boek_isbn_nummer, aantal =@aantal Where boek_isbn_nummer ='" + data.boek_isbn_nummer + "'";
            cmd.Parameters.AddWithValue("@boek_isbn_nummer", data.boek_isbn_nummer);
            cmd.Parameters.AddWithValue("@aantal", data.aantal);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// voorraad ophalen van een boek
        /// </summary>
        /// <param name="isbn">isbn van het boek waar je de voorraad van wilt</param>
        /// <returns>boekvoorraad van het boek</returns>
        public static Boekvoorraad ophalen(string isbn)
        {
            Boekvoorraad data = new Boekvoorraad();
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Boekvoorraad WHERE boek_isbn_nummer ='" + isbn + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.boek_isbn_nummer = (dr["boek_isbn_nummer"].ToString());
                data.aantal = (Convert.ToInt32(dr["aantal"].ToString()));
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }
    }
}
