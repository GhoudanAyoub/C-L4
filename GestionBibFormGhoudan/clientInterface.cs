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
    public partial class clientInterface : Form
    {
        public clientInterface()
        {
            InitializeComponent();
            loadForm();
        }

        private void checkMyStatus()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "SELECT name,delai,type_ouvrage FROM emprunteurs WHERE name='" + EmpruntService.currentClientUsername + "'";

            MySqlCommand cmd2 = Connection.getMySqlCommand();
            cmd2.CommandText = sqlSelectAll2;
            MyDA2.SelectCommand = cmd2;
            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);
            if (table2.Rows.Count != 0)
            {
                if (dateTime.CompareTo(DateTime.Parse(table2.Rows[0].Field<String>("delai"))) <= 0) MessageBox.Show("Veuillez rendre le livre : " + table2.Rows[0].Field<String>("type_ouvrage") + " à la bibliothèque!!");
            }

        }
        private void loadForm()
        {

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from emprunteurs where name='" + EmpruntService.currentClientUsername + "'";

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
            checkMyStatus();
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
