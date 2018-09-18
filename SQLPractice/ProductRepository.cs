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

        public void CreateProduct(string n, double p)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO product (name, ListPrice) VALUES (@name, @price);";
                cmd.Parameters.AddWithValue("name", n);
                cmd.Parameters.AddWithValue("price", p);
                cmd.ExecuteNonQuery();
                
            }
        }

        public void UpdateProduct(int pId, string n, double p)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET Name = @name, ListPrice = @price WHERE ProductID = @productID;";
                cmd.Parameters.AddWithValue("name", n);
                cmd.Parameters.AddWithValue("price", p);
                cmd.Parameters.AddWithValue("productID", pId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Product WHERE ProductId = @pId;";
                cmd.Parameters.AddWithValue("pId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(string name)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Product WHERE Name = @name;";
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
