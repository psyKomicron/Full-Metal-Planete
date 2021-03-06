﻿using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    /*
     * Classe représentant toutes les unités pouvant être présentes dans le jeu
     */
    public abstract class Unite : Entite
    {

        public Unite(Case position, Joueur joueur) : base(position)
        {
            this.Joueur = joueur;
        }


        private Joueur joueur;

        public Joueur Joueur
        {
            get => joueur;
            set => joueur = value;
        }


        /*
         * Cette méthode permet de déplacer une unité
         */
        
        public void DeplacerUnit(Case arrivee)
        {
            if (this.Position != null)
            {
                this.joueur.Carte.GetCase(this.Position.Coordonnee).Entity = null;
            }
            arrivee.Entity = this;
            this.Position = arrivee;
            this.joueur.Action--;
        }

        public virtual Boolean SeDeplacer(Case arrivee, Case Depart)
        {
            //Boolean res = false;
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
                                if (arrivee.Type() != TypeCases.MER && Depart.Type() != TypeCases.MER)
                                {
                                    return true;
                                }
                            }
                            else if (Joueur.Carte.Tide == Maree.MOYENNE)
                            {
                                if (Depart.Type() != TypeCases.MER && Depart.Type() != TypeCases.RECIF)
                                {
                                    if (arrivee.Type() != TypeCases.MER && arrivee.Type() != TypeCases.RECIF)
                                    {
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                if (Depart.Type() == TypeCases.MONTAGNE || Depart.Type() == TypeCases.PLAINE)
                                {
                                    if (arrivee.Type() == TypeCases.MONTAGNE || arrivee.Type() == TypeCases.PLAINE)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }



    }
}
