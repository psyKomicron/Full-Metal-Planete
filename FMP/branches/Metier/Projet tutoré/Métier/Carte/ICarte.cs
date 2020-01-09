
using System.Collections.Generic;

using Metier.Carte.Cases;

namespace Metier.Carte
{
    public interface ICarte
    {
        Case GetCase(Coordonnee coordonnee);
        ICollection<Case> GetCases();
        void AjouterCase(Case c);
        
    }
}
