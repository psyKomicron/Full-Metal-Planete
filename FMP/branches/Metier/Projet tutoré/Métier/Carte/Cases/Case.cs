﻿using Metier.Unites;
using System;
using System.Collections.Generic;

namespace Metier.Carte.Cases
{
    
    public abstract class Case : ICase
    {
        Dictionary<TypeDirection, Case> voisins ;

        IEntite entite;
        private bool ponton;
        private bool minerai;

        private Coordonnee coordonnee;

        /*
         * Renvoie les coordonnée de la case 
         */
        public Coordonnee Coordonnee
        {
            get => coordonnee;
            set => coordonnee = value;
        }

        public Case(Coordonnee coordonnee)
        {
            this.Coordonnee = coordonnee;
            voisins = new Dictionary<TypeDirection, Case>();
            this.entite = null;
        }

        /*
         * Renvoie l'unité prensente sur la case
         */
        public IEntite Entity
        {
            get => entite;
            set
            {
                entite = value;
            }
        }

        
        

        /*
         * Renvoie vrai si il y a un minerai sur la case
         *         False sinon
         */
        public bool Minerai
        {
            get => minerai;
            set => minerai = value;
        }


        
        /*
         * Retourn le type de la case
         * */
        public abstract TypeCases Type();

        /*
         * retourne tous les voisin de la case
         */
        public ICollection<Case> Voisins
        {
            get => voisins.Values;
            
        }

        /**
         * retourne un voisin en fonction de la direction
         * */
        public Case Voisin(TypeDirection dir) {
            voisins.TryGetValue(dir, out Case c);
            return c;
        }

        /*
         * ajoute un voisin a la case
         * */
        public void AjouterVoisin(Case voisin, TypeDirection dir)
        {
            voisins.Add(dir, voisin);
        }

        /**
         * retourne si la case est au bord
         */
        public bool EstBord() 
        {
            bool temp = false;
            if (this.coordonnee.X % 2 == 0 && this.coordonnee.Y == 0)
                temp = true;
            else if (this.coordonnee.Y == 18 && this.coordonnee.X % 2 == 0)
                temp = true;
            else if (this.coordonnee.X == 0 || this.coordonnee.X == 1)
                temp = true;
            else if (this.coordonnee.X == 45 || this.coordonnee.X == 46)
                temp = true;
            return temp;
        }


    }
}
