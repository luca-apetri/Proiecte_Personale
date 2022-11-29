using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibrarieClase;
using StocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareCarti_FisierText adminCarti;
        AdministrarePersoane_FisierText adminPersoane;

        private const int LATIME_CONTROL = 300;
        private const int DIMENSIUNE_PAS_Y = 20;
        private const int DIMENSIUNE_PAS_X = 100;
        private const int MARGINE = 10;

        private Label[] lblsTitluCarti;
        private Label[] lblsAutorCarti;
        private Label[] lblsNumePersoane;
        private Label[] lblsPrenumePersoane;




        public Form1()
        {
            string numeFisierCarti = ConfigurationManager.AppSettings["NumeFisierCarti"];
            string locatieFisierSolutie1 = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisierCarti;
            adminCarti = new AdministrareCarti_FisierText(caleCompletaFisier1);

            string numeFisierPersoane = ConfigurationManager.AppSettings["NumeFisierPersoane"];
            string locatieFisierSolutie2 = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisierPersoane;
            adminPersoane = new AdministrarePersoane_FisierText(caleCompletaFisier2);

            InitializeComponent();

            table.Columns.Add("Titlu", typeof(string));
            table.Columns.Add("Autor", typeof(string));
            table1.Columns.Add("Nume", typeof(string));
            table1.Columns.Add("Prenume", typeof(string));

            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.AliceBlue;
            this.Text = "biblioteca";
        }

        DataTable table = new DataTable("table");
        DataTable table1 = new DataTable("table1");



        private void Afisare_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            table1.Rows.Clear();
            Carte[] carti = adminCarti.GetCarti(out int nrCarti);
            if (nrCarti == 0)
                return;
            lblsAutorCarti = new Label[nrCarti];
            lblsTitluCarti = new Label[nrCarti];


            for (int i = 0; i < nrCarti; i++)
            {
                Carte carte = carti[i];




                lblsTitluCarti[i] = new Label();
                lblsTitluCarti[i].Width = LATIME_CONTROL;
                lblsTitluCarti[i].Text = carte.GetTitluC();
                lblsTitluCarti[i].Left = MARGINE * 2;
                lblsTitluCarti[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsTitluCarti[i].ForeColor = Color.Black;

                lblsAutorCarti[i] = new Label();
                lblsAutorCarti[i].Width = LATIME_CONTROL + 10;
                lblsAutorCarti[i].Text = carte.GetAutorC();
                lblsAutorCarti[i].Left = MARGINE * 5;
                lblsAutorCarti[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsAutorCarti[i].ForeColor = Color.Black;

                table.Rows.Add(lblsTitluCarti[i].Text, carte.GetAutorC());

            }
            dataGridView1.DataSource = table;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;



            Persoana[] persoane = adminPersoane.GetPersoane(out int nrPersoane);
            if (nrPersoane == 0)
                return;
            lblsNumePersoane = new Label[nrPersoane];
            lblsPrenumePersoane = new Label[nrPersoane];

            for (int i = 0; i < nrPersoane; i++)
            {

                Persoana persoana = persoane[i];
                table1.Rows.Add(persoana.GetNumeP(), persoana.GetPrenumeP());
                /*
                lblsNumePersoane[i] = new Label();
                lblsNumePersoane[i].Width = LATIME_CONTROL;
                lblsNumePersoane[i].Text =persoana.GetNumeP()+ " " + persoana.GetPrenumeP();
                lblsNumePersoane[i].Left = DIMENSIUNE_PAS_X * 6;
                lblsNumePersoane[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsNumePersoane[i].ForeColor = Color.Black;
                this.Controls.Add(lblsNumePersoane[i]);
                /*
                lblsPrenumePersoane[i] = new Label();
                lblsPrenumePersoane[i].Width = LATIME_CONTROL + 10;
                lblsPrenumePersoane[i].Text = persoana.GetPrenumeP();
                lblsPrenumePersoane[i].Left = DIMENSIUNE_PAS_X * 8;
                lblsPrenumePersoane[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsPrenumePersoane[i].ForeColor = Color.Black;
                this.Controls.Add(lblsPrenumePersoane[i]);
                */
            }
            dataGridView2.DataSource = table1;

            this.dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdaugareCarte_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox2.Text == string.Empty)
            {
                MessageBox.Show("Date invalide, completati casutele");
            }
            else
            {
                Carte[] carti = adminCarti.GetCarti(out int nrCarti);
                Carte carte = new Carte();
                carte.idCarte = nrCarti + 1;
                carte.titlu = textBox1.Text;
                carte.autor = textBox2.Text;
                adminCarti.AddCarte(carte);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }



        private void AdaugarePersoana_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox2.Text == string.Empty)
            {
                MessageBox.Show("Date invalide, completati casutele");
            }
            else
            {
                Persoana[] persoane = adminPersoane.GetPersoane(out int nrPersoane);
                Persoana persoana = new Persoana();
                persoana.idPersoana = nrPersoane + 1;
                persoana.nume = textBox1.Text;
                persoana.prenume = textBox2.Text;
                adminPersoane.AddPersoana(persoana);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }
        private void Iesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            {
                Dock = DockStyle.Fill;
                TopLevel = false;
                TopMost = true;
            }
            // frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            // this.pContainer.Controls.Add(frm);
            frm.Show();
        }
    }
}
