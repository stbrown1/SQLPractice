using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace SQLPractice
{
    public class AddressRepository
    {
        private string connectionString;

        public AddressRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public void CreateAddress(Address address)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Address " +
                    "(AddressLine1, AddressLine2, City, StateProvinceId, PostalCode)" +
                    "VALUES (@add1, @add2, @city, @sPId, @postal);";
                cmd.Parameters.AddWithValue("add1", address.Address1);
                cmd.Parameters.AddWithValue("add2", address.Address2);
                cmd.Parameters.AddWithValue("city", address.City);
                cmd.Parameters.AddWithValue("sPId", address.ProvinceId);
                cmd.Parameters.AddWithValue("postal", address.PostalCode);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
