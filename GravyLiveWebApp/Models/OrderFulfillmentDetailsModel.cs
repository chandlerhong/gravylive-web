using GravyLiveWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.WebApp.Models
{
    public class OrderFulfillmentDetailsModel
    {
        public DateTime Show_Date { get; set; }
        public int Product_ID { get; set; }
        public string Description { get; set; } // product description
        public string VendorName { get; set; }
        public IList<OrderFulfillmentDetailsLineItemsModel> Orders { get; set; }
    }
}