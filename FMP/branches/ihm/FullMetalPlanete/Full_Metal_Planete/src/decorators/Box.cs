using Metier.Carte;
using Metier.Carte.Cases;
using System.Windows;
using System.Windows.Controls;


namespace Full_Metal_Planete.src.decorators
{
    public class Box : ICase
    {
        private Case box;

        public Case Case => box;

        public Image Sprite { get; set; }

        public Coordonnee Coordonnee { get => box.Coordonnee; set => box.Coordonnee = value; }

        public Point Position { get; set; }

        public Box(Case box)
        {
            this.box = box;
        }

        public void AjouterVoisin(Case voisin, TypeDirection dir)
        {
            box.AjouterVoisin(voisin, dir);
        }

        public TypeCases Type()
        {
            return box.Type();
        }

        public void BoxSelected()
        {
            Sprite.Opacity = 0.5;
        }

        public void BoxUnselected()
        {
            Sprite.Opacity = 1;
        }

        public bool Hit()
        {
            return Sprite.IsMouseDirectlyOver;
        }

        public Point GetCenter()
        {
            return new Point(Position.X + Sprite.Width / 2, Position.Y + Sprite.Height / 2);
        }
    }
}
