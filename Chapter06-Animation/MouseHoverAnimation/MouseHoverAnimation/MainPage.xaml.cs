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

namespace MouseHoverAnimation
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Connect event handlers
            rect.MouseEnter += OnMouseEnter;
            rect.MouseLeave += OnMouseLeave;
        }

        void OnMouseEnter(object sender, MouseEventArgs e)
        {
            // Find the color animation and storyboard
            ColorAnimation colorAnimation =
                (ColorAnimation)FindName("colorAnimation");

            Storyboard storyboard = (Storyboard)FindName("storyboard");

            // Set the target color. The From value is not set. Animation
            // will start from the current value of color.

            colorAnimation.To = Colors.Red;
            // Start the animation
            storyboard.Begin();
        }

        void OnMouseLeave(object sender, MouseEventArgs e)
        {
            // Find the color animation and storyboard
            ColorAnimation colorAnimation =
                (ColorAnimation)FindName("colorAnimation");

            Storyboard storyboard = (Storyboard)FindName("storyboard");

            // Set the target color. The From value is not set. Animation
            // will start from the current value of color.
            colorAnimation.To = Colors.Blue;

            // Start the animation
            storyboard.Begin();
        }
    }
}
