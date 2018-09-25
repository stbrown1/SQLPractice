using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace SQLPractice
{
    public class DapperProductRepository : IRepository
    {
        private readonly string connectionString;

         public DapperProductRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public void CreateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute("INSERT INTO product (name, ListPrice) VALUES (@name, @price);", new { name = prod.Name, price = prod.Price});
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute("DELETE FROM Product WHERE ProductId = @pId;", new { pId = id });
            }
        }

        public List<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

               return conn.Query<Product>("SELECT ProductID AS Id, name AS Name, ListPrice AS Price FROM product;").ToList();
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute("UPDATE product SET Name = '@name', ListPrice = @price WHERE ProductID = @productID;", new { name = prod.Name, price = prod.Price, productID = prod.Id });
            }
        }
    }
}
