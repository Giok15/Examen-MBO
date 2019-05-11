using Bestelapplicatie.DatabaseClasses;
using Bestelapplicatie.EntiteitClasses;
using Bestelapplicatie.OverigeClasses;
using Bestelapplicatie.Schermen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bestelapplicatie
{
    public partial class Hoofdscherm : Form
    {
        private string scherm;
        Medewerker medewerker = new Medewerker();
        Bedrijfsinformatie bedrijfsinformatie = new Bedrijfsinformatie();

       public Overzicht_klein overzicht_klein;
       public Overzicht_groot overzicht_groot;


        public Hoofdscherm()
        {
            InitializeComponent();
            medewerker = Account.getMedewerker();
            rechten();

            if (Account.getMedewerker().rechten == "Bestelrechten" || Account.getMedewerker().rechten == "Allrechten")
            {
                menuItem_Click(tabBestel);
            }
            if (Account.getMedewerker().rechten == "Boekrechten")
            {
                menuItem_Click(tabBoek);
            }

        }

        private void rechten()
        {
            switch (medewerker.rechten)
            {
                case "Bestelrechten":
                    tabBestel.Visible = true;
                    break;

                case "Boekrechten":
                    tabBoek.Visible = true;
                    break;

                case "Allrechten":
                    tabBestel.Visible = true;
                    tabBoek.Visible = true;
                    tabLog.Visible = true;
                    tabBedrijf.Visible = true;
                    break;
            }
        }

        private void vulScherm()
        {
            Overzicht_groot overzichtG = new Overzicht_groot(scherm, this);
            Overzicht_klein overzichtK = new Overzicht_klein(scherm, this);

            overzicht_klein = overzichtK;
            overzicht_groot = overzichtG;

            pnlHoofdscherm.Controls.Clear();

            pnlHoofdscherm.Visible = true;
            pnlHoofdscherm.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlHoofdscherm.Controls.Clear();
            pnlSubGegevens.Controls.Clear();
            pnlGegevens.Controls.Clear();

            pnlSubGegevens.Visible = true;
            pnlSubGegevens.Size = new Size(785, 380);
            pnlHoofdscherm.Controls.Add(pnlSubGegevens);
            pnlSubGegevens.Location = new Point(0, 362);

            pnlGegevens.Visible = true;
            pnlGegevens.Size = new Size(1540, 765);
            pnlHoofdscherm.Controls.Add(pnlGegevens);
            pnlGegevens.Location = new Point(0, 0);
            pnlGegevens.Controls.Add(overzichtG);
            overzichtG.Location = new Point(800, 0);
            pnlGegevens.Controls.Add(overzichtK);
        }

        private void menuItem_Click(object sender, EventArgs e = null)
        {
            ToolStripItem tab = (ToolStripItem)sender;

            refreshMenu();
            tab.ForeColor = Color.FromArgb(0, 0, 0);

            switch (tab.Name)
            {
                case "tabBestel":
                    tab.Image = Bestelapplicatie.Properties.Resources.menu_bestel_focus;
                    scherm = "Bestelscherm";
                    vulScherm();

                    break;

                case "tabBoek":
                    tab.Image = Bestelapplicatie.Properties.Resources.menu_boek_focus;
                    scherm = "Boekscherm";
                    vulScherm();
                    break;

                case "tabLog":
                    tab.Image = Bestelapplicatie.Properties.Resources.menu_log_focus;
                    scherm = "Loggingscherm";
                    vulScherm();
                    break;

                case "tabBedrijf":
                    tab.Image = Bestelapplicatie.Properties.Resources.menu_bedrijf_focus;
                    scherm = "Bedrijfscherm";

                    bedrijfsinformatie = BedrijfsinformatieDb.ophalen();
                    BedrijfScherm bedrijfscherm = new BedrijfScherm(bedrijfsinformatie, false);

                    pnlHoofdscherm.Controls.Clear();

                    pnlHoofdscherm.Visible = true;
                    pnlHoofdscherm.Dock = System.Windows.Forms.DockStyle.Fill;
                    pnlHoofdscherm.Controls.Clear();
                    pnlSubGegevens.Controls.Clear();
                    pnlGegevens.Controls.Clear();

                    pnlGegevens.Visible = true;
                    pnlGegevens.Size = new Size(1540, 765);
                    pnlHoofdscherm.Controls.Add(pnlGegevens);
                    pnlGegevens.Location = new Point(0, 0);
                    pnlGegevens.Controls.Add(bedrijfscherm);
                    break;

                case "tabLoguit":
                    tab.Image = Bestelapplicatie.Properties.Resources.menu_loguit_focus;

                    Account.uitloggen();
                    this.Hide();
                    Inloggen form = new Inloggen();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                    break;
            }
        }

        private void refreshMenu()
        {
            tabBestel.Image = Bestelapplicatie.Properties.Resources.menu_bestel;
            tabBestel.ForeColor = Color.FromArgb(205, 205, 205);
            tabBoek.Image = Bestelapplicatie.Properties.Resources.menu_boek;
            tabBoek.ForeColor = Color.FromArgb(205, 205, 205);
            tabBedrijf.Image = Bestelapplicatie.Properties.Resources.menu_bedrijf;
            tabBedrijf.ForeColor = Color.FromArgb(205, 205, 205);
            tabLog.Image = Bestelapplicatie.Properties.Resources.menu_log;
            tabLog.ForeColor = Color.FromArgb(205, 205, 205);
            tabLoguit.Image = Bestelapplicatie.Properties.Resources.menu_loguit;
            tabLoguit.ForeColor = Color.FromArgb(205, 205, 205);
        }

    }
}
