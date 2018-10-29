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
        #endregion
    }
}

