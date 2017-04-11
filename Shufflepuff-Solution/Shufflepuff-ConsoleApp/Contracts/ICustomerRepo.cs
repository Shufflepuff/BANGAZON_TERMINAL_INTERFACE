using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.Contracts
{
    public interface ICustomerRepo
    {
        bool AddCustomer(string name, string address, string city, string state, int zip, long phone);

        Customer GetCustomer(int customerId);
    }
}
