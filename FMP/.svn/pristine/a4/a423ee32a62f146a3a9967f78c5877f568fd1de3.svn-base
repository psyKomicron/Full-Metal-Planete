using Full_Metal_Planete.src.decorators;
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

namespace Full_Metal_Planete.src.user_controls
{
    /// <summary>
    /// Interaction logic for GameStatsDisplay.xaml
    /// </summary>
    public partial class GameStatsDisplay : UserControl
    {
        private PlayerHMI _player;

        public GameStatsDisplay(PlayerHMI player)
        {
            InitializeComponent();
            _player = player;
            _actionPoints.SetBinding(Label.ContentProperty, new Binding("Action") { Source = _player.Joueur });
            _spaceshipsNumber.SetBinding(Label.ContentProperty, new Binding("SpaceshipsOwned") { Source = _player });
        }
    }
}
