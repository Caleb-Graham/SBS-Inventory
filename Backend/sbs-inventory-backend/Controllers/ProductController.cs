using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace SBS_Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            string connectionString = "Server=localhost;Database=SBS_Inventory;Trusted_Connection=True;";
            string query = "SELECT SbsID, NcrID, ProductDescription, ModelID, Counts, Price, Cost, AdvEA, Discontinued, Source FROM Product;";

            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SbsID = reader.GetInt32(0);
                    int NcrID = reader.GetInt32(1);
                    string ProductDescription = reader.GetString(2);
                    int ModelID = reader.GetInt32(3);
                    int Counts = reader.GetInt32(4);
                    decimal Price = reader.GetDecimal(5);
                    decimal Cost = reader.GetDecimal(6);
                    bool AdvEA = reader.GetBoolean(7);
                    bool Discontinued = reader.GetBoolean(8);
                    string Source = reader.GetString(9);

                    var product = new Product { 
                        SbsID = SbsID, 
                        NcrID = NcrID, 
                        ProductDescription = ProductDescription, 
                        ModelID = ModelID, 
                        Counts = Counts, 
                        Price = Price,
                        Cost = Cost,
                        AdvEA = AdvEA,
                        Discontinued = Discontinued,
                        Source = Source,
                    };

                    products.Add(product);
                }
            }

            return Ok(products);
        }
    }
}
