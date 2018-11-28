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

namespace FinalProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        MainWindow mainWindow;

        public wndSearch(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        /// <summary>
        /// When the cancel button is pressed it closes this window and takes you back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.IsEnabled = true;
            //mainWindow.currentInvoice = invoiceObjectThatTheUserSelects;
        }

        /// <summary>
        /// When the select button is pressed it passes the selected invoiceID to the main window
        /// This window closes and the main window is focused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.IsEnabled = true;
            //mainWindow.currentInvoice = invoiceObjectThatTheUserSelects;

            //The selected invoiceNum will be passed to the main form as 'iSelectedinvoiceNum'
            //This method will call another method from clsSearchLogic, 'selectedInvoiceID' to get the selected invoiceID
            //from the datagrid then pass it to the main form
        }

        /// <summary>
        /// When the clear button is pressed it clears the selected filters and show the datagrid
        /// with all data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //This method will call another method from clsSearchLogic, 'clearFilters' that will clear the selected filters and 
            //run the default SQL statements to fill datagrid with default data
        }
    }
}
