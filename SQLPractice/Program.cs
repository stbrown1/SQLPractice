using System;

namespace SQLPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new ProductRepository();

            var list1 = repo.GetProducts();

            foreach(Product prods in list1)
            {
                Console.WriteLine($"{prods.Id} {prods.Name} ------- ${prods.Price}");
            }

            Console.ReadLine();
        }
    }
}
