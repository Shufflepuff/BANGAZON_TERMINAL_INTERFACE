using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using Shufflepuff_ConsoleApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Shufflepuff_ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateAnAccount createAnAccount = new CreateAnAccount();
            GetCustomerList getCustomerList = new GetCustomerList();
            CreatePayment createPayment = new CreatePayment();
            AddProductToOrder addProduct = new AddProductToOrder();

            Console.WriteLine(@"
                         **************************
                      ********************************
                    ************ SHUFFLEPUFF ***********
                    ************* BANGAZON *************
                      ********************************
                         **************************"
                );
            START:
            Console.WriteLine(getCustomerList.GetSelectedUserId());
            Console.ReadLine();
            Console.WriteLine(@" 1. Create an Account" + Environment.NewLine + " 2. Choose Active Customer" + Environment.NewLine + " 3. Create Payment Option" + Environment.NewLine + " 4. Search for Products" + Environment.NewLine + " 5. Complete Order" + Environment.NewLine + " 6. See Product Popularity" + Environment.NewLine + " 7. Leave Shufflepuff Bangazon"
                );

                
            string userCommand = Console.ReadKey(true).KeyChar.ToString();

            switch (userCommand)
            {
                case "1":
                    Console.Clear();
                    var savedToDatabase = createAnAccount.CreateNewAccount();
                    Debug.WriteLine(savedToDatabase);
                    Console.Clear();
                    goto START;
                case "2":
                    Console.WriteLine("Choose Active Customer");
                    getCustomerList.DisplayCustomerList();
                    Console.Clear();
                    Console.WriteLine(getCustomerList.GetSelectedUserId());
                    Console.ReadLine();
                    goto START;
                case "3":
                    Console.Clear();
                    var paymentSavedToDatabase = createPayment.SelectPaymentType();
                    Debug.WriteLine(paymentSavedToDatabase);
                    Console.Clear();
                    goto START;
                case "4":
                    Console.WriteLine("Choose Product");
                    addProduct.DisplayProductList();
                    Console.Clear();
                    Console.WriteLine(addProduct.SelectedProductId);
                    Console.ReadLine();
                    goto START;
                ////product search
                //ProductRepo repo = new ProductRepo();

                //var products = repo.GetProducts();

                //foreach (Product product in products)
                //{
                //    Console.WriteLine(product.ProductId + ". " + product.Name + " " + product.Price);
                //}
                //break;
                case "5":
                    //complete order
                    break;
                case "6":
                    //product popularity
                    PaymentRepo repo = new PaymentRepo();

                    var payments = repo.GetPayments(getCustomerList.GetSelectedUserId());

                    foreach (var payment in payments)
                    {
                        Console.WriteLine(payment.Type + ". " + payment.AccountNumber);
                    }
                    goto START;
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
