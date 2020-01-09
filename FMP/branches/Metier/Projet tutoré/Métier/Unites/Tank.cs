﻿using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Unites
{
    public class Tank : Destructeur
    {

        public Tank(Case position, Joueur joueur) : base(position,joueur)
        {

        }

        public override TypeEntite Type
        {
            get => TypeEntite.TANK;
        }
    }
}
