using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Bestelapplicatie.DatabaseClasses;
using Bestelapplicatie.EntiteitClasses;
using System.Reflection;
using Bestelapplicatie.OverigeClasses;
using System.ComponentModel;

namespace Bestelapplicatie.Schermen
{
    public partial class Overzicht_groot : UserControl
    {
        string scherm = "";
        System.Data.DataTable dt = new System.Data.DataTable();
        Boek boek = new Boek();
        Bestelling bestelling = new Bestelling();
        Logging logging = new Logging();
        Hoofdscherm main;
        Klant klant = new Klant();
        Uitgeversector uitgever = new Uitgeversector();
        Bestellingregel bestellingregel = new Bestellingregel();

        public string selectieId = "";
        public int selectierow = -1;

        public Overzicht_groot(string scherm, Hoofdscherm main)
        {
            InitializeComponent();
            this.main = main;
            this.scherm = scherm;
            vulCmbZoek();
            vulDgOverzicht();

            switch (scherm)
            {
                case "Bestelscherm":
                    btnAanmaken.Visible = true;
                    btnVerwijderen.Visible = true;
                    btnAnnuleren.Visible = true;

                    btnAanmaken.Location = new System.Drawing.Point(630, 0);
                    btnAnnuleren.Location = new System.Drawing.Point(590, 2);
                    lblTitel.Text = "BESTELLINGEN";

                    break;

                case "Boekscherm":
                    btnAanmaken.Visible = true;
                    btnWijzigen.Visible = true;
                    btnVerwijderen.Visible = true;
                    lblTitel.Text = "BOEKEN";
                    break;

                case "Loggingscherm":
                    lblTitel.Text = "LOGGING";
                    break;
            }
        }

        //check of bestelling leverdatum vandaag is want dan word status veranderd
        private void checkBestellingen()
        {
            foreach (DataGridViewRow row in dgvOverzicht.Rows)
            {
               bestelling.id = (int)row.Cells[0].Value;
               BestellingDb.ophalen(bestelling);

                if (bestelling.leverdatum == DateTime.Today && bestelling.status == "Wachten op levering.")
                {
                    bestelling.status = "Boek is gedrukt.";
                    BestellingDb.wijzigen(bestelling);
                    vulDgOverzicht();
                }
            }
        }

        //vul combobox
        public void vulCmbZoek()
        {

            switch (scherm)
            {
                case "Bestelscherm":
                    foreach (PropertyInfo propertyInfo in bestelling.GetType().GetProperties())
                    {
                        if (propertyInfo.Name == "id")
                        {
                            cmbZoek.Items.Add("Bestelnummer");
                        }
                        else
                        {
                            if (propertyInfo.Name != "klant_id" && propertyInfo.Name != "factuur")
                            {
                                string eigenschap = propertyInfo.Name;
                                cmbZoek.Items.Add(char.ToUpper(eigenschap[0]) + eigenschap.Substring(1));
                            }
                        }
                    }
                    break;

                case "Boekscherm":
                    foreach (PropertyInfo propertyInfo in boek.GetType().GetProperties())
                    {
                        if (propertyInfo.Name != "uitgeversector_naam" && propertyInfo.Name != "zichtbaar")
                        {
                            string eigenschap = propertyInfo.Name;
                            cmbZoek.Items.Add(char.ToUpper(eigenschap[0]) + eigenschap.Substring(1));
                        }
                    }
                    break;

                case "Loggingscherm":
                    foreach (PropertyInfo propertyInfo in logging.GetType().GetProperties())
                    {
                        if (propertyInfo.Name != "id" && propertyInfo.Name != "medewerker_id" && propertyInfo.Name != "boek_isbn_nummer" && propertyInfo.Name != "bestelling_id" && propertyInfo.Name != "klant_id")
                        {
                            cmbZoek.Items.Add(propertyInfo.Name);
                        }
                    }
                    break;

            }

            cmbZoek.SelectedIndex = 0;
        }

