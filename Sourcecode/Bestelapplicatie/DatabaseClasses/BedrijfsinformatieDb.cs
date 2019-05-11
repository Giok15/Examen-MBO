using System.Data.SqlClient;
using Bestelapplicatie.EntiteitClasses;
using System.Data;
using System;

namespace Bestelapplicatie.DatabaseClasses
{
   static class BedrijfsinformatieDb
    {
        static SqlCommand cmd;

        /// <summary>
        /// Wijzig de bedrijfsinformatie.
        /// </summary>
        /// <param name="data">data = object van entity class bedrijfsinformatie</param>
        public static void wijzigen(Bedrijfsinformatie data)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Bedrijfsinformatie SET naam =@naam, adres =@adres, postcode =@postcode, plaats =@plaats, rekeningnummer =@rekeningnummer, telefoonnummer =@telefoonnummer, btw_nummer =@btw_nummer  where kvk_nummer ='" + data.kvk_nummer + "'";
            cmd.Parameters.AddWithValue("@naam", data.naam);
            cmd.Parameters.AddWithValue("@adres", data.adres);
            cmd.Parameters.AddWithValue("@postcode", data.postcode);
            cmd.Parameters.AddWithValue("@plaats", data.plaats);
            cmd.Parameters.AddWithValue("@rekeningnummer", data.rekeningnummer);
            cmd.Parameters.AddWithValue("@telefoonnummer", data.telefoonnummer);
            cmd.Parameters.AddWithValue("@btw_nummer", data.btw_nummer);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        /// <summary>
        /// Haal de bedrijfsinformatie op.
        /// </summary>
        /// <returns>Een object van entity class bedrijfsinformatie</returns>
        public static Bedrijfsinformatie ophalen()
        {
            Bedrijfsinformatie data = new Bedrijfsinformatie();
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Bedrijfsinformatie WHERE kvk_nummer = 01101855";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.kvk_nummer = Convert.ToInt32((dr["kvk_nummer"].ToString()));
                data.naam = (dr["naam"].ToString());
                data.adres = (dr["adres"].ToString());
                data.postcode = (dr["postcode"].ToString());
                data.plaats = (dr["plaats"].ToString());
                data.rekeningnummer = (dr["rekeningnummer"].ToString());
                data.telefoonnummer = (dr["telefoonnummer"].ToString());
                data.btw_nummer = (dr["btw_nummer"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
            return data;
        }
    }
}
