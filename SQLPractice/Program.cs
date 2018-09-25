using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SQLPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.Debug.json")
#else
                .AddJsonFile("appsettings.Release.json")
#endif
                .Build();

            string connString = configuration.GetConnectionString("DefaultConnection");



            //var repo = new ProductRepository(connString);

            //var addressRepo = new AddressRepository(connString);

            var dapperRepo = new DapperProductRepository(connString);

            var prod = new Product
            {
                Name = "New Dapper Product",
                Price = 100
            };

            Console.WriteLine("Creating Product...");
            dapperRepo.CreateProduct(prod);
            Console.WriteLine("Product Created!");

            Console.WriteLine("Deleting Product...");
            dapperRepo.DeleteProduct(1003);
            Console.WriteLine("Product Deleted!");

            //var address = new Address();
            //address.Address1 = "123 Main St";
            //address.Address2 = "3.14 Sesame St";
            //address.City = "Hoover";
            //address.ProvinceId = 3;
            //address.PostalCode = "35244";

            //Console.WriteLine("Creating Address...");
            //addressRepo.CreateAddress(address);
            //Console.WriteLine("Address Created!");

            //var list1 = repo.GetProducts();

            //foreach(Product prods in list1)
            //{
            //    Console.WriteLine($"{prods.Id} {prods.Name} ------- ${prods.Price}");
            //}

            //Console.WriteLine("Creating Product...");
            //var newProduct = new Product { Name = "NewProduct", Price = 100 };
            //repo.CreateProduct(newProduct);
            //Console.WriteLine("Product Created!");

            //Console.WriteLine("Updating Product...");
            //repo.UpdateProduct(1004, "Updated", 100);
            //Console.WriteLine("Product Updated!");

            //Console.WriteLine("Deleting Product...");
            //repo.DeleteProduct("Updated", 1000);
            //Console.WriteLine("Product Deleted!");

            Console.ReadLine();
        }
    }
}
