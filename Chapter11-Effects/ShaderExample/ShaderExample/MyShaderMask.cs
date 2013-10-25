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
    public class MyShaderMask: ShaderEffect
    {
        static MyShaderMask()
        {
            pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri(
                "/ShaderExample;component/mask.fx.ps",
                 UriKind.RelativeOrAbsolute
            );
        }

        public MyShaderMask()
        {
            this.PixelShader = pixelShader;
        }

        public Brush Mask
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        //
        // Connect shader sampler 1 to the Mask dependency property
        //

        public static readonly DependencyProperty InputProperty =
          ShaderEffect.RegisterPixelShaderSamplerProperty(
            "Mask",
            typeof(MyShaderMask),
            1
            );

        private static PixelShader pixelShader;
    }


}
