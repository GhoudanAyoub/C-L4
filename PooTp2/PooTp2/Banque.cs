using System;
using System.Collections.Generic;
using System.Text;

namespace PooTp2
{
    class Banque
    {
        private int nCompte;
        private float solde;
        private string cin;
        public Banque(int nCompte, float solde, string cin)
        {
            this.nCompte = nCompte;
            this.solde = solde;
            this.cin = cin;
        }
        public void deposer(float somme)
        {
            solde += somme;
        }
        public void retirer(float somme)
        {
            solde -= somme;
        }
        public float avoir_solde()
        {
            return solde;
        }
        public string avoir_informations()
        {
            return "Num " + nCompte + ", CIN : " + cin;
        }
    }
}
