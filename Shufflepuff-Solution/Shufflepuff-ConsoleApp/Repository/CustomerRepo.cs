using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Shufflepuff_ConsoleApp.Models;

namespace Shufflepuff_ConsoleApp.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        SqlConnection _shufflepuffConnection;

        public CustomerRepo()
        {
            _shufflepuffConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShufflepuffBang"].ConnectionString);
        }

        public void AddCustomer(string name, string address, string city, string state, int zip, long phone)
        {
            _shufflepuffConnection.Open();

            try
            {
                var addCustomerCommand = _shufflepuffConnection.CreateCommand();
                addCustomerCommand.CommandText = "Insert into Customer(Name,StreetAddress,City,State,Zip,Phone) values(@name,@address,@city,@state,@zip,@phone)";

                var nameParameter = new SqlParameter("name", SqlDbType.VarChar);
                nameParameter.Value = name;
                addCustomerCommand.Parameters.Add(nameParameter);

                var addressParameter = new SqlParameter("address", SqlDbType.VarChar);
                addressParameter.Value = address;
                addCustomerCommand.Parameters.Add(addressParameter);

                var cityParameter = new SqlParameter("city", SqlDbType.VarChar);
                cityParameter.Value = city;
                addCustomerCommand.Parameters.Add(cityParameter);

                var stateParameter = new SqlParameter("state", SqlDbType.VarChar);
                stateParameter.Value = state;
                addCustomerCommand.Parameters.Add(stateParameter);

                var zipParameter = new SqlParameter("zip", SqlDbType.Int);
                zipParameter.Value = zip;
                addCustomerCommand.Parameters.Add(zipParameter);

                var phoneParameter = new SqlParameter("phone", SqlDbType.BigInt);
                phoneParameter.Value = phone;
                addCustomerCommand.Parameters.Add(phoneParameter);

                addCustomerCommand.ExecuteNonQuery();
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

        public Customer GetCustomer(int customerId)
        {
            _shufflepuffConnection.Open();

            try
            {
                var getCustomerCommand = _shufflepuffConnection.CreateCommand();
                getCustomerCommand.CommandText = @"
                    SELECT * 
                    FROM Customer 
                    WHERE customerId = @customerId";
                var customerIdParam = new SqlParameter("customerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                getCustomerCommand.Parameters.Add(customerIdParam);

                var reader = getCustomerCommand.ExecuteReader();

                if (reader.Read())
                {
                    var customer = new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        StreetAddress = reader.GetString(2),
                        City = reader.GetString(3),
                        State = reader.GetString(4),
                        Zip = reader.GetInt32(5),
                        Phone = reader.GetInt32(6)
                    };
                    return customer;
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
        public List<Customer> GetCustomerList()
        {
            _shufflepuffConnection.Open();

            try
            {
                var getCustomerCommand = _shufflepuffConnection.CreateCommand();
                getCustomerCommand.CommandText = @"
                    SELECT *
                    FROM Customer 
                ";

                var reader = getCustomerCommand.ExecuteReader();
                var customers = new List<Customer>();

                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        StreetAddress = reader.GetString(2),
                        City = reader.GetString(3),
                        State = reader.GetString(4),
                        Zip = reader.GetInt32(5),
                        Phone = reader.GetInt64(6)
                    };
                    customers.Add(customer);
                }
                return customers;
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

            return new List<Customer>();
        }
    }
}
