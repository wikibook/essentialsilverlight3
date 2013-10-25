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

namespace Keyboard
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Page_KeyDown);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlock myTextBlock = (TextBlock)this.FindName("myTextBlock");

            myTextBlock.Text = e.Key.ToString();
        }

    }
}
