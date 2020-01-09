﻿using Metier;
using Metier.Carte;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Map c = new Map();
        Joueur j;
        Astronef a;
        public MainWindow()
        {
            InitializeComponent();
            j = new Joueur(c);
            //a = new Astronef(c.GetCase(new Coordonnee(1, 1)), j);
            Crabe cr = new Crabe(c.GetCase(new Coordonnee(1, 1)), j);
            //checkBox.IsChecked = a.EstPosable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
