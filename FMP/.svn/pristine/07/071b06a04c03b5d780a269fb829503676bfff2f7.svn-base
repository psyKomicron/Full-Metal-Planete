using Full_Metal_Planete.src.decorators;
using Full_Metal_Planete.src.decorators.units_decorators;
using Full_Metal_Planete.src.user_controls;
using Metier.Unites;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Full_Metal_Planete.src.tests
{
    /// <summary>
    /// Logique d'interaction pour CanvasTestWindow.xaml
    /// </summary>
    public partial class CanvasTestWindow : Window
    {
        public CanvasTestWindow()
        {
            InitializeComponent();
            UnitListView units = new UnitListView();
            UnitListView units2 = new UnitListView();
            Canvas.SetLeft(units, 20);
            Canvas.SetTop(units, 20);
            canvas.Children.Add(units);
            Canvas.SetLeft(units2, 700);
            Canvas.SetTop(units2, 20);
            canvas.Children.Add(units2);
            // adding elements
            units.AddUnit(new Spaceship(new Gros_Tas(null, null), null));
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            if (e.Data.GetDataPresent("Object"))
            {
                Point p = e.GetPosition(canvas);
                Image image = new Image()
                {
                    Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\images\\sprites\\hexagons\\eau.png"))
                };
                Canvas.SetLeft(image, p.X);
                Canvas.SetTop(image, p.Y);
                canvas.Children.Add(image);
            }
            e.Handled = true;
        }
    }
}
