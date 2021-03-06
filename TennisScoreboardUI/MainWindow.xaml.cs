﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;

namespace TennisScoreboardUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Registration page.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Frame.Visibility = Visibility.Hidden;
            this.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

        }

        /// <summary>
        /// Check if players name are not empty and start the game.
        /// </summary>
        private void Start_Game(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.FirstPlayerName.Text) && !String.IsNullOrWhiteSpace(this.SecondPlayerName.Text))
            {
                List<string> playerNames = new List<string> { this.FirstPlayerName.Text, this.SecondPlayerName.Text };
                ScoreboardPage sbp = new ScoreboardPage(playerNames);
                this.Frame.Navigate(sbp);
                Hide_Main();
                this.Frame.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Players Names are Mandtory");
            }
        }

        /// <summary>
        /// Hide registration page.
        /// </summary>
        private void Hide_Main()
        {
            this.FirstPlayerText.Visibility = Visibility.Collapsed;
            this.SecondPlayerText.Visibility = Visibility.Collapsed;
            this.FirstPlayerName.Visibility = Visibility.Collapsed;
            this.SecondPlayerName.Visibility = Visibility.Collapsed;
            this.StartGameButton.Visibility = Visibility.Collapsed;
        }
    }
}
