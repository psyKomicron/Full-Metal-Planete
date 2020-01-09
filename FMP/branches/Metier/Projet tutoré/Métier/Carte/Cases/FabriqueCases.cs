using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Carte.Cases
{
    public static class FabriqueCases
    {
        /*
         * Crée un case en fontion du type, a la coordonnée donnée en paramètre
         */
        public static Case CreeCase(TypeCases type, Coordonnee coo)
        {
            Case c;

            switch (type)
            {
                case TypeCases.MARECAGE :
                    c = new CaseMarecage(coo);
                    break;
                case TypeCases.PLAINE:
                    c = new CasePlaine(coo);
                    break;
                case TypeCases.RECIF:
                    c = new CaseRecif(coo);
                    break;
                case TypeCases.MONTAGNE:
                    c = new CaseMontagne(coo);
                    break;
                case TypeCases.MER:
                    c = new CaseMer(coo);
                    break;

                default:
                    throw new Exception("Problème lors de la fabrication des cases");
            }

            return c;
        }

    }
}
