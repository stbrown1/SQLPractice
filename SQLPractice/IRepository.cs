using System;
using System.Collections.Generic;
using System.Text;
namespace SQLPractice
{
    public interface IRepository
    {
        List<Product> GetProducts();
        void DeleteProduct(int id);
        void CreateProduct(Product prod);
        void UpdateProduct(Product prod);
    }
}
