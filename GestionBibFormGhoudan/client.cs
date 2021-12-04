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
        BiblioList biblioList;

        public client(BiblioTab biblio,BiblioList biblioList)
        {
            this.biblio = biblio;
            this.biblioList = biblioList;
        }

        public Ouvrage[] afficher() => this.biblio.toString();
        public List<Ouvrage> afficherbiblioList() => this.biblioList.Ouvrages;
        
    }
}
