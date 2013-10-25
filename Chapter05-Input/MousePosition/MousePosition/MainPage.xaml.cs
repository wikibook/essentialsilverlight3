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

namespace MousePosition
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Hook up event handlers for the rectangle

            Rectangle myRectangle = (Rectangle)this.FindName("myRectangle");

            myRectangle.MouseMove +=
              new MouseEventHandler(MyRectangle_MouseMove);

        }

        private void MyRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            // Get position relative to this element

            Point position = e.GetPosition(myRectangle);

            // Change the color based on mouse position

            myRectangle.Fill = new SolidColorBrush(
              Color.FromArgb(
                 255, // alpha
                 (byte)(255.0f * position.X
                        / myRectangle.ActualWidth),  // red
                 (byte)(255.0f * position.Y
                        / myRectangle.ActualHeight), // green
                 255 // blue
              ));
        }

    }
}
