using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class BoekScherm : UserControl
    {
        bool is_edit;
        Overzicht_groot submain;
        Boek boek = new Boek();
        Boekvoorraad boekvoorraad = new Boekvoorraad();
        BindingSource bindingSource = new BindingSource();
        Uitgeversector uitgever = new Uitgeversector();

        public BoekScherm(Overzicht_groot submain, Uitgeversector uitgever)
        {
            InitializeComponent();
            this.submain = submain;
            this.uitgever = uitgever;
            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName != "System.Windows.Forms.Label")
                {
                    c.Visible = true;
                }
                btnKlaar.Visible = true;
                btnKlaar.Text = "Aanmaken";
            }
        }

        public BoekScherm(Overzicht_groot submain, Boek boek, bool is_edit = false)
        {
            InitializeComponent();
            this.submain = submain;
            this.is_edit = is_edit;
            this.boek = boek;
            if (is_edit)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType().FullName != "System.Windows.Forms.Label")
                    {
                        c.Visible = true;
                    }
                    else
                    {
                        if (c.Name.Substring(0, 6) == "lblGeg")
                        {
                            c.Visible = false;
                        }
                    }
                }

                boekvoorraad.boek_isbn_nummer = boek.isbn_nummer;
                boekvoorraad = BoekvoorraadDb.ophalen(boekvoorraad.boek_isbn_nummer);
                txtVoorraad.Text = Convert.ToString(boekvoorraad.aantal);

                txtIsbnNummer.Text = boek.isbn_nummer.ToString();
                txtTitel.Text = boek.titel.ToString();
                txtAuteur.Text = boek.auteur.ToString();
                txtGenre.Text = boek.genre.ToString();
                txtBeschrijving.Text = boek.beschrijving.ToString();
                txtPrijs.Text = boek.prijs.ToString();
                btnKlaar.Visible = true;
                btnKlaar.Text = "Wijzigen";
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType().FullName == "System.Windows.Forms.Label" && c.Name != "lblError")
                    {
                        c.Visible = true;
                    }
                }
                txtBeschrijving.Visible = true;

                lblGegIsbnNummer.Text = boek.isbn_nummer.ToString();
                lblGegTitel.Text = boek.titel.ToString();
                lblGegAuteur.Text = boek.auteur.ToString();
                lblGegGenre.Text = boek.genre.ToString();
                lblGegPrijs.Text = "€ " + boek.prijs.ToString();
                lblGegVoorraad.Text = BoekvoorraadDb.ophalen(boek.isbn_nummer).aantal.ToString();

                txtBeschrijving.Text = boek.beschrijving.ToString();
                txtBeschrijving.ReadOnly = true;
                btnKlaar.Visible = false;
            }
        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            List<string> input = new List<string>();
            string eigenschapId = null;
            string id = null;

            input.Add(txtIsbnNummer.Text);
            input.Add(txtTitel.Text);
            input.Add(txtAuteur.Text);
            input.Add(txtGenre.Text);
            input.Add(txtPrijs.Text);
            input.Add(txtBeschrijving.Text);

            if (is_edit)
            {
                eigenschapId = "isbn_nummer";
                id = Convert.ToString(boek.isbn_nummer);
            }

            if (!Validatie.is_null(input))
            {
                if (Validatie.is_isbn_nummer(txtIsbnNummer.Text))
                {
                    if (Validatie.is_uniek(txtIsbnNummer.Text, "Boek", "isbn_nummer", eigenschapId, id))
                    {
                        if (Validatie.is_prijs(txtPrijs.Text))
                        {
                            if(Validatie.is_int(txtVoorraad.Text))
                            {
                                boek.isbn_nummer = txtIsbnNummer.Text;
                                boek.titel = txtTitel.Text;
                                boek.auteur = txtAuteur.Text;
                                boek.genre = txtGenre.Text;
                                boek.prijs = Convert.ToDecimal(txtPrijs.Text);
                                boek.beschrijving = txtBeschrijving.Text;

                                boekvoorraad.aantal = Convert.ToInt32(txtVoorraad.Text);
                                boekvoorraad.boek_isbn_nummer = boek.isbn_nummer;

                                if (is_edit)
                                {
                                    BoekDb.wijzigen(boek, boekvoorraad);
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[submain.selectierow].Selected = true;
                                    submain.dgvOverzichtClick(is_edit);

                                    Logging logging = new Logging();
                                    logging.onderwerp = "Boek";
                                    logging.handeling = "Gewijzigd";
                                    logging.datum = DateTime.Now;
                                    logging.medewerker_id = Account.getMedewerker().id;
                                    logging.boek_isbn_nummer = boek.isbn_nummer;

                                    LoggingDb.aanmaken(logging);
                                }
                                else
                                {
                                    boek.uitgeversector_naam = uitgever.naam;
                                    BoekDb.aanmaken(boek, boekvoorraad);
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[0].Selected = true;
                                    submain.dgvOverzichtClick();

                                    Logging logging = new Logging();
                                    logging.onderwerp = "Boek";
                                    logging.handeling = "Aangemaakt";
                                    logging.datum = DateTime.Now;
                                    logging.medewerker_id = Account.getMedewerker().id;
                                    logging.boek_isbn_nummer = boek.isbn_nummer;

                                    LoggingDb.aanmaken(logging);
                                }
                            }
                            else
                            {
                                Validatie.is_error("int", lblError, "Voorraad");
                            }
                        }
                        else
                        {
                            Validatie.is_error("prijs", lblError);
                        }
                    }
                    else
                    {
                        Validatie.is_error("uniek", lblError, "Isbn-nummer");
                    }
                }
                else
                {
                    Validatie.is_error("isbn", lblError);
                }
            }
            else
            {
                Validatie.is_error("null", lblError);
            }
        }
    }
}
