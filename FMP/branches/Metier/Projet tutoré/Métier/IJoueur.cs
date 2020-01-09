using Metier.Carte;
using Metier.Unites;
using System.Collections.Generic;

namespace Metier
{
    public interface IJoueur
    {
        int Action { get; set; }
        List<Astronef> Bases { get; set; }
        Map Carte { get; }
        bool Player { get; }

        void AjouterBase(Astronef a);
        void FinTour();
    }
}