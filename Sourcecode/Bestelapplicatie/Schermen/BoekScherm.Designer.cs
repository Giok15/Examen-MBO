namespace Bestelapplicatie.Schermen
{
    partial class BoekScherm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKlaar = new System.Windows.Forms.Button();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblIsbnNummer = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtIsbnNummer = new System.Windows.Forms.TextBox();
            this.txtTitel = new System.Windows.Forms.TextBox();
            this.txtAuteur = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblBeschrijving = new System.Windows.Forms.Label();
            this.txtBeschrijving = new System.Windows.Forms.TextBox();
            this.lblHoofdTitel = new System.Windows.Forms.Label();
            this.lblGegIsbnNummer = new System.Windows.Forms.Label();
            this.lblGegTitel = new System.Windows.Forms.Label();
            this.lblGegAuteur = new System.Windows.Forms.Label();
            this.lblGegGenre = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblGegPrijs = new System.Windows.Forms.Label();
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.lblPrijs = new System.Windows.Forms.Label();
            this.lblGegVoorraad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVoorraad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnKlaar
            // 
            this.btnKlaar.Font = new System.Drawing.Font("Papyrus", 8F);
            this.btnKlaar.Location = new System.Drawing.Point(190, 374);
            this.btnKlaar.Name = "btnKlaar";
            this.btnKlaar.Size = new System.Drawing.Size(135, 28);
            this.btnKlaar.TabIndex = 1034;
            this.btnKlaar.Text = "Aanmaken";
            this.btnKlaar.UseVisualStyleBackColor = true;
            this.btnKlaar.Visible = false;
            this.btnKlaar.Click += new System.EventHandler(this.btnKlaar_Click);
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.BackColor = System.Drawing.Color.Transparent;
            this.lblAuteur.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblAuteur.Location = new System.Drawing.Point(40, 160);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(69, 27);
            this.lblAuteur.TabIndex = 1029;
            this.lblAuteur.Text = "Auteur:";
            // 
            // lblIsbnNummer
            // 
            this.lblIsbnNummer.AutoSize = true;
            this.lblIsbnNummer.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblIsbnNummer.ForeColor = System.Drawing.Color.Black;
            this.lblIsbnNummer.Location = new System.Drawing.Point(40, 100);
            this.lblIsbnNummer.Name = "lblIsbnNummer";
            this.lblIsbnNummer.Size = new System.Drawing.Size(105, 27);
            this.lblIsbnNummer.TabIndex = 1028;
            this.lblIsbnNummer.Text = "Isbn-nummer:";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(40, 130);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(53, 27);
            this.lblTitel.TabIndex = 1027;
            this.lblTitel.Text = "Titel:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.BackColor = System.Drawing.Color.Transparent;
            this.lblGenre.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblGenre.Location = new System.Drawing.Point(40, 190);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(64, 27);
            this.lblGenre.TabIndex = 1035;
            this.lblGenre.Text = "Genre:";
            // 
            // txtIsbnNummer
            // 
            this.txtIsbnNummer.Location = new System.Drawing.Point(190, 100);
            this.txtIsbnNummer.Name = "txtIsbnNummer";
            this.txtIsbnNummer.Size = new System.Drawing.Size(203, 22);
            this.txtIsbnNummer.TabIndex = 1036;
            this.txtIsbnNummer.Visible = false;
            // 
            // txtTitel
            // 
            this.txtTitel.Location = new System.Drawing.Point(190, 130);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Size = new System.Drawing.Size(203, 22);
            this.txtTitel.TabIndex = 1037;
            this.txtTitel.Visible = false;
            // 
            // txtAuteur
            // 
            this.txtAuteur.Location = new System.Drawing.Point(190, 160);
            this.txtAuteur.Name = "txtAuteur";
            this.txtAuteur.Size = new System.Drawing.Size(203, 22);
            this.txtAuteur.TabIndex = 1038;
            this.txtAuteur.Visible = false;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(190, 190);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(203, 22);
            this.txtGenre.TabIndex = 1039;
            this.txtGenre.Visible = false;
            // 
            // lblBeschrijving
            // 
            this.lblBeschrijving.AutoSize = true;
            this.lblBeschrijving.BackColor = System.Drawing.Color.Transparent;
            this.lblBeschrijving.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblBeschrijving.Location = new System.Drawing.Point(486, 54);
            this.lblBeschrijving.Name = "lblBeschrijving";
            this.lblBeschrijving.Size = new System.Drawing.Size(102, 27);
            this.lblBeschrijving.TabIndex = 1040;
            this.lblBeschrijving.Text = "Beschrijving:";
            // 
            // txtBeschrijving
            // 
            this.txtBeschrijving.Location = new System.Drawing.Point(491, 89);
            this.txtBeschrijving.MaxLength = 1000000;
            this.txtBeschrijving.Multiline = true;
            this.txtBeschrijving.Name = "txtBeschrijving";
            this.txtBeschrijving.Size = new System.Drawing.Size(518, 224);
            this.txtBeschrijving.TabIndex = 1041;
            this.txtBeschrijving.Visible = false;
            // 
            // lblHoofdTitel
            // 
            this.lblHoofdTitel.AutoSize = true;
            this.lblHoofdTitel.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblHoofdTitel.Location = new System.Drawing.Point(103, 25);
            this.lblHoofdTitel.Name = "lblHoofdTitel";
            this.lblHoofdTitel.Size = new System.Drawing.Size(205, 27);
            this.lblHoofdTitel.TabIndex = 1065;
            this.lblHoofdTitel.Text = "BOEKGEGEVENS";
            // 
            // lblGegIsbnNummer
            // 
            this.lblGegIsbnNummer.AutoSize = true;
            this.lblGegIsbnNummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegIsbnNummer.ForeColor = System.Drawing.Color.Black;
            this.lblGegIsbnNummer.Location = new System.Drawing.Point(190, 100);
            this.lblGegIsbnNummer.Name = "lblGegIsbnNummer";
            this.lblGegIsbnNummer.Size = new System.Drawing.Size(112, 20);
            this.lblGegIsbnNummer.TabIndex = 1066;
            this.lblGegIsbnNummer.Text = "Isbn-nummer:";
            this.lblGegIsbnNummer.Visible = false;
            // 
            // lblGegTitel
            // 
            this.lblGegTitel.AutoSize = true;
            this.lblGegTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegTitel.ForeColor = System.Drawing.Color.Black;
            this.lblGegTitel.Location = new System.Drawing.Point(190, 130);
            this.lblGegTitel.Name = "lblGegTitel";
            this.lblGegTitel.Size = new System.Drawing.Size(46, 20);
            this.lblGegTitel.TabIndex = 1067;
            this.lblGegTitel.Text = "Titel:";
            this.lblGegTitel.Visible = false;
            // 
            // lblGegAuteur
            // 
            this.lblGegAuteur.AutoSize = true;
            this.lblGegAuteur.BackColor = System.Drawing.Color.Transparent;
            this.lblGegAuteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegAuteur.Location = new System.Drawing.Point(190, 160);
            this.lblGegAuteur.Name = "lblGegAuteur";
            this.lblGegAuteur.Size = new System.Drawing.Size(63, 20);
            this.lblGegAuteur.TabIndex = 1068;
            this.lblGegAuteur.Text = "Auteur:";
            this.lblGegAuteur.Visible = false;
            // 
            // lblGegGenre
            // 
            this.lblGegGenre.AutoSize = true;
            this.lblGegGenre.BackColor = System.Drawing.Color.Transparent;
            this.lblGegGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegGenre.Location = new System.Drawing.Point(190, 190);
            this.lblGegGenre.Name = "lblGegGenre";
            this.lblGegGenre.Size = new System.Drawing.Size(60, 20);
            this.lblGegGenre.TabIndex = 1069;
            this.lblGegGenre.Text = "Genre:";
            this.lblGegGenre.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(41, 315);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(18, 20);
            this.lblError.TabIndex = 1073;
            this.lblError.Text = "d";
            this.lblError.Visible = false;
            // 
            // lblGegPrijs
            // 
            this.lblGegPrijs.AutoSize = true;
            this.lblGegPrijs.BackColor = System.Drawing.Color.Transparent;
            this.lblGegPrijs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegPrijs.Location = new System.Drawing.Point(190, 222);
            this.lblGegPrijs.Name = "lblGegPrijs";
            this.lblGegPrijs.Size = new System.Drawing.Size(48, 20);
            this.lblGegPrijs.TabIndex = 1076;
            this.lblGegPrijs.Text = "Prijs:";
            this.lblGegPrijs.Visible = false;
            // 
            // txtPrijs
            // 
            this.txtPrijs.Location = new System.Drawing.Point(190, 222);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(203, 22);
            this.txtPrijs.TabIndex = 1075;
            this.txtPrijs.Visible = false;
            // 
            // lblPrijs
            // 
            this.lblPrijs.AutoSize = true;
            this.lblPrijs.BackColor = System.Drawing.Color.Transparent;
            this.lblPrijs.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblPrijs.Location = new System.Drawing.Point(40, 222);
            this.lblPrijs.Name = "lblPrijs";
            this.lblPrijs.Size = new System.Drawing.Size(45, 27);
            this.lblPrijs.TabIndex = 1074;
            this.lblPrijs.Text = "Prijs:";
            // 
            // lblGegVoorraad
            // 
            this.lblGegVoorraad.AutoSize = true;
            this.lblGegVoorraad.BackColor = System.Drawing.Color.Transparent;
            this.lblGegVoorraad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGegVoorraad.Location = new System.Drawing.Point(190, 260);
            this.lblGegVoorraad.Name = "lblGegVoorraad";
            this.lblGegVoorraad.Size = new System.Drawing.Size(56, 20);
            this.lblGegVoorraad.TabIndex = 1082;
            this.lblGegVoorraad.Text = "Aantal";
            this.lblGegVoorraad.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.label2.Location = new System.Drawing.Point(40, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 27);
            this.label2.TabIndex = 1081;
            this.label2.Text = "Voorraad:";
            // 
            // txtVoorraad
            // 
            this.txtVoorraad.Location = new System.Drawing.Point(190, 260);
            this.txtVoorraad.Name = "txtVoorraad";
            this.txtVoorraad.Size = new System.Drawing.Size(72, 22);
            this.txtVoorraad.TabIndex = 1083;
            this.txtVoorraad.Visible = false;
            // 
            // BoekScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGegVoorraad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGegPrijs);
            this.Controls.Add(this.txtPrijs);
            this.Controls.Add(this.lblPrijs);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblGegGenre);
            this.Controls.Add(this.lblGegAuteur);
            this.Controls.Add(this.lblGegTitel);
            this.Controls.Add(this.lblGegIsbnNummer);
            this.Controls.Add(this.lblHoofdTitel);
            this.Controls.Add(this.txtBeschrijving);
            this.Controls.Add(this.lblBeschrijving);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtAuteur);
            this.Controls.Add(this.txtTitel);
            this.Controls.Add(this.txtIsbnNummer);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.btnKlaar);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.lblIsbnNummer);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.txtVoorraad);
            this.Name = "BoekScherm";
            this.Size = new System.Drawing.Size(1074, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblIsbnNummer;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtIsbnNummer;
        private System.Windows.Forms.TextBox txtTitel;
        private System.Windows.Forms.TextBox txtAuteur;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblBeschrijving;
        private System.Windows.Forms.TextBox txtBeschrijving;
        private System.Windows.Forms.Label lblHoofdTitel;
        private System.Windows.Forms.Label lblGegIsbnNummer;
        private System.Windows.Forms.Label lblGegTitel;
        private System.Windows.Forms.Label lblGegAuteur;
        private System.Windows.Forms.Label lblGegGenre;
        private System.Windows.Forms.Button btnKlaar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblGegPrijs;
        private System.Windows.Forms.TextBox txtPrijs;
        private System.Windows.Forms.Label lblPrijs;
        private System.Windows.Forms.Label lblGegVoorraad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVoorraad;
    }
}
