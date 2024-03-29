﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ValueConverters
{
    public class MyPriorityConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType, // Ignore target type and always return a brush
          object parameter,
          System.Globalization.CultureInfo culture
          )
        {
            object result = null;

            //
            // Check for high priority items and mark red
            //

            if ((Priority)value == Priority.High)
            {
                return new SolidColorBrush(Colors.Red);
            }

            //
            // If we haven't converted to anything special, default to 
            // black
            //

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture
          )
        {
            // Implement this callback for two way data binding 

            throw new NotImplementedException();
        }
    }

}
