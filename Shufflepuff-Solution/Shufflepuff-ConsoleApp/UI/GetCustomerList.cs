using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.UI
{
    public class GetCustomerList
    {
        public int SelectedUserId { get; set; }

        private CustomerRepo customerRepo { get; set; }

        public GetCustomerList()
        {
            customerRepo = new CustomerRepo();
        }

        public void DisplayCustomerList()
        {
            List<Customer> customerList = customerRepo.GetCustomerList();

            int counter = 0;

            foreach (var customer in customerList)
            {
                Console.WriteLine($"{counter}. {customer.Name}");
                counter++;
            }
            var userInput = Console.ReadLine();

            int selectedUser;

            if (Int32.TryParse(userInput, out selectedUser))
            {
                for (var i = 0; i < customerList.Count(); i++)
                {
                    if (i == selectedUser)
                    {
                        SelectedUserId = customerList[i].CustomerId;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                DisplayCustomerList();
            }
        }
    }
}
