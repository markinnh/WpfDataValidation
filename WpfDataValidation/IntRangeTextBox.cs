using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDataValidation
{
    public class IntRangeTextBox : TextBox
    {
        public IntRangeTextBox()
        {
            
            TextChanged += IntRangeTextBox_TextChanged;
        }

        ~IntRangeTextBox()
        {
            TextChanged -= IntRangeTextBox_TextChanged;
        }

        void IntRangeTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender is IntRangeTextBox irtb)
            {

                if (irtb.Minimum == 0 && irtb.Maximum == 0)
                {
                    System.Diagnostics.Debug.WriteLine("minimum and maximum not initialized, range checking disabled until Minimum and/or Maximum are set.");
                    return;
                }

                if (int.TryParse(irtb.Text, out int testValue))
                {
                    if (testValue < irtb.Minimum || testValue < irtb.Maximum)
                    {
                        irtb.Foreground = Brushes.Red;
                        irtb.ToolTip = $"Error : expecting a value between {irtb.Minimum} and {irtb.Maximum}";
                        
                    }
                    else
                    {
                        irtb.Foreground = Brushes.Black;
                        irtb.ToolTip = $"Enter a value between {irtb.Minimum} and {irtb.Maximum}";
                    }
                }
            }
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(IntRangeTextBox), new PropertyMetadata(0));



        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(IntRangeTextBox), new PropertyMetadata(0));


    }
}
