﻿using Full_Metal_Planete.src.decorators.units_decorators;
using FullMetalPlaneteDAL;
using Metier;
using Metier.Carte.Cases;
using Metier.Unites;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.decorators.factory
{
    public static class UnitFactory
    {
        private static FileLoader fileLoader;

        private static MapHMI _map;

        public static Unit BuildUnitHMI(TypeEntite type, Case position, Joueur j)
        {
            Unit unit = null;
            switch (type)
            {
                case TypeEntite.ASTRONEF:
                    unit = new Spaceship((Unite)FabriqueUnite.CreeUnite(type, position, j), _map);
                    unit.Image = new Image() 
                    { 
                        Source = new BitmapImage(fileLoader.GetUri("astronef.png")),
                    };
                    break;
                case TypeEntite.BARGE:
                    unit = new BargeHMI((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("barge.png"))
                    };
                    break;
                case TypeEntite.TANK:
                    unit = new TankHMI((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("tank.png"))
                    };
                    break;
                case TypeEntite.CRABE:
                    unit = new Crab((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("Crab3.png"))
                    };
                    break;
                case TypeEntite.GROS_TAS:
                    unit = new T99((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("big_tank.png"))
                    };
                    break;
                case TypeEntite.PONDEUSE:
                    unit = new WeatherLayerHMI((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("weather_layer.png"))
                    };
                    break;
                case TypeEntite.VEDETTE:
                    unit = new Speedboat((Unite)FabriqueUnite.CreeUnite(type, position, j));
                    unit.Image = new Image()
                    {
                        Source = new BitmapImage(fileLoader.GetUri("boat.png")),
                    };
                    break;
            }
            unit.Image.Height = unit.Height;
            unit.Image.Width = unit.Width;
            unit.AddHandler();
            return unit;
        }

        public static void AddFileLoader(FileLoader loader) => fileLoader = loader;

        public static void AddMap(MapHMI map) => _map = map;
    }
}
