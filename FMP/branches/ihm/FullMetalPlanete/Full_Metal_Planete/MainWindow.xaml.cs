﻿using Full_Metal_Planete.src.game.game_window;
using Full_Metal_Planete.src.game.menus;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Full_Metal_Planete
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isPlaying;

        private SoundPlayer _soundPlayer;

        public WindowState FSWindowState { get; set; }

        public WindowStyle FSWindowStyle { get; set; }

        public Resolution FSResolution { get; set; }

        public static string LabelText => "(beta) version : 1.7.1";

        public MainWindow()
        {
            InitializeComponent();
            backgroundVideo.MediaEnded += new RoutedEventHandler(BackgroundVideo_MediaEnded);
            backgroundVideo.Play();
            _soundPlayer = new SoundPlayer();
            FSWindowStyle = WindowStyle.None;
            FSWindowState = WindowState.Maximized;
            FSResolution = new Resolution(1920, 1080);
            Activated += new EventHandler(Window_Activated);
            Deactivated += new EventHandler(Window_Deactivated);
            label.DataContext = this;
        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            backgroundVideo.Position = TimeSpan.FromSeconds(0);
            backgroundVideo.Play();
        }

        public void Window_Activated(object sender, EventArgs e) => ResumeOrPlayMedia(sender);

        public void Window_Deactivated(object sender, EventArgs e) => ResumeOrPlayMedia(sender);

        private void StartGame()
        {
            string file = Environment.CurrentDirectory + "\\media\\rocket_launch.wav";
            try
            {
                _soundPlayer.SoundLocation = file;
                _soundPlayer.Load();
                _soundPlayer.Play();
            }
            catch (InvalidOperationException)
            { }
            catch (System.IO.FileNotFoundException)
            { }
            new FullMetalPlaneteScreen(this).ShowDialog();
        }

        private void PlayVideo(object sender, MouseButtonEventArgs e) => ResumeOrPlayMedia(sender);

        private void ResumeOrPlayMedia(object sender)
        {
            if (sender is MediaElement media)
            {
                if (_isPlaying)
                {
                    _isPlaying = false;
                    media.Pause();
                }
                else
                {
                    _isPlaying = true;
                    media.Play();
                }
            }
        }

        private void Parameters_Click(object sender, RoutedEventArgs e)
        {
            new PreferencesWindow(this).ShowDialog();
        }

        public void StopSound() => _soundPlayer.Stop();

        private void Start_Click(object sender, RoutedEventArgs e) => StartGame();

        private void Quit_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnPlay_Click(object sender, RoutedEventArgs e) => StartGame();

        private void BtnRules_Click(object sender, RoutedEventArgs e) => ShowRules();

        private void BtnCredits_Click(object sender, RoutedEventArgs e) => ShowCredits();

        public void ShowCredits()
        {
            new CreditsWindow().ShowDialog();
        }

        private void ShowRules()
        {
            new RulesWindow().Show();
        }
    }
}
