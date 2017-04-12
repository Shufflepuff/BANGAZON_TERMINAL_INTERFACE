using Shufflepuff_ConsoleApp.Models;
using Shufflepuff_ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shufflepuff_ConsoleApp.UI
{
    class AddProductToOrder
    {
        public int SelectedProductId { get; set; }
        private ProductRepo productRepo { get; set; }
        private InvoiceRepo customerInvoice { get; set; }
        private OrderLineRepo invoiceOrderLine { get; set; }
        public AddProductToOrder()
        {
            productRepo = new ProductRepo();
            customerInvoice = new InvoiceRepo();
            invoiceOrderLine = new OrderLineRepo();
        }

        //Add Product to an Order

        //Note: These are examples.Add your own product names, please.
        //To make it easier to add multiple products, when the user selects a product to order, 
        //display the menu of products again.
        //Make sure the last option of Back to main menu 
        //so the user can specify that no more products are needed.

        //1. Diapers
        //2. Case of Cracking Cola
        //3. Bicycle
        //4. AA Batteries
        //...
        //9. Done adding products

        public void DisplayProductList()
        {
            List<Product> productList = productRepo.GetProducts();


            int counter = 0;

            foreach (var product in productList)
            {
                Console.WriteLine($"{counter}. {product.Name}");
                counter++;
            }
            var userInput = Console.ReadLine();

            int selectedProduct;

            if (Int32.TryParse(userInput, out selectedProduct))
            {
                for (var i = 0; i < productList.Count(); i++)
                {
                    if (i == selectedProduct)
                    {
                        SelectedProductId = productList[i].ProductId;
                    }
                }

            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                DisplayProductList();
            }
        }


    }
}
