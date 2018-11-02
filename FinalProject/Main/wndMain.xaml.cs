using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Current Invoice that the user has selected from searching or from recently creating it.
        /// </summary>
        public  Invoice currentInvoice { get; set; }

        /// <summary>
        /// Current Invoice Items.
        /// </summary>
        public List<LineItem> currentInvoiceItems;

        /// <summary>
        /// Object that handles all the logic for this class including all db requests.
        /// </summary>
        Main.clsMainLogic mainManager;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                currentInvoice = new Invoice();
                currentInvoiceItems = new List<LineItem>();
                mainManager = new Main.clsMainLogic();

                setupView();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void longClickDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void searchInvoicesBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Search.wndSearch searchWindow = new Search.wndSearch();
                this.IsEnabled = false;
                searchWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void editItemsBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Items.wndItems itemsWindow = new Items.wndItems();
                this.IsEnabled = false;
                itemsWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void createNewInvoiceBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show the Create Invoice Group Box
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void editCurrentInvoiceBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show the Edit Items Group Box and hide the currentInvoiceGroupBox
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void deleteCurrentInvoiceBtnClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                //Delete the Current Invoice from db, and set currentInvoice to null, and update UI according to that action
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void setupView()
        {
            try
            {
                if (currentInvoice.InvoiceNum == null)
                {
                    currentInvoiceGroupBox.Visibility = Visibility.Collapsed;
                    editCurrentInvoiceBtn.IsEnabled = false;
                    deleteCurrentInvoiceBtn.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
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
