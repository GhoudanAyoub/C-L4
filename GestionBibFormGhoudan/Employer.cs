using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioGhoudan
{
    class Employer
    {
        private BiblioTab biblio;

        public Employer(BiblioTab biblio)
        {
            this.biblio = biblio;
        }

        public Boolean ajouter(Ouvrage o) => biblio.Ajouter(o);
        public Boolean modifier(Ouvrage o) => biblio.Modifier(o);

        public Boolean supprimer(Ouvrage o) => biblio.delete(o);
    }
}
