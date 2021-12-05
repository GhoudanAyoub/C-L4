using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibFormGhoudan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string nom = textBox1.Text;
            string cin = textBox2.Text;
            string ouvrage = textBox5.Text;
            DateTime delai = dateTimePicker1.Value;
            DateTime dEmprunt = dateTimePicker2.Value;
            emprunt livre = new emprunt(nom, cin, delai, ouvrage, dEmprunt);
            ListViewItem ligne = new ListViewItem(livre.cin);
            ligne.SubItems.Add(livre.client);
            ligne.SubItems.Add(livre.delai.ToString());
            ligne.SubItems.Add(livre.typeOuvr);
            ligne.SubItems.Add(livre.DateEmprunt.ToString());

            listView3.Items.Add(ligne);
            Clean();
        }

        private void Clean()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string nom = textBox1.Text;
            string cin = textBox2.Text;
            string ouvrage = textBox5.Text;
            DateTime delai = dateTimePicker1.Value;
            DateTime dEmprunt = dateTimePicker2.Value;
            emprunt livre = new emprunt(nom, cin, delai, ouvrage, dEmprunt);
            ListViewItem ligne = new ListViewItem(livre.cin);
            ligne.SubItems.Add(livre.client);
            ligne.SubItems.Add(livre.delai.ToString());
            ligne.SubItems.Add(livre.typeOuvr);
            ligne.SubItems.Add(livre.DateEmprunt.ToString());

            listView3.Items[listView3.SelectedIndices[0]] = ligne;
            Clean();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listView3.SelectedItems.Count > 0)
            {
                textBox1.Text = listView3.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView3.SelectedItems[0].SubItems[0].Text;
                textBox5.Text = listView3.SelectedItems[0].SubItems[3].Text;
                button9.Enabled = true;
                button1.Enabled = false;
                button6.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            listView3.Items[listView3.SelectedIndices[0]].Remove();
            Clean();
            button9.Enabled = false;
            button1.Enabled = true;
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = "CD";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox5.Text = "Livre";
        }

        private void button13_Click(object sender, EventArgs e)
        { 
            textBox5.Text = "Periodique";
        }
    }
}
