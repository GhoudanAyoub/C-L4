using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //EX 1
            Point p1 = new Point(2, 3);
            Console.WriteLine(p1.afficher());
            p1.deplacer(6,4);
            Console.WriteLine(p1.afficher());
            Console.WriteLine(p1.SymParX().afficher());
            Console.WriteLine(p1.SymParY().afficher());
            Console.WriteLine(p1.SymParORIGIN().afficher());
            p1.Permuter();
            Console.WriteLine(p1.afficher());

            //EX 2

        }
    }

}
