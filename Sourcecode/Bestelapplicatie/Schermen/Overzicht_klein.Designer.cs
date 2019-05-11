namespace Bestelapplicatie.Schermen
{
    partial class Overzicht_klein
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOverzicht = new System.Windows.Forms.DataGridView();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnAanmaken = new System.Windows.Forms.Button();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.txtZoek = new System.Windows.Forms.TextBox();
            this.lblZoek = new System.Windows.Forms.Label();
            this.cmbZoek = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverzicht)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOverzicht
            // 
            this.dgvOverzicht.AllowUserToAddRows = false;
            this.dgvOverzicht.AllowUserToDeleteRows = false;
            this.dgvOverzicht.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            this.dgvOverzicht.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOverzicht.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverzicht.BackgroundColor = System.Drawing.Color.White;
            this.dgvOverzicht.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Papyrus", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOverzicht.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOverzicht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOverzicht.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOverzicht.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOverzicht.Location = new System.Drawing.Point(13, 49);
            this.dgvOverzicht.MultiSelect = false;
            this.dgvOverzicht.Name = "dgvOverzicht";
            this.dgvOverzicht.ReadOnly = true;
            this.dgvOverzicht.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOverzicht.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOverzicht.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(92)))), ((int)(((byte)(26)))));
            this.dgvOverzicht.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOverzicht.RowTemplate.Height = 24;
            this.dgvOverzicht.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOverzicht.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverzicht.Size = new System.Drawing.Size(1043, 368);
            this.dgvOverzicht.TabIndex = 157;
            this.dgvOverzicht.Sorted += new System.EventHandler(this.dgvOverzicht_Sorted);
            this.dgvOverzicht.Click += new System.EventHandler(this.dgvOverzicht_Click);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblTitel.Location = new System.Drawing.Point(18, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(120, 27);
            this.lblTitel.TabIndex = 158;
            this.lblTitel.Text = "KLANTEN";
            // 
            // btnAanmaken
            // 
            this.btnAanmaken.BackColor = System.Drawing.Color.Transparent;
            this.btnAanmaken.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAanmaken.FlatAppearance.BorderSize = 0;
            this.btnAanmaken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAanmaken.Image = global::Bestelapplicatie.Properties.Resources.imgToevoegen;
            this.btnAanmaken.Location = new System.Drawing.Point(895, 0);
            this.btnAanmaken.Name = "btnAanmaken";
            this.btnAanmaken.Size = new System.Drawing.Size(55, 40);
            this.btnAanmaken.TabIndex = 151;
            this.btnAanmaken.UseVisualStyleBackColor = false;
            this.btnAanmaken.Visible = false;
            this.btnAanmaken.Click += new System.EventHandler(this.btnAanmaken_Click);
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.BackColor = System.Drawing.Color.Transparent;
            this.btnWijzigen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWijzigen.FlatAppearance.BorderSize = 0;
            this.btnWijzigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWijzigen.Image = global::Bestelapplicatie.Properties.Resources.imgWijzigen;
            this.btnWijzigen.Location = new System.Drawing.Point(951, 0);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(55, 40);
            this.btnWijzigen.TabIndex = 152;
            this.btnWijzigen.UseVisualStyleBackColor = false;
            this.btnWijzigen.Visible = false;
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.BackColor = System.Drawing.Color.Transparent;
            this.btnVerwijderen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerwijderen.FlatAppearance.BorderSize = 0;
            this.btnVerwijderen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderen.Image = global::Bestelapplicatie.Properties.Resources.imgVerwijderen;
            this.btnVerwijderen.Location = new System.Drawing.Point(1007, 0);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(55, 40);
            this.btnVerwijderen.TabIndex = 153;
            this.btnVerwijderen.UseVisualStyleBackColor = false;
            this.btnVerwijderen.Visible = false;
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // txtZoek
            // 
            this.txtZoek.Location = new System.Drawing.Point(684, 9);
            this.txtZoek.Name = "txtZoek";
            this.txtZoek.Size = new System.Drawing.Size(209, 22);
            this.txtZoek.TabIndex = 150;
            this.txtZoek.TextChanged += new System.EventHandler(this.txtZoek_TextChanged);
            // 
            // lblZoek
            // 
            this.lblZoek.AutoSize = true;
            this.lblZoek.Font = new System.Drawing.Font("Papyrus", 10.2F);
            this.lblZoek.Location = new System.Drawing.Point(466, 7);
            this.lblZoek.Name = "lblZoek";
            this.lblZoek.Size = new System.Drawing.Size(80, 27);
            this.lblZoek.TabIndex = 155;
            this.lblZoek.Text = "Zoek op:";
            // 
            // cmbZoek
            // 
            this.cmbZoek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoek.FormattingEnabled = true;
            this.cmbZoek.Location = new System.Drawing.Point(557, 9);
            this.cmbZoek.Name = "cmbZoek";
            this.cmbZoek.Size = new System.Drawing.Size(121, 24);
            this.cmbZoek.TabIndex = 156;
            // 
            // Overzicht_klein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.dgvOverzicht);
            this.Controls.Add(this.cmbZoek);
            this.Controls.Add(this.lblZoek);
            this.Controls.Add(this.txtZoek);
            this.Controls.Add(this.btnVerwijderen);
            this.Controls.Add(this.btnWijzigen);
            this.Controls.Add(this.btnAanmaken);
            this.Name = "Overzicht_klein";
            this.Size = new System.Drawing.Size(1074, 440);
            this.Load += new System.EventHandler(this.Overzicht_klein_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverzicht)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvOverzicht;
        private System.Windows.Forms.Label lblTitel;
        public System.Windows.Forms.Button btnAanmaken;
        public System.Windows.Forms.Button btnWijzigen;
        public System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.TextBox txtZoek;
        private System.Windows.Forms.Label lblZoek;
        private System.Windows.Forms.ComboBox cmbZoek;
    }
}
