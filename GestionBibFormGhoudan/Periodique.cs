using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Periodique
    {
        private int id;
        private String nom;
        private int numero;
        private String  periodicite;
        private DateTime? dateEmprunt;

        public Periodique(int id, string nom, int numero, string periodicite, DateTime? dateEmprunt)
        {
            this.id = id;
            this.nom = nom;
            this.numero = numero;
            this.periodicite = periodicite;
            this.dateEmprunt = dateEmprunt;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
    }
}
