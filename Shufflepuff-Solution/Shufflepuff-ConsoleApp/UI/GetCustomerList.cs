﻿using Shufflepuff_ConsoleApp.Models;
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
        private static int SelectedUserId;

        private CustomerRepo customerRepo { get; set; }

        public GetCustomerList()
        {
            customerRepo = new CustomerRepo();
        }

        public int GetSelectedUserId()
        {
            return SelectedUserId;
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
                SelectedUserId = 0;
                for (var i = 0; i < customerList.Count(); i++)
                {
                    if (selectedUser >= customerList.Count() || selectedUser < 0)
                    {
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadLine();
                        selectedUser = 0;
                        DisplayCustomerList();
                    }
                    else if (i == selectedUser)
                    {
                        SelectedUserId = customerList[i].CustomerId;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid input!!!");
                Console.ReadLine();
                selectedUser = 0;
                DisplayCustomerList();
            }
        }
    }
}
