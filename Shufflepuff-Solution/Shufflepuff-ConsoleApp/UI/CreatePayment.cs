using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using Shufflepuff_ConsoleApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.UI
{
    class CreatePayment
    {
        private PaymentRepo paymentRepo { get; set; }
        private Payment payment { get; set; }

        public CreatePayment()
        {
            paymentRepo = new PaymentRepo();
            payment = new Payment();
        }

        public bool SelectPaymentType()
        {
            START:
            GetCustomerList getCustomerList =  new GetCustomerList();
            int customerSelected = getCustomerList.GetSelectedUserId();

            Console.WriteLine(@" 1. Visa" + Environment.NewLine + " 2. MasterCard" + Environment.NewLine + " 3. Paypal" + Environment.NewLine + " 4. Bitcoin" + Environment.NewLine);

            string typeSelectedByUser = Console.ReadKey(true).KeyChar.ToString();
            
            switch (typeSelectedByUser)
            {
                case "1":
                    Console.WriteLine("You have selected Visa");
                    payment.Type = "Visa";
                    break;
                case "2":
                    Console.WriteLine("You have selected MasterCard");
                    payment.Type = "MasterCard";
                    break;
                case "3":
                    Console.WriteLine("You have selected PayPal");
                    payment.Type = "PayPal";
                    break;
                case "4":
                    Console.WriteLine("You have selected Bitcoin");
                    payment.Type = "Bitcoin";
                    break;
                default:
                    Console.WriteLine("Please make a valid selection.  Press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    goto START;
            }

            Console.WriteLine("Enter account number");
            int paymentAccountNumber = Convert.ToInt32(Console.ReadLine());

           
            return paymentRepo.AddPayment(payment.Type, customerSelected, paymentAccountNumber);
        }
    }
}
