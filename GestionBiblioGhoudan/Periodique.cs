using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Periodique:Ouvrage
    {
        private String nom;
        private int numero;
        private String  periodicite;

        public Periodique(string nom, int numero, string periodicite,DateTime dateEmprunt) :base(dateEmprunt)
        {
            this.nom = nom;
            this.numero = numero;
            this.periodicite = periodicite;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }
        public override string ToString()
        {
            return base.ToString()+" "+numero+" "+nom+" "+periodicite ;
        }
    }
}
