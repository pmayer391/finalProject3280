using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Globalization;

namespace FinalProject.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// Gives access to searchSQL
        /// </summary>
        clsSearchSQL searchSQL = new clsSearchSQL();

        /// <summary>
        /// String to hold SQL statements returned from searchSQL
        /// </summary>
        string sSQL;

        /// <summary>
        /// Int that holds the values returned from SQL statement
        /// </summary>
        int iRet = 0;

        /// <summary>
        /// Gives access to clsDataAccess
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Instance of ds to store SQL vales in
        /// </summary>
        DataSet ds = new DataSet();

        /// <summary>
        /// invoiceNums as list
        /// </summary>
        List<string> invoiceNums = new List<string>();

        /// <summary>
        /// invoiceDates as list
        /// </summary>
        List<string> invoiceDates = new List<string>();

        /// <summary>
        /// invoiceTotals as list
        /// </summary>
        List<string> invoiceTotals = new List<string>();

        /// <summary>
        /// This is the inital load of the datagrid of all invoices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DataSet loadDataGrid() {

            try
            {
                DataSet ds;
                sSQL = searchSQL.initialLoad();
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }


        /// <summary>
        /// This will get the invoiceNums for the invoice nums combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceNums() {

            try
            {
                DataSet ds;
                iRet = 0;

                sSQL = searchSQL.getInvoiceNum();
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    invoiceNums.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return invoiceNums;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }

        /// <summary>
        /// This will get the invoicesDates for the invoice dates combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceDates() {

            try
            {
                DataSet ds;
                iRet = 0;

                sSQL = searchSQL.getInvoiceDate();
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    invoiceDates.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return invoiceDates;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// This will get the invoiceTotals for the invoice totals combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceTotals() {

            try
            {
                DataSet ds;
                iRet = 0;

                sSQL = searchSQL.getInvoiceTotalCost();
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    invoiceTotals.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return invoiceTotals;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }

        /// <summary>
        /// Gets the Invoice with the given invoice number;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Invoice getInvoice(string invoiceNum)
        {

            try
            {
                DataSet ds;
                iRet = 0;
                Invoice invoiceSelected = new Invoice();

                sSQL = searchSQL.getInvoice(invoiceNum);
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    invoiceSelected.invoiceNum= ds.Tables[0].Rows[i][0].ToString();
                    invoiceSelected.invoiceDate = ds.Tables[0].Rows[i][1].ToString();
                    invoiceSelected.invoiceDate = DateTime.Parse(invoiceSelected.invoiceDate).ToShortDateString().ToString();
                }

                return invoiceSelected;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }

        /// <summary>
        /// This will get the invoice dates for the invoice num selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceDateWithNumFiltered(string invoiceNum)
        {
             try
            {
                string sSQL = clsSearchSQL.getInvoiceDateWithNumFiltered(invoiceNum);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();
                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }

        /// <summary>
        /// This will get the invoice total for the invoice num selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceTotalWithNumFiltered(string invoiceNum)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceTotalWithNumFiltered(invoiceNum);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// This will get the invoice nums for the invoice date selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceNumsWithDateFiltered(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceNumsWithDateFiltered(invoiceDate);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// This will get the invoice nums for the invoice total selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceNumsWithTotalFiltered(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceNumsWithTotalFiltered(invoiceTotal);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// This will get the invoice nums for the invoice date and total selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceNumsWithDateTotalFiltered(string invoiceDate, string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceNumsWithDateTotalFiltered(invoiceDate, invoiceTotal);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This will get the invoice dates for the invoice total selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceDateWithTotalFiltered(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceDateWithTotalFiltered(invoiceTotal);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// This will get the invoice total for the invoice date selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<string> getInvoiceTotalWithDateFiltered(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.getInvoiceTotalWithDateFiltered(invoiceDate);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                List<string> temp = new List<string>();

                for (int i = 0; i < tempDS.Tables[0].Rows.Count; i++)
                {
                    temp.Add(tempDS.Tables[0].Rows[i][0].ToString());
                }

                return temp;
            }

            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


        /// <summary>
        /// This will get all invoices for the invoice num selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DataSet filterByInvoiceNum(string invoiceNum)
        {
            try
            {
                string sSQL = clsSearchSQL.filterByInvoiceNum(invoiceNum);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);

                return tempDS;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


        /// <summary>
        /// This will get all invoices for the invoice date selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DataSet filterByInvoiceDate(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.filterByInvoiceDate(invoiceDate);
                int tempRows = 0;
                DataSet tempDataSet = db.ExecuteSQLStatement(sSQL, ref tempRows);
                return tempDataSet;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This will get all invoices for the invoice cost selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DataSet filterByInvoiceTotalCost(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.filterByInvoiceTotalCost(invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = db.ExecuteSQLStatement(sSQL, ref tempRows);
                return tempDataSet;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


        /// <summary>
        /// This will get all invoices for the invoice date and total selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DataSet filterByInvoiceDateTotal(string invoiceDate, string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.filterByInvoiceDateTotal(invoiceDate, invoiceTotal);
                int iRet = 0;
                DataSet tempDS = db.ExecuteSQLStatement(sSQL, ref iRet);
                return tempDS;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);

            }
        }


    }


}
