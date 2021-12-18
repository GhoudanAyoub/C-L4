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
        private int cota;

        public Livre(string auteur, string titre, int cota)
        {
            this.auteur = auteur;
            this.titre = titre;
            this.cota = cota;
        }

        public Livre(int id, string auteur, string titre, int cota)
        {
            this.id = id;
            this.auteur = auteur;
            this.titre = titre;
            this.cota = cota;
        }

        public int Id { get => id; set => id = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public int Cota { get => cota; set => cota = value; }
    }
}
