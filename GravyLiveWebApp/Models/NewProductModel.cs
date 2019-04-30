using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace GravyLiveWebApp.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new orders
    /// </summary>
    public class NewProductModel
    {
        // form input values - populated in the view
        // public int Product_ID { get; set; }
        public string Description { get; set; }
        public string VendorName { get; set; }

        // don't need data to populate the form view fields in this case (eg: dropdowns) but we will in another one
    }
}