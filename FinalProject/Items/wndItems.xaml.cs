using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
        /// Holds all the logic of the wndItems window.
        /// </summary>
        clsItemsLogic logic;

        /// <summary>
        /// Constructor that will initialize this window.
        /// </summary>
        /// <param name="mainWindow"></param>
        public wndItems(MainWindow mainWindow)
        {
            try
            {
                InitializeComponent();
                this.mainWindow = mainWindow;

                logic = new clsItemsLogic();
                UpdateGUI();
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }      
        }

        /// <summary>
        /// Updates the selected item and the values in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ItemDesc desc = (ItemDesc)((ListBox)sender).SelectedItem;
                if (desc != null)
                {
                    txtCode.Text = desc.itemCode;
                    txtCost.Text = "" + desc.cost;
                    txtDescription.Text = desc.itemDescription;
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                lblError.Content = logic.DeleteItem(txtCode.Text);
                UpdateGUI();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Checks to see if the input is valid and that the entered item is not
        /// already in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblError.Content = logic.AddItem(txtCode.Text, txtDescription.Text, txtCost.Text);
                UpdateGUI();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }  
        }

        /// <summary>
        /// Checks to see if the input is valid and then checks if the item exists 
        /// in the database. if both checks pass updates the item with the new values in
        /// the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblError.Content = logic.UpdateItem(txtCode.Text, txtDescription.Text, txtCost.Text);
                UpdateGUI();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the values in the listbox. 
        /// </summary>
        private void UpdateGUI()
        {
            ListBox1.Items.Clear();
            foreach (ItemDesc item in logic.GetAllItems())
            {
                ListBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// Sets up the main window when this window is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                mainWindow.IsEnabled = true;
                mainWindow.setupView();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// prints an error message when an exception has taken place.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
