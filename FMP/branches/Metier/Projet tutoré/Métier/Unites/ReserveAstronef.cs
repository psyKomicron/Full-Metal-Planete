using System;
using System.Collections.Generic;
using System.Text;

namespace Metier.Unites
{
    public class ReserveAstronef
    {

        private int barge = 1;
        private int crabe = 1;
        private int pondeuse = 2;
        private int vedette = 2;
        private int tank = 4;
        private int gros_tas = 1;

        public ReserveAstronef()
        {

        }

        public int Barge => barge;

        public int Crabe => crabe;

        public int Pondeuse => pondeuse;

        public int Vedette => vedette;

        public int Tank => tank;

        public int GrosTas => gros_tas;

        public int NombreUnite(TypeEntite type)
        {
            switch (type)
            {
                case TypeEntite.BARGE: return Barge;
                case TypeEntite.CRABE: return Crabe;
                case TypeEntite.PONDEUSE: return Pondeuse;
                case TypeEntite.VEDETTE: return Vedette;
                case TypeEntite.TANK: return Tank;
                case TypeEntite.GROS_TAS: return GrosTas;
                default: return 0;
            }
        }

        /// <summary>
        /// Méthode permettant de crée une unité (coté reserve) a partie de la réserve si elle est disponible
        /// </summary>
        /// <param name="t"> Type de l'unité a crée</param>
        public void Utilise(TypeEntite t)
        {
            if (EstCreable(t))
            {
                switch (t)
                {
                    case TypeEntite.TANK:
                        tank--;
                        break;
                    case TypeEntite.CRABE:
                        crabe--;
                        break;
                    case TypeEntite.PONDEUSE:
                        pondeuse --;
                        break;
                    case TypeEntite.BARGE:
                        barge--;
                        break;
                    case TypeEntite.VEDETTE:
                        vedette--;
                        break;
                    case TypeEntite.GROS_TAS:
                        gros_tas--;
                        break;
                    default:
                        throw new Exception("Unité inconnue au battaillon (RéserveAstronef)");
                }
            }
        }

        public bool EstCreable(TypeEntite t)
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
                    if (crabe >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.PONDEUSE:
                    if (pondeuse >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.BARGE:
                    if (barge >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.VEDETTE:
                    if (vedette >= 1)
                    {
                        temp = true;
                    }
                    break;
                case TypeEntite.GROS_TAS:
                    if (gros_tas >= 1)
                    {
                        temp = true;
                    }
                    break;
                //default:
                    //throw new Exception("Unité inconnue au battaillon (RéserveAstronef)");
            }
            return temp;
        }

    }
}
