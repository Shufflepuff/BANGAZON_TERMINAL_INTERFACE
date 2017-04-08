using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Repository
{
    public class PaymentRepo : IPaymentRepo
    {

        SqlConnection _shufflepuffConnection;
 
        public PaymentRepo()
        {
            _shufflepuffConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }


        public void AddPayment(string type, int customerId, int accountNumber)
        {
            _shufflepuffConnection.Open();

            try
            {
                var addPaymentCommand = _shufflepuffConnection.CreateCommand();
                addPaymentCommand.CommandText = "Insert into Payment(Type,CustomerId,AccountNumber) values(@type,@customerid,@accountnumber)";
            }

            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            finally
            {
                _shufflepuffConnection.Close();
            }
        }

        public PaymentRepo GetPayment(int paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
