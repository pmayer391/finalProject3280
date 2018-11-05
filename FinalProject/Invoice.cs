using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Invoice
    {
        /// <summary>
        /// Invoice number property
        /// </summary>
        public string invoiceNum { get; set; }

        /// <summary>
        /// Invoice date property
        /// </summary>
        public string invoiceDate { get; set; }

        /// <summary>
        /// Total type property
        /// </summary>
        public string totalCost { get; set; }

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
