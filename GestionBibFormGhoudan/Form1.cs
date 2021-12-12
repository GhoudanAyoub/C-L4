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
            // TODO: This line of code loads data into the 'f1DataSet.emprunteurs' table. You can move, or remove it, as needed.
            this.emprunteursTableAdapter.Fill(this.f1DataSet.emprunteurs);
            // TODO: This line of code loads data into the 'f1DataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.f1DataSet.user);
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
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
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
            string sqlSelectAll = "SELECT * from periodiques";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView2.DataSource = bSource;
            dataGridView2.Update();
            dataGridView2.Refresh();
        }
        private void refrechEmp()
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from emprunteurs";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView4.DataSource = bSource;
            dataGridView4.Update();
            dataGridView4.Refresh();
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
            int rowIndex = dataGridView2.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Periodicites", "Delete Periodicite", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView2.Rows.RemoveAt(rowIndex);
                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "DELETE FROM periodiques WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();

            }

            Clean();
            button12.Enabled = false;
            button11.Enabled = true;
            button13.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {


            if (textBox7.Text == "" || textBox8.Text == "" || textBox6.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Cd L = new Cd(textBox4.Text, textBox5.Text, dateTimePicker2.Value);


                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "INSERT INTO periodiques (nom, periodicite,numero,date_emprunt)" +
                    "VALUES(@nom, @per,@n,@date_emprunt)";
                cmd.Parameters.AddWithValue("@nom", textBox6.Text);
                cmd.Parameters.AddWithValue("@per", textBox7.Text);
                cmd.Parameters.AddWithValue("@n", textBox8.Text);
                cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker3.Value);


                cmd.ExecuteNonQuery();
                Clean();
                refrechPer();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PeriodaquePanel.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {



            if (textBox7.Text == "" || textBox8.Text == ""|| textBox6.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MySqlCommand cmd = Connection.getMySqlCommand();

                cmd.CommandText = "UPDATE periodiques SET nom=@nom, periodicite=@per, numero=@n,date_emprunt=@date_emprunt" +
                        " WHERE id=" + currRowIndex;
                cmd.Parameters.AddWithValue("@nom", textBox6.Text);
                cmd.Parameters.AddWithValue("@per", textBox7.Text);
                cmd.Parameters.AddWithValue("@n", textBox8.Text);
                cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker3.Value);


                cmd.ExecuteNonQuery();
                Clean();


                refrechPer();
                button13.Enabled = false;
                button12.Enabled = false;
                button11.Enabled = true;
            }
            Clean();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EmpruntPanel.BringToFront();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {


            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "INSERT INTO emprunteurs (name, cin,date_emprunt,delai,type_ouvrage)" +
                    "VALUES(@nom, @cin,@date_emprunt,@delai,@type_ouvrage)";
                cmd.Parameters.AddWithValue("@nom", textBox11.Text);
                cmd.Parameters.AddWithValue("@cin", textBox10.Text);
                cmd.Parameters.AddWithValue("@delai", dateTimePicker5.Value);
                cmd.Parameters.AddWithValue("@type_ouvrage", textBox9.Text);
                cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker4.Value);


                cmd.ExecuteNonQuery();
                Clean();
                refrechEmp();
            }
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
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value);

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox4.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(row.Cells[3].Value);

            button8.Enabled = true;
            button9.Enabled = true;
            button7.Enabled = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox6.Text = row.Cells[1].Value.ToString();
            textBox7.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            dateTimePicker3.Value = Convert.ToDateTime(row.Cells[4].Value);

            button13.Enabled = true;
            button12.Enabled = true;
            button11.Enabled = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox10.Text = row.Cells[1].Value.ToString();
            textBox11.Text = row.Cells[2].Value.ToString();
            textBox9.Text = row.Cells[5].Value.ToString();
            dateTimePicker5.Value = Convert.ToDateTime(row.Cells[4].Value);
            dateTimePicker4.Value = Convert.ToDateTime(row.Cells[3].Value);

            button20.Enabled = true;
            button19.Enabled = true;
            button22.Enabled = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView4.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Emprunt", "Delete Emprunt", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView4.Rows.RemoveAt(rowIndex);
                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "DELETE FROM emprunteurs WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();

            }

            Clean();
            button20.Enabled = false;
            button19.Enabled = false;
            button22.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {


            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MySqlCommand cmd = Connection.getMySqlCommand();
                cmd.CommandText = "UPDATE emprunteurs SET name=@nom, cin=@cin,delai=@delai,type_ouvrage=@type_ouvrage,date_emprunt=@date_emprunt" +
                        " WHERE id=" + currRowIndex;
                cmd.Parameters.AddWithValue("@nom", textBox11.Text);
                cmd.Parameters.AddWithValue("@cin", textBox10.Text);
                cmd.Parameters.AddWithValue("@delai", dateTimePicker5.Value);
                cmd.Parameters.AddWithValue("@date_emprunt", dateTimePicker4.Value);
                cmd.Parameters.AddWithValue("@type_ouvrage", textBox9.Text);


                cmd.ExecuteNonQuery();
                Clean();
                refrechEmp();
                button20.Enabled = false;
                button19.Enabled = false;
                button22.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox9.Text = "CD";
        }

        private void button17_Click(object sender, EventArgs e)
        {

            textBox9.Text = "Livre";
        }

        private void button16_Click(object sender, EventArgs e)
        {

            textBox9.Text = "Periodique";
        }
    }
}
