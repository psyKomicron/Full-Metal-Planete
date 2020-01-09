using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Carte.Cases
{
    public interface ICase
    {
        TypeCases Type();
        void AjouterVoisin(Case voisin, TypeDirection dir);
        Coordonnee Coordonnee { get; set; }
    }
}
