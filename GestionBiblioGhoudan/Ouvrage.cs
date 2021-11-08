using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Ouvrage
    {
        private int cote;
        private DateTime? dateEmprunt;
        private static int i;

        public int Cote { get => cote; set => cote = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }

        public Ouvrage()
        {
            this.cote = ++i;
            this.dateEmprunt = null;
        }
        public Ouvrage( DateTime dateEmprunt)
        {
            this.cote = ++i;
            this.dateEmprunt = dateEmprunt;
        }

        public virtual string toString()
        {
            return "Ouvrage :"+cote+" "+dateEmprunt;
        }
    }
}
