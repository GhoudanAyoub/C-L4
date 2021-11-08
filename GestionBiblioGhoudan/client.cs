using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class client
    {
        BiblioTab biblio;

        public client(BiblioTab biblio)
        {
            this.biblio = biblio;
        }

        public string afficher() => this.biblio.toString();
        
    }
}
