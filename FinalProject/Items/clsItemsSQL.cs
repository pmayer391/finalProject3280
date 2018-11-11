using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Items
{
    public class clsItemsSQL
    {

        public static string ItemInsertDescSQL(string ItemCode, string ItemDesc, double Cost)
        {
            return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" 
                + ItemCode +"', '" + ItemDesc + "', '" + Cost + "')";
        }

        public static string ItemUpdateDescSQL(string ItemCode, string ItemDesc, double Cost)
        {
            return "UPDATE ItemDesc SET ItemCode='" 
                + ItemCode + "', ItemDesc = ' " + ItemDesc + " ', Cost = '" + Cost  
                + "' WHERE ItemCode='" + ItemCode + "'";        
        }

        public static string ItemDeleteDescSQL(string ItemCode)
        {
            return "DELETE FROM ItemDesc WHERE ItemCode = '" +  ItemCode +"'";
        }

        public static string ItemSelectDescSQL(string ItemCode)
        {
            return "SELECT * FROM ItemDesc WHERE ItemCode = '" +  ItemCode +"'";
        }

        public static string ItemsSelectDescSQL()
        {
            return "SELECT * FROM ItemDesc";
        }


    }
}
