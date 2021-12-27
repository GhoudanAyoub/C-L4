using GestionBibFormGhoudan.Db;
using GestionBiblioGhoudan;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibFormGhoudan.Services
{
    class EmpruntService : Biblioteque<emprunt>
    {
        public static String currentClientLevel;
        public static String currentClientUsername;


        public override BindingSource afficher()
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
            return bSource;

        }

        public override emprunt AfficherParIndex(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Ajouter(emprunt o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "INSERT INTO emprunteurs (name, cin,date_emprunt,delai,type_ouvrage,ouvrageName)" +
                "VALUES(@nom, @cin,@date_emprunt,@delai,@type_ouvrage,@ouvargeName)";
            cmd.Parameters.AddWithValue("@nom", o.Name);
            cmd.Parameters.AddWithValue("@cin", o.Cin);
            cmd.Parameters.AddWithValue("@delai", o.Delai);
            cmd.Parameters.AddWithValue("@type_ouvrage", o.TypeOuvr);
            cmd.Parameters.AddWithValue("@date_emprunt", o.DateEmprunt);
            cmd.Parameters.AddWithValue("@ouvargeName", o.OuvrageName);
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool delete(int o)
        {

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "DELETE FROM emprunteurs WHERE id=" + o;
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Modifier(emprunt o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "UPDATE emprunteurs SET name=@nom, cin=@cin,delai=@delai,type_ouvrage=@type_ouvrage,date_emprunt=@date_emprunt" +
                    " WHERE id=" + o.Id;
            cmd.Parameters.AddWithValue("@nom", o.Name);
            cmd.Parameters.AddWithValue("@cin", o.Cin);
            cmd.Parameters.AddWithValue("@delai", o.Delai);
            cmd.Parameters.AddWithValue("@type_ouvrage", o.TypeOuvr);
            cmd.Parameters.AddWithValue("@date_emprunt", o.DateEmprunt);
            cmd.Parameters.AddWithValue("@ouvargeName", o.OuvrageName);
            cmd.ExecuteNonQuery();
            return true;
        }

    }
}
