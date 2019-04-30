using System.Collections.Generic;

namespace GravyLiveWebApp.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new orders
    /// </summary>
    public class ProductViewModel
    {
        // form input values - populated in the view
        public int Product_ID { get; set; }
        public string Description { get; set; }
        public string VendorName { get; set; }

    }
}