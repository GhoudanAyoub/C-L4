using System;
using System.Collections.Generic;
using System.Text;

namespace GestionMagasin
{
    class Electromenager : Article, IPiece, ISolde
    {
        int stock;

        public Electromenager(double prixAchat, double prixVente, string nom, string fournisseur) : base(prixAchat, prixVente, nom, fournisseur)
        {
            stock = 0;
        }

        public double remplirStock(int s)
        {
            stock += s;
            return prixAchat * stock;
        }

        public double revenueMagasin(int quantiteVendue)
        {
            if(quantiteVendue < stock)
            {
                stock -= quantiteVendue;
                return prixVente * quantiteVendue;
            }
            else
            {
                Console.WriteLine("Le stock est insuffisant");
                return 0;
            }
        }
        public void lancerSolde(double pourcentage)
        {
            prixVente = prixVente - (prixVente * pourcentage/100);
        }

        public void terminerSolde(double pourcentage)
        {
            prixVente = prixVente + (prixVente * pourcentage/100);
        }

        public override string ToString()
        {
            return base.ToString() + ", Stock : " + stock;
        }
    }
}
