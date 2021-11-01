using System;
using System.Collections.Generic;
using System.Text;

namespace GestionMagasin
{
    class Magasin
    {
        public double depense;
        public double revenu;
        public Electromenager[] electromenagers;
        public Primeur[] primeurs;

        public Magasin()
        {
            electromenagers = new Electromenager[2];
            primeurs = new Primeur[2];
        }
        public double tauxRendement()
        {
            return (revenu - depense) / depense;
        }
        public string toString()
        {
            string s = "Dépense : " + depense + ", Revenu : " + revenu + ", Taux de rendement : " + tauxRendement();
            for (int i = 0; i < electromenagers.Length; i++)
            {
                s += electromenagers[i].toString();
            }
            for (int i = 0; i < primeurs.Length; i++)
            {
                s += primeurs[i].toString();
            }
            return s;
        }
    }
}
