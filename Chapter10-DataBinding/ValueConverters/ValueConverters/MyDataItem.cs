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

namespace ValueConverters
{
    public enum Priority
    {
        Normal,
        High
    }

    public struct MyDataItem
    {
        public MyDataItem(String name, Priority priority)
        {
            this.name = name;
            this.priority = priority;
        }

        public String Name
        {
            get { return this.name; }
        }

        public Priority Priority
        {
            get { return this.priority; }
        }

        private String name;
        private Priority priority;
    }

    public class MyDataCollection : ObservableCollection<MyDataItem>
    {
        public MyDataCollection()
        {
            //
            // Populate the data source with some data
            //

            this.Add(new MyDataItem("Item 1", Priority.High));
            this.Add(new MyDataItem("Item 2", Priority.Normal));
            this.Add(new MyDataItem("Item 3", Priority.Normal));
        }
    }

}
