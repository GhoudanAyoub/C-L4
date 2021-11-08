using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    interface IVendueSolde
    {
        public abstract void LancerSolde(double p);
        public abstract void TerminerSolde(double p);
    }
}
