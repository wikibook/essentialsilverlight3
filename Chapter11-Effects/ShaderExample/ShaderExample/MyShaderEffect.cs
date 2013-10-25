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
using System.Windows.Media.Effects;

namespace ShaderExample
{
    public class MyShaderEffect : ShaderEffect
    {
        static MyShaderEffect()
        {
            //
            // Load the pixel shader once in a static constructor
            // so that each use of the effect does not have to reload
            // the pixel shader.
            //

            pixelShader = new PixelShader();

            //
            // red.fx.ps must be compiled byte code embedded in the
            // assembly containing MyShaderEffect.
            //

            pixelShader.UriSource = new Uri(
              "/ShaderExample;component/red.fx.ps",
              UriKind.RelativeOrAbsolute
            );
        }

        public MyShaderEffect()
        {
            //
            // Set the pixel shader to the one we you loaded in the static
            // constructor
            //

            this.PixelShader = pixelShader;
        }

        //
        // Connect shader constant register 0 to the Opacity 
        // dependency property
        //

        public static readonly DependencyProperty OpacityProperty =
          DependencyProperty.Register(
            "Opacity",
            typeof(double),
            typeof(MyShaderEffect),
            new PropertyMetadata(ShaderEffect.PixelShaderConstantCallback(0))
          );

        //
        // Define the Opacity property
        // 

        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        private static PixelShader pixelShader;
    }
}