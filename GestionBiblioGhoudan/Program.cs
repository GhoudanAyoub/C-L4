using System;
using System.Collections.Generic;

namespace GestionBiblioGhoudan
{
    class Program
    {
        static void Main(string[] args)
        {

            //EX1
            BiblioTab biblio = new BiblioTab(3);
            Employer employer = new Employer(biblio);
            client client = new client(biblio);
            Livre livre = new Livre("aa", "aa", "aa", new DateTime());
            Livre livre2 = new Livre("bb", "bb", "bb", new DateTime());
            Livre livre3 = new Livre("cc", "cc", "cc", new DateTime());
            employer.ajouter(livre);
            employer.ajouter(livre2);
            employer.ajouter(livre3);
            Console.WriteLine(client.afficher());
            Console.Write("After Delete "+livre.Cote+"\n");
            employer.supprimer(livre);
            Console.WriteLine(client.afficher());

            Console.WriteLine("\nEX2\n");
            //EX2

           
            BiblioList biblioList = new BiblioList();
            biblioList.Ajouter(livre);
            biblioList.Ajouter(livre2);
            biblioList.Ajouter(livre3);
            Console.WriteLine(biblioList.toString());
            Console.Write("After Delete " + livre.Cote + "\n");
            biblioList.delete(livre);
            Console.WriteLine(biblioList.toString());

            

            Dictionary<string, Ouvrage> ouvrageDict = new Dictionary<string, Ouvrage>();
            ouvrageDict.Add(livre.Auteur, livre);
            ouvrageDict.Add(livre2.Auteur, livre2);
            ouvrageDict.Add(livre3.Auteur, livre3);

            foreach (var ouvrage in ouvrageDict) 
                if (ouvrage.Key=="aa")
                    Console.WriteLine("Ouvrage :"+ouvrage.Value.toString());
            
        }
    }
}
