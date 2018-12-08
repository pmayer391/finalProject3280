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
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace FinalProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Accesses main window
        /// </summary>
        MainWindow mainWindow;

        /// <summary>
        /// Accesses search logic
        /// </summary>
        clsSearchLogic searchLogic;

        /// <summary>
        /// Accesses dataset on main
        /// </summary>
        DataSet ds = new DataSet();

        /// <summary>
        /// Accesses the data access class to execute SQL
        /// </summary>
        clsDataAccess data;

        /// <summary>
        /// bool to show if the invoice Number is filtered
        /// </summary>
        bool invoiceNumFiltered;

        /// <summary>
        /// bool to show if the invoice Date is filtered
        /// </summary>
        bool invoiceDateFiltered;

        /// <summary>
        /// bool to show if the invoice Cost is filtered
        /// </summary>
        bool invoiceCostFiltered;

        /// <summary>
        /// bool to show if the invoice Cost and Date is filtered
        /// </summary>
        bool invoiceTotalAndDateFiltered;

        /// <summary>
        /// bool to show if the form is being cleared
        /// </summary>
        bool isClearing;

        /// <summary>
        /// value that is selected and passed to main
        /// </summary>
        string selectedInvoiceNum;


        /// <summary>
        /// Constructor for wndSearch
        /// </summary>
        /// <param name="mainWindow"></param>
        public wndSearch(MainWindow mainWindow)
        {
            try
            {
                InitializeComponent();
                this.mainWindow = mainWindow;
                searchLogic = new clsSearchLogic();
                clearForm();

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// When the cancel button is pressed it closes this window and takes you back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                this.Close();
                mainWindow.IsEnabled = true;
                mainWindow.setupView();
            }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }

        }

        /// <summary>
        /// When the select button is pressed it passes the selected invoiceID to the main window
        /// This window closes and the main window is focused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.CurrentCell != null)
                {
                    selectedInvoiceNum = ((DataRowView)dataGrid.SelectedValue).Row[0].ToString();

                    this.Close();
                    mainWindow.IsEnabled = true;
                    //mainWindow.currentInvoice = invoiceObjectThatTheUserSelects; //not sure how to use this
                    mainWindow.setupView();

                    clearForm();
                }
                else
                {
                    MessageBox.Show("Please select an invoice!");
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// When the clear button is pressed it clears the current filters and shoswthe datagrid
        /// with all data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearForm();

                invoiceNumFiltered = false;
                invoiceDateFiltered = false;
                invoiceCostFiltered = false;

            }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }
        }

        /// <summary>
        /// This function is called in the constructor and the comboboxes
        /// are filled and loaded to form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void loading_data() {

            try
            {
                ds = searchLogic.loadDataGrid();
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;


                cboInvoiceNum.Items.Clear();
                cboInvoiceDate.Items.Clear();
                cboInvoiceCost.Items.Clear();

                List<string> invoiceNums = searchLogic.getInvoiceNums();
                foreach (string item in invoiceNums)
                {
                    cboInvoiceNum.Items.Add(item);
                }

                List<string> invoiceDates = searchLogic.getInvoiceDates();
                foreach (string item in invoiceDates)
                {
                    cboInvoiceDate.Items.Add(item);
                }

                List<string> invoiceTotals = searchLogic.getInvoiceTotals();
                foreach (string item in invoiceTotals)
                {
                    cboInvoiceCost.Items.Add(item);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }


        }

        /// <summary>
        /// When invoiceNum is changed and the form is not clearing, the comboboxes are
        /// reloaded with filtered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!isClearing)

                {
                    invoiceNumFiltered = true;
                    cboInvoiceDate.Items.Clear();
                    cboInvoiceCost.Items.Clear();

                    List<string> invoiceDates = searchLogic.getInvoiceDateWithNumFiltered(cboInvoiceNum.SelectedItem.ToString());
                    foreach (string item in invoiceDates)
                    {
                        cboInvoiceDate.Items.Add(item);
                    }

                    List<string> invoiceTotals = searchLogic.getInvoiceTotalWithNumFiltered(cboInvoiceNum.SelectedItem.ToString());
                    foreach (string item in invoiceTotals)
                    {
                        cboInvoiceCost.Items.Add(item);
                    }

                    ds = searchLogic.filterByInvoiceNum(cboInvoiceNum.SelectedItem.ToString());
                    dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                }

            }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }
        }

        /// <summary>
        /// When invoiceDate is changed and the form is not clearing, 
        /// the comboboxes are reloaded with filtered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!isClearing && !invoiceNumFiltered)
                {
                    if (invoiceCostFiltered == true)
                    {
                        invoiceDateFiltered = true;//has been filtered by date and cost
                        cboInvoiceNum.Items.Clear();

                        List<string> invoices = searchLogic.getInvoiceNumsWithDateTotalFiltered(cboInvoiceDate.SelectedItem.ToString(), cboInvoiceCost.SelectedItem.ToString());
                        foreach (string item in invoices)
                        {
                            cboInvoiceNum.Items.Add(item);
                        }

                        ds = searchLogic.filterByInvoiceDateTotal(cboInvoiceDate.SelectedItem.ToString(), cboInvoiceCost.SelectedItem.ToString());
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;

                        if (!invoiceTotalAndDateFiltered)
                        {
                            isClearing = true;
                            invoiceTotalAndDateFiltered = true;

                            string invoice = cboInvoiceCost.SelectedItem.ToString();
                            cboInvoiceCost.Items.Clear();

                            invoices = searchLogic.getInvoiceTotalWithDateFiltered(cboInvoiceDate.SelectedItem.ToString());
                            foreach (string item in invoices)
                            {
                                cboInvoiceCost.Items.Add(item);
                            }

                            cboInvoiceCost.SelectedItem = invoice;

                            isClearing = false;
                        }

                    }

                    //If filtered by date only
                    else
                    {
                        invoiceDateFiltered = true;
                        cboInvoiceNum.Items.Clear();
                        cboInvoiceCost.Items.Clear();

                        List<string> invoiceNums = searchLogic.getInvoiceNumsWithDateFiltered(cboInvoiceDate.SelectedItem.ToString());

                        foreach (string item in invoiceNums)
                        {
                            cboInvoiceNum.Items.Add(item);
                        }

                        List<string> invoiceTotals = searchLogic.getInvoiceTotalWithDateFiltered(cboInvoiceDate.SelectedItem.ToString());
                        foreach (string item in invoiceTotals)
                        {
                            cboInvoiceCost.Items.Add(item);
                        }

                        ds = searchLogic.filterByInvoiceDate(cboInvoiceDate.SelectedItem.ToString());
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    }
                }

                }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }

        }

        /// <summary>
        /// When invoiceCost is changed and the form is not clearing, the comboboxes are
        /// reloaded with filtered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                invoiceCostFiltered = true;

                if (!isClearing && !invoiceNumFiltered)
                {
                    if (invoiceDateFiltered)
                    {
                        invoiceCostFiltered = true; // filtered by date and total
                        cboInvoiceNum.Items.Clear();

                        List<string> invoiceNums = searchLogic.getInvoiceNumsWithDateTotalFiltered(cboInvoiceDate.SelectedItem.ToString(), cboInvoiceCost.SelectedItem.ToString());
                        foreach (string item in invoiceNums)
                        {
                            cboInvoiceNum.Items.Add(item);
                        }

                        ds = searchLogic.filterByInvoiceDateTotal(cboInvoiceDate.SelectedItem.ToString(), cboInvoiceCost.SelectedItem.ToString());
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;

                        if (!invoiceTotalAndDateFiltered)
                        {
                            isClearing = true;
                            invoiceTotalAndDateFiltered = true;

                            string tempDate = cboInvoiceDate.SelectedItem.ToString();
                            cboInvoiceDate.Items.Clear();

                            List<string> invoiceDates = searchLogic.getInvoiceDateWithTotalFiltered(cboInvoiceCost.SelectedItem.ToString());
                            foreach (string item in invoiceDates)
                            {
                                cboInvoiceDate.Items.Add(item);
                            }

                            cboInvoiceDate.SelectedItem = tempDate;
                            isClearing = false;
                        }
                    }

                    //Filtered by total only
                    else
                    {
                        invoiceCostFiltered = true;

                        cboInvoiceNum.Items.Clear();
                        cboInvoiceDate.Items.Clear();

                        List<string> invoiceNums = searchLogic.getInvoiceNumsWithTotalFiltered(cboInvoiceCost.SelectedItem.ToString());

                        foreach (string item in invoiceNums)
                        {
                            cboInvoiceNum.Items.Add(item);
                        }

                        List<string> invoiceDates = searchLogic.getInvoiceDateWithTotalFiltered(cboInvoiceCost.SelectedItem.ToString());
                        foreach (string item in invoiceDates)
                        {
                            cboInvoiceDate.Items.Add(item);
                        }

                        ds = searchLogic.filterByInvoiceTotalCost(cboInvoiceCost.SelectedItem.ToString());
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    }

                }

            }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }

        }

        /// <summary>
        /// This method is called when the clear button is pressed, when the form is loaded and when 
        /// an invoice is selected and passed to main successfully. All filters are set to false and combobox data is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clearForm() {

            try
            {
                invoiceNumFiltered = false;
                invoiceDateFiltered = false;
                invoiceCostFiltered = false;
                invoiceTotalAndDateFiltered = false;
                isClearing = true;

                loading_data();

                isClearing = false;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        public void HandleError(string sClass, string sMethod, string sMessage)
        { 
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }

        }
    }
}
