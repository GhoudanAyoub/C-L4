using System;
using System.Collections.Generic;
using System.Text;

namespace GestionMagasin
{
    interface ISolde
    {
        public void lancerSolde(double pourcentage);
        public void terminerSolde(double pourcentage);
    }
}
