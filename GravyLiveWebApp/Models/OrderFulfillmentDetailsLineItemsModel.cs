using GravyLiveWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.WebApp.Models
{
    public class OrderFulfillmentDetailsLineItemsModel
    {
        public int OrderNum { get; set; }
        public string Full_Name { get; set; }
        public decimal Price { get; set; }
        public string Shipping_Address { get; set; }
    }
}