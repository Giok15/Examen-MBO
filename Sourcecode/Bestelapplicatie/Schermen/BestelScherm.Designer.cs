namespace Bestelapplicatie.Schermen
{
    partial class BestelScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BestelScherm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnKlaar = new System.Windows.Forms.Button();
            this.lblHoofdTitel = new System.Windows.Forms.Label();
            this.lblTotaal = new System.Windows.Forms.Label();
            this.lblPrijs = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.picVoltooid = new System.Windows.Forms.PictureBox();
            this.picWachten = new System.Windows.Forms.PictureBox();
            this.picVerzenden = new System.Windows.Forms.PictureBox();
            this.picKassa = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGegStatus = new System.Windows.Forms.Label();
            this.picAnnuleer = new System.Windows.Forms.PictureBox();
            this.lblGegBesteldatum = new System.Windows.Forms.Label();
            this.lblBesteldatum = new System.Windows.Forms.Label();
            this.lblGegLeverdatum = new System.Windows.Forms.Label();
            this.lblLeverdatum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrinten = new System.Windows.Forms.Button();
            this.btnFactuur = new System.Windows.Forms.Button();
            this.picHuisstijl = new System.Windows.Forms.PictureBox();
            this.lblGegStatusExtra = new System.Windows.Forms.Label();
            this.dgvBoeken = new System.Windows.Forms.DataGridView();
            this.Aantal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toevoegen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Prijs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbZoek = new System.Windows.Forms.ComboBox();
            this.lblZoek = new System.Windows.Forms.Label();
            this.txtZoek = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVoltooid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWachten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerzenden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKassa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnnuleer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHuisstijl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoeken)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKlaar
            // 
            this.btnKlaar.Font = new System.Drawing.Font("Papyrus", 8F);
            this.btnKlaar.Location = new System.Drawing.Point(18, 397);
            this.btnKlaar.Name = "btnKlaar";
            this.btnKlaar.Size = new System.Drawing.Size(135, 28);
            this.btnKlaar.TabIndex = 1026;
            this.btnKlaar.Text = "Aanmaken";
            this.btnKlaar.UseVisualStyleBackColor = true;
            this.btnKlaar.Visible = false;
            this.btnKlaar.Click += new System.EventHandler(this.btnKlaar_Click);
            // 
            // lblHoofdTitel
            // 
            this.lblHoofdTitel.AutoSize = true;
            this.lblHoofdTitel.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblHoofdTitel.Location = new System.Drawing.Point(293, 0);
            this.lblHoofdTitel.Name = "lblHoofdTitel";
            this.lblHoofdTitel.Size = new System.Drawing.Size(281, 27);
            this.lblHoofdTitel.TabIndex = 1065;
            this.lblHoofdTitel.Text = "BESTELLINGGEGEVENS";
            // 
            // lblTotaal
            // 
            this.lblTotaal.AutoSize = true;
            this.lblTotaal.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaal.ForeColor = System.Drawing.Color.Black;
            this.lblTotaal.Location = new System.Drawing.Point(870, 394);
            this.lblTotaal.Name = "lblTotaal";
            this.lblTotaal.Size = new System.Drawing.Size(69, 27);
            this.lblTotaal.TabIndex = 1109;
            this.lblTotaal.Text = "Totaal:";
            // 
            // lblPrijs
            // 
            this.lblPrijs.AutoSize = true;
            this.lblPrijs.BackColor = System.Drawing.Color.Transparent;
            this.lblPrijs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrijs.Location = new System.Drawing.Point(963, 397);
            this.lblPrijs.Name = "lblPrijs";
            this.lblPrijs.Size = new System.Drawing.Size(32, 20);
            this.lblPrijs.TabIndex = 1110;
            this.lblPrijs.Text = "€ 0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(177, 405);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 1111;
            this.lblError.Visible = false;
            // 
            // picVoltooid
            // 
            this.picVoltooid.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picVoltooid.Image = global::Bestelapplicatie.Properties.Resources.voltooid;
            this.picVoltooid.Location = new System.Drawing.Point(257, 238);
            this.picVoltooid.Name = "picVoltooid";
            this.picVoltooid.Size = new System.Drawing.Size(30, 30);
            this.picVoltooid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVoltooid.TabIndex = 1116;
            this.picVoltooid.TabStop = false;
            this.picVoltooid.Visible = false;
            // 
            // picWachten
            // 
            this.picWachten.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picWachten.Image = global::Bestelapplicatie.Properties.Resources.wachten;
            this.picWachten.Location = new System.Drawing.Point(352, 230);
            this.picWachten.Name = "picWachten";
            this.picWachten.Size = new System.Drawing.Size(40, 40);
            this.picWachten.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWachten.TabIndex = 1115;
            this.picWachten.TabStop = false;
            this.picWachten.Visible = false;
            // 
            // picVerzenden
            // 
            this.picVerzenden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVerzenden.Image = global::Bestelapplicatie.Properties.Resources.verzenden;
            this.picVerzenden.Location = new System.Drawing.Point(306, 230);
            this.picVerzenden.Name = "picVerzenden";
            this.picVerzenden.Size = new System.Drawing.Size(40, 40);
            this.picVerzenden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVerzenden.TabIndex = 1114;
            this.picVerzenden.TabStop = false;
            this.picVerzenden.Visible = false;
            this.picVerzenden.Click += new System.EventHandler(this.picVerzenden_Click);
            // 
            // picKassa
            // 
            this.picKassa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picKassa.Image = global::Bestelapplicatie.Properties.Resources.kassa;
            this.picKassa.Location = new System.Drawing.Point(328, 230);
            this.picKassa.Name = "picKassa";
            this.picKassa.Size = new System.Drawing.Size(40, 40);
            this.picKassa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKassa.TabIndex = 1113;
            this.picKassa.TabStop = false;
            this.picKassa.Visible = false;
            this.picKassa.Click += new System.EventHandler(this.picKassa_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblStatus.Location = new System.Drawing.Point(43, 241);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 27);
            this.lblStatus.TabIndex = 1117;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Visible = false;
            // 
            // lblGegStatus
            // 
            this.lblGegStatus.AutoSize = true;
            this.lblGegStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblGegStatus.Location = new System.Drawing.Point(164, 243);
            this.lblGegStatus.Name = "lblGegStatus";
            this.lblGegStatus.Size = new System.Drawing.Size(62, 20);
            this.lblGegStatus.TabIndex = 1118;
            this.lblGegStatus.Text = "Status:";
            this.lblGegStatus.Visible = false;
            // 
            // picAnnuleer
            // 
            this.picAnnuleer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picAnnuleer.Image = global::Bestelapplicatie.Properties.Resources.annuleren;
            this.picAnnuleer.Location = new System.Drawing.Point(300, 238);
            this.picAnnuleer.Name = "picAnnuleer";
            this.picAnnuleer.Size = new System.Drawing.Size(30, 30);
            this.picAnnuleer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnnuleer.TabIndex = 1119;
            this.picAnnuleer.TabStop = false;
            this.picAnnuleer.Visible = false;
            // 
            // lblGegBesteldatum
            // 
            this.lblGegBesteldatum.AutoSize = true;
            this.lblGegBesteldatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblGegBesteldatum.Location = new System.Drawing.Point(167, 102);
            this.lblGegBesteldatum.Name = "lblGegBesteldatum";
            this.lblGegBesteldatum.Size = new System.Drawing.Size(105, 20);
            this.lblGegBesteldatum.TabIndex = 1121;
            this.lblGegBesteldatum.Text = "besteldatum:";
            this.lblGegBesteldatum.Visible = false;
            // 
            // lblBesteldatum
            // 
            this.lblBesteldatum.AutoSize = true;
            this.lblBesteldatum.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblBesteldatum.Location = new System.Drawing.Point(40, 100);
            this.lblBesteldatum.Name = "lblBesteldatum";
            this.lblBesteldatum.Size = new System.Drawing.Size(110, 27);
            this.lblBesteldatum.TabIndex = 1120;
            this.lblBesteldatum.Text = "Besteldatum:";
            this.lblBesteldatum.Visible = false;
            // 
            // lblGegLeverdatum
            // 
            this.lblGegLeverdatum.AutoSize = true;
            this.lblGegLeverdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblGegLeverdatum.Location = new System.Drawing.Point(167, 147);
            this.lblGegLeverdatum.Name = "lblGegLeverdatum";
            this.lblGegLeverdatum.Size = new System.Drawing.Size(96, 20);
            this.lblGegLeverdatum.TabIndex = 1123;
            this.lblGegLeverdatum.Text = "leverdatum:";
            this.lblGegLeverdatum.Visible = false;
            // 
            // lblLeverdatum
            // 
            this.lblLeverdatum.AutoSize = true;
            this.lblLeverdatum.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblLeverdatum.Location = new System.Drawing.Point(40, 145);
            this.lblLeverdatum.Name = "lblLeverdatum";
            this.lblLeverdatum.Size = new System.Drawing.Size(100, 27);
            this.lblLeverdatum.TabIndex = 1122;
            this.lblLeverdatum.Text = "Leverdatum:";
            this.lblLeverdatum.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.label6.Location = new System.Drawing.Point(40, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 1124;
            this.label6.Text = "Factuur:";
            this.label6.Visible = false;
            // 
            // btnPrinten
            // 
            this.btnPrinten.BackColor = System.Drawing.Color.Transparent;
            this.btnPrinten.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinten.FlatAppearance.BorderSize = 0;
            this.btnPrinten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinten.Image = ((System.Drawing.Image)(resources.GetObject("btnPrinten.Image")));
            this.btnPrinten.Location = new System.Drawing.Point(232, 184);
            this.btnPrinten.Name = "btnPrinten";
            this.btnPrinten.Size = new System.Drawing.Size(55, 40);
            this.btnPrinten.TabIndex = 1127;
            this.btnPrinten.UseVisualStyleBackColor = false;
            this.btnPrinten.Visible = false;
            this.btnPrinten.Click += new System.EventHandler(this.btnPrinten_Click);
            // 
            // btnFactuur
            // 
            this.btnFactuur.BackColor = System.Drawing.Color.Transparent;
            this.btnFactuur.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFactuur.FlatAppearance.BorderSize = 0;
            this.btnFactuur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactuur.Image = ((System.Drawing.Image)(resources.GetObject("btnFactuur.Image")));
            this.btnFactuur.Location = new System.Drawing.Point(171, 184);
            this.btnFactuur.Name = "btnFactuur";
            this.btnFactuur.Size = new System.Drawing.Size(55, 40);
            this.btnFactuur.TabIndex = 1126;
            this.btnFactuur.UseVisualStyleBackColor = false;
            this.btnFactuur.Visible = false;
            this.btnFactuur.Click += new System.EventHandler(this.btnFactuur_Click);
            // 
            // picHuisstijl
            // 
            this.picHuisstijl.Image = global::Bestelapplicatie.Properties.Resources.afbeeldingHetBoekje3;
            this.picHuisstijl.Location = new System.Drawing.Point(531, 72);
            this.picHuisstijl.Name = "picHuisstijl";
            this.picHuisstijl.Size = new System.Drawing.Size(507, 345);
            this.picHuisstijl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHuisstijl.TabIndex = 1128;
            this.picHuisstijl.TabStop = false;
            // 
            // lblGegStatusExtra
            // 
            this.lblGegStatusExtra.AutoSize = true;
            this.lblGegStatusExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblGegStatusExtra.Location = new System.Drawing.Point(44, 279);
            this.lblGegStatusExtra.Name = "lblGegStatusExtra";
            this.lblGegStatusExtra.Size = new System.Drawing.Size(76, 20);
            this.lblGegStatusExtra.TabIndex = 1129;
            this.lblGegStatusExtra.Text = "Status 2:";
            this.lblGegStatusExtra.Visible = false;
            // 
            // dgvBoeken
            // 
            this.dgvBoeken.AllowUserToAddRows = false;
            this.dgvBoeken.AllowUserToDeleteRows = false;
            this.dgvBoeken.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            this.dgvBoeken.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBoeken.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoeken.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoeken.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Papyrus", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBoeken.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBoeken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoeken.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Aantal,
            this.Toevoegen,
            this.Prijs});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBoeken.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBoeken.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvBoeken.Location = new System.Drawing.Point(18, 79);
            this.dgvBoeken.MultiSelect = false;
            this.dgvBoeken.Name = "dgvBoeken";
            this.dgvBoeken.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBoeken.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBoeken.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            this.dgvBoeken.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBoeken.RowTemplate.Height = 24;
            this.dgvBoeken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBoeken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBoeken.Size = new System.Drawing.Size(1006, 312);
            this.dgvBoeken.TabIndex = 1130;
            this.dgvBoeken.Visible = false;
            this.dgvBoeken.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBoeken_CellBeginEdit);
            this.dgvBoeken.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoeken_CellContentClick);
            this.dgvBoeken.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoeken_CellEndEdit);
            // 
            // Aantal
            // 
            this.Aantal.HeaderText = "Aantal";
            this.Aantal.Name = "Aantal";
            // 
            // Toevoegen
            // 
            this.Toevoegen.FalseValue = "False";
            this.Toevoegen.HeaderText = "Toevoegen";
            this.Toevoegen.IndeterminateValue = "False";
            this.Toevoegen.Name = "Toevoegen";
            this.Toevoegen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Toevoegen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Toevoegen.TrueValue = "True";
            // 
            // Prijs
            // 
            this.Prijs.HeaderText = "Subtotaal prijs";
            this.Prijs.Name = "Prijs";
            // 
            // cmbZoek
            // 
            this.cmbZoek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoek.FormattingEnabled = true;
            this.cmbZoek.Location = new System.Drawing.Point(105, 41);
            this.cmbZoek.Name = "cmbZoek";
            this.cmbZoek.Size = new System.Drawing.Size(121, 24);
            this.cmbZoek.TabIndex = 1133;
            this.cmbZoek.Visible = false;
            // 
            // lblZoek
            // 
            this.lblZoek.AutoSize = true;
            this.lblZoek.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblZoek.Location = new System.Drawing.Point(14, 39);
            this.lblZoek.Name = "lblZoek";
            this.lblZoek.Size = new System.Drawing.Size(80, 27);
            this.lblZoek.TabIndex = 1132;
            this.lblZoek.Text = "Zoek op:";
            this.lblZoek.Visible = false;
            // 
            // txtZoek
            // 
            this.txtZoek.Location = new System.Drawing.Point(232, 41);
            this.txtZoek.Name = "txtZoek";
            this.txtZoek.Size = new System.Drawing.Size(209, 22);
            this.txtZoek.TabIndex = 1131;
            this.txtZoek.Visible = false;
            this.txtZoek.TextChanged += new System.EventHandler(this.txtZoek_TextChanged);
            // 
            // BestelScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbZoek);
            this.Controls.Add(this.lblZoek);
            this.Controls.Add(this.txtZoek);
            this.Controls.Add(this.picKassa);
            this.Controls.Add(this.lblGegStatusExtra);
            this.Controls.Add(this.picHuisstijl);
            this.Controls.Add(this.btnPrinten);
            this.Controls.Add(this.btnFactuur);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblGegLeverdatum);
            this.Controls.Add(this.lblLeverdatum);
            this.Controls.Add(this.lblGegBesteldatum);
            this.Controls.Add(this.lblBesteldatum);
            this.Controls.Add(this.picAnnuleer);
            this.Controls.Add(this.lblGegStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picVoltooid);
            this.Controls.Add(this.picWachten);
            this.Controls.Add(this.picVerzenden);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblPrijs);
            this.Controls.Add(this.lblTotaal);
            this.Controls.Add(this.lblHoofdTitel);
            this.Controls.Add(this.btnKlaar);
            this.Controls.Add(this.dgvBoeken);
            this.Name = "BestelScherm";
            this.Size = new System.Drawing.Size(1074, 440);
            this.Load += new System.EventHandler(this.BestelScherm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVoltooid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWachten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerzenden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKassa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnnuleer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHuisstijl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoeken)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnKlaar;
        private System.Windows.Forms.Label lblHoofdTitel;
        private System.Windows.Forms.Label lblTotaal;
        private System.Windows.Forms.Label lblPrijs;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox picKassa;
        private System.Windows.Forms.PictureBox picVerzenden;
        private System.Windows.Forms.PictureBox picWachten;
        private System.Windows.Forms.PictureBox picVoltooid;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGegStatus;
        private System.Windows.Forms.PictureBox picAnnuleer;
        private System.Windows.Forms.Label lblGegBesteldatum;
        private System.Windows.Forms.Label lblBesteldatum;
        private System.Windows.Forms.Label lblGegLeverdatum;
        private System.Windows.Forms.Label lblLeverdatum;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnPrinten;
        public System.Windows.Forms.Button btnFactuur;
        private System.Windows.Forms.PictureBox picHuisstijl;
        private System.Windows.Forms.Label lblGegStatusExtra;
        public System.Windows.Forms.DataGridView dgvBoeken;
        private System.Windows.Forms.ComboBox cmbZoek;
        private System.Windows.Forms.Label lblZoek;
        private System.Windows.Forms.TextBox txtZoek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aantal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Toevoegen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prijs;
    }
}
