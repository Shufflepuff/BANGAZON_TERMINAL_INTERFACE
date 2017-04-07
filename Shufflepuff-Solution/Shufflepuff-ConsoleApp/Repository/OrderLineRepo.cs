using Shufflepuff_ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace Shufflepuff_ConsoleApp.Repository
{
    public class OrderLineRepo : IOrderLineRepo
    {
        SqlConnection _DbConnection;

        public OrderLineRepo()
        {
            _DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShufflepuffBang"].ConnectionString);
        }
        public void AddOrderLine()
        {
            throw new NotImplementedException();
        }

        public OrderLineRepo GetOrderLine()
        {
            throw new NotImplementedException();
        }
    }
}
