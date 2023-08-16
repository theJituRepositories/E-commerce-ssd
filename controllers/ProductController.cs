using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TaskManager.helpers;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.controllers
{
    public class ProductController
    { 
        ProductServices productService = new ProductServices();

        public async static Task Init()
        {

            Console.WriteLine("Hello  Welcome to Mama Ngina Supermarket");
            Console.WriteLine("========================================");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3.View All Available Products");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. Exit");

            var input = Console.ReadLine();
            var validated = Validation.Validate(new List<string?> { input });
            if (!validated)
            {
              await  ProductController.Init();
            }
            else
            {
              await  new ProductController().MenuRedirect(input);
            }
        }

        public async Task MenuRedirect(string id)
        {
            switch(id)
            {
                case "1":
                  await  ViewProduct();
                    break;
                case "2":
                  await  AddProduct();
                    break;
                case "3":
                   await ViewAllAvailableProducts();
                    break;
                case "4":
                  await  UpdateProduct();
                    break;
                case "5":
                   await DeleteProduct();
                    break;
                case "6":
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    ProductController.Init();
                    break;
            }
           
           }

        public async Task ViewProduct()
        { 
            Console.WriteLine("Enter Product Id");
            var id = Console.ReadLine();
            var product = await productService.GetProductAsync(id);
            if(product != null)
            {
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Product Price: {product.Price}");
                Console.WriteLine($"Product Quantity: {product.Quantity}");
                Console.WriteLine($"Product Description: {product.Description}");
                Console.WriteLine($"Product Category: {product.ProductCategory}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

        }

        public async Task AddProduct()
        {
            Console.WriteLine("Enter Product Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            var price = Console.ReadLine();
            Console.WriteLine("Enter Product Quantity");
            var quantity = Console.ReadLine();
            Console.WriteLine("Enter Product Description");
            var description = Console.ReadLine();
            Console.WriteLine("Enter Product Category");
            var category = Console.ReadLine();

            var product = new Products
            {
                ProductName = name ,
                Price = price,
                Quantity = quantity,
                Description = description,
                ProductCategory = category,
            };
            // try posting
            try{
                var response = await productService.CreateProductAsync(product);
                Console.WriteLine(response.Message);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task ViewAllAvailableProducts()
        {
            
            var products = await productService.GetAllProductsAsync();
            if(products != null)
            {
                foreach(var product in products)
                {
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Product Price: {product.Price}");
                    Console.WriteLine($"Product Quantity: {product.Quantity}");
                    Console.WriteLine($"Product Description: {product.Description}");
                    Console.WriteLine($"Product Category: {product.ProductCategory}");
                }
            }
            else
            {
                Console.WriteLine("No products found");
            }
            
        }

        public async Task UpdateProduct()
        {
            await ViewAllAvailableProducts();
            Console.WriteLine("Enter Product Id");
            var id = Console.ReadLine();
            var product = await productService.GetProductAsync(id);
            if(product != null)
            {
                Console.WriteLine("Enter Product Name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter Product Price");
                var price = Console.ReadLine();
                Console.WriteLine("Enter Product Quantity");
                var quantity = Console.ReadLine();
                Console.WriteLine("Enter Product Description");
                var description = Console.ReadLine();
                Console.WriteLine("Enter Product Category");
                var category = Console.ReadLine();

                var updatedProduct = new Products
                {
                    ProductName = name,
                    Price = price,
                    Quantity = quantity,
                    Description = description,
                    ProductCategory = category,
                };
                // try posting
                try
                {
                    var response = await productService.UpdateProductAsync(updatedProduct);
                    Console.WriteLine(response.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }


        }

        public async Task DeleteProduct()
        {
            Console.WriteLine("Enter Product Id");
            var id = Console.ReadLine();
            var product = await productService.GetProductAsync(id);
            if (product != null)
            {
                var response = await productService.DeleteProductAsync(id);
                Console.WriteLine(response.Message);
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }


    }
            
}
