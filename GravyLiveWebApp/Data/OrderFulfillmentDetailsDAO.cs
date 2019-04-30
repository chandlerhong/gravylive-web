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
    public class OrderFulfillmentDetailsDAO
    {
        public OrderFulfillmentDetailsDTO getShowDetails(DateTime date)
        {
            DateTime Show_Date = date.Date;
            OrderFulfillmentDetailsDTO showdetails = new OrderFulfillmentDetailsDTO();
            
            // needs to get the following: Show Date, Product ID, Product Desc, Vendor
            // Given a Show Date
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT [Product].[Product_ID] AS Product_ID
                                  ,[Product].[Description] AS Description
                                  ,[Product].[VendorName] AS VendorName
                                  ,[Show].[Show_Date] AS Show_Date
                              FROM [Product], [Show]
                                WHERE [Show].[Product_ID]=[Product].[Product_ID] AND Show_Date=@Show_Date;";
                showdetails = connection.QueryFirstOrDefault<OrderFulfillmentDetailsDTO>(sql, new { Show_Date });
            }

            return showdetails;
        }

        public IList<OrderFulfillmentDetailsLineItemsModel> getOrderList(DateTime date)
        {

            DateTime Show_Date = date.Date;
            IList<OrderFulfillmentDetailsLineItemsModel> showdetails;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();  

                string sql = @"SELECT [Order].[Order#] AS OrderNum
                                  ,[User].[Full_Name] AS Full_Name
                                  ,[Order].[Price] AS Price
                                  ,[User].[Shipping_Address] AS Shipping_Address
                              FROM [Order], [User] WHERE [Order].[UserID]=[User].[UserID] AND Date=@Show_Date;";
                showdetails = connection.Query<OrderFulfillmentDetailsLineItemsModel>(sql, new { Show_Date }).ToList();
            }

            return showdetails;
        }
    }
}