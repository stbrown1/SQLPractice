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
            Console.WriteLine("Product Created");

            Console.ReadLine();
        }
    }
}
