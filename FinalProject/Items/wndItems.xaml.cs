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
using System.Windows.Shapes;

namespace FinalProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        string[] arr;
        public wndItems()
        {
            InitializeComponent();
            arr = new string[10] {"1","2","3","4","5","6","7","8","9","10" };
            ListBox1.Items.Add(arr[0]);
            ListBox1.Items.Add(arr[1]);
            ListBox1.Items.Add(arr[2]);
            ListBox1.Items.Add(arr[3]);
            ListBox1.Items.Add(arr[4]);
            ListBox1.Items.Add(arr[5]);
            ListBox1.Items.Add(arr[6]);
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            Console.WriteLine(ListBox1.SelectedItem.ToString());
        }

        
    }
}
