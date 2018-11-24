using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Items
{
    public class clsItemsSQL
    {

        /// <summary>
        /// Inserts a new Item into the database
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="ItemDesc"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public static string ItemInsertDescSQL(string ItemCode, string ItemDesc, double Cost)
        {
             return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" 
                + ItemCode +"', '" + ItemDesc + "', '" + Cost + "')";
        }

        /// <summary>
        /// Updates an existing item in the ItemDesc table
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="ItemDesc"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public static string ItemUpdateDescSQL(string ItemCode, string ItemDesc, double Cost)
        {
            return "UPDATE ItemDesc SET ItemCode='" 
                + ItemCode + "', ItemDesc = ' " + ItemDesc + " ', Cost = '" + Cost  
                + "' WHERE ItemCode='" + ItemCode + "'";        
        }

        /// <summary>
        /// Deletes an item from the ItemDesc table
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static string ItemDeleteDescSQL(string ItemCode)
        {
            return "DELETE FROM ItemDesc WHERE ItemCode = '" +  ItemCode +"'";
        }

        /// <summary>
        /// Selects one item from the ITemDesc table
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static string ItemSelectDescSQL(string ItemCode)
        {
            return "SELECT * FROM ItemDesc WHERE ItemCode = '" +  ItemCode +"'";
        }

        /// <summary>
        /// Selects all items in the ItemDesc table.
        /// </summary>
        /// <returns></returns>
        public static string ItemsSelectDescSQL()
        {
            return "SELECT * FROM ItemDesc";
        }


    }
}
