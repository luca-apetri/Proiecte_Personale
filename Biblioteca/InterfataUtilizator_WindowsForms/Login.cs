using System;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
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
