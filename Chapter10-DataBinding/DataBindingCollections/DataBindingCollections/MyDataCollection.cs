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
using System.Collections.ObjectModel;

namespace DataBindingCollections
{
    public class MyDataCollection : ObservableCollection<String>
    {
        public MyDataCollection()
        {
            //
            // Populate the data source with some data
            //

            this.Add("Item 1");
            this.Add("Item 2");
            this.Add("Item 3");
        }
    }
}
