using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Contracts
{
    public interface IPaymentRepo
    {
        void AddPayment(string type, int customerId, int accountNumber);

        Payment GetPayment(int paymentId);
    }
}
