using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Main
{
    /// <summary>
    /// Class that Contains all the SQL statements needed throughout the forms
    /// </summary>
    class clsMainSQL
    {
        #region SQLStatments Properties
        /// <summary>
        /// string that will hold all the various SQL statements
        /// </summary>
        private string sql;
        #endregion

        #region SQLStatment Public Methods

        /// <summary>
        /// SQL string that creates a new invoice.
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public string CreateNewInvoice(string invoiceDate, string totalCost )
        {
            sql = "INSERT INTO Invoices (InvoiceDate, TotalCost) Values (#"+invoiceDate+"#, "+totalCost+")";
            return sql;
        }

        /// <summary>
        /// SQL string that queries back the most recently created invoice because InvoiceNum is auto generated.
        /// </summary>
        /// <returns></returns>
        public string GetNewestInvoice()
        {
            sql = "SELECT MAX(InvoiceNum) FROM Invoices";
            return sql;
        }

        /// <summary>
        /// SQL string that queries back all the items in the ItemDesc table.
        /// </summary>
        /// <returns></returns>
        public string GetItems()
        {
            sql = "SELECT * FROM ItemDesc";
            return sql;
        }

        /// <summary>
        /// SQL string that creates a new Line Item Object in the LineItems Table.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="itemCode"></param>
        /// <param name="lineItemNum"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string CreateNewLineItem(string invoiceNum, string itemCode, string lineItemNum, string cost)
        {
            sql = "INSERT INTO LineItems (InvoiceNum, ItemCode, LineItemNum, Cost)" +
                " Values (" + invoiceNum + ", " + itemCode + ", " + lineItemNum + ", " + cost + ")";
            return sql;
        }
        #endregion
    }
}

