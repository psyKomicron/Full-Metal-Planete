﻿using Full_Metal_Planete.src.game.game_window;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.decorators.factory
{
    public class WeatherLayerHMI : Unit
    {
        public WeatherLayerHMI(Unite unite) : base(unite)
        {
            GhostImage = new Image()
            {
                Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\src\\files\\images\\sprites\\weather_layer.png")),
                Height = Height,
                Width = Width,
            };
        }

        public override double Width => 50;

        public override double Height => 50;

        public override Image GhostImage { get; protected set; }

        public override Point GetCenter()
        {
            return new Point((Image.Width / 2), (Image.Height / 2) - 5);
        }

        public override void Land(Canvas canvas, Box box)
        {
            base.Land(canvas, box);
        }

        public override void Move(Canvas canvas, Box box)
        {
            base.Move(canvas, box);
        }

        protected override void Unit_OnClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
