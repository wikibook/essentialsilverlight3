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

namespace ActualWidthHeight
{
    public partial class App : Application
    {

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Panel panel = new Canvas();

            //
            // Create the first TextBlock
            //

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Hello World";
            textBlock.FontSize = 24;
            textBlock.FontFamily = new FontFamily("Arial");

            panel.Children.Add(textBlock);

            //
            // Get the width and height
            //

            double width = textBlock.ActualWidth;
            double height = textBlock.ActualHeight;

            //
            // Create the second textblock after the first one
            //

            textBlock = new TextBlock();
            textBlock.Text = "Second Hello World";
            textBlock.FontSize = 24;
            textBlock.FontFamily = new FontFamily("Arial");
            textBlock.SetValue(Canvas.TopProperty, height);

            panel.Children.Add(textBlock);

            //
            // Update the width and height
            //

            width = Math.Max(width, textBlock.ActualWidth);
            height += textBlock.ActualHeight;

            //
            // Add a rectangle around the text
            //

            Rectangle border = new Rectangle();
            border.Width = width;
            border.Height = height;
            border.Stroke = new SolidColorBrush(Colors.LightGray);
            border.StrokeThickness = 2.0;

            panel.Children.Add(border);

            this.RootVisual = panel;
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }
        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
