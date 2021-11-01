using System;
using System.Collections.Generic;
using System.Text;

namespace GestionMagasin
{
    class Article
    {
        protected double prixAchat;
        protected double prixVente;
        protected string nom;
        protected string fournisseur;

        public Article(double prixAchat, double prixVente, string nom, string fournisseur)
        {
            this.prixAchat = prixAchat;
            this.prixVente = prixVente;
            this.nom = nom;
            this.fournisseur = fournisseur;
        }

        public double tauxRendement()
        {
            return (prixVente - prixAchat)/prixAchat;
        }

        public virtual string toString()
        {
            return "Nom : " + nom + ", Fournisseur : " + fournisseur + ", Prix : " + prixVente + ", Taux de rendement : " + tauxRendement() + "%";
        }
    }
}
