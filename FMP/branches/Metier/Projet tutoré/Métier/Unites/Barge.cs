﻿using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    public class Barge : Transporteur
    {

        public Barge(Case position, Joueur joueur) : base(position,joueur)
        {
            this.Capacité = 4;
        }

        
        
        public override TypeEntite Type
        {
            get => TypeEntite.BARGE;
        }

        public override Boolean SeDeplacer( Case arrivee, Case Depart)
        {
            Boolean res = false;

            if (Joueur.Action >= 1)
            {
                foreach (TypeDirection dir in Enum.GetValues(typeof(TypeDirection)))
                {
                    if (arrivee == Depart.Voisin(dir))
                    {
                        if (arrivee.Entity == null)
                        {
                            if (Joueur.Carte.Tide == Maree.BASSE)
                            {
                                if (arrivee.Type() == TypeCases.MER && Depart.Type() == TypeCases.MER)
                                {
                                    res = true;
                                }
                            }
                            else if (Joueur.Carte.Tide == Maree.MOYENNE)
                            {
                                if (Depart.Type() == TypeCases.MER | Depart.Type() == TypeCases.RECIF | Depart.Entity.Type == TypeEntite.ASTRONEF)
                                {
                                    if (arrivee.Type() == TypeCases.MER | arrivee.Type() == TypeCases.RECIF)
                                    {
                                        res = true;
                                    }
                                }
                            }
                            else
                            {
                                if (Depart.Type() != TypeCases.MONTAGNE && Depart.Type() != TypeCases.PLAINE)
                                {
                                    if (arrivee.Type() != TypeCases.MONTAGNE && arrivee.Type() != TypeCases.PLAINE)
                                    {
                                        res = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
    }
}
