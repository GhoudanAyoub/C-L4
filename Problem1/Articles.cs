using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Articles : Irendement, Idescription
    {
        private double prixAchat;
        private double prixvente;
        private String nom;
        private String Fournisseur;

        public Articles(double prixAchat, double prixvente, string nom, string fournisseur)
        {
            this.prixAchat = prixAchat;
            this.prixvente = prixvente;
            this.nom = nom;
            Fournisseur = fournisseur;
        }

        public double PrixAchat { get => prixAchat; set => prixAchat = value; }
        public double Prixvente { get => prixvente; set => prixvente = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Fournisseur1 { get => Fournisseur; set => Fournisseur = value; }

        public double redement()
        {
            return (this.prixvente - this.prixAchat) / this.prixAchat;
        }

        public String description() { return this.ToString(); }
        public override String ToString()
        {
            return "" + this.prixvente + " " + this.prixAchat + " " + this.nom + " " + this.Fournisseur + " " + this.redement();
        }

    }
}
