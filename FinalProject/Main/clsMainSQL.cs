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
        /// SQL string that creates a new line item.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="itemCode"></param>
        /// <param name="lineItemNum"></param>
        /// <param name="cost"></param>
        /// <param name="itemDesc"></param>
        /// <returns></returns>
        public string CreateNewLineItem(string invoiceNum, string itemCode, string lineItemNum, string cost, string itemDesc)
        {
            sql = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode, Cost, ItemDesc) Values ("+invoiceNum+", "+ lineItemNum + ", '"+itemCode+"', " +cost+ ", '"+itemDesc+"')";
            return sql;
        }

        /// <summary>
        /// SQL string that gets the most recently created invoice.
        /// </summary>
        /// <returns></returns>
        public string GetRecentlyCreatedInvoice()
        {
            sql = "SELECT MAX(InvoiceNum) FROM Invoices";
            return sql;
        }

        /// <summary>
        /// SQL string that gets all the invoice's line items.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string GetInvoiceLineItems(string invoiceNum)
        {
            sql = "SELECT * FROM LineItems WHERE invoiceNum = " + invoiceNum;
            return sql;
        }

        /// <summary>
        /// SQL string that updates an invoice.
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <returns></returns>
        public string UpdateInvoice(Invoice currentInvoice)
        {
            sql = "UPDATE Invoices SET InvoiceDate = " + currentInvoice.invoiceDate + ", TotalCost = " + currentInvoice.totalCost + "  WHERE invoiceNum = " + currentInvoice.invoiceNum;

            return sql;
        }

        /// <summary>
        /// SQL string that deletes a line item.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="itemCode"></param>
        /// <param name="lineItemNum"></param>
        /// <returns></returns>
        public string DeleteLineItem(string invoiceNum, string itemCode, string lineItemNum)
        {
            sql = "Delete FROM LineItems WHERE InvoiceNum = " + invoiceNum + " AND ItemCode = '" + itemCode + "' AND LineItemNum = " + lineItemNum;

            return sql;
        }

        /// <summary>
        /// SQL string that deletes an invoice.
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <returns></returns>
        public string DeleteInvoice(Invoice currentInvoice)
        {
            sql = "Delete FROM Invoices  WHERE invoiceNum = " + currentInvoice.invoiceNum;

            return sql;
        }
        #endregion
    }
}

