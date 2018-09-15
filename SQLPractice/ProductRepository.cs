using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SQLPractice
{
    public class ProductRepository
    {
        public string connectionString = "Server=127.0.0.1;Database=adventureworks;Uid=root;Pwd=password;";

        public List<Product> GetProducts()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID AS id, name, ListPrice AS price FROM product;";
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();
                while(reader.Read())
                {
                    Product prod = new Product();
                    prod.Id = (int)reader["id"];
                    prod.Name = reader["name"].ToString();
                    prod.Price = (double)reader["price"];
                    products.Add(prod);
                }

                return products;
            }

        }

    }
}
