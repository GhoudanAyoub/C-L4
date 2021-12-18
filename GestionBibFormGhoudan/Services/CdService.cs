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
    class CdService : Biblioteque<Cd>
    {
        public override BindingSource afficher()
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
            return bSource;
        }

        public override Cd AfficherParIndex(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Ajouter(Cd o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "INSERT INTO cd (auteur, titre,cota)" +
                "VALUES(@auteur, @titre,@cota)";
            cmd.Parameters.AddWithValue("@auteur", o.Auteur);
            cmd.Parameters.AddWithValue("@titre", o.Titre);
            cmd.Parameters.AddWithValue("@cota", o.Cota);
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool delete(int o)
        {

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "DELETE FROM cd WHERE id=" + o;
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Modifier(Cd o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "UPDATE cd SET auteur= @auteur, titre=@titre, cota=@cota" +
                    " WHERE id=" + o.Id;
            cmd.Parameters.AddWithValue("@auteur", o.Auteur);
            cmd.Parameters.AddWithValue("@titre", o.Titre);
            cmd.Parameters.AddWithValue("@cota", o.Cota);
            cmd.ExecuteNonQuery();
            return true;
        }

    }
}
