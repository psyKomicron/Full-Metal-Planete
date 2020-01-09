using System;
using System.Collections.Generic;
using System.Text;
using Metier.Carte.Cases;
using Metier.Unites;

namespace Metier.Unites
{
    public abstract class Entite : IEntite
    {
        private Case position;

        public abstract TypeEntite Type { get; }

        public Entite(Case position)
        {
            this.Position = position;
        }

        public Case Position
        {
            get => position;
            set => position = value;
        }

    }
}
