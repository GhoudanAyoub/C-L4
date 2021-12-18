using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBiblioGhoudan
{
    abstract class Biblioteque<T>
    {
        public abstract Boolean Ajouter(T o);
        public abstract Boolean delete(int o);
        public abstract Boolean Modifier(T o);
        public abstract T AfficherParIndex(int index);
        public abstract BindingSource afficher();
    }
}
