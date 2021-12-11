using GestionBiblioGhoudan;
using System;

namespace GestionBibFormGhoudan
{
    class emprunt  
    {
        private int id;
        private String name;
        private String cin;
        private DateTime delai;
        private String typeOuvr;
        private DateTime? dateEmprunt;

        public emprunt(int id, string name, string cin, DateTime delai, string typeOuvr, DateTime? dateEmprunt)
        {
            this.id = id;
            this.name = name;
            this.cin = cin;
            this.delai = delai;
            this.typeOuvr = typeOuvr;
            this.dateEmprunt = dateEmprunt;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Cin { get => cin; set => cin = value; }
        public DateTime Delai { get => delai; set => delai = value; }
        public string TypeOuvr { get => typeOuvr; set => typeOuvr = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
    }
}
