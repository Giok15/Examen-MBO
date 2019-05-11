using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class KlantScherm : UserControl
    {
        Klant klant = new Klant();
        Boolean is_edit;
        Overzicht_klein submain;

        public KlantScherm(Overzicht_klein submain)
        {
            InitializeComponent();
            this.submain = submain;
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

        public KlantScherm(Overzicht_klein submain, Klant klant, Boolean is_edit = false)
        {
            InitializeComponent();
            this.is_edit = is_edit;
            this.klant = klant;
            this.submain = submain;

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

                txtVoornaam.Text = klant.voornaam.ToString();
                txtAchternaam.Text = klant.achternaam.ToString();
                txtAdres.Text = klant.adres.ToString();
                txtPostcode.Text = klant.postcode.ToString();
                txtWoonplaats.Text = klant.woonplaats.ToString();
                txtTelefoon.Text = klant.telefoon.ToString();
                txtEmail.Text = klant.email.ToString();
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

                lblGegVoornaam.Text = klant.voornaam.ToString();
                lblGegAchternaam.Text = klant.achternaam.ToString();
                lblGegAdres.Text = klant.adres.ToString();
                lblGegPostcode.Text = klant.postcode.ToString();
                lblGegWoonplaats.Text = klant.woonplaats.ToString();
                lblGegTelefoon.Text = klant.telefoon.ToString();
                lblGegEmail.Text = klant.email.ToString();
                btnKlaar.Visible = false;
            }
        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            List<string> input = new List<string>();
            string eigenschapId = null;
            string id = null;

            input.Add(txtVoornaam.Text);
            input.Add(txtAchternaam.Text);
            input.Add(txtAdres.Text);
            input.Add(txtPostcode.Text);
            input.Add(txtWoonplaats.Text);
            input.Add(txtTelefoon.Text);
            input.Add(txtEmail.Text);

            if (is_edit)
            {
                eigenschapId = "id";
                id = Convert.ToString(klant.id);
            }

            if (!Validatie.is_null(input))
            {
                if (Validatie.is_postcode(txtPostcode.Text))
                {
                    if (Validatie.is_telefoon(txtTelefoon.Text))
                    {
                        if (Validatie.is_email(txtEmail.Text))
                        {
                            if (Validatie.is_uniek(txtEmail.Text, "Klant", "email", eigenschapId, id))
                            {
                                klant.voornaam = txtVoornaam.Text;
                                klant.achternaam = txtAchternaam.Text;
                                klant.adres = txtAdres.Text;
                                klant.postcode = txtPostcode.Text;
                                klant.woonplaats = txtWoonplaats.Text;
                                klant.telefoon = txtTelefoon.Text;
                                klant.email = txtEmail.Text;

                                if (is_edit)
                                {
                                    KlantDb.wijzigen(klant);
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[submain.selectierow].Selected = true;
                                    submain.dgvOverzichtClick(is_edit);

                                    Logging logging = new Logging();
                                    logging.onderwerp = "Klant";
                                    logging.handeling = "Gewijzigd";
                                    logging.datum = DateTime.Now;
                                    logging.medewerker_id = Account.getMedewerker().id;
                                    logging.boek_isbn_nummer = "";
                                    logging.klant_id = klant.id;

                                    LoggingDb.aanmaken(logging);
                                }
                                else
                                {
                                    KlantDb.aanmaken(klant);
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[0].Selected = true;
                                    submain.dgvOverzichtClick();

                                    klant.id = KlantDb.GetLaatsteKlant();

                                    Logging logging = new Logging();
                                    logging.onderwerp = "Klant";
                                    logging.handeling = "Aangemaakt";
                                    logging.datum = DateTime.Now;
                                    logging.medewerker_id = Account.getMedewerker().id;
                                    logging.boek_isbn_nummer = "";
                                    logging.klant_id = klant.id;

                                    LoggingDb.aanmaken(logging);
                                }
                            }
                            else
                            {
                                Validatie.is_error("uniek", lblError, "Email");
                            }
                        }
                        else
                        {
                            Validatie.is_error("email", lblError);
                        }
                    }
                    else
                    {
                        Validatie.is_error("telefoon", lblError);
                    }
                }
                else
                {
                    Validatie.is_error("postcode", lblError);
                }
            }
            else
            {
                Validatie.is_error("null", lblError);
            }
        }
    }
}
