﻿using Full_Metal_Planete.src.decorators.factory;
using Full_Metal_Planete.src.decorators.units_decorators;
using Full_Metal_Planete.src.user_controls;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Metal_Planete.src.decorators
{
    public class SpaceshipReserve //: IReserve
    {
        private ReserveAstronef _reserveAstronef;

        private Spaceship _spaceship;

        private UnitListView _reserve = new UnitListView();

        public SpaceshipReserve(ReserveAstronef r, Spaceship spaceship)
        {
            _reserveAstronef = r;
            _spaceship = spaceship;
            Build();
        }

        public UnitListView ReserveHMI 
        { 
            get 
            {
                Displayed = true;
                return _reserve; 
            } 
        }

        public bool Displayed { get; private set; }

        public void UseUnit(Unit unit)
        {
            _reserve.RemoveUnit();
            _reserveAstronef.Utilise(unit.Type);
        }

        private void Build()
        {
            foreach (var type in Enum.GetValues(typeof(TypeEntite)))
            {
                int n = 0;
                TypeEntite t = (TypeEntite)type;
                while (n < _reserveAstronef.NombreUnite(t))
                {
                    _reserve.AddUnit(UnitFactory.BuildUnitHMI(t, null, _spaceship.Unite.Joueur));
                    n++;
                } 
            }
        }
    }
}
