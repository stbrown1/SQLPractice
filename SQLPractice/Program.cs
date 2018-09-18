using System;

namespace SQLPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new ProductRepository();

            //var list1 = repo.GetProducts();

            //foreach(Product prods in list1)
            //{
            //    Console.WriteLine($"{prods.Id} {prods.Name} ------- ${prods.Price}");
            //}

            Console.WriteLine("Creating Product...");
            var newProduct = new Product { Name = "NewProduct", Price = 100 };
            repo.CreateProduct(newProduct)
            Console.WriteLine("Product Created!");

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
