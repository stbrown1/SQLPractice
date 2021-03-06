﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SQLPractice
{
    public class ProductRepository : IRepository
    {
        private static string connectionString;

        public ProductRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

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

        public void CreateProduct(Product p)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO product (name, ListPrice) VALUES (@name, @price);";
                cmd.Parameters.AddWithValue("name", p.Name);
                cmd.Parameters.AddWithValue("price", p.Price);
                cmd.ExecuteNonQuery();
                
            }
        }

        public void UpdateProduct(Product p)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET Name = '@name', ListPrice = @price WHERE ProductID = @productID;";
                cmd.Parameters.AddWithValue("name", p.Name);
                cmd.Parameters.AddWithValue("price", p.Name);
                cmd.Parameters.AddWithValue("productID", p.Id);
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
                cmd.CommandText = "DELETE FROM Product WHERE Name LIKE @name;";
                cmd.Parameters.AddWithValue("name", "%" + name + "%");
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(string name, int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Product WHERE Name LIKE @name AND ProductID = id;";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
