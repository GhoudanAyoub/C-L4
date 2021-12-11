using GestionBibFormGhoudan.Db;
using GestionBiblioGhoudan;
using MySql.Data.MySqlClient;
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
        private int currRowIndex;

        DataTable dataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string auteur = textBox1.Text;
            string titre = textBox2.Text;
            DateTime date = dateTimePicker1.Value;


            if (textBox1.Text == "" || textBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MySqlCommand cmd = Connection.getMySqlCommand();

                cmd.CommandText = "UPDATE livres SET auteur= @auteur, titre=@titre, date_emprunt=@date_emprunt" +
                        " WHERE id=" + currRowIndex;;
                    cmd.Parameters.AddWithValue("@titre", textBox2.Text);
                    cmd.Parameters.AddWithValue("@auteur", textBox1.Text);
                    cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker1.Value);


                    cmd.ExecuteNonQuery();

            Clean();
                refrechLivre();
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
                }
        }

        public void refrechLivre()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from livres";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView1.DataSource = bSource;
            dataGridView1.Update();
            dataGridView1.Refresh();
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

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DateTime date = dateTimePicker1.Value;
                Livre L = new Livre(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
                //dataGridView2.Rows.Add("", textBox1.Text, textBox2.Text,dateTimePicker1.Text );



                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "INSERT INTO livres (auteur, titre,date_emprunt)" +
                    "VALUES(@auteur, @titre,@date_emprunt)";
                cmd.Parameters.AddWithValue("@auteur", L.Auteur);
                cmd.Parameters.AddWithValue("@titre", L.Titre);
                cmd.Parameters.AddWithValue("@date_emprunt", L.DateEmprunt);
                cmd.ExecuteNonQuery();
                Clean();

                refrechLivre();
            }
        }

        private void Clean()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Livre", "Delete Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "DELETE FROM livres WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();

            }
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
            DateTime date = dateTimePicker2.Value;

            if (textBox4.Text == "" || textBox5.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Cd L = new Cd(textBox4.Text, textBox5.Text, dateTimePicker2.Value);


                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "INSERT INTO cd (auteur, titre,date_emprunt)" +
                    "VALUES(@auteur, @titre,@date_emprunt)";
                cmd.Parameters.AddWithValue("@auteur", L.Auteur);
                cmd.Parameters.AddWithValue("@titre", L.Titre);
                cmd.Parameters.AddWithValue("@date_emprunt", L.DateEmprunt);
                cmd.ExecuteNonQuery();
                Clean();

                refrechCd();
            }
            Clean();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            string auteur = textBox4.Text;
            string titre = textBox5.Text;
            DateTime date = dateTimePicker2.Value;



            if (textBox5.Text == "" || textBox4.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MySqlCommand cmd = Connection.getMySqlCommand();

                cmd.CommandText = "UPDATE cd SET auteur= @auteur, titre=@titre, date_emprunt=@date_emprunt" +
                        " WHERE id=" + currRowIndex; ;
                cmd.Parameters.AddWithValue("@titre", textBox4.Text);
                cmd.Parameters.AddWithValue("@auteur", textBox5.Text);
                cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker2.Value);


                cmd.ExecuteNonQuery();
                Clean();


                refrechCd();
                button8.Enabled = false;
                button9.Enabled = false;
                button7.Enabled = true;
            }
        }

        private void refrechCd()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from cd";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView3.DataSource = bSource;
            dataGridView3.Update();
            dataGridView3.Refresh();
        }
        private void refrechPer()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from cd";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView3.DataSource = bSource;
            dataGridView3.Update();
            dataGridView3.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView3.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Cd", "Delete Cd", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView3.Rows.RemoveAt(rowIndex);
                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "DELETE FROM cd WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();

            }

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox4.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();

            button8.Enabled = true;
            button9.Enabled = true;
            button7.Enabled = false;
        }
    }
}
