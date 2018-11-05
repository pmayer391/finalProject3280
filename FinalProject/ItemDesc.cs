using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
     public class ItemDesc
    {
        /// <summary>
        /// Item code property
        /// </summary>
        public string itemCode { get; set; }

        /// <summary>
        /// Item description property
        /// </summary>
        public string itemDescription { get; set; }

        /// <summary>
        /// Cost property
        /// </summary>
        public decimal cost { get; set; }

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
