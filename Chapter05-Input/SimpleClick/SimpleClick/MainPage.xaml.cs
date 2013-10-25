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

namespace SimpleClick
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MyRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            myRectangle.Fill = new SolidColorBrush(Colors.Blue);
        }
    }
}
