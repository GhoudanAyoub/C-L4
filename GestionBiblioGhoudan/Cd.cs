using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Cd:Ouvrage
    {
        private String auteur;

        private String titre;

        public Cd(DateTime dateEmprunt, string auteur, string titre) : base(dateEmprunt)
        {
            this.auteur = auteur;
            this.titre = titre;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public override string ToString()
        {
            return base.ToString()+" "+auteur+" "+titre;
        }
    }
}
