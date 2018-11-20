using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        #region sqlSearch Public Methods

        /// <summary>
        /// SQL statement to initally load the datagrid with invoice number
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceNum()
        {
            sql = "SELECT InvoiceNum FROM Invoice";

            return sql;
        }

        /// <summary>
        /// SQL statement to initally load the datagrid with invoice date
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceDate()
        {
            sql = "SELECT InvoiceDate FROM Invoice";

            return sql;
        }

        /// <summary>
        /// SQL statement to initally load the datagrid with total cost
        /// </summary>
        /// <returns>sql statement</returns>
        public string getInvoiceTotalCost()
        {
            sql = "SELECT TotalCost FROM Invoices";

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the invoiceNum and invoiceDate by invoiceNum combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public string filterByInvoiceNum(int invoiceNum)
        {
            sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoice WHERE invoiceNum = " + invoiceNum;

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the invoiceNum invoiceDate and TotalCost by invoiceDate combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public string filterByInvoiceDate(int invoiceDate)
        {
            sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoice WHERE invoiceDate = " + invoiceDate;

            return sql;
        }

        /// <summary>
        /// SQL statement to filter the totalCost invoiceDate and TotalCost by TotalCost combobox
        /// </summary>
        /// <returns>sql statement</returns>
        public string filterByInvoiceTotalCost(int totalCost)
        {
            sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = " + totalCost;

            return sql;
        }
        #endregion

    }
}
