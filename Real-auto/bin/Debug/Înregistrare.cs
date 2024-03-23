using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Real_auto
{
    public partial class Înregistrare : Form
    {
        public Înregistrare()
        {
            InitializeComponent();
        }

        private void Înregistrare_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.Masina' table. You can move, or remove it, as needed.
            this.masinaTableAdapter.Fill(this.dbDataSet.Masina);
            // TODO: This line of code loads data into the 'dbDataSet.Conturi' table. You can move, or remove it, as needed.
            this.conturiTableAdapter.Fill(this.dbDataSet.Conturi);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int a1 = 1,a2=1,a3=1,a4=1;
            if (conturiTableAdapter.IdUtilizator(a) !=null)
            {
                MessageBox.Show("Utilizator deja existent");
                a1 = 0;
            }
            string b = textBox2.Text;
            if(b.Length<4)
            {
                MessageBox.Show("Parola nu are destule caractere");
                a2=0;
            }
            string c = textBox3.Text;
            if (b != c)
            {
                MessageBox.Show("Parolele nu sunt identice");
                a3 = 0;
            }
            string d = textBox4.Text;
            if (d.Length != 10)
            {
                MessageBox.Show("Numărul de telefon nu conține 10 caractere");
                a4 = 0;
            }
            int nr=(int)conturiTableAdapter.Nrutilizatori()+1;
            if (a1 == 1 && a2 == 1 && a3 == 1 && a4 == 1)
            {
                conturiTableAdapter.Adaugare_utilizator(nr, a, b, d);
                conturiTableAdapter.Update(dbDataSet.Conturi);
                MessageBox.Show("Înregistrare cu succes");
                this.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
