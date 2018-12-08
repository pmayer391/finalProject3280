using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Main
{
    class clsMainLogic
    {
        /// <summary>
        /// Access the clsDataAccess class to execute queries to the database.
        /// </summary>
        clsDataAccess dbManager = new clsDataAccess();

        /// <summary>
        /// Accesses the SQL statements. 
        /// </summary>
        clsMainSQL sqlStatements = new clsMainSQL();

        /// <summary>
        /// Creates a new invoice in the database and returns that invoice to the caller.
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <param name="currentInvoiceItems"></param>
        /// <returns></returns>
        public Invoice createNewInvoice(Invoice currentInvoice, List<LineItem> currentInvoiceItems)
        {
            try
            {
                int numRowsAffected = dbManager.ExecuteNonQuery(sqlStatements.CreateNewInvoice(currentInvoice.invoiceDate, currentInvoice.totalCost));
                Console.WriteLine("Number of Invoices Created: " + numRowsAffected);

                DataSet ds;
                int numberOfRowsReturned = 0;
                ds = dbManager.ExecuteSQLStatement(sqlStatements.GetNewestInvoice(), ref numberOfRowsReturned);
                Invoice invoiceCreated = new Invoice();
                for (int i = 0; i < numberOfRowsReturned; i++)
                {
                    invoiceCreated.invoiceNum = ds.Tables[0].Rows[i][0].ToString();
                }

                Console.WriteLine(invoiceCreated);


                foreach (LineItem item in currentInvoiceItems)
                {
                    int numberOfRowsAffected =
                        dbManager.ExecuteNonQuery(sqlStatements.CreateNewLineItem(
                                invoiceCreated.invoiceNum,
                                item.itemCode,
                                item.lineItemNum,
                                item.cost.ToString(),
                                item.itemDesc));

                    Console.WriteLine("Number of items added to invoice: " + numberOfRowsAffected);
                }

                return invoiceCreated;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns all the line items for a particular invoice.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public List<LineItem> getAllLineItems(string invoiceNum)
        {
            try
            {
                List<LineItem> invoiceLineItems = new List<LineItem>();

                DataSet ds;
                int numberOfRowsReturned = 0;
                ds = dbManager.ExecuteSQLStatement(sqlStatements.GetInvoiceLineItems(invoiceNum), ref numberOfRowsReturned);
                LineItem lineItem;
                for (int i = 0; i < numberOfRowsReturned; i++)
                {
                    lineItem = new LineItem();
                    lineItem.invoiceNum = ds.Tables[0].Rows[i][0].ToString();
                    lineItem.lineItemNum = ds.Tables[0].Rows[i][1].ToString();
                    lineItem.itemCode = ds.Tables[0].Rows[i][2].ToString();
                    string itemCostAsString = ds.Tables[0].Rows[i][3].ToString();
                    lineItem.cost = convertStringToDecimal(itemCostAsString);
                    lineItem.itemDesc = ds.Tables[0].Rows[i][4].ToString();

                    invoiceLineItems.Add(lineItem);
                }

                return invoiceLineItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Updates a particular invoice. 
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <param name="currentInvoiceItems"></param>
        public void updateInvoice(Invoice currentInvoice, List<LineItem> currentInvoiceItems)
        {
            try
            {
                //Delete all lineItems for that invoice in case the price was updated.
                foreach (LineItem item in currentInvoiceItems)
                {
                    int rowsDeleted = dbManager.ExecuteNonQuery(sqlStatements.DeleteLineItem(currentInvoice.invoiceNum, item.itemCode, item.lineItemNum));
                    Console.WriteLine("Rows Deleted: " + rowsDeleted);
                }

                //Reinsert all line items for that invoice with the correct price if that was changed.
                foreach (LineItem item in currentInvoiceItems)
                {
                    int numberOfRowsAffected =
                        dbManager.ExecuteNonQuery(sqlStatements.CreateNewLineItem(
                                currentInvoice.invoiceNum,
                                item.itemCode,
                                item.lineItemNum,
                                item.cost.ToString(),
                                item.itemDesc));

                    Console.WriteLine("Number of items added to invoice: " + numberOfRowsAffected);
                }

                //Update Invoice
                int rowsUpdated = dbManager.ExecuteNonQuery(sqlStatements.UpdateInvoice(currentInvoice));
                Console.WriteLine("Rows Updated: " + rowsUpdated);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all the items that our business sells.
        /// </summary>
        /// <returns></returns>
        public List<ItemDesc> getItems()
        {
            try
            {
                List<ItemDesc> items = new List<ItemDesc>();

                DataSet ds;
                int numberOfRowsReturned = 0;
                ds = dbManager.ExecuteSQLStatement(sqlStatements.GetItems(), ref numberOfRowsReturned);
                ItemDesc item;
                for (int i = 0; i < numberOfRowsReturned; i++)
                {
                    item = new ItemDesc();
                    item.itemCode = ds.Tables[0].Rows[i][0].ToString();
                    item.itemDescription = ds.Tables[0].Rows[i][1].ToString();
                    string itemCost = ds.Tables[0].Rows[i][2].ToString();
                    item.cost = convertStringToDecimal(itemCost);

                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes all the line items for a particular invoice.
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <param name="item"></param>
        public void deleteLineItem(Invoice currentInvoice, LineItem item)
        {
            try
            {
                int rowsDeleted = dbManager.ExecuteNonQuery(sqlStatements.DeleteLineItem(currentInvoice.invoiceNum, item.itemCode, item.lineItemNum));
                Console.WriteLine("Rows Deleted: " + rowsDeleted);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes an invoice with its accompany line items from the db.
        /// </summary>
        /// <param name="currentInvoice"></param>
        /// <param name="currentInvoiceItems"></param>
        public void deleteInvoice(Invoice currentInvoice, List<LineItem> currentInvoiceItems)
        {
            try
            {
                //Delete all lineItems for that invoice
                foreach (LineItem item in currentInvoiceItems)
                {
                    int rowsDeleted = dbManager.ExecuteNonQuery(sqlStatements.DeleteLineItem(currentInvoice.invoiceNum, item.itemCode, item.lineItemNum));
                    Console.WriteLine("Line Items Deleted: " + rowsDeleted);
                }

                //Delete the invoice
                int invoicesDeleted = dbManager.ExecuteNonQuery(sqlStatements.DeleteInvoice(currentInvoice));
                Console.WriteLine("Invoices Deleted:  " + invoicesDeleted);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Converts a string to a decimal(money values). 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public decimal convertStringToDecimal(string input)
        {
            try
            {
                return decimal.Parse(Regex.Replace(input, @"[^\d.]", ""));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
