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

        public string CreateNewLineItem(string invoiceNum, string itemCode, string lineItemNum, string cost, string itemDesc)
        {
            sql = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode, Cost, ItemDesc) Values ("+invoiceNum+", "+ lineItemNum + ", '"+itemCode+"', " +cost+ ", '"+itemDesc+"')";
            return sql;
        }

        public string GetRecentlyCreatedInvoice()
        {
            sql = "SELECT MAX(InvoiceNum) FROM Invoices";
            return sql;
        }

        public string GetInvoiceLineItems(string invoiceNum)
        {
            sql = "SELECT * FROM LineItems WHERE invoiceNum = " + invoiceNum;
            return sql;
        }

        public string UpdateInvoice(Invoice currentInvoice)
        {
            sql = "UPDATE Invoices SET InvoiceDate = " + currentInvoice.invoiceDate + ", TotalCost = " + currentInvoice.totalCost + "  WHERE invoiceNum = " + currentInvoice.invoiceNum;

            return sql;
        }

        public string DeleteLineItem(string invoiceNum, string itemCode, string lineItemNum)
        {
            sql = "Delete FROM LineItems WHERE InvoiceNum = " + invoiceNum + " AND ItemCode = '" + itemCode + "' AND LineItemNum = " + lineItemNum;

            return sql;
        }

        public string DeleteInvoice(Invoice currentInvoice)
        {
            sql = "Delete FROM Invoices  WHERE invoiceNum = " + currentInvoice.invoiceNum;

            return sql;
        }


        ////Deleting the link
        //string sSQLDeleteLink = "Delete FROM FLIGHT_PASSENGER_LINK WHERE FLIGHT_ID = " + flightId + " AND PASSENGER_ID = " + passengerId;
        ////Delete the passenger
        //string sSQLDeletePassenger = "Delete FROM PASSENGER WHERE PASSENGER_ID = " + passengerId;
        #endregion
    }
}

