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

namespace SimpleDataBinding
{
    public class MyDataItem
    {
        public string Employee
        {
            get { return "John Smith"; }
        }

        public string Manager
        {
            get { return "Jessica Jones"; }
        }

    }
}
