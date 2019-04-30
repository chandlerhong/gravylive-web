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
    [RoutePrefix("orders")]
    public class OrdersController : Controller
    {
        public ActionResult Lookup()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult GetOrders(GravyLiveWebApp.WebApp.Models.OrdersLookupModel formdata)
        {
                return RedirectToAction("OrderFulfillmentDetails", new { d = formdata.Show_Date });

        }

        public ActionResult OrderFulfillmentDetails(DateTime d)
        {
            OrderFulfillmentDetailsDAO detailsDAO = new OrderFulfillmentDetailsDAO();
            IList<OrderFulfillmentDetailsLineItemsModel> orderList = detailsDAO.getOrderList(d);

            OrderFulfillmentDetailsDAO showspecificsDAO = new OrderFulfillmentDetailsDAO();
            OrderFulfillmentDetailsDTO showdata = showspecificsDAO.getShowDetails(d);
            
            OrderFulfillmentDetailsModel showdetails = new OrderFulfillmentDetailsModel()
            {
                Orders = orderList, // IList of products
                Show_Date = showdata.Show_Date,
                Product_ID = showdata.Product_ID,
                Description = showdata.Description,
                VendorName = showdata.VendorName
            };
            
            return View(showdetails);
        }
    }
}