﻿using Full_Metal_Planete.src.decorators;
using Full_Metal_Planete.src.decorators.units_decorators;
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

namespace Full_Metal_Planete.src.user_controls.unit_overlay
{
    /// <summary>
    /// Interaction logic for SpaceshipOverlay.xaml
    /// </summary>
    public partial class SpaceshipOverlay : UserControl
    {
        Spaceship _spaceship;

        public SpaceshipOverlay(Spaceship unit)
        {
            InitializeComponent();
            _spaceship = unit;
            BringIntoView();
        }

        private void dropBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Object o = null;
            o.ToString();
        }

        private void action2_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void action3_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
