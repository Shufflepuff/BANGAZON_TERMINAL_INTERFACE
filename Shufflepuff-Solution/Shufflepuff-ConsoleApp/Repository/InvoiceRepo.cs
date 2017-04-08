using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using Shufflepuff_ConsoleApp.Models;

namespace Shufflepuff_ConsoleApp.Repository
{
    public class InvoiceRepo : IInvoiceRepo
    {
        SqlConnection _shufflepuffBang;

        public InvoiceRepo()
        {
            _shufflepuffBang = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public void AddInvoice(int invoiceId, int paymentId)
        {
            _shufflepuffBang.Open();

            try
            {
                var addInvoiceCommand = _shufflepuffBang.CreateCommand();
                addInvoiceCommand.CommandText = "Insert into Invoice(InvoiceId,ProductId) values(@invoiceId,@productId)";
                var invoiceIdParameter = new SqlParameter("invoiceId", SqlDbType.Int);
                invoiceIdParameter.Value = invoiceId;
                addInvoiceCommand.Parameters.Add(invoiceIdParameter);
                var paymentIdParameter = new SqlParameter("paymentId", SqlDbType.Int);
                paymentIdParameter.Value = paymentId;
                addInvoiceCommand.Parameters.Add(paymentIdParameter);

                addInvoiceCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _shufflepuffBang.Close();
            }
        }

        public Invoice GetInvoice(int InvoiceId)
        {
            _shufflepuffBang.Open();

            try
            {
                var getInvoiceCommand = _shufflepuffBang.CreateCommand();
                getInvoiceCommand.CommandText = @"
                    SELECT invoiceId 
                    FROM Invoices
                    WHERE InvoiceId = @invoiceId";
                // does anything else need to go in the SELECT command? 
                var invoiceIdParam = new SqlParameter("invoiceId", SqlDbType.Int);
                invoiceIdParam.Value = InvoiceId;
                getInvoiceCommand.Parameters.Add(invoiceIdParam);

                var reader = getInvoiceCommand.ExecuteReader();

                if (reader.Read())
                {
                    var invoice = new Invoice
                    {
                        InvoiceId = reader.GetInt32(0),
                        PaymentId = reader.GetInt32(1)
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _shufflepuffBang.Close();
            }
            return null;
        }
    }
}
