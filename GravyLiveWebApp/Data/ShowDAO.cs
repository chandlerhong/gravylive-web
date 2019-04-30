using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using GravyLiveWebApp.DTO;
using GravyLiveWebApp.WebApp.Models;

namespace GravyLiveWebApp.Data
{
    /// <summary>
    /// Data access object for Products
    /// </summary>
    public class ShowDAO
    {

        public bool CreateShow(ShowDTO showDTO)
        {
            bool creationSuccessful = true;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [Show] (Show_Date, Product_ID, Product_Units, Start_Price, Total_COGS, Unit_Cost) 
                                VALUES (@Show_Date, @Product_ID, @Product_Units, @Start_Price, @Total_COGS, @Unit_Cost);";
                connection.ExecuteScalar(sql, showDTO);
            }

            return creationSuccessful;
        }
        

        public ShowViewModel getShowDetails(DateTime Show_Date)
        {
            ShowViewModel show;
            if (Show_Date == DateTime.MinValue)
            {
                show = null;
            }
            else
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
                {
                    connection.Open();

                    string sql = @"SELECT [Show_Date] AS Show_Date
                                  ,[Product_ID] AS Product_ID
                                  ,[Product_Units] AS Product_Units
                                  ,[Start_Price] AS Start_Price
                                  ,[Total_COGS] AS Total_COGS
                                  ,[Unit_Cost] AS Unit_Cost
                              FROM [Show] WHERE Show_Date=@Show_Date;";
                    show = connection.QueryFirstOrDefault<ShowViewModel>(sql, new { Show_Date = Show_Date });
                }
            }
            return show;
        }
        /*
        public IList<ProductViewModel> GetAllProducts()
        {
            IList<ProductViewModel> products;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT [Product_ID] AS Product_ID
                                  ,[Description] AS Description
                                  ,[VendorName] AS VendorName
                              FROM [Product];";
                products = connection.Query<ProductViewModel>(sql).ToList();
            }

            return products;
        }*/
    }
}