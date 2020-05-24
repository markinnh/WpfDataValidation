using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var key = FindResource("AgeValidationKey");
            System.Diagnostics.Debug.WriteLine($"Key = {key}");

        }

        private void RangeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    if (RangeTextBox.Maximum == 0)
        //        return;
        //    if (int.TryParse(RangeTextBox.Text, out int testValue))
        //    {
        //        if (testValue < RangeTextBox.Minimum || testValue > RangeTextBox.Maximum)
        //        {
        //            RangeTextBox.ToolTip = $"error : expecting a value between {RangeTextBox.Minimum} and {RangeTextBox.Maximum}";
        //            RangeTextBox.Foreground = Brushes.Red;
        //        }
        //        else
        //        {
        //            RangeTextBox.ToolTip = $"input a value between {RangeTextBox.Minimum} and {RangeTextBox.Maximum}";
        //            RangeTextBox.Foreground = Brushes.Black;
        //        }
        //    }
        }
    }
}
