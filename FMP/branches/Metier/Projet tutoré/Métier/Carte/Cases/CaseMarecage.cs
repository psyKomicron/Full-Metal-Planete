using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Carte.Cases
{
    class CaseMarecage : Case
    {
        public CaseMarecage(Coordonnee coordonnee) : base(coordonnee)
        {
        }

        /*
         * Renvoie le type de la case
         */
        public override TypeCases Type()
        {
            return TypeCases.MARECAGE;
        }
    }
}
