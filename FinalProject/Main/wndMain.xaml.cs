using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

        //TODO: Remove when done
        //List<LineItem> blah1;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                currentInvoice = new Invoice();
                currentInvoiceItems = new List<LineItem>();
                mainManager = new Main.clsMainLogic();


                //Remove when done debugging.
                //currentInvoice.invoiceNum = "6000";
                //currentInvoice.invoiceDate = DateTime.Today.ToShortDateString();
                //currentInvoice.totalCost = "50.01";
                //blah1 = new List<LineItem>();





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
                this.Close();
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
                this.Close();
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
                createNewInvoiceBtn.IsEnabled = false;
                editCurrentInvoiceBtn.IsEnabled = false;
                deleteCurrentInvoiceBtn.IsEnabled = false;
                currentInvoice.invoiceDate = null;
                currentInvoice.invoiceNum = null;
                currentInvoice.totalCost = null;
                currentInvoiceItems.Clear();

                createInvoiceDatePicker.SelectedDate = null;
                createInvoiceDatePicker.DisplayDate = DateTime.Today;
                createInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;
                createInvoiceInvoiceItemsDataGrid.Items.Refresh();

                List<ItemDesc> items = mainManager.getItems();
                createInvoiceItemsDataGrid.ItemsSource = items;
                createInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;

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
                createInvoiceGroupBox.Visibility = Visibility.Collapsed;
                emptyInvoieGroupBox.Visibility = Visibility.Collapsed;
                currentInvoiceGroupBox.Visibility = Visibility.Collapsed;
                editInvoiceGroupBox.Visibility = Visibility.Visible;
                editCurrentInvoiceBtn.IsEnabled = false;
                deleteCurrentInvoiceBtn.IsEnabled = true;
                createNewInvoiceBtn.IsEnabled = true;

                editInvoiceDatePicker.SelectedDate = DateTime.Parse(currentInvoice.invoiceDate.ToString());
                List<ItemDesc> items = mainManager.getItems();
                editInvoiceItemsDataGrid.ItemsSource = items;
                editInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;
                editInvoiceInvoiceItemsDataGrid.Items.Refresh();
                editInvoiceTotal.Content = currentInvoice.totalCost;

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
                    mainManager.deleteInvoice(currentInvoice, currentInvoiceItems);
                    closeInvoice();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void doubleClickDataGridName(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Process only clicks that are part of an actual Datagrid cell.
                //Ex. If the click happens on the datagrid header or scroll bar
                //then ignore those clicks. 
                DependencyObject dep = (DependencyObject)e.OriginalSource;

                //Traverse the visual tree
                while((dep != null) && !(dep is TextBlock))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                if (dep is TextBlock)
                {
                    DataGrid dataGrid = (DataGrid)sender;

                    //----CREATE INVOICE----
                    //Add items from the invoice if this grid is clicked
                    if (dataGrid.Name == "createInvoiceItemsDataGrid")
                    {
                        if (dataGrid.CurrentColumn.DisplayIndex == 0)
                        {
                            //Convert the ItemDesc to a LineItem so it can be linked to this invoice.
                            ItemDesc itemClicked = (ItemDesc)dataGrid.CurrentItem;
                            LineItem lineItem = new LineItem();
                            lineItem.invoiceNum = currentInvoice.invoiceNum;
                            lineItem.itemCode = itemClicked.itemCode;
                            lineItem.cost = itemClicked.cost;
                            lineItem.itemDesc = itemClicked.itemDescription;
                            
                            //Add item to the list and update the UI/datagrid.
                            currentInvoiceItems.Add(lineItem);
                            createInvoiceInvoiceItemsDataGrid.Items.Refresh();

                            int indexOfLineItem = currentInvoiceItems.IndexOf(lineItem);
                            currentInvoiceItems[indexOfLineItem].lineItemNum = indexOfLineItem.ToString();
                        }
                    }
                    //Remove items from the invoice if this grid is clicked
                    else if (dataGrid.Name == "createInvoiceInvoiceItemsDataGrid")
                    {
                        if (dataGrid.CurrentColumn.DisplayIndex == 0)
                        {
                            LineItem itemClicked = (LineItem)dataGrid.CurrentItem;
                            currentInvoiceItems.Remove(itemClicked);
                            
                            //In order for the datagrid to update, these lines have to be included.
                            dataGrid.CommitEdit();
                            dataGrid.CommitEdit();

                            //Update the UI/datagrid when an item is removed.
                            createInvoiceInvoiceItemsDataGrid.Items.Refresh();
                        }
                    }

                    //----EDIT INVOICE----
                    //Add items from the invoice if this grid is clicked
                    else if (dataGrid.Name == "editInvoiceItemsDataGrid")
                    {
                        if (dataGrid.CurrentColumn.DisplayIndex == 0)
                        {
                            //Convert the ItemDesc to a LineItem so it can be linked to this invoice.
                            ItemDesc itemClicked = (ItemDesc)dataGrid.CurrentItem;
                            LineItem lineItem = new LineItem();
                            lineItem.invoiceNum = currentInvoice.invoiceNum;
                            lineItem.itemCode = itemClicked.itemCode;
                            lineItem.cost = itemClicked.cost;
                            lineItem.itemDesc = itemClicked.itemDescription;

                            //Add item to the list and update the UI/datagrid.
                            currentInvoiceItems.Add(lineItem);
                            editInvoiceInvoiceItemsDataGrid.Items.Refresh();

                            int indexOfLineItem = currentInvoiceItems.IndexOf(lineItem);
                            currentInvoiceItems[indexOfLineItem].lineItemNum = indexOfLineItem.ToString();
                        }
                    }
                    //Remove items from the invoice if this grid is clicked
                    else if (dataGrid.Name == "editInvoiceInvoiceItemsDataGrid")
                    {
                        if (dataGrid.CurrentColumn.DisplayIndex == 0)
                        {
                            LineItem itemClicked = (LineItem)dataGrid.CurrentItem;
                            currentInvoiceItems.Remove(itemClicked);

                            ////In order for the datagrid to update, these lines have to be included.
                            dataGrid.CommitEdit();
                            dataGrid.CommitEdit();

                            //Update the UI/datagrid when an item is removed.
                            editInvoiceInvoiceItemsDataGrid.Items.Refresh();

                            //Update the database
                            mainManager.deleteLineItem(currentInvoice, itemClicked);
                        }
                    }

                    calculateTotal();
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
                    editCurrentInvoiceBtn.IsEnabled = false;
                    deleteCurrentInvoiceBtn.IsEnabled = false;

                }
                else
                {
                    currentInvoiceGroupBox.Visibility = Visibility.Visible;
                    createInvoiceGroupBox.Visibility = Visibility.Collapsed;
                    editInvoiceGroupBox.Visibility = Visibility.Collapsed;
                    emptyInvoieGroupBox.Visibility = Visibility.Collapsed;
                    editCurrentInvoiceBtn.IsEnabled = true;
                    createNewInvoiceBtn.IsEnabled = true;
                    deleteCurrentInvoiceBtn.IsEnabled = true;

                    //Clear the current invoiceItems and repopulate it with what the database has.
                    currentInvoiceItems.Clear();

                    //Populate the currentInvoiceItems with the lineItems from the DB for the current invoice.
                    currentInvoiceItems = mainManager.getAllLineItems(currentInvoice.invoiceNum);

                    currentInvoiceNumber.Content = currentInvoice.invoiceNum.ToString();
                    currentInvoiceDate.Text = currentInvoice.invoiceDate;
                    currentInvoiceItemsComboBox.ItemsSource = currentInvoiceItems;
                    currentInvoiceTotal.Content = currentInvoice.totalCost;


                    ////TODO: Remove when done Debugging
                    //LineItem blah = new LineItem();
                    //blah.cost = 5.00m;
                    //blah.itemCode = "blah";
                    //blah.itemDesc = "blah";
                    //blah.lineItemNum = "0";
                    //blah.itemCode = "A";
                    //blah.invoiceNum = "6000";
                    //blah1.Add(blah);
                    //currentInvoiceItemsComboBox.ItemsSource = blah1;

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

        private void cellInvoiceCostChanged(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //Regular Expression to accept decimals
                Regex regex = new Regex(@"^\d+\.?\d*$");
                DataGrid dataGridSelected = (DataGrid)sender;
                if (e.EditAction == DataGridEditAction.Commit)
                {
                    var column = e.Column as DataGridBoundColumn;

                    if (column != null)
                    {
                        //The index of the row that was clicked which is also the lineItemNumber for each Line Item in the currentInvoiceItemsArray.
                        int rowClickedIndex = e.Row.GetIndex();
                        var textBoxEditing = e.EditingElement as TextBox;
                        string newItemCost = textBoxEditing.Text;
                        
                        //Validate input from user is of decimal format.
                        if(regex.IsMatch(newItemCost))
                        {
                            //Get the lineItem that was clicked so it can be updated.
                            LineItem lineItemClicked = currentInvoiceItems[rowClickedIndex];

                            //Convert the user input to a decimal
                            decimal cost = decimal.Parse(newItemCost);

                            //Update the items cost
                            lineItemClicked.cost = cost;

                            //Calculate new total
                            calculateTotal();

                            
                            if(editInvoiceGroupBox.Visibility == Visibility.Visible)
                            {
                                createNewInvoiceBtn.IsEnabled = true;
                            }

                            editItemsBtn.IsEnabled = true;
                            searchInvoicesBtn.IsEnabled = true;
                            createInvoiceCreateInvoiceBtn.IsEnabled = true;

                        }
                        else
                        {
                            editCurrentInvoiceBtn.IsEnabled = false;
                            createNewInvoiceBtn.IsEnabled = false;
                            editItemsBtn.IsEnabled = false;
                            searchInvoicesBtn.IsEnabled = false;
                            createInvoiceCreateInvoiceBtn.IsEnabled = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void calculateTotal()
        {
            decimal total = 0.00m;
            foreach(LineItem lineItem in currentInvoiceItems)
            {
                total += lineItem.cost;
            }
            currentInvoice.totalCost = total.ToString();

            if(createInvoiceGroupBox.Visibility == Visibility.Visible)
            {
                createInvoiceTotal.Content = "$" + currentInvoice.totalCost;
            }
            if (editInvoiceGroupBox.Visibility == Visibility.Visible)
            {
                editInvoiceTotal.Content = "$" + currentInvoice.totalCost;
            }
        }

        private void createInvoiceCancelBtnClicked(object sender, RoutedEventArgs e)
        {
            closeInvoice();
        }

        public void closeInvoice()
        {
            createNewInvoiceBtn.IsEnabled = true;
            currentInvoice.invoiceDate = null;
            currentInvoice.invoiceNum = null;
            currentInvoice.totalCost = null;
            currentInvoiceItems.Clear();

            createInvoiceDatePicker.SelectedDate = null;
            createInvoiceDatePicker.DisplayDate = DateTime.Today;

            if (createInvoiceGroupBox.Visibility == Visibility.Visible)
            {
                createInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;
                createInvoiceInvoiceItemsDataGrid.Items.Refresh();
            }
            if (editInvoiceGroupBox.Visibility == Visibility.Visible)
            {
                editInvoiceInvoiceItemsDataGrid.ItemsSource = currentInvoiceItems;
                editInvoiceInvoiceItemsDataGrid.Items.Refresh();
            }

            calculateTotal();
            createInvoiceGroupBox.Visibility = Visibility.Collapsed;
            editInvoiceGroupBox.Visibility = Visibility.Collapsed;
            setupView();
        }

        private void createInvoice(object sender, RoutedEventArgs e)
        {
            if (currentInvoice.totalCost == null)
            {
                MessageBox.Show("All Fields must be completed before creating an invoice");
            }
            else
            { 
                decimal totalCost = decimal.Parse(currentInvoice.totalCost);

                if (currentInvoice.invoiceDate == null || totalCost == 0.00m)
                {
                    MessageBox.Show("All Fields must be completed before creating an invoice");
                }
                else
                {
                    if (createInvoiceGroupBox.Visibility == Visibility.Visible)
                    {
                        Invoice invoiceCreated = mainManager.createNewInvoice(currentInvoice, currentInvoiceItems);
                        currentInvoice.invoiceNum = invoiceCreated.invoiceNum;

                        setupView();
                    }
                }
            }
        }

        private void calenderClosed(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            currentInvoice.invoiceDate = datePicker.SelectedDate.Value.Date.ToShortDateString();
        }

        private void editInvoiceCancelBtnClicked(object sender, RoutedEventArgs e)
        {
            editInvoiceGroupBox.Visibility = Visibility.Collapsed;
            editCurrentInvoiceBtn.IsEnabled = true;
            currentInvoiceGroupBox.Visibility = Visibility.Visible;
        }

        private void editInvoiceSaveEditsBtnClicked(object sender, RoutedEventArgs e)
        {

            editInvoiceGroupBox.Visibility = Visibility.Collapsed;
            editCurrentInvoiceBtn.IsEnabled = true;
            currentInvoiceGroupBox.Visibility = Visibility.Visible;

            currentInvoiceDate.Text = currentInvoice.invoiceDate;
            currentInvoiceTotal.Content = currentInvoice.totalCost;
            currentInvoiceItemsComboBox.ItemsSource = null;
            currentInvoiceItemsComboBox.Items.Clear();
            currentInvoiceItemsComboBox.ItemsSource = currentInvoiceItems;
            mainManager.updateInvoice(currentInvoice, currentInvoiceItems);

        }
    }
}
