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

namespace MyEllipse_UserControl
{
    public partial class MyEllipse : UserControl
    {
        private Ellipse ellipse;

        public MyEllipse()
        {
            // Load the XAML file
            System.Windows.Application.LoadComponent(
                this,
                new System.Uri(
                "/MyEllipse-UserControl;component/MyEllipse.xaml",
                System.UriKind.Relative
                )
            );

            // Find the ellipse
            this.ellipse = (Ellipse)this.FindName("myEllipse");
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
