using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    /*
     * Unité pouvant attaquer
     */
    public abstract class Destructeur : Unite
    {
        
        public Destructeur(Case position, Joueur joueur) : base(position,joueur)
        {

        }

        public void Attaquer(Case c)
        {

        }

    }
}
