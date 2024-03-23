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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listaMTableAdapter.Fill(this.dbDataSet.ListaM);
            this.masinaTableAdapter.Fill(this.dbDataSet.Masina);
            // TODO: This line of code loads data into the 'dbDataSet.Conturi' table. You can move, or remove it, as needed.
            this.conturiTableAdapter.Fill(this.dbDataSet.Conturi);
            dbDataSet.EnforceConstraints = false;

        }
        Login fa = new Login();
        private void button1_Click(object sender, EventArgs e)//buton autentificare
        {
            if (button1.Text == "Autentificare")
            {
                fa.ShowDialog();
                int ok = fa.Ok;
                if (ok == 1)
                {
                    button1.Text = "Logout";
                    button2.Visible = false;
                }
            }
            else
            {
                if (button1.Text == "Logout")
                {
                    button1.Text = "Autentificare";
                    button2.Visible = true;
                    fa.Util = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//buton inregistrare
        {
            Înregistrare f = new Înregistrare();
            f.ShowDialog();
        }
        public bool vf(string a)//functie verificare daca nr contine doar cifre
        {
            bool ok = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > '9' || a[i] < '0')
                {
                    ok = false;
                }
            }
            return ok;
        }
        private void button3_Click(object sender, EventArgs e)//buton cautare masina
        {
            listBox1.Items.Clear();
            int vp = 0;
            string a = textBox1.Text;
            string b = textBox2.Text;
            float c;
            if (textBox3.Text != "")
            {
                if (vf(textBox3.Text))
                    c = float.Parse(textBox3.Text);
                else { c = -2; MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre."); }
            }
            else c = -1;
                
            string d="";
            if (checkBox1.Checked == true)
            {
                d = "benzină";
            }
            else
            {
                if (checkBox2.Checked == true)
                {
                    d = "motorină";
                }
                else
                {
                    if (checkBox3.Checked == true)
                    {
                        d = "hibrid";
                    }
                    else
                    {
                        if (checkBox4.Checked == true)
                        {
                            d = "electric";
                        }
                    }
                }
            }
            int f = 0;
            if (checkBox5.Checked == true)
            {
                f = 2;
                if (checkBox6.Checked == true)
                    f = 3;
            }
            else if (checkBox6.Checked == true)
                f = 1;
            if (f == 3)
            {
                MessageBox.Show("Selectati doar o obțiune!");
                vp = 1;
            }
            float g;
            if (textBox4.Text != "")
            {
                if (vf(textBox4.Text))
                    g = float.Parse(textBox4.Text);
                else
                {
                    g = -2;
                    MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");

                }
            }
            else g = -1;
            float mp, map;
            if (textBox5.Text != "")
            {
                if (vf(textBox5.Text))
                    mp = float.Parse(textBox5.Text);
                else
                {
                    mp = -2;
                    MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                }
            }else mp=-1;
            if (textBox6.Text != "")
            {
                if (vf(textBox6.Text))
                    map = float.Parse(textBox6.Text);
                else
                {
                    map = -2;
                    MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                }
            }
            else map = -1;
            float min, max;
            if (textBox7.Text != "")
            {
                if (vf(textBox7.Text))
                    min = float.Parse(textBox7.Text);
                else
                {
                    min = -2;
                    MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                }
            }else min=-1;
            if (textBox8.Text != "")
            {
                if (vf(textBox8.Text))
                    max = float.Parse(textBox8.Text);
                else
                {
                    max = -2;
                    MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                }
            }
            else max = -1;
            int a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0,a9=0,a10=0;
            conturiTableAdapter.ListaMasiniCuUtilizatori(dbDataSet.Conturi);
            DataTable t = dbDataSet.Conturi; 
            string mas="";
            int nr = 0;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                mas= "";
                a1 = 0; a2 = 0; a3 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0;
                if (a.ToLower() == t.Rows[i]["Nume"].ToString().ToLower() || a=="")
                    a1 = 1;
                if (b.ToLower() == t.Rows[i]["Marca"].ToString().ToLower() || b=="")
                    a2 = 1;
                if (c == float.Parse(t.Rows[i]["Anul_fabricari"].ToString()) || c == -1)
                    a3 = 1;
                if (d == t.Rows[i]["Combustibil"].ToString().ToLower() || d == "")
                    a4 = 1;
                if (f == int.Parse(t.Rows[i]["CutieViteze"].ToString()) || f == 0)
                    a5 = 1;
                if (g >= float.Parse(t.Rows[i]["Kilometraj"].ToString()) || g == -1)
                    a6 = 1;
                if (mp == -1  || mp <= float.Parse(t.Rows[i]["Putere"].ToString()))
                    a7 = 1;
                if( map >= float.Parse(t.Rows[i]["Putere"].ToString())|| map == -1)
                    a8=1;
                if (min == -1 || min <= float.Parse(t.Rows[i]["Pret"].ToString()))
                    a9 = 1;
                if (max >= float.Parse(t.Rows[i]["Pret"].ToString()) || max == -1)
                    a10 = 1;
                if (a1 == 1 && a2 == 1 && a3 == 1 && a4 == 1 && a5 == 1 && a6 == 1 && a7 == 1 && a8 == 1 && a9==1 && a10==1)
                {
                    vp = 1;
                    nr++;
                    mas +=nr.ToString()+". "+"Numele utilizatorului: "+t.Rows[i]["utilizator"].ToString()+"\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Numărul de telefon: " + t.Rows[i]["Telefon"].ToString() + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Numele masina: " + t.Rows[i]["Nume"].ToString() + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Marca: " + t.Rows[i]["Marca"].ToString() + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Anul fabricarii: " + t.Rows[i]["Anul_fabricari"].ToString() + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += " Kilometrajul: " + t.Rows[i]["Kilometraj"].ToString() + " Km" + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Puterea: " + t.Rows[i]["Putere"].ToString() + " CP" + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas = "Cutiea de viteze: ";
                    if (int.Parse(t.Rows[i]["CutieViteze"].ToString()) == 1)
                    {
                        mas += "Manuală" + " ";
                    }
                    else mas += "Automată" + " ";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas +="Combustibil: " +t.Rows[i]["Combustibil"] + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Serie" + t.Rows[i]["Serie"].ToString() + "\n";
                    listBox1.Items.Add(mas);
                    mas = "";
                    mas += "Pretul: " + t.Rows[i]["Pret"].ToString() + " euro" + "\n";
                    listBox1.Items.Add(mas);
                    listBox1.Items.Add("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    mas = "Nu exista mașină cu aceste informații";
                }
                
            }
            if (mas == "Nu exista mașină cu aceste informații" && vp==0)
                listBox1.Items.Add(mas);
        }

        private void button4_Click(object sender, EventArgs e)//buton vanzare masina
        {
            
            if (fa.Util!=null)
            {
                string ut = fa.Util;
                string a = textBox9.Text;
                string b = textBox10.Text;
                float c = -1;
                if (textBox11.Text != "")
                {
                    if (vf(textBox11.Text))
                    {
                        c = float.Parse(textBox11.Text);
                    }
                    else
                    {
                        MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                    }
                }
                string d = "";
                if (checkBox7.Checked == true)
                {
                    d = "benzină";
                }
                else
                {
                    if (checkBox8.Checked == true)
                    {
                        d = "motorină";
                    }
                    else
                    {
                        if (checkBox9.Checked == true)
                        {
                            d = "hibrid";
                        }
                        else
                        {
                            if (checkBox10.Checked == true)
                            {
                                d = "electric";
                            }
                        }
                    }
                }
                int f = 0;
                if (checkBox11.Checked == true)
                {
                    f = 2;
                    if (checkBox12.Checked == true)
                        f = 3;
                }
                else if (checkBox12.Checked == true)
                    f = 1;
                if (f == 3)
                {
                    MessageBox.Show("Selectati doar o obtiune!");
                }
                float k = -1;
                if (textBox12.Text != "")
                {
                    if (vf(textBox12.Text))
                        k = float.Parse(textBox12.Text);
                    else
                    {
                        MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                    }
                }
                else k = -2;
                float pp = -1;
                if (textBox13.Text != "")
                {
                    if (vf(textBox13.Text))
                    {
                        pp = float.Parse(textBox13.Text);
                        if (pp == 0)
                          {
                              MessageBox.Show("Nu poate fii 0 câmpul putere");
                          }
                    }
                    else
                    {
                        MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                    }
                }
                else pp = -2;
                
                string serie = textBox14.Text;
                float p = -1;
                if (textBox15.Text != "")
                {
                    if (vf(textBox15.Text))
                    {
                        p = float.Parse(textBox15.Text);
                        if (p == 0)
                        {
                            pictureBox2.Visible = true;
                        }
                        else pictureBox2.Visible = false;
                    }
                    else MessageBox.Show("Date introduse greșit,trebuie să introduceți doar cifre.");
                }
                else p = -2;
                int id = (int)conturiTableAdapter.IdUtilizator(ut);
                if (a != "" && b != "" && serie != "" && pp > 0 && k > -1 && p > 0 && c > 0)
                {
                    masinaTableAdapter.AdaugareMasina(a, b, c, k, pp, f, p, serie, id, d);
                    masinaTableAdapter.Update(dbDataSet.Masina);
                    MessageBox.Show("Mașină adăugată cu succes.");
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    checkBox9.Checked = false;
                    checkBox10.Checked = false;
                    checkBox11.Checked = false;
                    checkBox12.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                }
                if(k==-2 || p==-2 || c==-2 || a=="" || b=="" || serie=="" || pp==-2)
               MessageBox.Show("Nu ați introdus toate informațile.");
            }
            else MessageBox.Show("Nu ești conectat.");
        }

        private void button6_Click(object sender, EventArgs e)//buton afisare masina dorita sa fie cumparata
        {
            listBox2.Items.Clear();
            string a = textBox16.Text;
            string m = "";
            if(a!="")
            {
                if (conturiTableAdapter.SerieExista(a) != null)
                {
                    conturiTableAdapter.CăutareDupaSerie(dbDataSet.Conturi, a);
                    DataTable t = dbDataSet.Conturi;
                    m += "Numele utilizatorului: " + t.Rows[0]["utilizator"].ToString() + "\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Numărul de telefon: " + t.Rows[0]["Telefon"].ToString() + "\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Numele masina: " + t.Rows[0]["Nume"].ToString() + "\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Marca: " + t.Rows[0]["Marca"].ToString() + "\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Anul fabricarii: " + t.Rows[0]["Anul_fabricari"].ToString()+"\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += " Kilometrajul: " + t.Rows[0]["Kilometraj"].ToString()+" Km" +"\n";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Puterea: " + t.Rows[0]["Putere"].ToString() +" CP"+ "\n";
                     listBox2.Items.Add(m);
                    m = "";
                    m = "Cutiea de viteze: ";
                    if (int.Parse(t.Rows[0]["CutieViteze"].ToString()) == 1)
                    {
                        m += "Manuală" + " ";
                    }
                    else m += "Automată" + " ";
                    listBox2.Items.Add(m);
                    m = "";
                    m += "Pretul: " + t.Rows[0]["Pret"].ToString() +" euro"+ "\n";
                    listBox2.Items.Add(m);

                }     
        }else MessageBox.Show("Nu ați introdus nimic");
        }

        private void button5_Click(object sender, EventArgs e)//buton cumpărare
        { 
            string a=textBox16.Text;
            if (fa.Util != null)
            {
                if (conturiTableAdapter.SerieExista(a) != null)
                {
                    if (a != "")
                    {
                        conturiTableAdapter.MasinaDupaSerie(dbDataSet.Conturi, a);
                        DataTable t = dbDataSet.Conturi;
                        listaMTableAdapter.Adaug(t.Rows[0]["Nume"].ToString(), t.Rows[0]["Marca"].ToString(), t.Rows[0]["Serie"].ToString(), float.Parse(t.Rows[0]["Pret"].ToString()), t.Rows[0]["utilizator"].ToString(), fa.Util.ToString());
                        listaMTableAdapter.Update(dbDataSet.ListaM);
                        listaMTableAdapter.Fill(dbDataSet.ListaM);
                        dataGridView1.Update();
                        masinaTableAdapter.StergereDupaSerie(a);
                        masinaTableAdapter.Update(dbDataSet.Masina);
                        MessageBox.Show("Felicităti!Ați achiziționat mașina.");
                        listBox2.Items.Clear();
                        textBox16.Text = "";
                    }
                    else MessageBox.Show("Nu ați introdus nicio serie.");
                }
                else MessageBox.Show("Nu există mașină cu acestă serie.");
            }
            else MessageBox.Show("Nu sunteți conectat.");
        }

        private void button7_Click(object sender, EventArgs e)//inchide aplicatia
        {
            this.Close();
        }

       }
    }
