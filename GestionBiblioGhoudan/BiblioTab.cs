using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class BiblioTab : Biblioteque<Ouvrage>
    {
        private Ouvrage[] livres;

        public BiblioTab(int t)
        {
            this.livres = new Ouvrage[t];
        }

        internal Ouvrage[] Livres { get => livres; set => livres = value; }

        public override bool Ajouter(Ouvrage o)
        {
            for (int i = 0; i < livres.Length; i++)
            {
                if (livres[i] == null)
                {
                    livres[i] = o;
                    return true;
                }
            }
            return false;
        }

        public override Ouvrage AfficherParIndex(int index)
        {
            for (int i = 0; i < livres.Length; i++)
            {
                if (livres[i].Cote == index)
                {
                    return livres[i];
                }
            }
            return null;
        }
        public override bool delete(Ouvrage o)
        {
            for (int i = 0; i < livres.Length; i++)
            {
                if (livres[i].Cote == o.Cote)
                {
                    livres[i] = null;
                    return true;
                }
            }
            return false;

        }

        public override string toString()
        {
            string s = "\nLe nombre d'ouvrages : " + livres.Length + "\n";
            for (int i = 0; i < livres.Length; i++)
            {
                if (livres[i] != null)
                {
                    s += livres[i].toString() + "\n";
                }
            }
            return s;
        }
    }
}
