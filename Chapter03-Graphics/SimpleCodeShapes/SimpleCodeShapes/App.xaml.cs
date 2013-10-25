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

namespace SimpleCodeShapes
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
            Canvas canvas = new Canvas();

            //
            // Make the triangle
            //

            Path path = new Path();

            path.Fill = new SolidColorBrush(Colors.Green);

            PathFigure pathFigure = new PathFigure();

            pathFigure.StartPoint = new Point(128, 12);

            LineSegment lineSegment1 = new LineSegment();
            lineSegment1.Point = new Point(12, 224);
            pathFigure.Segments.Add(lineSegment1);

            LineSegment lineSegment2 = new LineSegment();
            lineSegment2.Point = new Point(224, 224);
            pathFigure.Segments.Add(lineSegment2);


            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = new PathFigureCollection();

            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;

            canvas.Children.Add(path);

            //
            // Make the rectangle
            //

            Rectangle rectangle = new Rectangle();

            rectangle.Fill = new SolidColorBrush(Colors.Blue);
            Canvas.SetLeft(rectangle, 96);
            Canvas.SetTop(rectangle, 160);
            rectangle.Width = 256;
            rectangle.Height = 224;

            canvas.Children.Add(rectangle);

            //
            // Make the circle
            //

            Ellipse ellipse = new Ellipse();

            ellipse.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(ellipse, 230);
            Canvas.SetTop(ellipse, 288);
            ellipse.Width = 200;
            ellipse.Height = 200;

            canvas.Children.Add(ellipse);
            
            //
            // Set the root visual to the canvas
            //

            this.RootVisual = canvas;
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
