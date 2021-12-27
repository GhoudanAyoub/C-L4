using GestionBibFormGhoudan.Db;
using GestionBibFormGhoudan.Services;
using GestionBiblioGhoudan;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        private Livre emruntedLivre;
        private Cd emruntedCd;
        private Periodique emruntedPeriodique;
        public Form1()
        {
            InitializeComponent();

            checkPriveligies();
            checkMyStatus();
            fetchCharts();
            fetchPie();
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
                if(dateTime.CompareTo(DateTime.Parse(table2.Rows[0].Field<String>("delai")))<=0) MessageBox.Show("Veuillez rendre le livre : "+ table2.Rows[0].Field<String>("type_ouvrage") + " à la bibliothèque!!");
            }

        }

        private void checkPriveligies()
        {
            if (EmpruntService.currentClientLevel.Contains("Admin"))
            {
                button2.Visible = true;
                button3.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
                button18.Visible = true;
                button19.Visible = true;
                button20.Visible = true;
                button21.Visible = true;
                button23.Visible = true;
                pictureBox6.Visible = true;
                button16.Visible = true;
                pictureBox5.Visible = true;

            }
            else
            {
                button2.Visible = false;
                button3.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button23.Visible = false;
                pictureBox6.Visible = false;
                button16.Visible = false;
                pictureBox5.Visible = false;

            }
        }

        private void fetchPie()
        {
            chart2.Series.Clear();
            chart2.Legends.Clear();

            chart2.Legends.Add("Ouvrages Statistics");
            chart2.Legends[0].LegendStyle = LegendStyle.Table;
            chart2.Legends[0].Docking = Docking.Bottom;
            chart2.Legends[0].Alignment = StringAlignment.Center;
            chart2.Legends[0].Title = "Ouvrages ";
            chart2.Legends[0].BorderColor = Color.Black;

            string seriesname = "ouvrages";
            chart2.Series.Add(seriesname);
            chart2.Series[seriesname].ChartType = SeriesChartType.Pie;


            string query = " SELECT ouvrageName, COUNT(ouvrageName)  \"Total N.\" FROM emprunteurs GROUP BY ouvrageName; ";

            MySqlDataAdapter MyDA = new MySqlDataAdapter();

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = query;
            MyDA.SelectCommand = cmd;


            DataTable dt = new DataTable();
            MyDA.Fill(dt);
            //Get the names of Cities.
            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("ouvrageName") ascending
                          select p.Field<string>("ouvrageName")).ToArray();

            //Get the Total of Orders for each City.
            Int64[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("ouvrageName") ascending
                       select p.Field<Int64>("Total N.")).ToArray();
            chart2.Series["ouvrages"].Points.DataBindXY(x, y);
        }

        private void fetchCharts()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("Clients Statistics");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Clients ";
            chart1.Legends[0].BorderColor = Color.Black;

            string seriesname = "clients";
            chart1.Series.Add(seriesname);
            chart1.Series[seriesname].ChartType = SeriesChartType.Bar;
            string query = " SELECT name, COUNT(name)  \"Total N.\" FROM emprunteurs GROUP BY name; ";

            MySqlDataAdapter MyDA = new MySqlDataAdapter();

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = query;
            MyDA.SelectCommand = cmd;


            DataTable dt = new DataTable();
            MyDA.Fill(dt);

            //Get the names of Cities.
            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("name") ascending
                          select p.Field<string>("name")).ToArray();

            //Get the Total of Orders for each City.
            Int64[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("name") ascending
                       select p.Field<Int64>("Total N.")).ToArray();
            chart1.Series[seriesname].Points.DataBindXY(x, y);
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
            // TODO: This line of code loads data into the 'f1DataSet1.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.f1DataSet1.user);
            // TODO: This line of code loads data into the 'f1DataSet1.periodiques' table. You can move, or remove it, as needed.
            this.periodiquesTableAdapter1.Fill(this.f1DataSet1.periodiques);
            // TODO: This line of code loads data into the 'f1DataSet1.emprunteurs' table. You can move, or remove it, as needed.
            this.emprunteursTableAdapter1.Fill(this.f1DataSet1.emprunteurs);
            // TODO: This line of code loads data into the 'f1DataSet1.cd' table. You can move, or remove it, as needed.
            this.cdTableAdapter1.Fill(this.f1DataSet1.cd);
            // TODO: This line of code loads data into the 'f1DataSet1.livres' table. You can move, or remove it, as needed.
            this.livresTableAdapter1.Fill(this.f1DataSet1.livres);
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
            textBox11.Clear();
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
            this.Hide();
            new Form2().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox10.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Field Empty", "*", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int i = 0;
                int j = 0;
                foreach (DataGridViewRow row in this.dataGridView4.Rows)
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().ToLower().Contains(textBox10.Text.ToLower())) 
                        i++;
                foreach (DataGridViewRow row in this.dataGridView4.Rows)
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString().ToLower().Contains(textBox11.Text.ToLower())) 
                        j++;
                foreach (DataGridViewRow row in this.dataGridView4.Rows){
                    if (j == 1)
                    {
                        MessageBox.Show("Ce Client ne peux pas Emprunter le meme livre" + row.Cells[5].Value.ToString(), "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (i == 0)
                    {

                        add();
                        return;
                    }
                    else if (i!=0 && i <= 3 ){
                            String vall = i == 1 ? " un " : " Deux ";
                            MessageBox.Show("Ce Client Deja Emprunter "+ vall + " ouvrages ", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            add();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Ce Client a Emprunter Le max Des Ouvrages ", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            Clean();
                            return;
                        }
                }       
            }
        }

        private void add()
        {
            empruntService.Ajouter(new emprunt(textBox10.Text, textBox10.Text, dateTimePicker5.Value, dateTimePicker4.Value, textBox9.Text, textBox11.Text));
            if (textBox9.Text.ToLower().Contains("livre"))
            {
                livreService.Modifier(emruntedLivre);
                refrechLivre();
            }
            else if (textBox9.Text.ToLower().Contains("cd"))
            {
                cdService.Modifier(emruntedCd);
                refrechCd();
            }
            else if (textBox9.Text.ToLower().Contains("per"))
            {
                periodiqueService.Modifier(emruntedPeriodique);
                refrechPer();
            }
            Clean();
            refrechEmp();
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

        private void Nouveau_Click(object sender, EventArgs e)
        {
            new NewClient().Show();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox11.Text = row.Cells[1].Value.ToString();
            textBox9.Text = row.Cells[2].Value.ToString();
            if (textBox9.Text.ToLower().Contains("livre"))
            {
                emruntedLivre = new Livre(Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(),row.Cells[2].Value.ToString(),Convert.ToInt32( row.Cells[3].Value)-1);
            }
            else if (textBox9.Text.ToLower().Contains("cd"))
            {
                emruntedCd = new Cd(Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(),row.Cells[2].Value.ToString(),Convert.ToInt32( row.Cells[3].Value)-1);
            }
            else if (textBox9.Text.ToLower().Contains("per"))
            {
                emruntedPeriodique = new Periodique(Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(), Convert.ToInt32(row.Cells[2].Value), row.Cells[3].Value.ToString(),Convert.ToInt32( row.Cells[4].Value)-1);
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            string sqlSelectAll ="";
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            MySqlDataAdapter MyDA3 = new MySqlDataAdapter();
      
            if (textBox13.Text.ToLower().Contains("cd"))
            {
                sqlSelectAll = "select * from cd where LOWER(cd.titre) like '" + textBox13.Text.ToLower() + "'; ";

            }
            else if (textBox13.Text.ToLower().Contains("livre"))
            {
                sqlSelectAll = "select * from livres where  LOWER(livres.titre) like '" + textBox13.Text.ToLower() + "' ; ";

            }
            else if (textBox13.Text.ToLower().Contains("per"))
            {
                sqlSelectAll = "select * from periodiques where  LOWER(periodiques.nom) like '" + textBox13.Text.ToLower() + "'  ; ";
            }
            DataTable table = new DataTable();
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView5.DataSource = bSource;
            dataGridView5.Update();
            dataGridView5.Refresh();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ChartPanel.BringToFront();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            fetchCharts();
            fetchPie();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (dataGridView4.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Emprunt.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView4.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView4.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView4.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {if(cell.Value!=null)
                                        pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            userpanel.BringToFront();
        }

        private void userpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || comboBox111.Text.Equals(""))
            {
                MessageBox.Show("Remplis les champs");
            }
            else
            {

                    MySqlDataAdapter MyDA = new MySqlDataAdapter();
                    string sqlSelectAll = "select Count(*) from user  where username = '" + textBox16.Text + "' ";

                    MySqlCommand cmd = Connection.getMySqlCommand();
                    cmd.CommandText = sqlSelectAll;
                    MyDA.SelectCommand = cmd;

                    DataTable table = new DataTable();
                    MyDA.Fill(table);

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    if (table.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Name already exist");
                    }
                    else
                    {

                    if (ajouterUsers()) { MessageBox.Show("secuussefully saved");
                        clearUser();
                        refrechusers();
                    }
                    else MessageBox.Show("Error");
                    }


            }
           
        }

        public bool ajouterUsers()
        {

            MySqlCommand cmd = Connection.getMySqlCommand();

            cmd.CommandText = "INSERT INTO user (username, password,level,fullName,birthdate,email,city,state)" +
                "VALUES(@username, @password,@level,@fullName,@birthdate,@email,@city,@state)";
            cmd.Parameters.AddWithValue("@username", textBox16.Text);
            cmd.Parameters.AddWithValue("@password", textBox15.Text);
            cmd.Parameters.AddWithValue("@level", comboBox111.Text);
            cmd.Parameters.AddWithValue("@fullName", textBox19.Text);
            cmd.Parameters.AddWithValue("@birthdate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@email", textBox18.Text);
            cmd.Parameters.AddWithValue("@city",textBox14.Text);
            cmd.Parameters.AddWithValue("@state", null);
            cmd.ExecuteNonQuery();
            return true;
        }
        private void refrechusers()
        {

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "select * from user;";

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = sqlSelectAll;
            MyDA.SelectCommand = cmd;

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView6.DataSource = bSource;
            dataGridView6.Update();
            dataGridView6.Refresh();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dataGridView6.Rows.RemoveAt(currRowIndex);
           deleteUser(currRowIndex);
        }

        private void deleteUser(int currRowIndex)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "DELETE FROM user WHERE id=" + currRowIndex;
            cmd.ExecuteNonQuery();
            clearUser();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox16.Text = row.Cells[1].Value.ToString();
            textBox15.Text = row.Cells[2].Value.ToString();
            comboBox111.Text = row.Cells[3].Value.ToString();
            textBox14.Text = row.Cells[7].Value.ToString();
            textBox19.Text = row.Cells[4].Value.ToString();
            textBox18.Text = row.Cells[6].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells[5].Value);

            button25.Enabled = true;
            button24.Enabled = true;
            button26.Enabled = false;
        }

        public bool modifierUsers()
        {

            MySqlCommand cmd = Connection.getMySqlCommand();

            cmd.CommandText = "UPDATE user SET username=@username, password=@password,level=@level,email=@email,city=@city" +
                    " WHERE id=" + currRowIndex;
            cmd.Parameters.AddWithValue("@username", textBox16.Text);
            cmd.Parameters.AddWithValue("@password", textBox15.Text);
            cmd.Parameters.AddWithValue("@level", comboBox111.Text);
            cmd.Parameters.AddWithValue("@email", textBox18.Text);
            cmd.Parameters.AddWithValue("@city", textBox14.Text);
            cmd.ExecuteNonQuery();
            return true;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            modifierUsers();
            refrechusers(); clearUser();
        }

      
        private void clearUser()
        {

            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox19.Clear();
            comboBox111.Text = "";
            button25.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = true;
        }
    }
}
