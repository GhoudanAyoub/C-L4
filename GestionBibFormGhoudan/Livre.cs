using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Livre
    {
        private int id;
        private String auteur;
        private String titre;
        private DateTime? dateEmprunt;

        public Livre(int id, string auteur, string titre,  DateTime? dateEmprunt)
        {
            this.id = id;
            this.auteur = auteur;
            this.titre = titre;
            this.dateEmprunt = dateEmprunt;
        }
        public Livre( string auteur, string titre,  DateTime? dateEmprunt)
        {
            this.auteur = auteur;
            this.titre = titre;
            this.dateEmprunt = dateEmprunt;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public int Id { get => id; set => id = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
    }
}
