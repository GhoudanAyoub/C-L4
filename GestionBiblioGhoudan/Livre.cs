using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Livre:Ouvrage
    {
        private String auteur;
        private String titre;
        private String periodique;

        public Livre(string auteur, string titre, string periodique, DateTime dateEmprunt) :base( dateEmprunt)
        {
            this.auteur = auteur;
            this.titre = titre;
            this.periodique = periodique;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Periodique { get => periodique; set => periodique = value; }

        public override string toString()
        {
            return base.toString() + " " +auteur+" "+titre+" "+periodique;
        }
    }
}
