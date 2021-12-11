using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Cd
    {
        private int id;
        private String auteur;
        private String titre;
        private DateTime? dateEmprunt;

        public Cd(int id, string auteur, string titre, DateTime? dateEmprunt)
        {
            this.id = id;
            this.auteur = auteur;
            this.titre = titre;
            this.dateEmprunt = dateEmprunt;
        }

        public int Id { get => id; set => id = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
    }
}
