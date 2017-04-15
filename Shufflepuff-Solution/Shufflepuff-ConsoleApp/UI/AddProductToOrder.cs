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
        private static List<Product> products;
        public int SelectedProductId { get; set; }
        private ProductRepo productRepo { get; set; }
        private InvoiceRepo customerInvoice { get; set; }
        private OrderLineRepo invoiceOrderLine { get; set; }
        public AddProductToOrder()
        {
            productRepo = new ProductRepo();
            customerInvoice = new InvoiceRepo();
            invoiceOrderLine = new OrderLineRepo();
            products = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return products;
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

        public bool DisplayProductList()
        {
            List<Product> productList = productRepo.GetProducts();


            int counter = 0;

            foreach (var product in productList)
            {
                Console.WriteLine($"{counter}. {product.Name}");
                counter++;
            }
            int exitcode = counter++;
            Console.WriteLine($"{exitcode}. Done adding products");

            var userInput = Console.ReadLine();

            Product selectedProduct;

            int selectedUIProduct;

            if (Int32.TryParse(userInput, out selectedUIProduct))
            {
                for (var i = 0; i < productList.Count(); i++)
                {
                    if (i == selectedUIProduct)
                    {
                        selectedProduct = productList[i];
                        products.Add(selectedProduct);
                        DisplayProductList();    
                        
                    }
                }
                return true;
            }
            else if(selectedUIProduct == exitcode)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                DisplayProductList();
                return false;
            }
        }


    }
}
