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

        public CreateAnAccount()
        {
            customerRepo = new CustomerRepo();
        }

        public bool CreateNewAccount()
        {
            Console.WriteLine("Enter customer name");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter street address");
            string customerAddress = Console.ReadLine();

            Console.WriteLine("Enter city");
            string customerCity= Console.ReadLine();

            Console.WriteLine("Enter state");
            string customerState = Console.ReadLine();

            Console.WriteLine("Enter postal code");
            int customerPostalCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter phone number");
            long customerPhoneNumber = Convert.ToInt64(Console.ReadLine());

            return customerRepo.AddCustomer(customerName, customerAddress, customerCity, customerState, customerPostalCode, customerPhoneNumber);
        }
    }
}
