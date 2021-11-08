using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Magasins : Irendement, Idescription
    {
        public double coutAchat;
        public double revenus;
        public Articles[] primeurs;
        public Articles[] electro;

        public Magasins()
        {
            this.coutAchat = 0;
            this.revenus = 0;
            primeurs = new primeurs[2];
            electro = new elecromenagers[2];
        }

        public String description() { return this.ToString(); }

        public override string ToString()
        {
            return "" + this.coutAchat + " " + redement() + " ";
        }
        public double redement()
        {
            return (this.revenus - this.coutAchat) / this.coutAchat;
        }

    }
}
