using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class BedrijfScherm : UserControl
    {
        Bedrijfsinformatie bedrijfsinformatie;

        public BedrijfScherm(Bedrijfsinformatie bedrijfsinformatie, Boolean is_edit)
        {
            InitializeComponent();
            gegevens(bedrijfsinformatie, is_edit);
        }

        //methode om te kijken of het edit scherm of het laten zien scherm moet worden geladen
        private void gegevens(Bedrijfsinformatie bedrijfsinformatie, Boolean is_edit)
        {
            this.bedrijfsinformatie = bedrijfsinformatie;
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

                txtKvknummer.Text = bedrijfsinformatie.kvk_nummer.ToString();
                txtBedrijfsnaam.Text = bedrijfsinformatie.naam.ToString();
                txtAdres.Text = bedrijfsinformatie.adres.ToString();
                txtPostcode.Text = bedrijfsinformatie.postcode.ToString();
                txtPlaats.Text = bedrijfsinformatie.plaats.ToString();
                txtRekeningnummer.Text = bedrijfsinformatie.rekeningnummer.ToString();
                txtTelefoonnummer.Text = bedrijfsinformatie.telefoonnummer.ToString();
                txtBtwnummer.Text = bedrijfsinformatie.btw_nummer.ToString();
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

                lblGegKvknummer.Text = bedrijfsinformatie.kvk_nummer.ToString();
                lblGegBedrijfsnaam.Text = bedrijfsinformatie.naam.ToString();
                lblGegAdres.Text = bedrijfsinformatie.adres.ToString();
                lblGegPostcode.Text = bedrijfsinformatie.postcode.ToString();
                lblGegPlaats.Text = bedrijfsinformatie.plaats.ToString();
                lblGegRekeningnummer.Text = bedrijfsinformatie.rekeningnummer.ToString();
                lblGegTelefoonnummer.Text = bedrijfsinformatie.telefoonnummer.ToString();
                lblGegBtwnummer.Text = bedrijfsinformatie.btw_nummer.ToString();
            }
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            gegevens(bedrijfsinformatie, true);
        }

        private void Wijzigen_Click(object sender, EventArgs e)
        {
            List<string> input = new List<string>();

            input.Add(txtKvknummer.Text);
            input.Add(txtBedrijfsnaam.Text);
            input.Add(txtAdres.Text);
            input.Add(txtPostcode.Text);
            input.Add(txtPlaats.Text);
            input.Add(txtRekeningnummer.Text);
            input.Add(txtTelefoonnummer.Text);
            input.Add(txtBtwnummer.Text);


            if (!Validatie.is_null(input))
            {
                if (Validatie.is_int(txtKvknummer.Text))
                {
                    if (Validatie.is_postcode(txtPostcode.Text))
                    {
                        if (Validatie.is_telefoon(txtTelefoonnummer.Text))
                        {
                            bedrijfsinformatie.kvk_nummer = Convert.ToInt32(txtKvknummer.Text);
                            bedrijfsinformatie.naam = txtBedrijfsnaam.Text;
                            bedrijfsinformatie.adres = txtAdres.Text;
                            bedrijfsinformatie.postcode = txtPostcode.Text;
                            bedrijfsinformatie.plaats = txtPlaats.Text;
                            bedrijfsinformatie.rekeningnummer = txtRekeningnummer.Text;
                            bedrijfsinformatie.telefoonnummer = txtTelefoonnummer.Text;
                            bedrijfsinformatie.btw_nummer = txtBtwnummer.Text;

                            BedrijfsinformatieDb.wijzigen(bedrijfsinformatie);
                            gegevens(bedrijfsinformatie, false);

                            foreach (Control c in this.Controls)
                            {
                                if (c.GetType().FullName == "System.Windows.Forms.TextBox" || c.Name == "Wijzigen" || c.Name == "lblError")
                                {
                                    c.Visible = false;
                                }
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
                    Validatie.is_error("int", lblError);
                }
            }
            else
            {
                Validatie.is_error("null", lblError);
            }
        }
    }
}
