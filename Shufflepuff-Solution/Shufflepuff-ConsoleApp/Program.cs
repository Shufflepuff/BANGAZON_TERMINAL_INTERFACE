
using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using Shufflepuff_ConsoleApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(@"
                         **************************
                      ********************************
                    ************ SHUFFLEPUFF ***********
                    ************* BANGAZON *************
                      ********************************
                         **************************"
                );
            Console.WriteLine(@" 1. Create an Account" + Environment.NewLine + " 2. Choose Active Customer" + Environment.NewLine + " 3. Create Payment Option" + Environment.NewLine + " 4. Search for Products" + Environment.NewLine + " 5. Complete Order" + Environment.NewLine + " 6. See Product Popularity" + Environment.NewLine + " 7. Leave Shufflepuff Bangazon"
                );

            while (true)
            {
                
                string userCommand = Console.ReadKey(true).KeyChar.ToString();

                switch (userCommand)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("enter name");
                        break;
                    case "2":
                        Console.WriteLine("Choose Active Customer");
                        break;
                    case "3":
                        //create payment option
                        break;
                    case "4":
                        //product search
                        ProductRepo repo = new ProductRepo();

                        var products = repo.GetProducts();

                        foreach (Product product in products)
                        {
                            Console.WriteLine(product.ProductId + ". " + product.Name + " " + product.Price);
                        }
                        break;
                    case "5":
                        CompleteOrder completeOrder = new CompleteOrder();
                        completeOrder.completeOrderPrompt();
                        //complete order
                        break;
                    case "6":
                        //product popularity
                        break;
                    case "7":
                        Console.WriteLine("See Ya!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option...");
                        break;
                }
            }

        }
    }
}
