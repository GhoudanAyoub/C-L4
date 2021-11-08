using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class elecromenagers : Articles, IVendableParPiece, IVendueSolde, Idescription
    {
        private double Pstock;
        public elecromenagers(double prixAchat, double prixvente, string nom, string fournisseur) : base(prixAchat, prixvente, nom, fournisseur)
        {
            this.Pstock = 0;
        }

        public double remplir(int val)
        {
            this.Pstock += val;
            return this.PrixAchat * val;
        }

        public String description() { return this.ToString(); }
        public override string ToString()
        {
            return base.ToString() + " " + this.Pstock;
        }

        public double vender(double Q)
        {
            if (Q < this.Pstock)
            {
                this.Pstock -= Q;
                return Q * base.Prixvente;
            }
            else
            {
                Console.WriteLine("Stock insuffisant.");
                return 0;
            }
        }

        public void LancerSolde(double p)
        {
            base.Prixvente *= p / 100;
        }

        public void TerminerSolde(double p)
        {
            base.Prixvente *= p / 100;
        }
    }
}
