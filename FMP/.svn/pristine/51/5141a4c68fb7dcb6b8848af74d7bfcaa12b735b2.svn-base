using Full_Metal_Planete.src.decorators.factory;
using Full_Metal_Planete.src.decorators.units_decorators;
using Full_Metal_Planete.src.game.game_window;
using Metier;
using Metier.Carte;
using Metier.Carte.Cases;
using System.Collections.Generic;

namespace Full_Metal_Planete.src.decorators
{
    class Game : IJeu
    {
        private Jeu _game;

        private MapHMI _map;

        public Game(Jeu jeu, FullMetalPlaneteScreen window)
        {
            _game = jeu;
            _map = new MapHMI(jeu.Carte, window);
        }

        public Map Carte { get => _game.Carte; set => _game.Carte = value; }
        public List<Joueur> Players { get => _game.Players; set => _game.Players = value; }
        public int Tour { get => _game.Tour; set => _game.Tour = value; }
        public MapHMI Map { get => _map; set => _map = value; }

        public void PoserBase(IJoueur j, Case c)
        {
            PlayerHMI p = j as PlayerHMI;
            _game.PoserBase(p.Joueur, c);
            _map.UpdateMap();
            p.AddSpaceship(UnitFactory.BuildUnitHMI(Metier.Unites.TypeEntite.ASTRONEF, c, p.Joueur) as Spaceship);
        }
    }
}
