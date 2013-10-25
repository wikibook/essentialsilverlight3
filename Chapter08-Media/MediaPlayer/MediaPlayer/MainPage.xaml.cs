using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MediaPlayer
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.myMediaElement.CurrentStateChanged
                += new RoutedEventHandler(OnCurrentStateChanged);
        }

        private void OnPlay(object sender, RoutedEventArgs e)
        {
            this.myMediaElement.Play();
        }

        private void OnPause(object sender, RoutedEventArgs e)
        {
            this.myMediaElement.Pause();
        }

        private void OnStop(object sender, RoutedEventArgs e)
        {
            this.myMediaElement.Stop();
        }

        void OnCurrentStateChanged(object sender, RoutedEventArgs e)
        {
            bool isPlaying =
              (this.myMediaElement.CurrentState == MediaElementState.Playing);

            //
            // Update buttons for playing and paused state
            //

            this.myPauseButton.IsEnabled =
              isPlaying && this.myMediaElement.CanPause;

            this.myPlayButton.IsEnabled = !isPlaying;

            //
            // Set a status indicator
            //

            this.myStatus.Text = this.myMediaElement.CurrentState.ToString();
        }

    }
}
