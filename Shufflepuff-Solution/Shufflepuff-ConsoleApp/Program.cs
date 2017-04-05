using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
            ************************************
            ******* SHUFFLEPUFF BANGAZON *******
            ************************************");
            Console.WriteLine(" 1. Create an Account" + Environment.NewLine + " 2. Choose Active Customer" + Environment.NewLine + " 3. Create Payment Option" + Environment.NewLine + " 4. Search for Products" + Environment.NewLine + " 5. Complete Order" + Environment.NewLine + " 6. See Product Popularity" + Environment.NewLine + " 7. Leave Shufflepuff Bangazon");

            string Command = Console.ReadLine();
            int userCommand = Int32.Parse(Command);

            if (userCommand == 1)
            {
                Console.WriteLine("CREATING ACCOUNTNUTNT");
            }
            else if (userCommand == 2)
            {
                Console.WriteLine("blahblahglhg");
            }


        }
    }
}
