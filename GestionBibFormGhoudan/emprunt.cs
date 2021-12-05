using GestionBiblioGhoudan;
using System;

namespace GestionBibFormGhoudan
{
    class emprunt : Ouvrage 
    {

        public String client;
        public String cin;
        public DateTime delai;
        public String typeOuvr;

        public emprunt(string client, string cin, DateTime delai1, string typeOuvr, DateTime t):base(t)
        {
            this.client = client;
            this.cin = cin;
            this.delai = delai1;
            this.typeOuvr = typeOuvr;
        }
    }
}
