using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionBibFormGhoudan.Db;
using GestionBibFormGhoudan.Services;
using MySql.Data.MySqlClient;

namespace GestionBibFormGhoudan
{
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox2.Text == ""|| textBox3.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
               Ajouter();
            }
        }


        public void Ajouter()
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "INSERT INTO client (name, cin,phone)" +
                "VALUES(@nom, @cin,@phone)";
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@cin", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
