using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.UI
{
    public class CreateAnAccount
    {
        private CustomerRepo customerRepo { get; set; }
        private Customer customer { get; set; }

        public CreateAnAccount()
        {
            customerRepo = new CustomerRepo();
            customer = new Customer();
        }

        public bool CreateNewAccount()
        {
            Console.WriteLine("Enter customer name");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Enter street address");
            customer.StreetAddress = Console.ReadLine();

            Console.WriteLine("Enter city");
            customer.City = Console.ReadLine();

            Console.WriteLine("Enter state");
            customer.State = Console.ReadLine();

            Console.WriteLine("Enter postal code");
            customer.Zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter phone number");
            customer.Phone = Convert.ToInt64(Console.ReadLine());

            return customerRepo.AddCustomer(customer);
        }
    }
}
