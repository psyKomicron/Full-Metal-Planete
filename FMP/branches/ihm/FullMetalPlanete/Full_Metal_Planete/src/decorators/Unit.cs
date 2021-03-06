﻿using Full_Metal_Planete.src.game.game_window;
using Metier.Unites;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.decorators
{
    public abstract class Unit : IUnite
    {
        private Unite unite;

        public Unit(Unite unite)
        {
            this.unite = unite;
        }

        public virtual Image GhostImage
        {
            get
            {
                return new Image()
                {
                    Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\src\\files\\images\\question_mark.png")),
                    Height = 50,
                    Width = 50,
                };
            }
            protected set => throw new NotImplementedException();
        }

        public bool Landed { get; private set; }

        public abstract double Width { get; }

        public abstract double Height { get; }

        public ImageSource Sprite { get => Image.Source; set => Image.Source = value; }

        public Image Image { get; set; }

        public Point Position { get; set; }

        public Box BoxHMI { get; set; }

        public TypeEntite Type => unite.Type;

        public Unite Unite => unite;

        public void AddHandler()
        {
            if (Image is Image image)
            {
                image.MouseLeftButtonDown += Unit_OnClick;
                image.MouseMove += Unit_OnMouseMove;
            }
        }

        public abstract Point GetCenter();

        protected abstract void Unit_OnClick(object sender, MouseButtonEventArgs e);

        protected virtual void Unit_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Object", this);
                DragDrop.DoDragDrop(this.Image, data, DragDropEffects.Move);
            }
        }

        public virtual void Move(Canvas canvas, Box box)
        {
            Unite.DeplacerUnit(box.Case);
            BoxHMI = box;
            Image image = Image;
            Canvas.SetLeft(image, (box.GetCenter().X - GetCenter().X));
            Canvas.SetTop(image, (box.GetCenter().Y - GetCenter().Y));
            Position = new Point(Canvas.GetLeft(Image), Canvas.GetTop(Image));
        }

        public virtual void Land(Canvas canvas, Box box)
        {
            Unite.DeplacerUnit(box.Case);
            Landed = true;
            BoxHMI = box;
            Image image = Image;
            Canvas.SetLeft(image, (box.GetCenter().X - GetCenter().X));
            Canvas.SetTop(image, (box.GetCenter().Y - GetCenter().Y));
            Canvas.SetZIndex(image, FullMetalPlaneteScreen.MAXZINDEX);
            canvas.Children.Add(image);
            Position = new Point(Canvas.GetLeft(Image), Canvas.GetTop(Image));
        }
    }
}
