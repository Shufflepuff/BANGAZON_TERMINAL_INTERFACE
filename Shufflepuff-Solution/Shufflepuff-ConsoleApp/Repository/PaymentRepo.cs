using Shufflepuff_ConsoleApp.Contracts;
using Shufflepuff_ConsoleApp.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
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
            _shufflepuffConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShufflepuffBang"].ConnectionString);
        }


        public bool AddPayment(string type, int customerId, int accountNumber)
        {
            _shufflepuffConnection.Open();

            try
            {
                var addPaymentCommand = _shufflepuffConnection.CreateCommand();
                addPaymentCommand.CommandText = "Insert into Payment(Type,CustomerId,AccountNumber) values(@type,@customerid,@accountnumber)";

                var typeParameter = new SqlParameter("type", SqlDbType.VarChar);
                typeParameter.Value = type;
                addPaymentCommand.Parameters.Add(typeParameter);

                var customerIdParameter = new SqlParameter("customerid", SqlDbType.Int);
                customerIdParameter.Value = customerId;
                addPaymentCommand.Parameters.Add(customerIdParameter);

                var accountNumberParameter = new SqlParameter("accountnumber", SqlDbType.Int);
                accountNumberParameter.Value = accountNumber;
                addPaymentCommand.Parameters.Add(accountNumberParameter);

                addPaymentCommand.ExecuteNonQuery();
                return true;
            }

            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }

            finally
            {
                _shufflepuffConnection.Close();
            }
        }

        public Payment GetPayment(int paymentId, int customerId)
        {
            _shufflepuffConnection.Open();

            try
            {
                var getPaymentCommand = _shufflepuffConnection.CreateCommand();
                getPaymentCommand.CommandText = @"
                     SELECT * 
                     FROM Payment 
                     WHERE paymentId = @paymentId";

                var paymentIdParam = new SqlParameter("paymentId", SqlDbType.Int);
                paymentIdParam.Value = paymentId;
                getPaymentCommand.Parameters.Add(paymentIdParam);
                
                var reader = getPaymentCommand.ExecuteReader();

                if (reader.Read())
                 {
                    var payment = new Payment
                     {
                        PaymentId = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        CustomerId = reader.GetInt32(2),
                        AccountNumber = reader.GetInt32(3)
                    };
                     return payment;
                 }

                getPaymentCommand.ExecuteNonQuery();
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

        public List<Payment> GetPayments(int customerId)
        {
            _shufflepuffConnection.Open();

            try
            {
                var getPaymentsCommand = _shufflepuffConnection.CreateCommand();
                getPaymentsCommand.CommandText = @"
                    SELECT *    
                    FROM Payment 
                    WHERE CustomerId = @customerId";

                var customerIdParam = new SqlParameter("customerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                getPaymentsCommand.Parameters.Add(customerIdParam);

                var reader = getPaymentsCommand.ExecuteReader();
                var payments = new List<Payment>();

                while (reader.Read())
                {
                    var payment = new Payment
                    {
                        PaymentId = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        CustomerId = reader.GetInt32(2),
                        AccountNumber = reader.GetInt32(3)
                    };
                    payments.Add(payment);
                }
                return payments;
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

            return new List<Payment>();
        }
    }
}
