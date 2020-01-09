using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Carte.Cases
{
    
    class CaseMer : Case
    {
        public CaseMer(Coordonnee coordonnee) : base(coordonnee)
        {
        }

        /*
         * Renvoie le type de la case
         */
        public override TypeCases Type()
        {
            return TypeCases.MER;
        }
    }
}
