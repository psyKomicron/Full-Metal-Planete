using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    public static class FabriqueUnite
    {
        /*
         * Fonction permettant de crée une unité à un joueur
         * Son type et sa position son passé en paramètre
         */
        public static IEntite CreeUnite(TypeEntite type, Case position,Joueur j)
        {
            IEntite unit;
            switch (type)
            {
                case TypeEntite.ASTRONEF:
                    unit = new Astronef(position,j);
                    break;
                case TypeEntite.BARGE:
                    unit = new Barge(position, j);
                    break;
                case TypeEntite.TANK:
                    unit = new Tank(position, j);
                    break;
                case TypeEntite.CRABE:
                    unit = new Crabe(position, j);
                    break;
                case TypeEntite.GROS_TAS:
                    unit = new Gros_Tas(position, j);
                    break;
                case TypeEntite.PONDEUSE:
                    unit = new Pondeuse(position, j);
                    break;
                case TypeEntite.TOURELLE:
                    unit = new Tourelle(position, j);
                    break;
                case TypeEntite.VEDETTE:
                    unit = new Vedette(position, j);
                    break;
                default:
                    throw new Exception("Unité inconnue au battaillon");
            }
            return unit;
        }

    }
}
