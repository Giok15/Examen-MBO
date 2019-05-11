using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie.Schermen
{
    public partial class MedewerkerScherm : UserControl
    {
        bool is_edit;
        bool is_uitgever = false;
        Overzicht_klein submain;
        Medewerker medewerker = new Medewerker();
        Sectorgroep sectorgroep = new Sectorgroep();

        public MedewerkerScherm(Overzicht_klein submain)
        {
            InitializeComponent();
            this.submain = submain;
            vulDgUitgever();
            cmbRechten.SelectedIndex = 0;

            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName != "System.Windows.Forms.Label" && c.Name.Substring(0, 3) != "dgv")
                {
                    c.Visible = true;
                }
                btnKlaar.Visible = true;
                btnKlaar.Text = "Aanmaken";    
            }

            dgvUitgevers.ReadOnly = false;
        }

        public MedewerkerScherm(Overzicht_klein submain, Medewerker medewerker, Boolean is_edit = false)
        {
            InitializeComponent();
            this.submain = submain;
            this.is_edit = is_edit;
            this.medewerker = medewerker;
            
            cmbRechten.SelectedIndex = 0;

            if (is_edit)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType().FullName != "System.Windows.Forms.Label" && c.Name != "lblError")
                    {
                        c.Visible = true;
                    }
                    else
                    {
                        if (c.Name.Substring(0, 6) == "lblGeg" && c.Name.Substring(0,3) != "dgv")
                        {
                            c.Visible = false;
                        }
                    }
                }

                txtVoornaam.Text = medewerker.voornaam.ToString();
                txtAchternaam.Text = medewerker.achternaam.ToString();
                txtGebruikersnaam.Text = medewerker.gebruikersnaam.ToString();
                txtWachtwoord.Text = medewerker.wachtwoord;
                txtHerWachtwoord.Text = medewerker.wachtwoord;

                cmbRechten.Text = medewerker.rechten.ToString();

                if (medewerker.rechten == "Boekrechten")
                {
                    dgvUitgevers.Visible = true;
                    picHuisstijl.Visible = false;
                    vulDgUitgever();
                }
                else
                {
                    dgvUitgevers.Visible = false;
                    picHuisstijl.Visible = true;
                }

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

                        if (c.Name == "lblWachtwoord" || c.Name == "lblHerhaalww")
                        {
                            c.Visible = false;
                        }
                    }
                }

                lblGegVoornaam.Text = medewerker.voornaam.ToString();
                lblGegAchternaam.Text = medewerker.achternaam.ToString();
                lblGegGebruikersnaam.Text = medewerker.gebruikersnaam.ToString();

                lblGegRechten.Text = medewerker.rechten.ToString();

                if (medewerker.rechten == "Boekrechten")
                {
                    dgvUitgevers.Visible = true;
                    picHuisstijl.Visible = false;
                    dgvUitgevers.ReadOnly = true;
                    vulDgUitgeverMedewerker();
                    dgvUitgevers.Columns[0].Visible = false;
                }
                else
                {
                    dgvUitgevers.Visible = false;
                    picHuisstijl.Visible = true;
                }
            }
        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            List<string> input = new List<string>();
            string eigenschapId = null;
            string id = null;

            input.Add(txtVoornaam.Text);
            input.Add(txtAchternaam.Text);
            input.Add(txtGebruikersnaam.Text);
            input.Add(txtWachtwoord.Text);
            input.Add(txtHerWachtwoord.Text);

            if (is_edit)
            {
                eigenschapId = "id";
                id = Convert.ToString(medewerker.id);
            }

            if (!Validatie.is_null(input))
            {
                if (txtWachtwoord.Text == txtHerWachtwoord.Text)
                {
                    if (Validatie.is_wachtwoord(txtWachtwoord.Text))
                    {
                        if (Validatie.is_uniek(txtGebruikersnaam.Text, "Medewerker", "gebruikersnaam", eigenschapId, id))
                        {
                            foreach (DataGridViewRow row in dgvUitgevers.Rows)
                            {
                                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvUitgevers.Rows[row.Index].Cells[0];

                                if ((bool)checkbox.EditedFormattedValue)
                                {
                                    is_uitgever = true;
                                }
                            }

                            if (!dgvUitgevers.Visible || is_uitgever)
                            {
                                if (medewerker.rechten == "Boekrechten")
                                {
                                    if (is_edit)
                                    {
                                        UitgeversectorDb.verwijderenSectorgroep(medewerker);
                                    }
                                }

                                medewerker.voornaam = txtVoornaam.Text;
                                medewerker.achternaam = txtAchternaam.Text;
                                medewerker.gebruikersnaam = txtGebruikersnaam.Text;
                                medewerker.wachtwoord = txtWachtwoord.Text;
                                medewerker.rechten = cmbRechten.Text;

                                if (is_edit)
                                {
                                    MedewerkerDb.wijzigen(medewerker);
                                }
                                else
                                {
                                    MedewerkerDb.aanmaken(medewerker);
                                }

                                if (medewerker.rechten == "Boekrechten")
                                {
                                    medewerker = MedewerkerDb.ophalenGebruikersnaam(medewerker);

                                    foreach (DataGridViewRow row in dgvUitgevers.Rows)
                                    {
                                        DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvUitgevers.Rows[row.Index].Cells[0];

                                        if ((bool)checkbox.EditedFormattedValue)
                                        {
                                            sectorgroep.medewerker_id = medewerker.id;
                                            sectorgroep.uitgeversector_naam = (string)row.Cells[1].Value;
                                            UitgeversectorDb.aanmakenSectorgroep(sectorgroep);
                                        }
                                    }
                                }

                                if (is_edit)
                                {
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[submain.selectierow].Selected = true;
                                    submain.dgvOverzichtClick(is_edit);
                                }
                                else
                                {
                                    submain.vulDgOverzicht();
                                    submain.dgvOverzicht.Rows[0].Selected = true;
                                    submain.dgvOverzichtClick();
                                }
                            }
                            else
                            {
                                lblError.Text = "Selecteer minimaal 1 uitgeversector.";
                                lblError.Visible = true;
                            }
                        }
                        else
                        {
                            Validatie.is_error("uniek", lblError, "Gebruikersnaam");
                        }
                    }
                    else
                    {
                        txtHerWachtwoord.Text = "";
                        Validatie.is_error("wachtwoord", lblError);
                    }
                }
                else
                {
                    lblError.Text = "De wachtwoorden zijn niet hetzelfde.";
                    lblError.Visible = true;
                }
            }
            else
            {
                Validatie.is_error("null", lblError);
            }
        }

        private void cmbRechten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRechten.Text == "Boekrechten")
            {
                dgvUitgevers.Visible = true;
                picHuisstijl.Visible = false;
                vulDgUitgever();
            }
            else
            {
                dgvUitgevers.Visible = false;
                picHuisstijl.Visible = true;
            }
        }

        //vul datagrid
        private void vulDgUitgever()
        {
            BindingSource bindingSource = new BindingSource();

            DataTable dt = UitgeversectorDb.overzicht();
            bindingSource.DataSource = dt;
            dgvUitgevers.DataSource = bindingSource;

            dgvUitgevers.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvUitgevers.Rows[0].Selected = false;
        }

        //vul datagrid met uitgevers van medewerker
        private void vulDgUitgeverMedewerker()
        {
            BindingSource bindingSource = new BindingSource();

            DataTable dt = UitgeversectorDb.ophalen(medewerker);
            bindingSource.DataSource = dt;
            dgvUitgevers.DataSource = bindingSource;

            dgvUitgevers.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            try
            {
                dgvUitgevers.Rows[0].Selected = false;
            }
            catch { }
        }

        private void MedewerkerScherm_Load(object sender, EventArgs e)
        {
            if (is_edit)
            {
                DataTable dt = UitgeversectorDb.ophalen(medewerker);
                foreach (DataRow Row in dt.Rows)
                {
                    foreach (DataGridViewRow dgrow in dgvUitgevers.Rows)
                    {
                        if (Row["Uitgeversector"].ToString() == (string)dgrow.Cells[1].Value)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgrow.Cells[0];
                            if (chk.Value == chk.TrueValue)
                            {
                                chk.Value = chk.FalseValue;
                            }
                            else
                            {
                                chk.Value = chk.TrueValue;
                            }
                        }
                    }
                }
            }
        }
    }
}
