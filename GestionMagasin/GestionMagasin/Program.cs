using System;

namespace GestionMagasin
{
    class Program
    {
        static void Main(string[] args)
        {
            Magasin m1 = new Magasin();

            m1.electromenagers[0] = new Electromenager(600, 5500, "Camera WiFi Dôme Motorisée Extérieure HD Zoom", "HV");
            m1.electromenagers[1] = new Electromenager(400, 1500, "HV Dome SVTC", "HV");
            m1.primeurs[0] = new Primeur(1000, 3000, "V1", "V1");
            m1.primeurs[1] = new Primeur(800, 12000, "V2", "V1");
            m1.depense += m1.electromenagers[0].remplirStock(10);
            m1.depense += m1.electromenagers[1].remplirStock(5);
            m1.depense += m1.primeurs[0].remplirStock(200);
            m1.depense += m1.primeurs[1].remplirStock(150);
            m1.electromenagers[1].lancerSolde(5);
            m1.revenu += m1.electromenagers[0].revenueMagasin(2);
            m1.revenu += m1.electromenagers[1].revenueMagasin(3);
            m1.revenu += m1.primeurs[0].revenueMagasin(180);
            m1.revenu += m1.primeurs[1].revenueMagasin(135);
            Console.WriteLine(m1.toString());
        }
    }
}
