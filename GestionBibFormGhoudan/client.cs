using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibFormGhoudan
{
    class client
    {
        private int id;
        private String name;
        private String cin;
        private String phone;

        public client(int id, string name, string cin, string phone)
        {
            this.id = id;
            this.name = name;
            this.cin = cin;
            this.phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
