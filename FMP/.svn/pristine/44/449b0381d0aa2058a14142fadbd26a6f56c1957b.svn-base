using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Carte;
using Metier.Carte.Cases;
using Metier.Unites;

namespace Metier
{
    public class Joueur : IJoueur, INotifyPropertyChanged
    {
        // action du joueur
        private int action = 10;

        //Carte du joueur
        private Map carte;
        //Base(s) posséder par le joueur
        private List<Astronef> bases;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Astronef> Bases
        {
            get => bases;
            set => bases = value;
        }


        public Joueur(Map c)
        {
            carte = c;
            bases = new List<Astronef>();
        }


        /*
         * Renvoie true si je joueur est un joueur Réel 
         * False si c'est un IA
         */
        public virtual bool Player
        {
            get => true;
        }


        public Map Carte
        {
            get => carte;
        }


        public int Action
        {
            get => action;
            set
            {
                action = value;
                OnPropertyChanged("Action");
            }
        }

        /*
         * Permet d'ajouter une base au joueur
         */
        public void AjouterBase(Astronef a)
        {
            bases.Add(a);
        }

        public void FinTour()   //Possibilité d'ajout de la fonctionnalité d'économie des points
        {
            Action = 15;
            //Possibilité d'ajout de points si il a plus de 1 astronef
        }

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
