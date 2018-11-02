using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class LineItem
    {
        /// <summary>
        /// Invoice number property
        /// </summary>
        public string InvoiceNum { get; set; }

        /// <summary>
        /// Item code property
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Line item number property.
        /// </summary>
        public string LineItemNum { get; set; }

        /// <summary>
        /// Cost number property.
        /// </summary>
        public decimal Cost { get; set; }

        //TODO: REMOVE THIS IF NOT NEEDED LATER ON.
        ///// <summary>
        ///// 
        ///// </summary>
        //public override string ToString()
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        //    }
        //}
    }
}
