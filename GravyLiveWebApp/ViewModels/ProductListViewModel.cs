using System.Collections.Generic;

namespace GravyLiveWebApp.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new orders
    /// </summary>
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            productlist = new List<ProductViewModel>();
        }

        public IList<ProductViewModel> productlist { get; set; }
    }
}