using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.DTO
{
    /// <summary>
    /// DTO used for persisting Products
    /// </summary>
    public class ProductDTO
    {

        public int Product_ID { get; set; } = -1;
        public string Description { get; set; }
        public string VendorName { get; set; }
    }
}