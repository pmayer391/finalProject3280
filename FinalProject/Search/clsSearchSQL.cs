using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FinalProject.Search
{
    class clsSearchSQL
    {
        #region sqlSearch Properties
        /// <summary>
        /// Class that contains all sql statements for the Search class
        /// </summary>
        private string sql;
        #endregion


        /// <summary>
        /// SQL statement to get all data from Invoice table to initially load the datagrid
        /// </summary>
        /// <returns>sql statement</returns>
        public string initialLoad()
        {
            sql = "SELECT InvoiceNum, Format([InvoiceDate], 'MM/DD/YYYY') AS InvoiceDate, TotalCost FROM Invoices";

            return sql;
        }

        /// <summary>
        /// SQL statement to load the invoiceNum combobox with invoice number
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceNum()
        {
            sql = "SELECT InvoiceNum FROM Invoices";

            return sql;
        }

        /// <summary>
        /// SQL statement to load the invoiceDate combobox with invoice date
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceDate()
        {
            sql = "SELECT DISTINCT Format([InvoiceDate], 'MM/DD/YYYY') AS InvoiceDate FROM Invoices";

            return sql;
        }

        /// <summary>
        /// SQL statement to load the invoiceCost combobox with total cost
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceTotalCost()
        {
            string sql = "SELECT DISTINCT TotalCost FROM Invoices";

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the invoiceNum and invoiceDate by invoiceNum combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string filterByInvoiceNum(string invoiceNum)
        {
            string sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE invoiceNum = " + invoiceNum;

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the invoiceNum invoiceDate and TotalCost by invoiceDate combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string filterByInvoiceDate(string invoiceDate)
        {
            string sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE invoiceDate = #" + invoiceDate  + "#";

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the totalCost invoiceDate and TotalCost by TotalCost combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string filterByInvoiceTotalCost(string totalCost)
        {
            string sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = " + totalCost;

            return sql;
        }

        /// <summary>
        /// SQL statement to fill the datagrid with all invoices with selected invoice date and invoice total
        /// </summary>
        /// <returns>sql statement</returns>
        public static string filterByInvoiceDateTotal(string invoiceDate, string invoiceTotal) 
        {
            try
            {
                string sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = " + invoiceTotal + " AND InvoiceDate = #" + invoiceDate + "#";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


        /// <summary>
        /// SQL statement to filter the InvoiceDate combobox by the InvoiceNum selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceDateWithNumFiltered(string invoiceNum)
        {
            try
            {
                string sql = "SELECT DISTINCT InvoiceDate FROM Invoices WHERE InvoiceNum = " + invoiceNum;
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }
        
        /// <summary>
        /// SQL statement to filter the totalCost combobox by the InvoiceNum selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceTotalWithNumFiltered(string invoiceNum)
        {
            try
            {
                string sql = "SELECT DISTINCT TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum;

                return sql;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// SQL statement to filter the InvoiceNum combobox by the invoiceDate selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceNumsWithDateFiltered(string invoiceDate)
        {
            try
            {
                string sql = "SELECT InvoiceNum FROM Invoices WHERE InvoiceDate = # " + invoiceDate + "#";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement to filter the InvoiceDate combobox by the invoiceTotal selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceNumsWithTotalFiltered(string invoiceTotal)
        {
            try
            {
                string sql = "SELECT InvoiceNum FROM Invoices WHERE TotalCost = " + invoiceTotal;

                return sql;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement to filter the InvoiceNum combobox by the invoiceDate and invoiceTotal selected from comboboxs
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceNumsWithDateTotalFiltered(string invoiceDate, string invoiceTotal)
        { 
            try
            {
                string sql = "SELECT InvoiceNum FROM Invoices WHERE InvoiceDate = #" + invoiceDate + "# AND TotalCost = " + invoiceTotal;

                return sql;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// SQL String that gets the invoice object for that invoice number.
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public string getInvoice(string invoiceNumber)
        {
            try
            {
                string sql = "SELECT * FROM Invoices WHERE InvoiceNum = " + invoiceNumber;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement to filter the InvoiceDate combobox by the InvoiceTotal selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceDateWithTotalFiltered(string invoiceTotal)
        {
            try
            {
                string sql = "SELECT DISTINCT InvoiceDate FROM Invoices WHERE TotalCost = " + invoiceTotal;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// SQL statement to filter the InvoiceTotal combobox by the InvoiceDate selected from combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public static string getInvoiceTotalWithDateFiltered(string invoiceDate)
        {
            try
            {
                string sql = "SELECT DISTINCT TotalCost FROM Invoices WHERE InvoiceDate = #" + invoiceDate + "#";

                return sql;
            }

            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


    }
}
