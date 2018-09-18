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
            repo.CreateProduct("newProduct", 100.5);
            Console.WriteLine("Product Created!");

            //Console.WriteLine("Updating Product...");
            //repo.UpdateProduct(1004, "Updated", 100);
            //Console.WriteLine("Product Updated!");

            //Console.WriteLine("Deleting Product...");
            //repo.DeleteProduct(1001);
            //Console.WriteLine("Product Deleted!");

            Console.ReadLine();
        }
    }
}
