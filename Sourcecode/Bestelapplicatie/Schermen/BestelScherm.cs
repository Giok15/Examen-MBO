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
using Bestelapplicatie.DatabaseClasses;
using System.Reflection;
using Bestelapplicatie.OverigeClasses;
using System.Diagnostics;
using System.IO;

namespace Bestelapplicatie.Schermen
{
    public partial class BestelScherm : UserControl
    {
        Bestellingregel bestellingregel = new Bestellingregel();

        Boek boek = new Boek();
        DataTable dt = new DataTable();
        decimal totaalPrijs = 0;
        DateTime datum = new DateTime();
        Bestelling bestelling = new Bestelling();
        Klant klant = new Klant();
        bool is_nietVoorraad;
        bool is_error;
        Overzicht_groot submain;

        List<string> isbn_nummers = new List<string>();
        List<int> totalen = new List<int>();
        int rowIndex;
        int columnIndex;


        //bestelling scherm aanmaken
        public BestelScherm(Overzicht_groot submain, Klant klant)
        {
            InitializeComponent();
            this.submain = submain;
            this.klant = klant;
            datum = DateTime.Now;
            vulDgUitgever();
            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName != "System.Windows.Forms.Label" && c.GetType().FullName != "System.Windows.Forms.PictureBox")
                {
                    c.Visible = true;
                }

                lblZoek.Visible = true;
                btnFactuur.Visible = false;
                btnPrinten.Visible = false;
                picHuisstijl.Visible = false;
                btnKlaar.Visible = true;
                btnKlaar.Text = "Aanmaken";
            }
            dgvBoeken.Enabled = true;

            if (dgvBoeken.Rows.Count > 0)
            {
                dgvBoeken.Rows[0].Cells[0].Selected = true;
            }

            dgvBoeken.Focus();

            dgvBoeken.Columns["Toevoegen"].DisplayIndex = 0;
            dgvBoeken.Columns["Aantal"].DisplayIndex = 1;
            dgvBoeken.Columns["Prijs"].DisplayIndex = 7;

