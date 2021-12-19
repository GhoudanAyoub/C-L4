using GestionBibFormGhoudan.Db;
using GestionBiblioGhoudan;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibFormGhoudan.Services
{
    class LivreService : Biblioteque<Livre>
    {
        public override BindingSource afficher()
        {
            throw new NotImplementedException();
        }

        public override Livre AfficherParIndex(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Ajouter(Livre o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "INSERT INTO livres (auteur, titre,cota)" +
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
            cmd.CommandText = "DELETE FROM livres WHERE id=" + o;
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Modifier(Livre o)
        {
            MySqlCommand cmd = Connection.getMySqlCommand();
            cmd.CommandText = "UPDATE livres SET auteur= @auteur, titre=@titre, cota=@cote" +
                    " WHERE id=" + o.Id; 
            cmd.Parameters.AddWithValue("@auteur", o.Auteur);
            cmd.Parameters.AddWithValue("@titre", o.Titre);
            cmd.Parameters.AddWithValue("@cote", o.Cota);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
