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
        private String periodique;
        private DateTime? dateEmprunt;

        public Livre(int id, string auteur, string titre, string periodique, DateTime? dateEmprunt)
        {
            this.id = id;
            this.auteur = auteur;
            this.titre = titre;
            this.periodique = periodique;
            this.dateEmprunt = dateEmprunt;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Periodique { get => periodique; set => periodique = value; }
        public int Id { get => id; set => id = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
    }
}