            vulCmbZoek();
        }

        //bestelling laten zien
        public BestelScherm(Overzicht_groot submain, Klant klant, Bestelling bestelling)
        {
            InitializeComponent();
            this.submain = submain;
            this.bestelling = bestelling;
            this.klant = klant;

            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName == "System.Windows.Forms.Label" && c.Name != "lblError" && c.Name != "lblGegStatusExtra" && c.Name != "lblZoek")
                {
                    c.Visible = true;
                }
            }

            btnKlaar.Visible = false;
            btnFactuur.Visible = true;
            btnPrinten.Visible = true;

            lblGegBesteldatum.Text = bestelling.besteldatum.ToString().Substring(0, bestelling.besteldatum.ToString().Length - 3);
            lblGegLeverdatum.Text = bestelling.leverdatum.ToString().Substring(0, bestelling.leverdatum.ToString().Length - 8);

            lblGegStatus.Text = bestelling.status.ToString();

            if (bestelling.status == "Boek is gedrukt.")
            {
                lblGegStatusExtra.Text = "klik op het icoontje om de klant een mail te sturen";
                lblGegStatusExtra.Visible = true;
            }

            if (bestelling.status == "Wachten op klant.")
            {
                lblGegStatusExtra.Text = "klik op het icoontje om de bevestiging te voltooien";
                lblGegStatusExtra.Visible = true;
            }


            checkStatus();

            bestellingregel.bestelling_id = bestelling.id;
            DataTable dt = new DataTable();


            dt = BestellingregelDB.overzicht(bestellingregel);

            foreach (DataRow drow in dt.Rows)
            {
                bestellingregel.boek_isbn_nummer = Convert.ToString(drow["boek_isbn_nummer"]);
                dt = BestellingregelDB.overzichtBestelling(bestellingregel);
            }

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dgvBoeken.DataSource = bindingSource;

            dgvBoeken.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dgvBoeken.SelectedRows.Count > 0)
            {
                dgvBoeken.Rows[0].Selected = false;
            }

            dgvBoeken.Columns["Toevoegen"].DisplayIndex = 0;
            dgvBoeken.Columns["Aantal"].DisplayIndex = 1;
            dgvBoeken.Columns["Prijs"].DisplayIndex = 2;

            dgvBoeken.Columns[1].Visible = false;
        }

        //check welke status in de bestelling staat om de juiste img te laden
        private void checkStatus()
        {
            switch (bestelling.status)
            {
                case "Wachten op levering.":
                    picWachten.Visible = true;
                    break;

                case "Boek is gedrukt.":
                    picVerzenden.Visible = true;
                    break;

                case "Wachten op klant.":
                    picKassa.Visible = true;
                    break;

                case "Voltooid":
                    picVoltooid.Visible = true;
                    break;

                case "Geannuleerd":
                    picAnnuleer.Visible = true;
                    break;
            }

        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            is_nietVoorraad = false;
            is_error = false;

            if (lblError.Visible != true)
            {
                if (totaalPrijs > 0)
                {
                    foreach (DataGridViewRow row in dgvBoeken.Rows)
                    {
                        DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvBoeken.Rows[row.Index].Cells[1];

                        if ((bool)checkbox.EditedFormattedValue)
                        {
                            if (Convert.ToInt32(row.Cells[0].Value) > Convert.ToInt32(row.Cells[6].Value))
                            {
                                is_nietVoorraad = true;
                            }
                        }
                    }
                }
                else
                {
                        lblError.Text = "Er moet minimaal 1 boek toegevoegd worden.";
                        lblError.Visible = true;
                        is_error = true;
                }

                if (is_nietVoorraad && !is_error)
                {
                    DialogResult dialogResult = MessageBox.Show("Niet alle boeken zijn op voorraad \r\n de leverdatum wordt: " + DateTime.Today.AddDays(3).ToString("dd/MM/yyyy") + "\r\n\r\n gaat de klant hiermee akkoord?", "NIET GENOEG OP VOORRAAD", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bestelling.status = "Wachten op levering.";
                        bestelling.leverdatum = DateTime.Today.AddDays(3);
                        bestellen();
                    }
                }
                else if (!is_error)
                {
                    bestelling.status = "Voltooid";
                    bestelling.leverdatum = DateTime.Today;
                    bestellen();
                }
            }
        }

        //methode om bestelling aan te maken : 
        private void bestellen()
        {
            Cursor.Current = Cursors.WaitCursor;
            bestelling.besteldatum = datum;
            bestelling.klant_id = klant.id;

            string strDatum = "";
            string omschrijving = "";
            string aantal = "";
            string prijs = "";
            string totaalPrijs = "";

            foreach (DataGridViewRow row in dgvBoeken.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvBoeken.Rows[row.Index].Cells[1];

                if ((bool)checkbox.EditedFormattedValue)
                {
                    strDatum += datum.AddDays(3).ToString("dd/MM/yyyy") + "\v";
                    omschrijving += row.Cells[4].Value + "\v";
                    aantal += row.Cells[0].Value + "\v";
                    totaalPrijs += row.Cells[2].Value + "\v";
                    prijs += "€" + row.Cells[7].Value + "\v";
                }
            }

            BestellingDb.aanmaken(bestelling);

            bestelling.id = BestellingDb.GetLaatsteBestelling();

            Factuur factuur = new Factuur();
            bestelling.factuur = factuur.aanmaken(klant, BedrijfsinformatieDb.ophalen(), bestelling, strDatum, omschrijving, aantal, prijs, totaalPrijs, lblPrijs.Text);

            BestellingDb.wijzigen(bestelling);

            foreach (DataGridViewRow row in dgvBoeken.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvBoeken.Rows[row.Index].Cells[1];

                if ((bool)checkbox.EditedFormattedValue)
                {
                    bestellingregel.bestelling_id = bestelling.id;
                    bestellingregel.boek_isbn_nummer = Convert.ToString(row.Cells[3].Value);
                    bestellingregel.aantal = Convert.ToInt32(row.Cells[0].Value);
                    BestellingregelDB.aanmaken(bestellingregel);

                    Boekvoorraad voorraad = new Boekvoorraad();
                    voorraad.boek_isbn_nummer = bestellingregel.boek_isbn_nummer;

                    if (bestellingregel.aantal > Convert.ToInt32(row.Cells[6].Value))
                    {
                        voorraad.aantal = 0;
                    }
                    else
                    {
                        voorraad.aantal = Convert.ToInt32(row.Cells[6].Value) - bestellingregel.aantal;
                    }
                    BoekvoorraadDb.wijzigen(voorraad);
                }
            }

            Mail mail = new Mail();
            mail.mailAanmaken(klant, bestelling, bestelling.factuur);

            submain.vulDgOverzicht();
            submain.dgvOverzicht.Rows[0].Selected = true;
            submain.dgvOverzichtClick();

            Logging logging = new Logging();
            logging.onderwerp = "Bestelling";
            logging.handeling = "Aangemaakt";
            logging.datum = DateTime.Now;
            logging.medewerker_id = Account.getMedewerker().id;
            logging.bestelling_id = bestelling.id;
            logging.boek_isbn_nummer = "";

            LoggingDb.aanmaken(logging);
        }
        //vul datagrid
        private void vulDgUitgever()
        {
            BindingSource bindingSource = new BindingSource();

            DataTable dt = BoekDb.overzichtBestelling();
            bindingSource.DataSource = dt;
            dgvBoeken.DataSource = bindingSource;

            foreach (DataGridViewColumn column in dgvBoeken.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dgvBoeken.SelectedRows.Count > 0)
            {
                dgvBoeken.Rows[0].Selected = false;
            }

            dgvBoeken.Columns[3].ReadOnly = true;
            dgvBoeken.Columns[4].ReadOnly = true;
            dgvBoeken.Columns[5].ReadOnly = true;
            dgvBoeken.Columns[6].ReadOnly = true;
            dgvBoeken.Columns[7].ReadOnly = true;
            dgvBoeken.Columns[2].ReadOnly = true;
        }

        private void BestelScherm_Load(object sender, EventArgs e)
        {
            dgvBoeken.Focus();
        }

        private void checkPrijs()
        {
            totaalPrijs = 0;
            foreach (DataGridViewRow row in dgvBoeken.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvBoeken.Rows[row.Index].Cells[1];

                if ((bool)checkbox.EditedFormattedValue)
                {
                    List<string> aantal = new List<string>();
                    aantal.Add(Convert.ToString(row.Cells[0].Value));

                    if (Validatie.is_null(aantal))
                    {
                        row.Cells[0].Value = 1;
                    }

                    if (Validatie.is_int(Convert.ToString(row.Cells[0].Value)))
                    {
                        decimal prijs = Convert.ToDecimal(row.Cells[7].Value) * Convert.ToDecimal(row.Cells[0].Value);
                        row.Cells[2].Value = "€" + Convert.ToString(prijs);
                        totaalPrijs += prijs;

                    }
                    else
                    {
                        lblError.Text = "Niet alle aantallen zijn getallen.";
                        lblError.Visible = true;
                        is_error = true;
                    }
                }
                else
                {
                    row.Cells[0].Value = null;
                    row.Cells[2].Value = null;
                    lblPrijs.Text = "";
                }
            }

            lblPrijs.Text = "€" + Convert.ToString(totaalPrijs);

            if (!is_error)
            {
                lblError.Visible = false;
            }
            is_error = false;
        }

        private void dgvBoeken_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            checkPrijs();
            editLijst();
        }

        private void dgvBoeken_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            checkPrijs();
            addInLijst();
        }

        private void btnFactuur_Click(object sender, EventArgs e)
        {
            Factuur factuur = new Factuur();
            factuur.overzicht(bestelling);
        }

        private void btnPrinten_Click(object sender, EventArgs e)
        {
            Factuur factuur = new Factuur();
            factuur.printen(bestelling);
        }

        private void picVerzenden_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            mail.mailAanmaken(klant, bestelling);
            bestelling.status = "Wachten op klant.";
            BestellingDb.wijzigen(bestelling);
            submain.vulDgOverzicht();
            submain.dgvOverzicht.Rows[submain.selectierow].Selected = true;
            submain.dgvOverzichtClick(true);

            Logging logging = new Logging();
            logging.onderwerp = "Bestelling";
            logging.handeling = "Status gewijzigd";
            logging.datum = DateTime.Now;
            logging.medewerker_id = Account.getMedewerker().id;
            logging.bestelling_id = bestelling.id;
            logging.boek_isbn_nummer = "";

            LoggingDb.aanmaken(logging);
        }

        private void picKassa_Click(object sender, EventArgs e)
        {
            bestelling.status = "Voltooid";
            BestellingDb.wijzigen(bestelling);
            submain.dgvOverzichtClick(true);
            submain.vulDgOverzicht();
            submain.dgvOverzicht.Rows[submain.selectierow].Selected = true;
            submain.dgvOverzichtClick(true);

            Logging logging = new Logging();
            logging.onderwerp = "Bestelling";
            logging.handeling = "Status gewijzigd";
            logging.datum = DateTime.Now;
            logging.medewerker_id = Account.getMedewerker().id;
            logging.bestelling_id = bestelling.id;
            logging.boek_isbn_nummer = "";

            LoggingDb.aanmaken(logging);
        }
        //vul combobox
        public void vulCmbZoek()
        {
            foreach (PropertyInfo propertyInfo in boek.GetType().GetProperties())
            {
                if (propertyInfo.Name != "uitgeversector_naam" && propertyInfo.Name != "zichtbaar")
                {
                    string eigenschap = propertyInfo.Name;
                    cmbZoek.Items.Add(char.ToUpper(eigenschap[0]) + eigenschap.Substring(1));
                }
            }

            cmbZoek.SelectedIndex = 0;
        }

        private void txtZoek_TextChanged(object sender, EventArgs e)
        {
            dt = Zoeken.zoeken("Boek", cmbZoek.Text, txtZoek.Text, true);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dgvBoeken.DataSource = bindingSource;

            if (dgvBoeken.SelectedRows.Count > 0)
            {
                dgvBoeken.Rows[0].Selected = false;
            }
            getLijst();

            dgvBoeken.Columns[3].ReadOnly = true;
            dgvBoeken.Columns[4].ReadOnly = true;
            dgvBoeken.Columns[5].ReadOnly = true;
            dgvBoeken.Columns[6].ReadOnly = true;
            dgvBoeken.Columns[7].ReadOnly = true;
            dgvBoeken.Columns[2].ReadOnly = true;
        }

        private void getLijst()
        {
            foreach (DataGridViewRow row in dgvBoeken.Rows)
            {
                int count = 0;
                foreach (string isbn_nummer in isbn_nummers)
                {

                    if (Convert.ToString(row.Cells[3].Value) == isbn_nummer)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                        chk.Value = true;
                        row.Cells[0].Value = totalen[count];
                    }
                    count++;
                }
            }
            checkPrijs();
        }

        private void addInLijst()
        {
            foreach (DataGridViewCell selCel in dgvBoeken.SelectedCells)
            {
                if (selCel.ColumnIndex == 1)
                {
                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)selCel;

                    if ((bool)checkbox.EditedFormattedValue)
                    {
                        var row = dgvBoeken.Rows[selCel.RowIndex];
                        isbn_nummers.Add(row.Cells[3].Value.ToString());
                        totalen.Add(Convert.ToInt32(row.Cells[0].Value));
                    }
                    else
                    {
                        int index = isbn_nummers.IndexOf(dgvBoeken.Rows[selCel.RowIndex].Cells[3].Value.ToString());
                        isbn_nummers.RemoveAt(index);
                        totalen.RemoveAt(index);
                    }
                }
            }
        }

        private void editLijst()
        {
            if (columnIndex == 0)
            {
                var row = dgvBoeken.Rows[rowIndex];
                if ((bool)row.Cells[1].EditedFormattedValue)
                {
                    int index = isbn_nummers.IndexOf(dgvBoeken.Rows[rowIndex].Cells[3].Value.ToString());
                    totalen[index] = Convert.ToInt32(row.Cells[0].Value);
                }
            }
        }

        private void dgvBoeken_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (DataGridViewCell cell in dgvBoeken.SelectedCells)
            {
                columnIndex = cell.ColumnIndex;
                rowIndex = cell.RowIndex;
            }
        }
    }
}