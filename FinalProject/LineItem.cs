using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class LineItem
    {
        /// <summary>
        /// Invoice number property
        /// </summary>
        public string invoiceNum { get; set; }

        /// <summary>
        /// Item code property
        /// </summary>
        public string itemCode { get; set; }

        /// <summary>
        /// Line item number property.
        /// </summary>
        public string lineItemNum { get; set; }

        /// <summary>
        /// Cost number property.
        /// </summary>
        public decimal cost { get; set; }

        /// <summary>
        /// Item name or description.
        /// </summary>
        public string itemDesc { get; set; }

        //TODO: REMOVE THIS IF NOT NEEDED LATER ON.
        /// <summary>
        /// Formatted string for this class.
        /// </summary>
        public override string ToString()
        {
            try
            {
                return "" + itemDesc + "   $" + cost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
