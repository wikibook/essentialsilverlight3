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

namespace CustomEasingFunction
{
    public class Quadratic : EasingFunctionBase
    {
        // Progress is normalized from 0–1 value range.
        protected override double EaseInCore(double progress)
        {
            return progress * progress;
        }
    }
}
