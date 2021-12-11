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
        public Form1()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string auteur = textBox1.Text;
            string titre = textBox2.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;

            Clean();
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'f1DataSet.cd' table. You can move, or remove it, as needed.
            this.cdTableAdapter.Fill(this.f1DataSet.cd);
            // TODO: This line of code loads data into the 'f1DataSet.periodiques' table. You can move, or remove it, as needed.
            this.periodiquesTableAdapter.Fill(this.f1DataSet.periodiques);
            // TODO: This line of code loads data into the 'livres._livres' table. You can move, or remove it, as needed.
            this.livresTableAdapter.Fill(this.livres._livres);

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
            Clean();
        }

        private void Clean()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clean();
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LivrePanel.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CDPanel.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string auteur = textBox4.Text;
            string titre = textBox5.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            Clean();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            string auteur = textBox4.Text;
            string titre = textBox5.Text;
            String per = textBox3.Text;
            DateTime date = dateTimePicker1.Value;

            Clean();
            button8.Enabled = false;
            button9.Enabled = false;
            button7.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {


            Clean();
            button8.Enabled = false;
            button9.Enabled = false;
            button7.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clean();
            button12.Enabled = false;
            button11.Enabled = true;
            button13.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string name = textBox6.Text;
            int num = int.Parse(textBox7.Text);
            String per = textBox8.Text;
            DateTime date = dateTimePicker3.Value;
            Clean();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PeriodaquePanel.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {


            string name = textBox6.Text;
            int num = int.Parse(textBox7.Text);
            String per = textBox8.Text;
            DateTime date = dateTimePicker3.Value;

            Clean();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EmpruntPanel.BringToFront();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }
    }
}
