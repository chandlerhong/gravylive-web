using GravyLiveWebApp.Data;
using GravyLiveWebApp.DTO;
using GravyLiveWebApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GravyLiveWebApp.Controllers
{
    public class ShowController : Controller
    {
        public ActionResult NewShow()
        {

            ProductDAO productDAO = new ProductDAO();
            IList<ProductViewModel> productList = productDAO.GetAllProducts();

            NewShowModel model = new NewShowModel()
            {
                Products = productList // IList of products
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateShow(GravyLiveWebApp.WebApp.Models.NewShowModel formdata)
        {
            ShowDTO dto = new ShowDTO();

            dto.Show_Date = formdata.Show_Date;
            dto.Product_ID = formdata.Product_ID;
            dto.Product_Units = formdata.Product_Units;
            dto.Start_Price = formdata.Start_Price;
            dto.Total_COGS = formdata.Unit_Cost * formdata.Product_Units;
            dto.Unit_Cost = formdata.Unit_Cost;

            ShowDAO dao = new ShowDAO();
            bool success = dao.CreateShow(dto);

            return RedirectToAction("AfterAddShow", new { r = success, s = formdata.Show_Date });

        }


        public ActionResult AfterAddShow(bool r, DateTime s )
        {

            if (r)
            {
                ShowDAO show_viewer = new ShowDAO();
                ShowViewModel show = show_viewer.getShowDetails(s);
                return View(show);
            }
            else
            {
                ShowDAO show_viewer = new ShowDAO();
                ShowViewModel show = show_viewer.getShowDetails(DateTime.MinValue);
                return View(show);
            }
            
        }
    }
}