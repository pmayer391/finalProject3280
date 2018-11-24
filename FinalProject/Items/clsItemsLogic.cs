using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// Checks to see if the entered values are valid if they are returns true
        /// If they are not returns false.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool isValidInput(string code, string cost, string description)
        {
            // TODO
            return true;
        }

        /// <summary>
        /// Returns all items in the items table
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllItems()
        {
            return null;
        }

    }
}
