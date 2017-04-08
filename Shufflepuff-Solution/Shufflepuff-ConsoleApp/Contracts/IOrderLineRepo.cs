using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Contracts
{
    public interface IOrderLineRepo
    {
        void AddOrderLine(int Invoice_Id, int Product_Id, int Quantity);

        OrderLine GetOrderLine(int OrderLineId);
    }
}
