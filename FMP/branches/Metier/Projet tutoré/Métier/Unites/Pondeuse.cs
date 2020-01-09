using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    public class Pondeuse : Transporteur
    {
        public Pondeuse(Case position, Joueur joueur) : base(position,joueur)
        {
            this.Capacité = 1;
        }

        public override TypeEntite Type
        {
            get => TypeEntite.PONDEUSE;
        }
    }
}
