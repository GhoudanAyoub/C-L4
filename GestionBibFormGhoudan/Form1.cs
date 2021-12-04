using GestionBiblioGhoudan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibFormGhoudan
{
    public partial class Form1 : Form
    {
        private BiblioTab biblio;
        private Employer employer;
        private client client;
        public Form1()
        {
            InitializeComponent();
            biblio = new BiblioTab(3);
            employer = new Employer(biblio);
            client = new client(biblio,null);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string auteur = textBox1.Text;
            string titre = textBox2.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            Livre livre = new Livre(int.Parse(listView1.SelectedItems[0].SubItems[0].Text),auteur, titre, per, date);
            employer.modifier(livre);
            ListViewItem ligne = new ListViewItem(livre.Id.ToString());
            ligne.SubItems.Add(livre.Auteur);
            ligne.SubItems.Add(livre.Titre);
            ligne.SubItems.Add(livre.Periodique);
            ligne.SubItems.Add(livre.DateEmprunt.ToString());

            listView1.Items[listView1.SelectedIndices[0]] = ligne;

            Clean();
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string auteur = textBox1.Text;
            string titre = textBox2.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            Livre livre = new Livre(auteur,titre,per,date);
            employer.ajouter(livre);
            ListViewItem ligne = new ListViewItem(livre.Id.ToString());
            ligne.SubItems.Add(livre.Auteur);
            ligne.SubItems.Add(livre.Titre);
            ligne.SubItems.Add(livre.Periodique);
            ligne.SubItems.Add(livre.DateEmprunt.ToString());

            listView1.Items.Add(ligne);
            Clean();
        }

        private void Clean()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
                //dateTimePicker1.Value = DateTime.ParseExact(listView1.SelectedItems[0].SubItems[4].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                button2.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listView1.Items[listView1.SelectedIndices[0]].Remove();
            Clean();
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LivrePanel.BringToFront();
            CDPanel.SendToBack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LivrePanel.SendToBack();

            CDPanel.BringToFront();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string auteur = textBox4.Text;
            string titre = textBox5.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            Cd cd = new Cd(date,auteur, titre); 
            employer.ajouter(cd);
            ListViewItem ligne = new ListViewItem(cd.Id.ToString());
            ligne.SubItems.Add(cd.Auteur);
            ligne.SubItems.Add(cd.Titre);
            ligne.SubItems.Add(cd.DateEmprunt.ToString());

            listView2.Items.Add(ligne);
            Clean();

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                textBox4.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox5.Text = listView2.SelectedItems[0].SubItems[2].Text;
                //dateTimePicker1.Value = DateTime.ParseExact(listView1.SelectedItems[0].SubItems[4].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                button8.Enabled = true;
                button7.Enabled = false;
                button9.Enabled = true;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string auteur = textBox4.Text;
            string titre = textBox5.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            Cd cd = new Cd(int.Parse(listView2.SelectedItems[0].SubItems[0].Text),date, auteur, titre);
            employer.modifier(cd);
            ListViewItem ligne = new ListViewItem(cd.Id.ToString());
            ligne.SubItems.Add(cd.Auteur);
            ligne.SubItems.Add(cd.Titre);
            ligne.SubItems.Add(cd.DateEmprunt.ToString());

            listView2.Items[listView1.SelectedIndices[0]] = ligne;

            Clean();
            button8.Enabled = false;
            button9.Enabled = false;
            button7.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {


            listView2.Items[listView2.SelectedIndices[0]].Remove();
            Clean();
            button8.Enabled = false;
            button9.Enabled = false;
            button7.Enabled = true;
        }
    }
}
