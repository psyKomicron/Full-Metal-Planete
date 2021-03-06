﻿using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    /*
     * Ce sont des des unités pouvant transporter des unités
     */
    public abstract class Transporteur : Unite
    {
        // object contenue
        private List<Entite> contenance;
        
        private int capacite;

        public Transporteur(Case position, Joueur joueur) : base(position,joueur)
        {
            this.Position = position;
            this.Joueur = joueur;
        }


        public int Capacité
        {
            get => capacite;
            set => capacite = value;
        }

        public List<Entite> Contenance
        {
            get => contenance;
            set => contenance = value;
        }

        /*
         * Permet de ramasser l'object dans la direction voulue
         */
        public void PeutRamasser(Case c) // bool
        {

        }




    }
}
