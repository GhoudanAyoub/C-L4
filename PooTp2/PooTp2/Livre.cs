using System;
using System.Collections.Generic;
using System.Text;

namespace PooTp2
{
    class Livre
    {
        // Variables
        private string titre, auteur;
        private int nbPages;
        private double prix;
        private bool prixFixe = false;
        // Constructeur
        public Livre() { }
        public Livre(string unAuteur, string unTitre)
        {
            auteur = unAuteur;
            titre = unTitre;
        }
        public Livre(string unAuteur, string unTitre, int unNb, double unPrix)
        {
            auteur = unAuteur;
            titre = unTitre;
            nbPages = unNb;
            prix = unPrix;
            prixFixe = true;
        }
        // Accesseur
        public string getAuteur()
        {
            return auteur;
        }
        public string getTitre()
        {
            return titre;
        }
        public int getNbPages()
        {
            return nbPages;
        }
        public double getPrix()
        {
            return prix;
        }
        // Modificateur
        public void setNbPages(int n)
        {
            if(n > 0)
            {
                nbPages = n;
            }else
            {
                Console.WriteLine("positive OBG!");
            }
        }
        public void setAuteur(string a)
        {
            auteur = a;
        }
        public void setTitre(string t)
        {
            titre = t;
        }
        public void setPrix(double p)
        {
            if (!prixFixe)
            {
                prix = p;
                prixFixe = true;
            }else
            {
                Console.WriteLine(" prix fixed");
            }

        }

        public bool isPrixFixe()
        {
            return prixFixe;
        }

        public string toString()
        {
            string s = "Auteur : " + auteur + ", Titre : " + titre;
            if(prix == -1)
            {
                s+= ", Prix pas encore donner";
            }else if(prix == 0)
            {
                s+= ", Livre gratuit";
            }else if(prix > 0)
            {
                s+= ", Prix : " + prix;
            }
            return s;
        }
    }
}
