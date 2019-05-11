namespace Bestelapplicatie
{
    partial class Hoofdscherm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hoofdscherm));
            this.pnlHoofdscherm = new System.Windows.Forms.Panel();
            this.pnlGegevens = new System.Windows.Forms.Panel();
            this.pnlSubGegevens = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabBestel = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBoek = new System.Windows.Forms.ToolStripMenuItem();
            this.tabLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBedrijf = new System.Windows.Forms.ToolStripMenuItem();
            this.tabLoguit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHoofdscherm
            // 
            this.pnlHoofdscherm.Location = new System.Drawing.Point(24, 230);
            this.pnlHoofdscherm.Name = "pnlHoofdscherm";
            this.pnlHoofdscherm.Size = new System.Drawing.Size(396, 218);
            this.pnlHoofdscherm.TabIndex = 0;
            // 
            // pnlGegevens
            // 
            this.pnlGegevens.Location = new System.Drawing.Point(471, 230);
            this.pnlGegevens.Name = "pnlGegevens";
            this.pnlGegevens.Size = new System.Drawing.Size(345, 218);
            this.pnlGegevens.TabIndex = 1;
            // 
            // pnlSubGegevens
            // 
            this.pnlSubGegevens.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSubGegevens.Location = new System.Drawing.Point(858, 230);
            this.pnlSubGegevens.Name = "pnlSubGegevens";
            this.pnlSubGegevens.Size = new System.Drawing.Size(345, 218);
            this.pnlSubGegevens.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(77)))), ((int)(((byte)(11)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabBestel,
            this.tabBoek,
            this.tabLog,
            this.tabBedrijf,
            this.tabLoguit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 39);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabBestel
            // 
            this.tabBestel.Font = new System.Drawing.Font("Papyrus", 12F);
            this.tabBestel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabBestel.Image = global::Bestelapplicatie.Properties.Resources.menu_bestel;
            this.tabBestel.Name = "tabBestel";
            this.tabBestel.Size = new System.Drawing.Size(162, 35);
            this.tabBestel.Text = "Bestelscherm";
            this.tabBestel.Visible = false;
            this.tabBestel.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // tabBoek
            // 
            this.tabBoek.Font = new System.Drawing.Font("Papyrus", 12F);
            this.tabBoek.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabBoek.Image = global::Bestelapplicatie.Properties.Resources.menu_boek;
            this.tabBoek.Name = "tabBoek";
            this.tabBoek.Size = new System.Drawing.Size(154, 35);
            this.tabBoek.Text = "Boekscherm";
            this.tabBoek.Visible = false;
            this.tabBoek.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // tabLog
            // 
            this.tabLog.Font = new System.Drawing.Font("Papyrus", 12F);
            this.tabLog.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabLog.Image = global::Bestelapplicatie.Properties.Resources.menu_log;
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(118, 35);
            this.tabLog.Text = "Logging";
            this.tabLog.Visible = false;
            this.tabLog.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // tabBedrijf
            // 
            this.tabBedrijf.Font = new System.Drawing.Font("Papyrus", 12F);
            this.tabBedrijf.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabBedrijf.Image = global::Bestelapplicatie.Properties.Resources.menu_bedrijf;
            this.tabBedrijf.Name = "tabBedrijf";
            this.tabBedrijf.Size = new System.Drawing.Size(206, 35);
            this.tabBedrijf.Text = "Bedrijfsinformatie";
            this.tabBedrijf.Visible = false;
            this.tabBedrijf.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // tabLoguit
            // 
            this.tabLoguit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tabLoguit.Font = new System.Drawing.Font("Papyrus", 12F);
            this.tabLoguit.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabLoguit.Image = global::Bestelapplicatie.Properties.Resources.menu_loguit;
            this.tabLoguit.Name = "tabLoguit";
            this.tabLoguit.Size = new System.Drawing.Size(133, 35);
            this.tabLoguit.Text = "Uitloggen";
            this.tabLoguit.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // Hoofdscherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 477);
            this.Controls.Add(this.pnlSubGegevens);
            this.Controls.Add(this.pnlGegevens);
            this.Controls.Add(this.pnlHoofdscherm);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Hoofdscherm";
            this.Text = "Bestelapplicatie Uitgeverij Het Boekje";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabBestel;
        private System.Windows.Forms.ToolStripMenuItem tabBoek;
        private System.Windows.Forms.ToolStripMenuItem tabLog;
        private System.Windows.Forms.ToolStripMenuItem tabBedrijf;
        private System.Windows.Forms.ToolStripMenuItem tabLoguit;
        public System.Windows.Forms.Panel pnlHoofdscherm;
        public System.Windows.Forms.Panel pnlGegevens;
        public System.Windows.Forms.Panel pnlSubGegevens;
    }
}