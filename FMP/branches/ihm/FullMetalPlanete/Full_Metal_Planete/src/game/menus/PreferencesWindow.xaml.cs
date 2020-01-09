using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Full_Metal_Planete.src.game.menus
{
    /// <summary>
    /// Logique d'interaction pour PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        private Button btnDown;
        private Button btnUp;

        Label lblResolution;

        private MainWindow window;

        private bool ButtonPressed { get; set; }

        public PreferencesWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void LoadCredits()
        {
            new CreditsWindow().ShowDialog();
        }

        private void DisplayVideoSettings()
        {
            btnDown = new Button()
            {
                Content = "Down",
                Height = 50,
                Width = 70
            };
            btnUp = new Button()
            {
                Content = "Up",
                Height = 50,
                Width = 70,
            };
            lblResolution = new Label()
            {
                Margin = new Thickness(20),
                Height = 50,
                Width = 100,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            // string array & others
            InitializeResolutionsArray();
            // Event handlers
            btnDown.Click += new RoutedEventHandler(BtnDown_Click);
            btnUp.Click += new RoutedEventHandler(BtnUp_Click);
            // Adding elements & setting position
            StackPanel panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            panel.Children.Add(btnDown);
            panel.Children.Add(lblResolution);
            panel.Children.Add(btnUp);
            Canvas.SetTop(panel, 10);
            Canvas.SetLeft(panel, 10);
            rightCanvas.Children.Add(panel);
        }

        private void ChangeWindowStyle()
        {
            if (window.FSWindowStyle == WindowStyle.ThreeDBorderWindow)
            {
                window.FSWindowStyle = WindowStyle.None;
            }
            else if (window.FSWindowStyle == WindowStyle.None)
            {
                window.FSWindowStyle = WindowStyle.ThreeDBorderWindow;
            }
        }

        private void VideoSettings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DisplayVideoSettings();

        private void Credits_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => LoadCredits();

        protected override void OnClosed(EventArgs e)
        {
            window.FSResolution = lblResolution.Content as Resolution;
            base.OnClosed(e);
        }

        #region resolution
        private void InitializeResolutionsArray()
        {
            Resolution[] array = new Resolution[]
            {
                new Resolution(800, 600), new Resolution(1280, 960), new Resolution(1600, 900), new Resolution(1680, 1050), new Resolution(1920, 1080)
            };
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                    array[i].Previous = array[i - 1];
                else
                    array[i].Previous = null;

                if (i == array.Length - 1)
                    array[i].Next = null;
                else
                    array[i].Next = array[i + 1];
            }
            // Handling if the resolution has already been set
            foreach (Resolution resolution in array)
            {
                if (null == window.FSResolution)
                {
                    lblResolution.Content = array[0];
                    break;
                }
                else if (resolution.Equals(window.FSResolution))
                {
                    lblResolution.Content = resolution;
                }
            }
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            var obj = lblResolution.Content as Resolution;
            if (null != obj && null != obj.Previous)
            {
                lblResolution.Content = obj.Previous;
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            var obj = lblResolution.Content as Resolution;
            if (null != obj && null != obj.Next)
            {
                lblResolution.Content = obj.Next;
            }
        }

        private void ChangeResolution(Delegate @delegate)
        {
            var obj = lblResolution.Content as Resolution;
            if (null != obj && null != @delegate)
            {
                lblResolution.Content = @delegate;
            }
        }
        #endregion
    }
}
