using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyEllipse_CustomControl
{
    public class MyEllipse : Canvas
    {
        private Ellipse ellipse;

        public MyEllipse()
        {
            // Create an ellipse
            ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            ellipse.Width = 100;
            ellipse.Height = 100;

            // Add the ellipse as a child of the Canvas
            this.Children.Add(ellipse);
        }

        public Brush FillColor
        {
            set
            {
                this.ellipse.Fill = value;
            }
            get
            {
                return this.ellipse.Fill;
            }
        }
    }
}
