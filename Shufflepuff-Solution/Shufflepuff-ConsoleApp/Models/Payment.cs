using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string Type { get; set; }

        public int CustomerId { get; set; }

        public int AccountNumber { get; set; }
    }
}
