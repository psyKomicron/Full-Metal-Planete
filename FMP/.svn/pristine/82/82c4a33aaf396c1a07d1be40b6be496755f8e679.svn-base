using Full_Metal_Planete.src.decorators.units_decorators;
using Full_Metal_Planete.src.game.game_window;
using Metier.Carte;
using Metier.Carte.Cases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.decorators
{
    public class MapHMI : ICarte
    {
        private static Map _map;
        private FullMetalPlaneteScreen _window;
        private List<Box> _boxIHMs;
        private const double _imageHeight = 69;
        private const double _imageWidth = 69;

        public List<Box> BoxesIHM => _boxIHMs;
        public Map Map => _map;

        public MapHMI(Map carte, FullMetalPlaneteScreen window)
        {
            _map = carte;
            _window = window;
            _boxIHMs = new List<Box>();
        }

        public Box ChooseBox(Point cursorPosition)
        {
            double delta = 2000;
            Box tempBoxIHM = null;
            foreach (Box box in _boxIHMs)
            {
                double dist = Math.Sqrt(
                    Math.Pow((box.GetCenter().X - cursorPosition.X), 2)
                    +
                    Math.Pow((box.GetCenter().Y - cursorPosition.Y), 2)
                    );
                if (delta > dist)
                {
                    delta = dist;
                    tempBoxIHM = box;
                }
            }
            return tempBoxIHM;
        }

        public void Astronef_OnClick(Spaceship spaceship)
        {
            _window.DisplayAstronefReserve(spaceship);
        }

        public void UpdateMap() => changeMats();

        #region drawing map
        public void DrawMap(Canvas canvas, IDictionary<string, Uri> imagesPathes)
        {
            if (null != imagesPathes)
                BuildBoxes(imagesPathes);
            double[] coordinate;
            foreach (Box box in _boxIHMs)
            {
                coordinate = GiveCoordinate(box);
                Canvas.SetTop(box.Sprite, coordinate[0]);
                Canvas.SetLeft(box.Sprite, coordinate[1]);
                Canvas.SetZIndex(box.Sprite, 1);
                canvas.Children.Add(box.Sprite);
                box.Position = new System.Windows.Point(coordinate[1], coordinate[0]);
            }
            changeMats();
        }

        private void changeMats()
        {
            foreach (Box box in _boxIHMs)
            {
                if (box.Case.Minerai) box.BoxSelected();
                else box.BoxUnselected();
            }
        }

        private double[] GiveCoordinate(Box box)
        {
            double[] coordinate = new double[2];
            coordinate[0] = 0;
            coordinate[1] = 0;
            int coorY = box.Coordonnee.Y;
            int coorX = box.Coordonnee.X;
            // Correcting .png problems
            int yOffset = 15;
            int xOffset = 8;
            if (coorX % 2 == 0)
            {
                coordinate[1] = (coorY * (box.Sprite.Width + (box.Sprite.Width / 2)));
                coordinate[0] = (coorX / 2) * (box.Sprite.Height - xOffset);
            }
            else
            {
                if (coorY == 0)
                    coordinate[1] = (box.Sprite.Width / 2) + yOffset;
                else
                    coordinate[1] = ((box.Sprite.Width / 2) + yOffset) + ((box.Sprite.Width + (box.Sprite.Width / 2)) * coorY);
                coordinate[0] = ((box.Sprite.Height - xOffset) / 2) * coorX;
            }
            coordinate[0] -= 5;
            coordinate[1] -= 5;
            return coordinate;
        }

        private void BuildBoxes(IDictionary<string, Uri> pathes)
        {
            foreach (Case box in _map.GetCases())
            {
                Image img = new Image()
                {
                    Height = _imageHeight,
                    Width = _imageWidth,
                };
                switch (box.Type())
                {
                    case TypeCases.MARECAGE:
                        img.Source = new BitmapImage(pathes["maracage.png"]);
                        break;
                    case TypeCases.MER:
                        img.Source = new BitmapImage(pathes["eau2.png"]);
                        break;
                    case TypeCases.MONTAGNE:
                        img.Source = new BitmapImage(pathes["montagne.png"]);
                        break;
                    case TypeCases.PLAINE:
                        img.Source = new BitmapImage(pathes["plaine.png"]);
                        break;
                    case TypeCases.RECIF:
                        img.Source = new BitmapImage(pathes["recif.png"]);
                        break;
                    default:
                        img.Source = new BitmapImage(pathes["question_mark.png"]);
                        break;
                }
                _boxIHMs.Add(new Box(box)
                {
                    Sprite = img,
                });
            }
        }
        #endregion

        #region interface implementation
        public Case GetCase(Coordonnee coordonnee)
        {
            return _map.GetCase(coordonnee);
        }

        public ICollection<Case> GetCases()
        {
            return _map.GetCases();
        }

        public void AjouterCase(Case c)
        {
            _map.AjouterCase(c);
        }
        #endregion
    }
}
