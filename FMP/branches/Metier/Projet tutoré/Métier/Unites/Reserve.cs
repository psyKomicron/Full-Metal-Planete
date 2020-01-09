using Metier;
using Metier.Carte.Cases;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Métier.Unites
{
    public static class Reserve
    {
        static int tank = 16; 
        static int crabe = 4;
        static int ponton = 4;


        /// <summary>
        /// Méthode permettant de crée une unité (coté reserve) a partie de la réserve si elle est disponible
        /// </summary>
        /// <param name="t"> Type de l'unité a crée</param>
        public static void Utilise(TypeEntite t)
        {
            if (EstCreable(t))
            {
                switch (t)
                {
                    case TypeEntite.TANK:
                        tank -= 1;
                        break;
                    case TypeEntite.CRABE:
                        crabe -= 1;
                        break;
                    case TypeEntite.PONTON:
                        ponton -= 1;
                        break;
                    default:
                        throw new Exception("Unité inconnue au battaillon (Réserve)");
                }
            }
        } 

        /*
         * Cette méthode permet de vérifié si il reste des entités 
         */
        public static bool EstCreable(TypeEntite t)
        {
            bool temp = false;
            switch (t)
            {
                case TypeEntite.TANK:
                    if (tank >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.CRABE:
                    if(crabe >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.PONTON:
                    if(ponton >= 1)
                    {
                        temp = true;
                    }
                    break;
                default:
                    throw new Exception("Unité inconnue au battaillon (Réserve)");
            }
            return temp;
        }

    }
}
