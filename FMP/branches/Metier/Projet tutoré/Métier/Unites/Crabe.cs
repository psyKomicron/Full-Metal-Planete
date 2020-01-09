﻿using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    public class Crabe : Transporteur
    {
        
        public Crabe(Case position, Joueur joueur) : base(position,joueur)
        {
            this.Capacité = 2;
            
        }


        public override TypeEntite Type
        {
            get => TypeEntite.CRABE;
        }


    }
}
