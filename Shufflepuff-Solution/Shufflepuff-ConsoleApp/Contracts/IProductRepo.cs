using Shufflepuff_ConsoleApp.Repository;
using Shufflepuff_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Contracts
{
    public interface IProductRepo
    {
        void GetProducts(int ProductId, string Name, int Price);
        Product GetProduct(int ProductId);
    }
}
