using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bestelapplicatie.DatabaseClasses;
using Bestelapplicatie.EntiteitClasses;
using System.Reflection;
using Bestelapplicatie.OverigeClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class Overzicht_klein : UserControl
    {
        string scherm = "";
        DataTable dt = new DataTable();
        Klant klant = new Klant();
        Sectorgroep sectorgroep = new Sectorgroep();
        Medewerker medewerker = new Medewerker();
        Hoofdscherm main;

        public string selectieId = "";
        public int selectierow = -1;

        public Overzicht_klein(string scherm, Hoofdscherm main)
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
                    btnWijzigen.Visible = true;
                    btnVerwijderen.Visible = true;
                    lblTitel.Text = "KLANT";
                    break;

                case "Boekscherm":
                    txtZoek.Visible = false;
                    cmbZoek.Visible = false;
                    lblZoek.Visible = false;
                    dgvOverzicht.Size = new Size(760, 197);
                    lblTitel.Text = "UITGEVERSSECTOR";
                    break;

                case "Loggingscherm":
                    btnAanmaken.Visible = true;
                    btnWijzigen.Visible = true;
                    btnVerwijderen.Visible = true;
                    lblTitel.Text = "MEDEWERKER";
                    break;
            }
        }

        //vul combobox
        public void vulCmbZoek()
        {
            if (scherm == "Bestelscherm")
            {
                foreach (PropertyInfo propertyInfo in klant.GetType().GetProperties())
                {
                    if (propertyInfo.Name != "id")
                    {
                        string eigenschap = propertyInfo.Name;
                        cmbZoek.Items.Add(char.ToUpper(eigenschap[0]) + eigenschap.Substring(1));
                    }
                }
                cmbZoek.SelectedIndex = 0;
            }

            if (scherm == "Loggingscherm")
            {
                foreach (PropertyInfo propertyInfo in medewerker.GetType().GetProperties())
                {
                    if (propertyInfo.Name != "id")
                    {
                        string eigenschap = propertyInfo.Name;
                        cmbZoek.Items.Add(char.ToUpper(eigenschap[0]) + eigenschap.Substring(1));
                    }
                }
                cmbZoek.SelectedIndex = 0;
            }
        }

        //vul datagrid
        public void vulDgOverzicht()
        {
            BindingSource bindingSource = new BindingSource();
            switch (scherm)
            {
                case "Bestelscherm":
                    dt = KlantDb.overzicht();
                    break;

                case "Boekscherm":
                    if (Account.getMedewerker().rechten == "Allrechten")
                    {
                        dt = UitgeversectorDb.overzicht();
                    }
                    else
                    {
                        dt = UitgeversectorDb.ophalen(Account.getMedewerker());
                    }
                    break;

                case "Loggingscherm":
                    dt = MedewerkerDb.overzicht();
                    break;
            }

            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0 && scherm != "Boekscherm")
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }
        }

        private void Overzicht_klein_Load(object sender, EventArgs e)
        {
            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
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
                KlantScherm klantscherm = new KlantScherm(this);
                main.pnlSubGegevens.Controls.Clear();
                main.pnlSubGegevens.Controls.Add(klantscherm);
            }

            if (scherm == "Loggingscherm")
            {
                MedewerkerScherm medewerkerscherm = new MedewerkerScherm(this);
                main.pnlSubGegevens.Controls.Clear();
                main.pnlSubGegevens.Controls.Add(medewerkerscherm);
            }
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
            clearPnlSubGegevens();

            if (scherm == "Bestelscherm")
            {
                if (selectieId != "")
                {
                    foreach(DataGridViewRow Row in dgvOverzicht.SelectedRows)
                    {
                        klant.id = (int)Row.Cells[0].Value;
                        klant = KlantDb.ophalen(klant);
                    }

                    KlantScherm klantscherm = new KlantScherm(this, klant, true);
                    main.pnlSubGegevens.Controls.Clear();
                    main.pnlSubGegevens.Controls.Add(klantscherm);
                }
                else
                {
                    MessageBox.Show("U moet een klant selecteren om deze te kunnen bewerken.", "KLANT BEWERKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (scherm == "Loggingscherm")
            {
                if (selectieId != "")
                {
                    foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                    {
                        medewerker.id = (int)Row.Cells[0].Value;
                        medewerker= MedewerkerDb.ophalen(medewerker);
                    }

                    MedewerkerScherm medewerkerscherm = new MedewerkerScherm(this, medewerker, true);
                    main.pnlSubGegevens.Controls.Clear();
                    main.pnlSubGegevens.Controls.Add(medewerkerscherm);
                }
                else
                {
                    MessageBox.Show("U moet een medewerker selecteren om deze te kunnen bewerken.", "MEDEWEREKR BEWERKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                            klant.voornaam = (string)Row.Cells[1].Value;
                            klant.achternaam = (string)Row.Cells[2].Value;
                            klant.email = (string)Row.Cells[6].Value;

                        }

                        DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt verwijderen: \r\n\r\n " + klant.voornaam[0] + ". " + klant.achternaam + "\r\n " + klant.email, "KLANT VERWIJDEREN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            KlantDb.verwijderen(klant);
                            vulDgOverzicht();
                             main.pnlSubGegevens.Controls.Clear();

                            Logging logging = new Logging();
                            logging.onderwerp = "Klant";
                            logging.handeling = "Verwijderd";
                            logging.datum = DateTime.Now;
                            logging.medewerker_id = Account.getMedewerker().id;
                            logging.klant_id = klant.id;
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
                        MessageBox.Show("U moet een klant selecteren om deze te kunnen verwijderen.", "KLANT VERWIJDEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            if (scherm == "Loggingscherm")
            {
                    if (selectieId != "")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            medewerker.voornaam = (string)Row.Cells[1].Value;
                            medewerker.achternaam = (string)Row.Cells[2].Value;
                            medewerker.gebruikersnaam = (string)Row.Cells[4].Value;

                        }

                        DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt verwijderen: \r\n\r\n " + medewerker.voornaam[0] + ". " + medewerker.achternaam + "\r\n " + medewerker.gebruikersnaam, "MEDEWERKER VERWIJDEREN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        MedewerkerDb.verwijderen(medewerker);
                        vulDgOverzicht();
                        main.pnlSubGegevens.Controls.Clear();

                        Logging logging = new Logging();
                        logging.onderwerp = "Klant";
                        logging.handeling = "Verwijderd";
                        logging.datum = DateTime.Now;
                        logging.medewerker_id = Account.getMedewerker().id;
                        logging.klant_id = klant.id;
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
                        MessageBox.Show("U moet een Medewerker selecteren om deze te kunnen verwijderen.", "MEDEWERKER VERWIJDEREN", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (main.overzicht_groot.selectieId != "")
                {
                    dt = Zoeken.zoekenSelectie("Klant", cmbZoek.Text, txtZoek.Text, "id", main.overzicht_groot.selectieId);
                }
                else
                {
                    dt = Zoeken.zoeken("Klant", cmbZoek.Text, txtZoek.Text);
                }
            }

            if (scherm == "Loggingscherm")
            {
                if (main.overzicht_groot.selectieId != "")
                {
                    dt = Zoeken.zoekenSelectie("Medewerker", cmbZoek.Text, txtZoek.Text, "id", main.overzicht_groot.selectieId);
                }
                else
                {
                    dt = Zoeken.zoeken("Medewerker", cmbZoek.Text, txtZoek.Text);
                }
            }

                BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0)
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }
        }

        private void dgvOverzicht_Click(object sender, EventArgs e)
        {
            dgvOverzichtClick();
        }

        public void dgvOverzichtClick(bool is_edit = false)
        {
            main.overzicht_groot.selectieId = "";
            main.overzicht_groot.selectierow = -1;

            foreach (DataGridViewRow row in dgvOverzicht.SelectedRows)
            {
                int currentindex = row.Index;

                if (currentindex == selectierow && !is_edit)
                {
                    dgvOverzicht.Rows[currentindex].Selected = false;
                    selectierow = -1;
                    selectieId = "";

                    main.pnlSubGegevens.Controls.Clear();

                    main.overzicht_groot.vulDgOverzicht();
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
                            klant.id = (int)Row.Cells[0].Value;
                            klant = KlantDb.ophalen(klant);
                        }

                        KlantScherm klantscherm = new KlantScherm(this, klant);
                        main.pnlSubGegevens.Controls.Clear();
                        main.pnlSubGegevens.Controls.Add(klantscherm);

                        main.overzicht_groot.dgvOverzichtSelectie(Convert.ToString(klant.id));
                    }

                    if (scherm == "Boekscherm")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            selectieId = Convert.ToString(Row.Cells[0].Value);
                            sectorgroep.uitgeversector_naam = (string)Row.Cells[0].Value;
                        }

                        main.pnlSubGegevens.Controls.Clear();

                        main.overzicht_groot.dgvOverzichtSelectie(Convert.ToString(sectorgroep.uitgeversector_naam));
                    }

                    if (scherm == "Loggingscherm")
                    {
                        foreach (DataGridViewRow Row in dgvOverzicht.SelectedRows)
                        {
                            selectieId = Convert.ToString(Row.Cells[0].Value);
                            medewerker.id = (int)Row.Cells[0].Value;
                            medewerker = MedewerkerDb.ophalen(medewerker);
                        }

                        MedewerkerScherm medewerkerscherm = new MedewerkerScherm(this, medewerker);
                        main.pnlSubGegevens.Controls.Clear();
                        main.pnlSubGegevens.Controls.Add(medewerkerscherm);

                        main.overzicht_groot.dgvOverzichtSelectie(Convert.ToString(medewerker.id));
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
                    dt = KlantDb.overzichtBestelling(Convert.ToInt32(id));
                    break;

                case "Boekscherm":
                    dt = UitgeversectorDb.overzichtUitgever(id); //id = sectornaam
                    break;

                case "Loggingscherm":
                    dt = MedewerkerDb.overzichtLogging(Convert.ToInt32(id));
                    break;
            }

            bindingSource.DataSource = dt;
            dgvOverzicht.DataSource = bindingSource;

            if (dgvOverzicht.ColumnCount > 0 && scherm != "Boekscherm")
            {
                dgvOverzicht.Columns[0].Visible = false;
            }

            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.Rows[0].Selected = false;
            }
        }

        //clear panel
        private void clearPnlSubGegevens()
        {
            main.pnlSubGegevens.Controls.Clear();
        }

        private void dgvOverzicht_Sorted(object sender, EventArgs e)
        {
            if (dgvOverzicht.SelectedRows.Count > 0)
            {
                dgvOverzicht.SelectedRows[0].Selected = false;
            }
        }
    }
}
