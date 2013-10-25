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
using System.ComponentModel;

namespace BindingMode 
{
    public class MyDataItem : INotifyPropertyChanged
    {
        //
        // Set a default value in the constructor
        //

        public MyDataItem()
        {
            this.employee = "";
        }

        //
        // INotifyPropertyChanged implementation
        //

        public event PropertyChangedEventHandler PropertyChanged;

        //
        // Employee property
        // 

        public string Employee
        {
            get
            {
                return this.employee;
            }

            set
            {
                this.employee = value;

                // Call the PropertyChanged handler

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Employee"));
                }
            }
        }

        private String employee;
    }
}
