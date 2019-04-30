using System;
using System.Collections.Generic;

namespace GravyLiveWebApp.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new shows
    /// </summary>
    public class ShowViewModel
    {
        // form input values - populated in the view
        public DateTime Show_Date { get; set; }
        public int Product_ID { get; set; }
        public int Product_Units { get; set; }
        public int Start_Price { get; set; }
        public int Total_COGS { get; set; }
        public int Unit_Cost { get; set; }

    }
}