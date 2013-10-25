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

namespace BindingMode
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            MyDataItem dataItem = new MyDataItem();

            this.DataContext = dataItem;

            // Will Updates only the TextBlocks set to bind mode
            // OneWay and TwoWay.  Will Does not update the OneTime 
            // binding mode TextBlock.

            dataItem.Employee = "Original Data";

            // Will Does not update the data source since only OneWay 
            // binding is specified
            //
            // Setting the local value will also removes the binding
            // associated with this property

            this.myOneWayTextBlock.Text = "OneWayBinding";

            // Will Updates the data source since TwoWay binding
            // is specified

            this.myTwoWayTextBlock.Text = "TwoWayBinding";

        }
    }
}
