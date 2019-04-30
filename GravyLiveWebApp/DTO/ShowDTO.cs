using GravyLiveWebApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravyLiveWebApp.DTO
{
    /// <summary>
    /// DTO used for persisting Shows
    /// </summary>
    public class ShowDTO
    {
        public DateTime Show_Date { get; set; }
        public int Product_ID { get; set; }
        public int Product_Units { get; set; }
        public int Start_Price { get; set; }
        public int Total_COGS { get; set; }
        public int Unit_Cost { get; set; }

        // not sure if this belongs here
        public IList<ProductViewModel> Products { get; set; }

    }
}