using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.ViewModels
{
    public class CustomerOrderDetailsViewModel
    {
        public int OrderNum { get; set; }
        public string Price { get; set; }
        public string Full_Name { get; set; }
        public string Shipping_Address { get; set;}
        // Order number, Customer name, Customer address, Customer City/St/Zip, Price paid

    }
}