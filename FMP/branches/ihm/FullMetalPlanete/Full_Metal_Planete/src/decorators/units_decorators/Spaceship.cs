using Full_Metal_Planete.src.game.game_window;
using Full_Metal_Planete.src.user_controls;
using Full_Metal_Planete.src.user_controls.unit_overlay;
using Metier;
using Metier.Unites;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.decorators.units_decorators
{
    public class Spaceship : Unit
    {
        private SpaceshipReserve _reserve;

        public Spaceship(Unite unite, MapHMI map) : base(unite)
        {
            MapHMI = map;
            Astronef u = (Astronef)Unite;
            _reserve = new SpaceshipReserve(u.Reserve, this);
            GhostImage = new Image()
            {
                Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\src\\files\\images\\sprites\\astronef.png")),
                Height = Height,
                Width = Width,
            };
        }

        public override double Width => 170;

        public override double Height => 170;

        public override Image GhostImage { get; protected set; }

        public MapHMI MapHMI { get; set; }

        public SpaceshipReserve Reserve => _reserve;

        protected override void Unit_OnClick(object sender, MouseButtonEventArgs e)
        {
            var w = Image.Parent;
            if (w is Canvas canvas && !_reserve.Displayed)
            {
                MapHMI.Astronef_OnClick(this);
            }
        }

        public override Point GetCenter()
        {
            return new Point((Image.Width / 2), (Image.Height / 2) + 13);
        }

        public override void Land(Canvas canvas, Box boxIHM)
        {
            base.Land(canvas, boxIHM);
            Astronef a = (Astronef)Unite;
            a.Position = boxIHM.Case;
        }

        public override void Move(Canvas canvas, Box box)
        {
        }

        protected override void Unit_OnMouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}

/*
var overlay = new SpaceshipOverlay(this);
Canvas.SetLeft(overlay, Position.X - 10);
Canvas.SetTop(overlay, Position.Y);
Canvas.SetZIndex(overlay, FullscreenWindow.MAXZINDEX + 1);
canvas.Children.Add(overlay);
*/
