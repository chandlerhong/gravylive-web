using GravyLiveWebApp.Data;
using GravyLiveWebApp.DTO;
using GravyLiveWebApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GravyLiveWebApp.WebApp.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult NewProduct()
        {
            return View();
        }
        
        /*
        // view for creating new products
        public ActionResult NewProduct()
        {
            // need to eventually query our business layers to retrieve information to pre-populates parts of the form
            // create bll viewer objects used for populating data
            int StoreID = 1;  // Santa Cruz Store
            StaffViewer staffViewer = new StaffViewer();
            ProductViewer productViewer = new ProductViewer();
            CustomerViewer customerViewer = new CustomerViewer();
            StoreViewer storeViewer = new StoreViewer();

            NewOrderModel model = new NewOrderModel()
            {
                Staff = staffViewer.GetAllEmployesByStore(StoreID),
                Products = productViewer.GetRandom10(),
                Customers = customerViewer.GetRandom10(),
                Store = storeViewer.GetStore(StoreID)


            };

            IList<StaffViewModel> staff = staffViewer.GetAllEmployesByStore(10);

            return View(model);
        }
        */
        /// <summary>
        /// Action for actually creating a new product
        /// </summary>
        /// <remarks>Is executed from the NewProduct view</remarks>
        [HttpPost]
        public ActionResult CreateProduct(GravyLiveWebApp.WebApp.Models.NewProductModel formdata)
        {
            ProductDTO dto = new ProductDTO();

            dto.Description = formdata.Description;
            dto.VendorName = formdata.VendorName;

            ProductDAO dao = new ProductDAO();
            int Product_ID = dao.CreateProduct(dto);

            return RedirectToAction("AfterAddProduct", new { p = Product_ID });

        }

        public ActionResult AfterAddProduct(int p)
        {
            ProductDAO product_viewer = new ProductDAO();
            ProductViewModel product = product_viewer.getProductDetails(p);

            return View(product);
        }
    }
}