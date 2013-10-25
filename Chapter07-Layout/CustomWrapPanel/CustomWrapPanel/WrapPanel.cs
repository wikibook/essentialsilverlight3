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

namespace CustomWrapPanel
{
    public class WrapPanel : Panel
    {
        //
        // MeasureOverride implementation
        //
        protected override Size MeasureOverride(Size availableSize)
        {
            Size panelSize = new Size();
            Size childMeasure = new Size();

            //
            // Keep track of the height and width of the current row
            //
            double currentRowWidth = 0;
            double currentRowHeight = 0;

            //
            // Measure children to determine their natural size
            // by calling Measure with size PositiveInfinity
            //
            childMeasure.Width = Double.PositiveInfinity;
            childMeasure.Height = Double.PositiveInfinity;
            foreach (UIElement child in Children)
            {
                //
                // Measure the child to determine its size
                //
                child.Measure(childMeasure);
                
                //
                // If the current child is too big to fit on the
                // current row, start a new row
                //
                if (child.DesiredSize.Width
                    + currentRowWidth > availableSize.Width)
                {
                    panelSize.Width = Math.Max(
                        panelSize.Width,
                        currentRowWidth
                    );
                    panelSize.Height += currentRowHeight;
                    currentRowWidth = 0;
                    currentRowHeight = 0;
                }

                //
                // Advance the row width by the child width
                //
                currentRowWidth += child.DesiredSize.Width;

                //
                // Set the height to the max of the child size and the
                // current row height
                //
                currentRowHeight = Math.Max(
                    currentRowHeight,
                    child.DesiredSize.Height
                );  
            }
            //
            // Update panel size to account for the new row
            //
            panelSize.Width = Math.Max(panelSize.Width, currentRowWidth);
            panelSize.Height += currentRowHeight;
            return panelSize;
        }

        //
        // ArrangeOverride implementation
        //
        protected override Size ArrangeOverride(Size finalSize)
        {
            //
            // Keep track of the position of the current row
            //
            double currentRowX = 0;
            double currentRowY = 0;
            double currentRowHeight = 0;
            foreach (UIElement child in Children)
            {
                Size childFinalSize = new Size();
                // If the current child is too big to fit on the
                // current row, start a new row
                if (child.DesiredSize.Width + currentRowX > finalSize.Width)
                {
                    currentRowY += currentRowHeight;
                    currentRowHeight = 0;
                    currentRowX = 0;
                }

                // Set the height to be the maximum of the child size and the
                // current row height
                currentRowHeight = Math.Max(
                    currentRowHeight,
                    child.DesiredSize.Height
                );
                
                //
                // Set the child to its desired size
                //
                childFinalSize.Width = child.DesiredSize.Width;
                childFinalSize.Height = child.DesiredSize.Height;

                //
                // Arrange the child elements
                //
                Rect childRect = new Rect(
                    currentRowX,
                    currentRowY,
                    childFinalSize.Width,
                    childFinalSize.Height
                );
                child.Arrange(childRect);

                //
                // Update the current row position
                //
                currentRowX += childFinalSize.Width;
            }
            return finalSize;
        }
    }
}
