using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
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

        public void SelectPaymentType()
        {
            int customerSlected = getCustomerList.SelectedUserId;
            //logic for selected custom, customer Id needed from getCustomerList.cs

            Console.WriteLine(@" 1. Visa" + Environment.NewLine + " 2. MasterCard" + Environment.NewLine + " 3. Paypal" + Environment.NewLine + " 4. Bitcoin" + Environment.NewLine);



            //logic for number selected = to string type ie: 1 is selected "Visa" gets stored as string into paymentType
            string paymentType = Console.ReadLine();

            Console.WriteLine("Enter account number");
            int paymentAccountNumber = Convert.ToInt32(Console.ReadLine());  
        }
    }
}
