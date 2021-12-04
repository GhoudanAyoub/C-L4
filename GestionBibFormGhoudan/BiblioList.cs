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

        internal List<Ouvrage> Ouvrages { get => ouvrages; set => ouvrages = value; }

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

        public override bool Modifier(Ouvrage o)
        {
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Cote.Equals(o.Cote)) {
                    ouvrage.DateEmprunt = o.DateEmprunt;
                    return true;
                }
            }
            return false;
        }

        public override Ouvrage[] toString()
        {
            throw new NotImplementedException();
        }
        
      
    }
}
