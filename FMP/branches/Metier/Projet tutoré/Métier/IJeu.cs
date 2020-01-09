using Metier.Carte;
using Metier.Carte.Cases;
using System.Collections.Generic;

namespace Metier
{
    public interface IJeu
    {
        Map Carte { get; set; }
        List<Joueur> Players { get; set; }
        int Tour { get; set; }

        void PoserBase(IJoueur j, Case c);
    }
}