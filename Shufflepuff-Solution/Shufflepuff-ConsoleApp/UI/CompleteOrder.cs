using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.UI
{
    public class CompleteOrder
    {
        private CustomerRepo customerRepo { get; set; }
        private PaymentRepo paymentRepo { get; set; }
        private AddProductToOrder addProductToOrder { get; set; }
        private GetCustomerList getCustomerList { get; set; }
        private InvoiceRepo invoiceRepo { get; set; }

        public CompleteOrder()
        {
            customerRepo = new CustomerRepo();
            paymentRepo = new PaymentRepo();
            addProductToOrder = new AddProductToOrder();
            getCustomerList = new GetCustomerList();
            invoiceRepo = new InvoiceRepo();
        }

        public bool DetermineIfOrderContainsProducts()
        {
            if (addProductToOrder.GetProducts().Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DetermineIfReadyToPurchase()
        {
            decimal orderTotal = 0;
            var products = addProductToOrder.GetProducts();

            foreach (Product product in products)
            {
                orderTotal += product.Price;
            }

            Console.WriteLine($"Your order total is ${orderTotal}.  Ready to purchase?  Press Y or N.");
            var userInput = Console.ReadLine();

            if (userInput.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChoosePaymentMethod()
        {
            var payments = paymentRepo.GetPayments(getCustomerList.GetSelectedUserId());

            int counter = 0;

            foreach (var payment in payments)
            {
                Console.WriteLine($"{counter}. {payment.Type} {payment.AccountNumber}");
                counter++;
            }

            var userInput = Console.ReadLine();

            Payment selectedPayment;

            int selectedUIPayment;

            if (Int32.TryParse(userInput, out selectedUIPayment))
            {
                for (var i = 0; i < payments.Count(); i++)
                {
                    if (selectedUIPayment >= payments.Count() || selectedUIPayment < 0)
                    {
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadLine();
                        selectedPayment = null;
                        ChoosePaymentMethod();
                    }
                    else if (i == selectedUIPayment)
                    {
                        selectedPayment = payments[i];
                        invoiceRepo.AddInvoice(selectedPayment.PaymentId);
                        AddInvoiceLine();
                        Console.WriteLine("You have selected " + i);
                        Console.ReadLine();
                    }
                }
            }

            else
            {
                Console.WriteLine("Please enter a valid input!!!");
                Console.ReadLine();
                selectedPayment = null;
                ChoosePaymentMethod();
            }
        }

        public void AddInvoiceLine()
        {
            var payments = paymentRepo.GetPayments(getCustomerList.GetSelectedUserId());

            foreach (var payment in payments)
            {

            }
        }
    }
}