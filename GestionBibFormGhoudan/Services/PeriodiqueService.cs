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
    class PeriodiqueService : Biblioteque<Periodique>
    {
        public override BindingSource afficher()
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
            return bSource;
        }

        public override Periodique AfficherParIndex(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Ajouter(Periodique o)
        {

            MySqlCommand cmd = Connection.getMySqlCommand();

            cmd.CommandText = "INSERT INTO periodiques (nom, periodicite,numero,cota)" +
                "VALUES(@nom, @per,@n,@cota)";
            cmd.Parameters.AddWithValue("@nom", o.Nom);
            cmd.Parameters.AddWithValue("@per", o.Periodicite);
            cmd.Parameters.AddWithValue("@n", o.Numero);
            cmd.Parameters.AddWithValue("@cota", o.Cota);
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool delete(int o)
        {

            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "DELETE FROM periodiques WHERE id=" + o;
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Modifier(Periodique o)
        {

            MySqlCommand cmd = Connection.getMySqlCommand();

            cmd.CommandText = "UPDATE periodiques SET nom=@nom, periodicite=@per, numero=@n,cota=@cota" +
                    " WHERE id=" + o.Id;
            cmd.Parameters.AddWithValue("@nom", o.Nom);
            cmd.Parameters.AddWithValue("@per", o.Periodicite);
            cmd.Parameters.AddWithValue("@n", o.Numero);
            cmd.Parameters.AddWithValue("@cota", o.Cota);
            cmd.ExecuteNonQuery();
            return true;
        }

    }
}
