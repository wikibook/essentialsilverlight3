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

namespace MouseHover
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Hook up event handlers for the rectangle

            Rectangle myRectangle = (Rectangle)this.FindName("myRectangle");

            myRectangle.MouseEnter +=
              new MouseEventHandler(MyRectangle_MouseEnter);

            myRectangle.MouseLeave +=
              new MouseEventHandler(MyRectangle_MouseLeave);
        }

        private void MyRectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            // Set to mouse over color

            myRectangle.Fill = new SolidColorBrush(Colors.Blue);
        }

        private void MyRectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle myRectangle = (Rectangle)sender;

            // Restore to default color

            myRectangle.Fill = new SolidColorBrush(Colors.Red);
        }

    }
}
