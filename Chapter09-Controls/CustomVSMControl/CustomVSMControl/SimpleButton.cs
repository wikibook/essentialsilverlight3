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

namespace CustomVSMControl
{
    public class SimpleButton : ContentControl
    {
        public SimpleButton()
        {
            // Hookup event handlers

            this.MouseLeftButtonDown += new MouseButtonEventHandler(ButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(ButtonUp);
        }


        //
        // Define VisualStateManager states
        //

        private const string Normal = "Normal";
        private const string Pressed = "Pressed";


        //
        // Define transitions by calling GoToState
        //

        void ButtonDown(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToState(this, Pressed, true /* transitions */);
        }

        void ButtonUp(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToState(this, Normal, true /* transitions */);
        }
    }
}
