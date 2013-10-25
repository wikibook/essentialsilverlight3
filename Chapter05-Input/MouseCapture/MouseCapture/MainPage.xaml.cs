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

namespace MouseCapture
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            myRectangle.MouseLeftButtonDown +=
              new MouseButtonEventHandler(MyRectangle_MouseLeftButtonDown);

            myRectangle.MouseLeftButtonUp +=
              new MouseButtonEventHandler(MyRectangle_MouseLeftButtonUp);

        }

        private void MyRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            // Set to mouse depressed color

            myRectangle.Fill = new SolidColorBrush(Colors.Blue);

            // Take capture so we always get the mouse up event

            myRectangle.CaptureMouse();
        }

        private void MyRectangle_MouseLeftButtonUp(object sender,MouseButtonEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            // Restore to default color

            myRectangle.Fill = new SolidColorBrush(Colors.Red);

            // Release capture 

            myRectangle.ReleaseMouseCapture();
        }


    }
}