        //vul datagrid
        public void vulDgOverzicht()
        {
            BindingSource bindingSource = new BindingSource();
            switch (scherm)
            {
                case "Bestelscherm":
                    dt = BestellingDb.overzicht();
                    break;

                case "Boekscherm":
                    if (Account.getMedewerker().rechten == "Allrechten")
                    {
                        dt = BoekDb.overzicht();
                    }
                    else
                    {
                        dt = UitgeversectorDb.ophalen(Account.getMedewerker());

                        int i = 1;
                        string data = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            if (i == 1)
                            {
                                data += " WHERE u.naam = '" + row["Uitgeversector"] + "'";
                            }
                            else
                            {
                                data += " OR u.naam = '" + row["Uitgeversector"] + "'";
                            }
                            i++;
                        }

                        dt = BoekDb.overzichtSectoren(data);
                    }
                    break;

                case "Loggingscherm":
                    dt = LoggingDb.overzicht();
                    break;
            }

            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0 && scherm != "Bestelscherm" && scherm != "Boekscherm")
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.Rows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }
        }

        private void Overzicht_groot_Load(object sender, EventArgs e)
        {
            if (dgvOverzicht.Rows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }

            if (scherm == "Bestelscherm")
            {
                checkBestellingen();
                bestellingenGroen();
                dgvOverzicht.Sort(dgvOverzicht.Columns["status"], ListSortDirection.Ascending);
            }
        }

        //bestelling groen maken als datum leverdatum zelfde is als datum vandaag
        public void bestellingenGroen()
        {
            foreach (DataGridViewRow row in dgvOverzicht.Rows)
            {
                bestelling.leverdatum = (DateTime)row.Cells[2].Value;
                bestelling.status = (string)row.Cells[3].Value;

                if (bestelling.leverdatum == DateTime.Today && bestelling.status == "Boek is gedrukt.")
                    {
                    dgvOverzicht.Rows[row.Index].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void btnAanmaken_Click(object sender, EventArgs e)
        {
            clearPnlSubGegevens();

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzichtClick();
            }

            selectieId = "";
            selectierow = -1;

            if (scherm == "Bestelscherm")
            {
                    if (main.overzicht_klein.selectieId != "")
                    {
                        klant.id = Convert.ToInt32(main.overzicht_klein.selectieId);
                        klant = KlantDb.ophalen(klant);

                        BestelScherm bestelscherm = new BestelScherm(this, klant);
                        main.pnlSubGegevens.Controls.Clear();
                        main.pnlSubGegevens.Controls.Add(bestelscherm);
                    }
                    else
                    {
                        MessageBox.Show("U moet een klant selecteren om een bestelling aan te maken.", "BESTELLING AANMAKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            if (scherm == "Boekscherm")
            {
                if (main.overzicht_klein.selectieId != "")
                {
                    uitgever.naam = main.overzicht_klein.selectieId;

                    BoekScherm boekscherm = new BoekScherm(this, uitgever);
                    main.pnlSubGegevens.Controls.Clear();
                    main.pnlSubGegevens.Controls.Add(boekscherm);
                }
                else
                {
                    MessageBox.Show("U moet een uitgeversector selecteren om een boek aan te maken.", "BOEK AANMAKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            clearPnlSubGegevens();

            if (scherm == "Boekscherm")
            {
                foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                {
                    boek.isbn_nummer = (string)Row.Cells[0].Value;
                    boek = BoekDb.ophalen(boek);
                }

                if (selectieId != "")
                {
                    BoekScherm boekscherm = new BoekScherm(this, boek, true);
                    main.pnlSubGegevens.Controls.Clear();
                    main.pnlSubGegevens.Controls.Add(boekscherm);
                }
                else
                {
                    MessageBox.Show("U moet een boek selecteren om deze te kunnen bewerken.", "BOEK BEWERKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOverzicht_Click(object sender, EventArgs e)
        {
            dgvOverzichtClick();
           
        }

        public void dgvOverzichtClick(bool is_edit = false)
        {
            main.overzicht_klein.selectieId = "";
            main.overzicht_klein.selectierow = -1;

            foreach (DataGridViewRow row in dgvOverzicht.SelectedRows)
            {
                int currentindex = row.Index;

                if (currentindex == selectierow && !is_edit)
                {
                    dgvOverzicht.Rows[currentindex].Selected = false;
                    selectierow = -1;
                    selectieId = "";

                    main.pnlSubGegevens.Controls.Clear();

                    main.overzicht_klein.vulDgOverzicht();
                    vulDgOverzicht();
                }
                else
                {
                    dgvOverzicht.Rows[currentindex].Selected = true;
                    selectierow = currentindex;

                    if (scherm == "Bestelscherm")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            selectieId = Convert.ToString(Row.Cells[0].Value);
                            bestelling.id = (int)Row.Cells[0].Value;
                            bestelling = BestellingDb.ophalen(bestelling);

                            klant.id = bestelling.klant_id;
                            klant = KlantDb.ophalen(klant);
                        }

                           BestelScherm bestelscherm = new BestelScherm(this, klant, bestelling);
                           main.pnlSubGegevens.Controls.Clear();
                           main.pnlSubGegevens.Controls.Add(bestelscherm);

                        main.overzicht_klein.dgvOverzichtSelectie(Convert.ToString(bestelling.id));
                    }

                    if (scherm == "Boekscherm")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            selectieId = Convert.ToString(Row.Cells[0].Value);
                            boek.isbn_nummer = (string)Row.Cells[0].Value;
                            boek = BoekDb.ophalen(boek);
                        }

                        BoekScherm boekscherm = new BoekScherm(this, boek);
                        main.pnlSubGegevens.Controls.Clear();
                        main.pnlSubGegevens.Controls.Add(boekscherm);

                        main.overzicht_klein.dgvOverzichtSelectie(Convert.ToString(boek.isbn_nummer));
                    }

                    if (scherm == "Loggingscherm")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            selectieId = Convert.ToString(Row.Cells[0].Value);
                            logging.id = (int)Row.Cells[0].Value;
                            logging = LoggingDb.ophalen(logging);
                        }

                        Loggingscherm loggingscherm = new Loggingscherm(logging);
                        main.pnlSubGegevens.Controls.Clear();
                        main.pnlSubGegevens.Controls.Add(loggingscherm);

                        main.overzicht_klein.dgvOverzichtSelectie(Convert.ToString(logging.id));
                    }
                }
            }
        }

        public void dgvOverzichtSelectie(string id)
        {
            BindingSource bindingSource = new BindingSource();
            switch (scherm)
            {
                case "Bestelscherm":
                    dt = BestellingDb.overzichtKlant(Convert.ToInt32(id));
                    break;

                case "Boekscherm":
                    dt = BoekDb.overzichtSector(id); //id = sectornaam
                    break;

                case "Loggingscherm":
                    dt = LoggingDb.overzichtMedewerker(Convert.ToInt32(id));
                    break;
            }

            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0 && scherm != "Bestelscherm" && scherm != "Boekscherm")
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }

            if (scherm == "Bestelscherm")
            {
                checkBestellingen();
            }
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (scherm == "Bestelscherm")
            {
                if (selectieId != "")
                {
                    foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                    {
                        bestelling.id = (int)Row.Cells[0].Value;
                        bestelling.besteldatum = (DateTime)Row.Cells[2].Value;

                    }

                    DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt verwijderen: \r\n\r\n Bestelnummer: " + bestelling.id + ". \r\n " + bestelling.besteldatum.ToString().Substring(0, bestelling.besteldatum.ToString().Length - 3), "BESTELLING VERWIJDEREN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bestellingregel.bestelling_id = bestelling.id;
                        BestellingregelDB.verwijderen(bestellingregel);
                        BestellingDb.verwijderen(bestelling);
                        vulDgOverzicht();
                        if (dgvOverzicht.Rows.Count > 0)
                        {
                            dgvOverzicht.Rows[0].Selected = true;
                        }
                        dgvOverzichtClick();
                        main.pnlSubGegevens.Controls.Clear();

                        Logging logging = new Logging();
                        logging.onderwerp = "Bestelling";
                        logging.handeling = "Verwijderd";
                        logging.datum = DateTime.Now;
                        logging.medewerker_id = Account.getMedewerker().id;
                        logging.bestelling_id = bestelling.id;
                        logging.boek_isbn_nummer = "";

                        LoggingDb.aanmaken(logging);
                    }
                    else
                    {
                        dgvOverzichtClick(true);
                    }
                }
                else
                {
                    MessageBox.Show("U moet een Bestelling selecteren om deze te kunnen verwijderen.", "BESTELLING VERWIJDEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            if (scherm == "Boekscherm")
            {
                if (selectieId != "")
                {
                    foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                    {
                        boek.isbn_nummer = (string)Row.Cells[0].Value;
                        boek = BoekDb.ophalen(boek);

                    }

                    DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt verwijderen: \r\n\r\n " + boek.isbn_nummer + ". \r\n " + boek.titel, "BOEK VERWIJDEREN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        BoekDb.verwijderen(boek);
                        vulDgOverzicht();
                        main.pnlSubGegevens.Controls.Clear();

                        Logging logging = new Logging();
                        logging.onderwerp = "Boek";
                        logging.handeling = "Verwijderd";
                        logging.datum = DateTime.Now;
                        logging.medewerker_id = Account.getMedewerker().id;
                        logging.boek_isbn_nummer = boek.isbn_nummer;

                        LoggingDb.aanmaken(logging);
                    }
                    else
                    {
                        dgvOverzichtClick(true);
                    }
                }
                else
                {
                    MessageBox.Show("U moet een boek selecteren om deze te kunnen verwijderen.", "BOEK VERWIJDEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtZoek_TextChanged(object sender, EventArgs e)
        {
            selectierow = -1;
            selectieId = "";
            main.pnlSubGegevens.Controls.Clear();

            if (scherm == "Bestelscherm")
            {
                if (main.overzicht_klein.selectieId != "")
                {
                    dt = Zoeken.zoekenSelectie("Bestelling", cmbZoek.Text, txtZoek.Text, "klant_id", main.overzicht_klein.selectieId);
                }
                else
                {
                    dt = Zoeken.zoeken("Bestelling", cmbZoek.Text, txtZoek.Text);
                }
            }

            if (scherm == "Boekscherm")
            {
                if (main.overzicht_klein.selectieId != "")
                {
                    dt = Zoeken.zoekenSelectie("Boek", cmbZoek.Text, txtZoek.Text, "uitgeversector_naam", main.overzicht_klein.selectieId);
                }
                else
                {
                    if (Account.getMedewerker().rechten == "Allrechten")
                    {
                        dt = Zoeken.zoeken("Boek", cmbZoek.Text, txtZoek.Text);
                    }
                    else
                    {
                        dt = UitgeversectorDb.ophalen(Account.getMedewerker());

                        int i = 1;
                        string data = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            if (i == 1)
                            {
                                data += " AND (uitgeversector_naam = '" + row["Uitgeversector"] + "'";
                            }
                            else
                            {
                                data += " OR uitgeversector_naam = '" + row["Uitgeversector"] + "'";
                            }
                            i++;
                        }
                        data += ")";

                        dt = Zoeken.zoekenRestrictie(cmbZoek.Text, txtZoek.Text, data);
                    }
                }
            }

            if (scherm == "Loggingscherm")
            {
                if (main.overzicht_klein.selectieId != "")
                {
                    dt = Zoeken.zoekenSelectie("Logging", cmbZoek.Text, txtZoek.Text, "medewerker_id", main.overzicht_klein.selectieId);
                }
                else
                {
                    dt = Zoeken.zoeken("Logging", cmbZoek.Text, txtZoek.Text);
                }
            }

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0 && scherm != "Bestelscherm" && scherm != "Boekscherm")
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }
        }

        private void clearPnlSubGegevens()
        {
            main.pnlSubGegevens.Controls.Clear();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            if (selectieId != "")
            {
                bestelling.id = Convert.ToInt32(selectieId);
                bestelling = BestellingDb.ophalen(bestelling);

                if (bestelling.leverdatum != DateTime.Today && bestelling.leverdatum > DateTime.Today)
                {

                    DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt Annuleren: \r\n\r\n Bestelnummer: " + bestelling.id + ". \r\n " + bestelling.besteldatum, "BESTELLING ANNULEREN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bestelling.status = "Geannuleerd";
                        BestellingDb.wijzigen(bestelling);
                        vulDgOverzicht();
                        dgvOverzicht.Rows[selectierow].Selected = true;
                        dgvOverzichtClick(true);

                        Logging logging = new Logging();
                        logging.onderwerp = "Bestelling";
                        logging.handeling = "Geannuleerd";
                        logging.datum = DateTime.Now;
                        logging.medewerker_id = Account.getMedewerker().id;
                        logging.bestelling_id = bestelling.id;
                        logging.boek_isbn_nummer = "";

                        LoggingDb.aanmaken(logging);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("U kunt deze bestelling niet annuleren. \r\n\r\n Het boek is al gedrukt.", "BESTELLING ANNULEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("U moet een bestelling selecteren om deze te kunnen annuleren.", "BESTELLING ANNULEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOverzicht_Sorted(object sender, EventArgs e)
        {
            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.SelectedRows[0].Selected = false;
            }

            if (scherm == "Bestelscherm")
            {
                bestellingenGroen();
            }
        }

        private void dgvOverzicht_DataSourceChanged(object sender, EventArgs e)
        {
            if (scherm == "Bestelscherm")
            {
                bestellingenGroen();
            }
        }
    }
}
