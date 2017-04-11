using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shufflepuff_ConsoleApp.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;

namespace Shufflepuff_ConsoleApp.Repository
    {
        public class ProductRepo : IProductRepo
        {
            SqlConnection _shufflepuffConnection;

        public ProductRepo()
        {
            _shufflepuffConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShufflepuffBang"].ConnectionString);
        }
        public void GetProducts(int ProductId, string Name, int Price)
        {
                _shufflepuffConnection.Open();

                try
                {
                    var getProductsCommand = _shufflepuffConnection.CreateCommand();
                getProductsCommand.CommandText = "Insert into Product(Name,Price) values(@Name,@Price)";

                    var nameParameter = new SqlParameter("name", SqlDbType.VarChar);
                    nameParameter.Value = Name;
                    getProductsCommand.Parameters.Add(nameParameter);

                    var priceParameter = new SqlParameter("price", SqlDbType.VarChar);
                    priceParameter.Value = Price;
                    getProductsCommand.Parameters.Add(priceParameter);

                    getProductsCommand.ExecuteNonQuery();
                }

                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                }

                finally
                {
                    _shufflepuffConnection.Close();
                }
            }

            public Product GetProduct(int ProductId)
            {
                _shufflepuffConnection.Open();

                try
                {
                    var getProductCommand = _shufflepuffConnection.CreateCommand();
                    getProductCommand.CommandText = @"
                    SELECT * 
                    FROM Product 
                    WHERE ProductId = @ProductId";
                    var productIdParam = new SqlParameter("ProductId", SqlDbType.Int);
                    productIdParam.Value = ProductId;
                    getProductCommand.Parameters.Add(productIdParam);

                    var reader = getProductCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        var Product = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                        };
                        return Product;
                    }
                }

                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                }

                finally
                {
                    _shufflepuffConnection.Close();
                }

                return null;
            }

        //test for CLI
        public List<Product> GetProducts()
        {
            _shufflepuffConnection.Open();

            try
            {
                var getProductCommand = _shufflepuffConnection.CreateCommand();
                getProductCommand.CommandText = @"
                    SELECT *    
                    FROM Product 
                ";

                var reader = getProductCommand.ExecuteReader();
                var products = new List<Product>();

                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                    };
                    products.Add(product);
                }
                return products;
            }

            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            finally
            {
                _shufflepuffConnection.Close();
            }

            return new List<Product>();
        }
    }
}
