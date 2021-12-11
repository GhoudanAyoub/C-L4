using GestionBiblioGhoudan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibFormGhoudan.Services
{
    class LivreService : Biblioteque<Livre>
    {
        public override List<Livre> afficher()
        {
            throw new NotImplementedException();
        }

        public override Livre AfficherParIndex(int index)
        {
            throw new NotImplementedException();
        }

        public override bool Ajouter(Livre o)
        {
            throw new NotImplementedException();
        }

        public override bool delete(Livre o)
        {
            throw new NotImplementedException();
        }

        public override bool Modifier(Livre o)
        {
            throw new NotImplementedException();
        }
    }
}
