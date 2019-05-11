using System;
using System.Windows.Forms;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class Loggingscherm : UserControl
    {
        Medewerker medewerker = new Medewerker();
        Klant klant = new Klant();
        Boek boek = new Boek();

        public Loggingscherm(Logging logging)
        {
            InitializeComponent();

                lblGegOnderwerp.Text = logging.onderwerp.ToString();

            if(logging.klant_id != 0)
            {
                klant.id = Convert.ToInt32(logging.klant_id);
                klant = KlantDb.ophalen(klant);
                lblId.Text = "Email:";
                lblGegId.Text = klant.email.ToString();
            }
            if (logging.bestelling_id != 0)
            {
                lblId.Text = "bestelnummer:";
                lblGegId.Text = logging.bestelling_id.ToString();
            }
            if (logging.boek_isbn_nummer != "")
            {
                boek.isbn_nummer = logging.boek_isbn_nummer;
                boek = BoekDb.ophalen(boek);
                lblId.Text = "isbn-nummer:";
                lblGegId.Text = boek.isbn_nummer.ToString();
            }

                lblGegHandeling.Text = logging.handeling.ToString();
                lblGegDatum.Text = logging.datum.ToString().Substring(0, logging.datum.ToString().Length - 3);

                medewerker.id = logging.medewerker_id;
                medewerker = MedewerkerDb.ophalen(medewerker);
                lblGegMedewerkerNaam.Text = medewerker.voornaam.ToString() + " " + medewerker.achternaam.ToString();
                lblGegMedewerkerGebruikersnaam.Text = medewerker.gebruikersnaam.ToString();
        }
    }
}
