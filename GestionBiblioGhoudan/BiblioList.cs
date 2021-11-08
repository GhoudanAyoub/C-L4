using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class BiblioList : Biblioteque<Ouvrage>
    {
        List<Ouvrage> ouvrages;

        public BiblioList()
        {
            this.ouvrages = new List<Ouvrage>();
        }

        public override Ouvrage AfficherParIndex(int index)
        {
            foreach (Ouvrage o in ouvrages)
            {
                if (o.Cote == index)
                    return o;
            }
            return null;
        }

        public override bool Ajouter(Ouvrage o)
        {
            if (!ouvrages.Contains(o))
            {
                ouvrages.Add(o);
                return true;
            }
            return false;
        }

        public override bool delete(Ouvrage o)
        {
            if (ouvrages.Contains(o))
            {
                ouvrages.Remove(o);
                return true;
            }
            return false;
        }

        public override string toString()
        {

            string s = "Le nombre d'ouvrages : " + ouvrages.Count + "\n";
            foreach(Ouvrage o in ouvrages)
            {
                s += o.toString() + "\n";
            }
            return s;
        }
    }
}
