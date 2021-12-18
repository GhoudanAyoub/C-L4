using GestionBibFormGhoudan.Db;
using GestionBibFormGhoudan.Services;
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
        private LivreService livreService = new LivreService();
        private CdService cdService = new CdService();
        private PeriodiqueService periodiqueService = new PeriodiqueService();
        private EmpruntService empruntService = new EmpruntService();
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
                livreService.Modifier(new Livre(currRowIndex, textBox2.Text, textBox1.Text, int.Parse(textBox33.Text)));

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
            // TODO: This line of code loads data into the 'f1DataSet1.periodiques' table. You can move, or remove it, as needed.
            this.periodiquesTableAdapter1.Fill(this.f1DataSet1.periodiques);
            // TODO: This line of code loads data into the 'f1DataSet1.emprunteurs' table. You can move, or remove it, as needed.
            this.emprunteursTableAdapter1.Fill(this.f1DataSet1.emprunteurs);
            // TODO: This line of code loads data into the 'f1DataSet1.cd' table. You can move, or remove it, as needed.
            this.cdTableAdapter1.Fill(this.f1DataSet1.cd);
            // TODO: This line of code loads data into the 'f1DataSet1.livres' table. You can move, or remove it, as needed.
            this.livresTableAdapter1.Fill(this.f1DataSet1.livres);
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

                livreService.Ajouter(new Livre(textBox1.Text, textBox2.Text, int.Parse(textBox33.Text)));
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
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Livre", "Delete Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
                livreService.delete(currRowIndex);

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
                Cd L = new Cd(textBox4.Text, textBox5.Text, int.Parse(textBox3.Text));
                cdService.Ajouter(L);
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

                Cd L = new Cd(currRowIndex,textBox4.Text, textBox5.Text, int.Parse(textBox3.Text));
                cdService.Modifier(L);
                Clean();
                refrechCd();
                button8.Enabled = false;
                button9.Enabled = false;
                button7.Enabled = true;
            }
        }

        private void refrechCd()
        {
            dataGridView3.DataSource = cdService.afficher();
            dataGridView3.Update();
            dataGridView3.Refresh();
        }
        private void refrechPer()
        {
            dataGridView2.DataSource = periodiqueService.afficher();
            dataGridView2.Update();
            dataGridView2.Refresh();
        }
        private void refrechEmp()
        {

            dataGridView4.DataSource = empruntService.afficher();
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
                cdService.delete(currRowIndex);
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
                periodiqueService.delete(currRowIndex);

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
                Periodique periodique = new Periodique( textBox6.Text, int.Parse(textBox7.Text), textBox8.Text, int.Parse(textBox12.Text));
                periodiqueService.Ajouter(periodique);
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
                Periodique periodique = new Periodique(currRowIndex, textBox6.Text, int.Parse(textBox8.Text),textBox7.Text,int.Parse(textBox12.Text));
                periodiqueService.Modifier(periodique);
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
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {


            if (textBox9.Text == "" || textBox10.Text == "" )
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                empruntService.Ajouter(new emprunt(textBox10.Text, textBox10.Text, dateTimePicker5.Value, dateTimePicker4.Value, textBox9.Text, textBox11.Text));
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

        private void button21_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView4.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("Do You want to delete this Emprunt", "Delete Emprunt", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView4.Rows.RemoveAt(rowIndex);
                empruntService.delete(currRowIndex);

            }

            Clean();
            button20.Enabled = false;
            button19.Enabled = false;
            button22.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {


            if (textBox9.Text == "" || textBox10.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                empruntService.Modifier(new emprunt(currRowIndex, textBox10.Text, textBox10.Text, dateTimePicker5.Value, dateTimePicker4.Value, textBox11.Text, textBox9.Text));
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void button15_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox10.Text = row.Cells[1].Value.ToString();
            textBox9.Text = row.Cells[5].Value.ToString();
            textBox11.Text = row.Cells[6].Value.ToString();
            dateTimePicker5.Value = Convert.ToDateTime(row.Cells[4].Value);
            dateTimePicker4.Value = Convert.ToDateTime(row.Cells[3].Value);

            button20.Enabled = true;
            button19.Enabled = true;
            button22.Enabled = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox6.Text = row.Cells[1].Value.ToString();
            textBox7.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            textBox12.Text = row.Cells[4].Value.ToString();

            button13.Enabled = true;
            button12.Enabled = true;
            button11.Enabled = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            button1.Enabled = false;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox33.Text = row.Cells[3].Value.ToString();

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox4.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();

            button8.Enabled = true;
            button9.Enabled = true;
            button7.Enabled = false;
        }
    }
}
