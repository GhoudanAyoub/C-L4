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
        private int cota;

        public Periodique(string nom, int numero, string periodicite, int cota)
        {
            this.nom = nom;
            this.numero = numero;
            this.periodicite = periodicite;
            this.cota = cota;
        }

        public Periodique(int id, string nom, int numero, string periodicite, int cota)
        {
            this.id = id;
            this.nom = nom;
            this.numero = numero;
            this.periodicite = periodicite;
            this.cota = cota;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }
        public int Cota { get => cota; set => cota = value; }
    }
}
