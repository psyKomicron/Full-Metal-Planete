using Full_Metal_Planete.src.decorators;
using Full_Metal_Planete.src.decorators.factory;
using Full_Metal_Planete.src.decorators.units_decorators;
using Full_Metal_Planete.src.user_controls;
using FullMetalPlaneteDAL;
using FullMetalPlaneteDAL.ImageLoader;
using Metier;
using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Full_Metal_Planete.src.game.game_window
{
    /// <summary>
    /// Logique d'interaction pour FullscreenWindow.xaml
    /// </summary>
    public partial class FullMetalPlaneteScreen : Window
    {
        public const int MAXZINDEX = 11;
        private static string _path = Environment.CurrentDirectory + "\\src";
        private bool _urisLoaded = false;
        private MapHMI _map;
        private Game _game;
        private PlayerHMI _player;
        private MainWindow _mainWindow;
        #region graphics items
        private Grid _bottomLeft;
        private Grid _bottomCenter;
        private Grid _bottomRight;
        private UnitListView _unitList;
        private Label _consoleOutput = new Label();
        private Image _ghostImage = null;
        private MediaElement media = new MediaElement()
        {
            Source = new Uri(_path + "\\files\\media\\ecran_chargement.mp4"),
            Visibility = Visibility.Visible,
            Stretch = Stretch.Fill,
            Height = 1080,
            LoadedBehavior = MediaState.Manual
        };
        #endregion
        #region names arrays & files
        private static readonly string[] unitsNames =
            {
                "astronef.png",
                "barge.png",
                "barge2.png",
                "big_tank.png",
                "BigTank2.png",
                "boat.png",
                "crab.png",
                "Crab2.png",
                "Crab3.png",
                "ponton.png",
                "question_mark.png",
                "tank.png",
                "Tank2.png",
                "time.png",
                "weather_layer.png",
            };
        private static readonly string[] hexagonsNames =
            {
                "eau.png",
                "eau2.png",
                "maracage.png",
                "montagne.png",
                "plaine.png",
                "recif.png",
                "question_mark.png",
            };

        private FileLoader _unitsFileLoader;
        private FileLoader _hexagonsFileLoader;
        #endregion

        public FullMetalPlaneteScreen(MainWindow w)
        {
            InitializeComponent();
            _mainWindow = w;
            DataContext = _mainWindow;
            LoadSettings();
            new Thread(new ThreadStart(LoadAssets)).Start();
            LoadingScreen();
        }

        #region second thread & assets
        /// <summary>
        /// Function using DAL class to create Uris for map sprites
        /// </summary>
        private void LoadAssets()
        {
            Dictionary<string, Uri> tempPathes = new Dictionary<string, Uri>();
            _unitsFileLoader = new ImageLoader(_path + "\\files\\images\\question_mark.png");
            _unitsFileLoader.Load(unitsNames, _path + "\\files\\images\\sprites\\");
            _hexagonsFileLoader = new ImageLoader(_path + "\\files\\images\\question_mark.png");
            _hexagonsFileLoader.Load(hexagonsNames, _path + "\\files\\images\\sprites\\hexagons\\");
            //------------------------------------------------------------------------------------//
            _game = new Game(new Jeu(), this);
            _map = _game.Map;
            _player = new PlayerHMI(new Joueur(_map.Map));
            UnitFactory.AddFileLoader(_unitsFileLoader);
            UnitFactory.AddMap(_map);
            _urisLoaded = true;
        }

        /// <summary>
        /// Function running in main thread while assets are being loaded
        /// </summary>
        private void LoadingScreen()
        {
            Rectangle fillBlank = new Rectangle()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 1080,
                Width = 1920
            };
            media.MediaEnded += new RoutedEventHandler(Media_OnMediaEnded);
            Canvas.SetTop(fillBlank, 0);
            Canvas.SetLeft(fillBlank, 0);
            Canvas.SetZIndex(fillBlank, 0);
            _mapCanvas.Children.Add(fillBlank);
            Canvas.SetTop(media, 0);
            Canvas.SetLeft(media, 250);
            Canvas.SetZIndex(media, 1);
            _mapCanvas.Children.Add(media);
            media.Play();
        }
        #endregion

        private void BuildReserve()
        {
            Spaceship spaceship = UnitFactory.BuildUnitHMI(TypeEntite.ASTRONEF, null, _player.Joueur) as Spaceship;
            _unitList.AddUnit(spaceship);
        }

        private void DrawGhostUnit(DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                var v = e.Data.GetData("Object");
                if (v is Unit unit)
                {
                    if (_ghostImage == null)
                    {
                        _ghostImage = unit.GhostImage;
                        _mapCanvas.Children.Add(_ghostImage);
                        Canvas.SetZIndex(_ghostImage, FullMetalPlaneteScreen.MAXZINDEX);
                    }
                    Canvas.SetLeft(_ghostImage, e.GetPosition(_mapCanvas).X - (_ghostImage.Width / 2));
                    Canvas.SetTop(_ghostImage, e.GetPosition(_mapCanvas).Y - (_ghostImage.Height / 2));
                }
            }
        }

        private void DeleteGhostUnit()
        {
            _mapCanvas.Children.Remove(_ghostImage);
            _ghostImage = null;
        }

        public void DisplayAstronefReserve(Spaceship spaceship)
        {
            SpaceshipReserve v = spaceship.Reserve;
            _bottomRight.Children.Remove(_unitList);
            _bottomRight.Children.Add(v.ReserveHMI); 
        }

        #region user interface
        private void DrawUI()
        {
            _scrollPanel.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            Brush aRGBcolor = new SolidColorBrush(Color.FromArgb(50, 50, 100, 150));
            _bottomLeft = new Grid()
            {
                Height = 246,
                Width = 327,
                Background = aRGBcolor,
            };
            _bottomCenter = new Grid()
            {
                Height = 246,
                Width = 1195,
                Background = aRGBcolor,
            };
            _bottomRight = new Grid()
            {
                Height = 246,
                Width = 400,
                Background = aRGBcolor,
            };
            _unitList = new UnitListView();
            _bottomRight.Children.Add(_unitList);

            Border background = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };
            Border background2 = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };
            Border background3 = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };
            _bottomLeft.Children.Add(background);
            _bottomCenter.Children.Add(background2);
            _bottomRight.Children.Add(background3);

            Rectangle timeZoneContainer = new Rectangle()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.DarkOrange,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 50,
                Width = 100,
            };
            Label timer = new Label()
            {
                Content = "00 : 00",
                Background = Brushes.Transparent,
            };
            Image timePNG = new Image()
            {
                Source = new BitmapImage(_unitsFileLoader.GetUri("time.png")),
                Height = 28,
                Width = 16,
            };
            Canvas timeZone = new Canvas()
            {
                Margin = new Thickness(20),
            };
            Canvas.SetTop(timeZoneContainer, 0);
            Canvas.SetLeft(timeZoneContainer, 0);
            Canvas.SetZIndex(timeZoneContainer, 0);
            Canvas.SetTop(timePNG, 5);
            Canvas.SetLeft(timePNG, 5);
            Canvas.SetZIndex(timePNG, 1);
            Canvas.SetTop(timer, 5);
            Canvas.SetLeft(timer, 20);
            Canvas.SetZIndex(timer, 1);
            timeZone.Children.Add(timeZoneContainer);
            timeZone.Children.Add(timePNG);
            timeZone.Children.Add(timer);
            _bottomLeft.Children.Add(timeZone);

            _bottomCenter.Children.Add(new GameStatsDisplay(_player));

            ToolBarTray toolBarTray = new ToolBarTray()
            {
                Background = Brushes.Transparent,
            };
            Border toolBarBorder = new Border()
            {
                BorderThickness = new Thickness(0),
            };
            ToolBar toolBar = new ToolBar();
            toolBar.Items.Add(toolBarBorder);
            Menu menu = new Menu();
            MenuItem menuItem = new MenuItem()
            {
                Header = "Options",
            };
            MenuItem menuItem1 = new MenuItem()
            {
                Header = "Quit",
            };
            menuItem1.Click += new RoutedEventHandler(BtnClose_Click);
            // build toolbar tray
            menuItem.Items.Add(menuItem1);
            menu.Items.Add(menuItem);
            toolBar.Items.Add(menu);
            toolBarTray.ToolBars.Add(toolBar);
            Canvas.SetZIndex(toolBarTray, 10);
            _uiCanvas.Children.Add(toolBarTray);

            Canvas.SetBottom(_consoleOutput, 10);
            Canvas.SetLeft(_consoleOutput, 50);
            Canvas.SetZIndex(_consoleOutput, 10);
            _bottomCenter.Children.Add(_consoleOutput);

            AddElements(_bottomLeft, _bottomCenter, _bottomRight);
            Binding binding = new Binding("Action");
            binding.Source = _player.Joueur;
            _consoleOutput.SetBinding(Label.ContentProperty, binding);

            _map.DrawMap(_mapCanvas, _hexagonsFileLoader.Uris);
            BuildReserve();
        }

        private void AddElements(Grid bottomLeft, Grid bottomCenter, Grid bottomRight)
        {
            // on the left side
            Canvas.SetLeft(bottomLeft, 0);
            Canvas.SetTop(bottomLeft, 805);
            Canvas.SetZIndex(bottomLeft, MAXZINDEX);
            // in the center
            Canvas.SetLeft(bottomCenter, 326);
            Canvas.SetTop(bottomCenter, 805);
            Canvas.SetZIndex(bottomCenter, MAXZINDEX);
            // on the left side
            Canvas.SetLeft(bottomRight, 1520);
            Canvas.SetTop(bottomRight, 805);
            Canvas.SetZIndex(bottomRight, MAXZINDEX);
            // adding to display
            _uiCanvas.Children.Add(bottomLeft);
            _uiCanvas.Children.Add(bottomCenter);
            _uiCanvas.Children.Add(bottomRight);
        }
        #endregion

        protected override void OnDrop(DragEventArgs e)
        {
            if (e.Effects == DragDropEffects.Move)
            {
                if (e.Data.GetDataPresent("Object"))
                {
                    Unit unit = (Unit)e.Data.GetData("Object");
                    Box box = _map.ChooseBox(e.GetPosition(_mapCanvas));

                    if (unit.Type == TypeEntite.ASTRONEF && Astronef.EstPosable(box.Case))
                    {
                        _game.PoserBase(_player, box.Case);
                        _player.Spaceships[0] = (Spaceship)unit;
                        _player.Spaceships[0].Land(_mapCanvas, box);
                        _unitList.RemoveUnit();
                    }
                    else if (unit.Type != TypeEntite.ASTRONEF)
                    {
                        if (unit.Landed)
                        {
                            if (unit.Unite.SeDeplacer(_map.ChooseBox(e.GetPosition(_mapCanvas)).Case, unit.BoxHMI.Case))
                            {
                                unit.Move(_mapCanvas, _map.ChooseBox(e.GetPosition(_mapCanvas)));
                            }
                        }
                        else
                        {
                            Astronef astronef = (Astronef)_player.Spaceships[0].Unite;
                            TypeEntite typeEntite = (TypeEntite)e.Data.GetData("TypeEntite");
                            if (astronef.PeutSortir(_map.ChooseBox(e.GetPosition(_mapCanvas)).Case, typeEntite))
                            {
                                unit.Land(_mapCanvas, _map.ChooseBox(e.GetPosition(_mapCanvas)));
                                _player.Spaceships[0].Reserve.UseUnit(unit);
                            }
                        }
                    }
                }
            }
            DeleteGhostUnit();
            e.Handled = true;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            DrawGhostUnit(e);
            if (_player.Spaceships.Count == 0)
                _ghostImage.Opacity = Astronef.EstPosable(_map.ChooseBox(e.GetPosition(_mapCanvas)).Case) ? 1 : 0.5;
            else
            {
                Unit unit = (Unit)e.Data.GetData("Object");
                if (unit.Landed)
                    _ghostImage.Opacity = unit.Unite.SeDeplacer(_map.ChooseBox(e.GetPosition(_mapCanvas)).Case, unit.BoxHMI.Case) ? 1 : 0.5;
                else
                {
                    Astronef astronef = (Astronef)_player.Spaceships[0].Unite;
                    TypeEntite typeEntite = (TypeEntite)e.Data.GetData("TypeEntite");
                    _ghostImage.Opacity = astronef.PeutSortir(_map.ChooseBox(e.GetPosition(_mapCanvas)).Case, typeEntite) ? 1 : 0.5;
                }
            }
            e.Handled = true;
        }

        private void Media_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            if (sender is MediaElement media)
            {
                if (_urisLoaded)
                {
                    media.Stop();
                    _mapCanvas.Children.Remove(media);
                    Image tempImage = null;
                    Rectangle tempRect = null;
                    foreach (UIElement elt in _mapCanvas.Children)
                    {
                        if (elt is Image image)
                            tempImage = image;
                        if (elt is Rectangle rectangle)
                            tempRect = rectangle;
                    }
                    if (null != tempImage)
                        _mapCanvas.Children.Remove(tempImage);
                    if (null != tempRect)
                        _mapCanvas.Children.Remove(tempRect);
                    DrawUI();
                }
                else
                {
                    media.Position = TimeSpan.FromSeconds(0);
                    media.Play();
                }
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        #region window settings
        private void LoadSettings()
        {
            if (_mainWindow.FSWindowState == WindowState.Normal)
            {
                Width = _mainWindow.FSResolution.ResX;
                Height = _mainWindow.FSResolution.ResY;
            }
            else
                WindowState = _mainWindow.FSWindowState;
            _scrollPanel.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

        public void FakeConsoleOutput(string str)
        {
            _consoleOutput.Content = str;
        }
        #endregion
    }
}
