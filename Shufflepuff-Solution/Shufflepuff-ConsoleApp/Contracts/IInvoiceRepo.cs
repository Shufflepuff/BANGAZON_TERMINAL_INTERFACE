using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Contracts
{
    public interface IInvoiceRepo
    {
        void AddInvoice(int paymentId);

        Invoice GetInvoice(int InvoiceId);
    }
}
