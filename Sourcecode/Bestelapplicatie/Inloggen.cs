using Bestelapplicatie.EntiteitClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.DatabaseClasses;

namespace Bestelapplicatie
{
    public partial class Inloggen : Form
    {
        Medewerker medewerker = new Medewerker();

        public Inloggen()
        {
            InitializeComponent();

           //check of de connectie met de database werkt
           bool connectie = DatabaseClasses.DatabaseCon.getConnectieString();
           if (!connectie){ MessageBox.Show("Database connectie werkt niet, neem contact op met de programmeur.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);  System.Windows.Forms.Application.Exit(); }

        }

        private void btnInloggen_Click(object sender, EventArgs e)
        {
            bool is_correct = validatieInloggen();
            if (is_correct)
            {
                this.Hide();
                Hoofdscherm form = new Hoofdscherm();
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }

        private void txtWachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInloggen_Click(this, new EventArgs());
            }
        }

        private bool validatieInloggen()
        {
            List<string> input = new List<string>();
            input.Add(txtGebruikersnaam.Text);
            input.Add(txtWachtwoord.Text);

            if (!Validatie.is_null(input))
            {
                medewerker = MedewerkerDb.accountOphalen(txtGebruikersnaam.Text, txtWachtwoord.Text);
                if (medewerker.gebruikersnaam != null)
                {
                    Account.inloggen(medewerker);
                    return true;
                }
                else
                {
                    lblError.Location = new Point(5, 260);
                    this.Size = new Size(459, 327);
                    lblError.Text = "Uw gebruikersnaam en wachtwoord komen niet overheen.";
                    return false;
                }
            }
            else
            {
                lblError.Location = new Point(100, 260);
                this.Size = new Size(459, 327);
                Validatie.is_error("null", lblError);
                return false;
            }
        }
    }
}
