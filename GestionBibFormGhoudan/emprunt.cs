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
        private DateTime? dateEmprunt;
        private String typeOuvr;
        private String ouvrageName;

        public emprunt(string name, string cin, DateTime delai, DateTime? dateEmprunt, string typeOuvr, string ouvrageName)
        {
            this.name = name;
            this.cin = cin;
            this.delai = delai;
            this.dateEmprunt = dateEmprunt;
            this.typeOuvr = typeOuvr;
            this.ouvrageName = ouvrageName;
        }

        public emprunt(int id, string name, string cin, DateTime delai, DateTime? dateEmprunt, string typeOuvr, string ouvrageName)
        {
            this.id = id;
            this.name = name;
            this.cin = cin;
            this.delai = delai;
            this.dateEmprunt = dateEmprunt;
            this.typeOuvr = typeOuvr;
            this.ouvrageName = ouvrageName;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Cin { get => cin; set => cin = value; }
        public DateTime Delai { get => delai; set => delai = value; }
        public DateTime? DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
        public string TypeOuvr { get => typeOuvr; set => typeOuvr = value; }
        public string OuvrageName { get => ouvrageName; set => ouvrageName = value; }
    }
}
