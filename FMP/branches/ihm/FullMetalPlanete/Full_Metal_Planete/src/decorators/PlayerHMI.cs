using Full_Metal_Planete.src.decorators.units_decorators;
using Metier;
using Metier.Carte;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Metal_Planete.src.decorators
{
    public class PlayerHMI : IJoueur, INotifyPropertyChanged
    {
        private Joueur _player;

        private List<Spaceship> _spaceships = new List<Spaceship>();

        public PlayerHMI(Joueur joueur)
        {
            _player = joueur;
        }

        public List<Spaceship> Spaceships => _spaceships;

        public int SpaceshipsOwned => Bases.Count;

        public int Action { get => _player.Action; set => _player.Action = value; }

        public List<Astronef> Bases { get => _player.Bases; set => _player.Bases = value; }

        public Map Carte => _player.Carte;

        public bool Player => _player.Player;

        public Joueur Joueur => _player;

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddSpaceship(Spaceship spaceship)
        {
            _spaceships.Add(spaceship);
            OnPropertyChanged("SpaceshipsOwned");
        }

        public void AjouterBase(Astronef a)
        {
            _player.AjouterBase(a);
        }

        public void FinTour()
        {
            _player.FinTour();
        }

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
