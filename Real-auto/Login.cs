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
    public partial class Login : Form
    {
        public string Util { get; set; }
        public int Ok{ get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.Masina' table. You can move, or remove it, as needed.
            this.masinaTableAdapter.Fill(this.dbDataSet.Masina);
            // TODO: This line of code loads data into the 'dbDataSet.Conturi' table. You can move, or remove it, as needed.
            this.conturiTableAdapter.Fill(this.dbDataSet.Conturi);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string util = textBox1.Text;
             string Pr = textBox2.Text;
            Ok = 0;
            conturiTableAdapter.Fill(dbDataSet.Conturi);
            DataTable t = dbDataSet.Conturi;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                if (util == t.Rows[i]["utilizator"].ToString() && Pr == t.Rows[i]["parola"].ToString())
                    Ok = 1;
            }
            if (Ok == 1)
            {
                Util = util;
                MessageBox.Show("Te-ai logat cu succes");
                this.Close();
            }
            else MessageBox.Show("date incorecte");
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
