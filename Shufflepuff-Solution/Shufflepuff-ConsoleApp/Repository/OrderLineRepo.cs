using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using Shufflepuff_ConsoleApp.Models;

namespace Shufflepuff_ConsoleApp.Repository
{
    public class OrderLineRepo : IOrderLineRepo
    {
        SqlConnection _DbConnection;

        public OrderLineRepo()
        {
            _DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShufflepuffBang"].ConnectionString);
        }
        public void AddOrderLine(int Invoice_Id, int Product_Id, int Quantity)
        {
            //open connection
            _DbConnection.Open();

            try
            {
                //run queries
                var addPostCommand = _DbConnection.CreateCommand();
                addPostCommand.CommandText = @"Insert into OrderLine(InvoiceId,ProductId,Quantity) values(@InvoiceId,@ProductId,@Quantity)";
                var InvoiceIdParameter = new SqlParameter("InvoiceId", System.Data.SqlDbType.Int);
                InvoiceIdParameter.Value = Invoice_Id;
                addPostCommand.Parameters.Add(InvoiceIdParameter);
                var ProductIdParameter = new SqlParameter("ProductId", System.Data.SqlDbType.Int);
                ProductIdParameter.Value = Product_Id;
                addPostCommand.Parameters.Add(ProductIdParameter);
                var quantityParameter = new SqlParameter("quantityParameter", System.Data.SqlDbType.Int);
                quantityParameter.Value = Quantity;
                addPostCommand.Parameters.Add(quantityParameter);

                //execute the command
                addPostCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                //close the connection
                _DbConnection.Close();
            }
        }

        public OrderLine GetOrderLine(int OrderLineId)
        {
            _DbConnection.Open();

            try
            {
                var getPostCommand = _DbConnection.CreateCommand();
                getPostCommand.CommandText = @"
                    SELECT InvoiceId, ProductId, Quantity
                    FROM OrderLine
                    WHERE OrderLineId == @OrderLineId
                ";
                var OrderLineIdParam = new SqlParameter("OrderLineId", System.Data.SqlDbType.Int);
                OrderLineIdParam.Value = OrderLineId;
                getPostCommand.Parameters.Add(OrderLineIdParam);

                //going to return a sql data reader
                var reader = getPostCommand.ExecuteReader();

                //reads one row at a time
                if (reader.Read())
                {
                    var OrderLineToAdd = new OrderLine()
                    {
                        InvoiceId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2),
                    };
                    return OrderLineToAdd;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _DbConnection.Close();
            }
            return null;
        }
    }
}
