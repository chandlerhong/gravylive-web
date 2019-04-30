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
    public class ProductDAO
    {

        public int CreateProduct(ProductDTO productDTO)
        {
            int Product_ID = -1;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [Product] (Description, VendorName) 
                                VALUES (@Description, @VendorName);

                                SELECT CONVERT(int, SCOPE_IDENTITY());";
                Product_ID = (int)connection.ExecuteScalar(sql, productDTO);
            }

            return Product_ID;
        }
        

        public ProductViewModel getProductDetails(int Product_ID)
        {
            ProductViewModel product;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gravyliveconnection"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT [Product_ID] AS Product_ID
                                  ,[Description] AS Description
                                  ,[VendorName] AS VendorName
                              FROM [Product] WHERE Product_ID=@Product_ID;";
                product = connection.QueryFirstOrDefault<ProductViewModel>(sql, new { Product_ID = Product_ID });
            }

            return product;
        }

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
        }
    }
}