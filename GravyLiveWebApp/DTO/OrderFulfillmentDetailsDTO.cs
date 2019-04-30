using GravyLiveWebApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.DTO
{
    /// <summary>
    /// DTO used for persisting Shows
    /// </summary>
    public class OrderFulfillmentDetailsDTO
    {
        public DateTime Show_Date { get; set; }
        public int Product_ID { get; set; }
        public string Description { get; set; }
        public string VendorName { get; set; }
        
        public IList<OrderFulfillmentDetailsLineItemsModel> Orders { get; set; }

    }
}