using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {

            Magasins M1 = new Magasins();

            elecromenagers e = new elecromenagers(600, 5500, "Camera WiFi Dôme Motorisée Extérieure HD Zoom", "HV");e.remplir(50);
            elecromenagers e2 = new elecromenagers(400, 1500, "HV Dome SVTC", "HV");e2.remplir(30);
            primeurs p = new primeurs(1000, 3000, "V1", "V1");p.remplir(70);
            primeurs p2 = new primeurs(800, 12000, "V2", "V1");p2.remplir(10);
            M1.electro[0] = e;
            M1.electro[1] = e2;
            M1.primeurs[0] = p;
            M1.primeurs[1] = p2;

            Console.WriteLine(M1.description());
            

        }
    }
}
