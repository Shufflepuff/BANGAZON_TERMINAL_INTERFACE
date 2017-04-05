using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
