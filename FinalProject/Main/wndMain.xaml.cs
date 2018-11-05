using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Search.wndSearch searchWindow = new Search.wndSearch(this);
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
                Items.wndItems itemsWindow = new Items.wndItems(this);
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
                if(editInvoiceGroupBox.Visibility == Visibility.Visible)
                    editInvoiceGroupBox.Visibility = Visibility.Collapsed;
                if (emptyInvoieGroupBox.Visibility == Visibility.Visible)
                    emptyInvoieGroupBox.Visibility = Visibility.Collapsed;
                if (currentInvoiceGroupBox.Visibility == Visibility.Visible)
                    currentInvoiceGroupBox.Visibility = Visibility.Collapsed;

                createInvoiceGroupBox.Visibility = Visibility.Visible;
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
                if (createInvoiceGroupBox.Visibility == Visibility.Visible)
                    createInvoiceGroupBox.Visibility = Visibility.Collapsed;
                if (emptyInvoieGroupBox.Visibility == Visibility.Visible)
                    emptyInvoieGroupBox.Visibility = Visibility.Collapsed;
                if (currentInvoiceGroupBox.Visibility == Visibility.Visible)
                    currentInvoiceGroupBox.Visibility = Visibility.Collapsed;

                editInvoiceGroupBox.Visibility = Visibility.Visible;
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
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(
                    "Are you sure you want to delete the current invoice?",
                    "Delete Confirmation",
                    btnMessageBox,
                    icnMessageBox
                );
                if (rsltMessageBox.Equals(MessageBoxResult.Yes))
                {
                    //TODO: Delete Invoice from db and update UI.
                }
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
                if (currentInvoice.invoiceNum == null)
                {
                    currentInvoiceGroupBox.Visibility = Visibility.Collapsed;
                    emptyInvoieGroupBox.Visibility = Visibility.Visible;
                    //TODO: Uncomment when working on the logic of program.
                    //editCurrentInvoiceBtn.IsEnabled = false;
                    //deleteCurrentInvoiceBtn.IsEnabled = false;
                }
                else
                {
                    currentInvoiceGroupBox.Visibility = Visibility.Visible;
                    //TODO: Populate all fields of the currentInvoiceGroupBox
                }

                //TODO: Remove this dummy data with real data from the Items table when ready. Also abstract this logic into the clsMainLogic class.

                ItemDesc item = new ItemDesc();
                    item.itemCode = "0";
                    item.itemDescription = "iPhone";
                    item.cost = 454.45m;

                    ItemDesc item1 = new ItemDesc();
                    item1.itemCode = "1";
                    item1.itemDescription = "iPad";
                    item1.cost = 1454.45m;

                    ItemDesc item2 = new ItemDesc();
                    item2.itemCode = "2";
                    item2.itemDescription = "iMac";
                    item2.cost = 4454.45m;

                    List<ItemDesc> itemList = new List<ItemDesc>();
                    itemList.Add(item);
                    itemList.Add(item1);
                    itemList.Add(item2);

                    //DataGrid dataGrid = (DataGrid)sender;

                    createInvoiceItemsDataGrid.ItemsSource = itemList;
                    createInvoiceInvoiceItemsDataGrid.ItemsSource = itemList;
                    editInvoiceInvoiceItemsDataGrid.ItemsSource = itemList;
                    editInvoiceItemsDataGrid.ItemsSource = itemList;
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

        private void datagridCellClicked(object sender, EventArgs e)
        {
            try
            {
                //TODO:  datagrid is not returing the object that is selected.

                //DataGrid dataGrid = (DataGrid)sender;
                //Console.WriteLine(dataGrid.Name);

                //DataRowView row = dataGrid.SelectedItem as DataRowView;
                //Console.WriteLine(row);
                //MessageBox.Show(row.Row.ItemArray[1].ToString());

                //ItemDesc item = (ItemDesc)dataGrid.SelectedItem;

                //LineItem lineItem = new LineItem();
                //lineItem.invoiceNum = currentInvoice.invoiceNum;
                //lineItem.itemCode = item.itemCode;
                //lineItem.itemDescription = item.itemDescription;
                //lineItem.lineItemNum = dataGrid.SelectedIndex.ToString();

                //currentInvoiceItems.Add(lineItem);
                //createInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;

             }
             catch (Exception ex)
             {
                  HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
             }
        }
    }
}
