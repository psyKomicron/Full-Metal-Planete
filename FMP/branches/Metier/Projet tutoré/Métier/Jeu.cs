﻿using Metier.Carte;
using Metier.Carte.Cases;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Jeu : IJeu
    {
        private int tour = 1;
        private Map carte;
        private List<Joueur> joueurs;

        public int Tour
        {
            get => tour;
            set => tour = value;
        }

        public Map Carte
        {
            get => carte;
            set => carte = value;
        }

        public List<Joueur> Players
        {
            get => joueurs;
            set => joueurs = value;
        }

        public Jeu()
        {
            carte = new Map();
            joueurs = new List<Joueur>();

        }


        /*
         * Foncton permettant de poser une base
         * N'est normalement utilisé qu'au premier tour (sinon c'est bizarre)
         * Pour le moment on ne peut pas tourner la base, elle sera forcement avec une case au DESSUS, BAS GAUCHE, BAS DROITE
         */
        public void PoserBase(IJoueur j, Case c)
        {
            Astronef a = new Astronef(c, j as Joueur);
            if (Astronef.EstPosable(c))
            {
                a.SupprMinerai();
                carte.AjouterUnite(a, c);  //ajouter unité a la carte
                a.Tourelle();
                j.AjouterBase(a);
            }
        }
    }
}
