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
using FinalProject.Main;

namespace FinalProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        /// <summary>
        /// The main window for this application that will open this window.
        /// </summary>
        MainWindow mainWindow;

        /// <summary>
        /// holds some dummy data.
        /// </summary>
        string[] arr;

        /// <summary>
        /// If the items table has been changed this will be set to true
        /// </summary>
        public bool newItemData;

        public wndItems(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            //dummy data that is added to the list box

            arr = new string[10] {"1","2","3","4","5","6","7","8","9","10" };
            ListBox1.Items.Add(arr[0]);
            ListBox1.Items.Add(arr[1]);
            ListBox1.Items.Add(arr[2]);
            ListBox1.Items.Add(arr[3]);
            ListBox1.Items.Add(arr[4]);
            ListBox1.Items.Add(arr[5]);
            ListBox1.Items.Add(arr[6]);

        }

        /// <summary>
        /// Updates the selected item and the values in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            Console.WriteLine(ListBox1.SelectedItem.ToString());
        }
        /// <summary>
        /// Checks invoices to see if this item is used at all.
        /// If the item is not used anywhere, delete the item from the database.
        /// If the Item is used in a invoice, cancel this delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {            

        }

        /// <summary>
        /// Checks to see if the input is valid and that the entered item is not
        /// already in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Checks to see if the input is valid and then checks if the item exists 
        /// in the data base. if both checks pass updates the intem with the new values in
        /// the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
              
             
        }

        /// <summary>
        /// Refreshes the values in the text boxes 
        /// </summary>
        private void UpdateGUI()
        {

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.IsEnabled = true;
        }
    }
}
