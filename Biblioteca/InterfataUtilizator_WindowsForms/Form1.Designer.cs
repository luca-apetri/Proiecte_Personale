
namespace InterfataUtilizator_WindowsForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Afisare = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AdaugareCarte = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AdaugaraPersoana = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Iesire = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Afisare
            // 
            this.Afisare.BackColor = System.Drawing.SystemColors.Control;
            this.Afisare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.Afisare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Afisare.ForeColor = System.Drawing.Color.Black;
            this.Afisare.Location = new System.Drawing.Point(83, 135);
            this.Afisare.Name = "Afisare";
            this.Afisare.Size = new System.Drawing.Size(75, 23);
            this.Afisare.TabIndex = 1;
            this.Afisare.Text = "afisare";
            this.Afisare.UseVisualStyleBackColor = false;
            this.Afisare.Click += new System.EventHandler(this.Afisare_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AdaugareCarte
            // 
            this.AdaugareCarte.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.AdaugareCarte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AdaugareCarte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.AdaugareCarte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdaugareCarte.ForeColor = System.Drawing.Color.Black;
            this.AdaugareCarte.Location = new System.Drawing.Point(12, 89);
            this.AdaugareCarte.Name = "AdaugareCarte";
            this.AdaugareCarte.Size = new System.Drawing.Size(100, 36);
            this.AdaugareCarte.TabIndex = 3;
            this.AdaugareCarte.Text = "Adaugare carte";
            this.AdaugareCarte.UseVisualStyleBackColor = true;
            this.AdaugareCarte.Click += new System.EventHandler(this.AdaugareCarte_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nume/Titlu";
            // 
            // AdaugaraPersoana
            // 
            this.AdaugaraPersoana.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.AdaugaraPersoana.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AdaugaraPersoana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.AdaugaraPersoana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdaugaraPersoana.ForeColor = System.Drawing.Color.Black;
            this.AdaugaraPersoana.Location = new System.Drawing.Point(130, 89);
            this.AdaugaraPersoana.Name = "AdaugaraPersoana";
            this.AdaugaraPersoana.Size = new System.Drawing.Size(98, 36);
            this.AdaugaraPersoana.TabIndex = 7;
            this.AdaugaraPersoana.Text = "Adaugare persoana";
            this.AdaugaraPersoana.UseVisualStyleBackColor = true;
            this.AdaugaraPersoana.Click += new System.EventHandler(this.AdaugarePersoana_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(140, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Prenume/Autor";
            // 
            // Iesire
            // 
            this.Iesire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Iesire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Iesire.ForeColor = System.Drawing.Color.Black;
            this.Iesire.Location = new System.Drawing.Point(83, 164);
            this.Iesire.Name = "Iesire";
            this.Iesire.Size = new System.Drawing.Size(75, 23);
            this.Iesire.TabIndex = 9;
            this.Iesire.Text = "Iesire";
            this.Iesire.UseVisualStyleBackColor = true;
            this.Iesire.Click += new System.EventHandler(this.Iesire_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(236, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(263, 405);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.Black;
            this.dataGridView2.Location = new System.Drawing.Point(497, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(255, 405);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Logout
            // 
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.Logout.FlatAppearance.BorderSize = 2;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout.ForeColor = System.Drawing.Color.Black;
            this.Logout.Location = new System.Drawing.Point(83, 394);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 12;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Iesire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdaugaraPersoana);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.AdaugareCarte);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Afisare);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Afisare;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AdaugareCarte;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AdaugaraPersoana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Iesire;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button Logout;
    }
}

