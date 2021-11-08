using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class primeurs : Articles, IVendablePaKg, Idescription
    {

        private double Qstock;

        public primeurs(double prixAchat, double prixvente, string nom, string fournisseur) : base(prixAchat, prixvente, nom, fournisseur)
        {
            this.Qstock = 0;
        }

        public double remplir(double val)
        {
            this.Qstock += val;
            return base.PrixAchat* val;

        }
        public String description() { return this.ToString(); }
        public override string ToString()
        {
            return base.ToString() + " " + this.Qstock;
        }
        public double vender(double Q)
        {
            if (Q < this.Qstock)
            {
                this.Qstock -= Q;
                return Q * base.Prixvente;
            }
            else
            {
                Console.WriteLine("Stock insuffisant.");
                return 0;
            }
        }
    }
}
