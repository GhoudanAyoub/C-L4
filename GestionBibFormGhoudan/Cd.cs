using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Cd:Ouvrage
    {
        private int id;
        private static int comp;
        private String auteur;

        private String titre;

        public Cd(DateTime dateEmprunt, string auteur, string titre) : base(dateEmprunt)
        {
            this.id = ++comp;
            this.auteur = auteur;
            this.titre = titre;
        }
        public Cd(int id, DateTime dateEmprunt, string auteur, string titre) : base(dateEmprunt)
        {
            this.id = id;
            this.auteur = auteur;
            this.titre = titre;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return base.ToString()+" "+auteur+" "+titre;
        }
    }
}
