using System;
using System.Collections.Generic;
using System.Text;

namespace PooTp2
{
    class Test
    {
        static void Main(string[] args)
        {
            Livre l1 = new Livre();
            l1.setAuteur("denzel washington");
            l1.setTitre("Invisible Man");
            l1.setNbPages(366);
            l1.setPrix(800);
            Livre l2 = new Livre("JustMe ", "IDK");
            l2.setNbPages(840);
            l2.setPrix(1200);
            Livre l3 = new Livre("Be HERE ", "IDK", 1555,  3000);
            l3.setPrix(2655);
            Console.WriteLine(l1.toString());
            Console.WriteLine(l2.toString());
            Console.WriteLine(l3.toString());

        }
    }
}
