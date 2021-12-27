using GestionBibFormGhoudan.Db;
using GestionBibFormGhoudan.Services;
using MySql.Data.MySqlClient;
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
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            setCurrentUser();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT COUNT(*),username FROM user WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;
            DataTable table = new DataTable();
            MyDA.Fill(table);
            if (table.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                if (EmpruntService.currentClientLevel.Contains("Admin")) new Form1().Show();
                else new clientInterface().Show();
            }
            else
            {
                MessageBox.Show("Veuillez vérifier vos informations de login ! ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void setCurrentUser()
        {
            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "SELECT level,username FROM user WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

            MySqlCommand cmd2 = Connection.getMySqlCommand();
            cmd2.CommandText = sqlSelectAll2;
            MyDA2.SelectCommand = cmd2;
            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);
           if(table2.Rows.Count!=0)
            {
                EmpruntService.currentClientLevel = table2.Rows[0].Field<String>("level");
                EmpruntService.currentClientUsername = table2.Rows[0].Field<String>("username");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {

            DialogResult dialogClose = MessageBox.Show("Do you Want To Close The APP", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (dialogClose == DialogResult.Cancel)
            {
                //do something else
            }
        }
    }
}
