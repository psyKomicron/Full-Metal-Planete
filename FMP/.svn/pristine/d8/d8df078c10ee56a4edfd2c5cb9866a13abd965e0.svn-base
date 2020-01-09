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
using System.Windows.Shapes;

namespace Full_Metal_Planete.src.game.menus
{
    /// <summary>
    /// Logique d'interaction pour CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        public CreditsWindow()
        {
            InitializeComponent();
            media.MediaEnded += new RoutedEventHandler(Media_MediaEnded);
            media.Play();
        }

        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
            media.Play();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e) => Close();
    }
}