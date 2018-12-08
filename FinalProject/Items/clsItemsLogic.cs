using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// Holds the logic to connect to the database and run sql commands.
        /// </summary>
        clsDataAccess data;

        /// <summary>
        /// Constructor that will initialize the clsDataAccess object. 
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                data = new clsDataAccess();
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks to see if the entered values are valid if they are returns true
        /// If they are not returns false.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private bool isValidInput(string code, string cost, string description)
        {
            try
            {
                if (code == null || code.Length == 0)
                {
                    return false;
                }
                if (description == null || description.Length == 0)
                {
                    return false;
                }
                decimal temp;
                if (decimal.TryParse(cost, out temp) == false)
                {
                    return false;
                }
                return true;
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns all items in the items table
        /// </summary>
        /// <returns></returns>
        public List<ItemDesc> GetAllItems()
        {
            try
            {
                int x = 0;
                List<ItemDesc> itemsList = new List<ItemDesc>();
                DataSet newData = data.ExecuteSQLStatement(clsItemsSQL.ItemsSelectDescSQL(), ref x);
                for (int i = 0; i < x; i++)
                {
                    ItemDesc desc = new ItemDesc();
                    desc.itemCode = (string)newData.Tables[0].Rows[i][0];
                    desc.itemDescription = (string)newData.Tables[0].Rows[i][1];
                    desc.cost = (decimal)newData.Tables[0].Rows[i][2];
                    itemsList.Add(desc);
                }
                return itemsList;
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes a item from the itemDesc table if that item is not in use.
        /// If that item is in a invoice. this will show a message box of all invoices it's using.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string DeleteItem(string itemCode)
        {
            try
            {
                if (DoesItemExist(itemCode))
                {
                    int count = 0;
                    DataSet usedInvoices = data.ExecuteSQLStatement(clsItemsSQL.InvoicesBeingUsed(itemCode), ref count);

                    if (count == 0)
                    {
                        data.ExecuteNonQuery(clsItemsSQL.ItemDeleteDescSQL(itemCode));
                        return "Item Deleted";
                    }
                    else
                    {
                        string returnMessage = "Invoice Id: \r";
                        for (int i = 0; i < count; i++)
                        {
                            returnMessage += usedInvoices.Tables[0].Rows[i][0] + "\r";
                        }
                        MessageBox.Show(returnMessage, "Item in use by invoices");
                        return "Item not deleted";
                    }
                }
                return "Error! Item does not exist";
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Updates the itemDesc and cost of an item.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string UpdateItem(string itemCode, string itemDesc, string cost)
        {
            try
            {
                if (isValidInput(itemCode, cost, itemDesc))
                {
                    if (DoesItemExist(itemCode))
                    {
                        data.ExecuteNonQuery(clsItemsSQL.ItemUpdateDescSQL(itemCode, itemDesc, cost));
                        return "Item Updated";
                    }
                    return "Error! item does not exist";
                }
                return "Error! input is not valid";
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks in the item already exists and if it doesn't then adds a new item into the table.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string AddItem(string itemCode, string itemDesc, string cost)
        {
            try
            {
                if (isValidInput(itemCode, cost, itemDesc))
                {
                    if (DoesItemExist(itemCode))
                    {
                        return "Error! Item already exists";
                    }
                    int status = data.ExecuteNonQuery(clsItemsSQL.ItemInsertDescSQL(itemCode, itemDesc, cost));
                    return "Item added to database";
                }
                return "Error! invalid input";
            }
            catch (System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks to see if an item already exists in the ItemDesc table.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        private bool DoesItemExist(string itemCode)
        {
            try
            {
                int count = 0;
                data.ExecuteSQLStatement(clsItemsSQL.ItemSelectDescSQL(itemCode), ref count);
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
            catch ( System.Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
