using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProduct
    {
        private string connectionString = "Data Source=LAPTOP-KUI6COAV\\SQLEXPRESS;Initial Catalog=Tecsup;User ID=dvaldez1;Password=terminator";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ListarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };
                            products.Add(product);
                        }
                    }
                }

                connection.Close();
            }

            return products;
        }

        public void Create(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Active", product.Active);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("EliminarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", productId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}