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
            string query = @"SELECT P.ProductID, P.SbsID, P.NcrID, P.ProductDescription, P.ModelID, P.Counts, P.Price, P.Cost, P.AdvEA, P.StatusID, P.LocationID, P.Discontinued, P.Source, L.LocationName, S.StatusName
                            FROM Product P
                            JOIN Location L ON P.LocationID = L.LocationID
                            JOIN Status S ON P.StatusID = S.StatusID
";

            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ProductID = reader.GetInt32(0);
                    int SbsID = reader.GetInt32(1);
                    int NcrID = reader.GetInt32(2);
                    string ProductDescription = reader.GetString(3);
                    int ModelID = reader.GetInt32(4);
                    int Counts = reader.GetInt32(5);
                    decimal Price = reader.GetDecimal(6);
                    decimal Cost = reader.GetDecimal(7);
                    bool AdvEA = reader.GetBoolean(8);
                    int StatusID = reader.GetInt32(9);
                    int LocationID = reader.GetInt32(10);
                    bool Discontinued = reader.GetBoolean(11);
                    string Source = reader.GetString(12);
                    string LocationName = reader.GetString(13);
                    string StatusName = reader.GetString(14);

                    var product = new Product
                    {
                        ProductID = ProductID,
                        SbsID = SbsID,
                        NcrID = NcrID,
                        ProductDescription = ProductDescription,
                        ModelID = ModelID,
                        Counts = Counts,
                        Price = Price,
                        Cost = Cost,
                        AdvEA = AdvEA,
                        StatusID = StatusID,
                        LocationID = LocationID,
                        Discontinued = Discontinued,
                        Source = Source,
                        LocationName = LocationName,
                        StatusName = StatusName,
                    };

                    products.Add(product);
                }
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            string connectionString = "Server=localhost;Database=SBS_Inventory;Trusted_Connection=True;";
            string query = @"SELECT P.SbsID, P.NcrID, P.ProductDescription, P.ModelID, P.Counts, P.Price, P.Cost, P.AdvEA, P.StatusID, P.LocationID, P.Discontinued, P.Source, L.LocationName, S.StatusName
                                FROM Product P
                                JOIN Location L ON P.LocationID = L.LocationID
                                JOIN Status S ON P.StatusID = S.StatusID
                                WHERE P.ProductID = @ProductID
                                ;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int SbsID = reader.GetInt32(0);
                    int NcrID = reader.GetInt32(1);
                    string ProductDescription = reader.GetString(2);
                    int ModelID = reader.GetInt32(3);
                    int Counts = reader.GetInt32(4);
                    decimal Price = reader.GetDecimal(5);
                    decimal Cost = reader.GetDecimal(6);
                    bool AdvEA = reader.GetBoolean(7);
                    int StatusID = reader.GetInt32(8);
                    int LocationID = reader.GetInt32(9);
                    bool Discontinued = reader.GetBoolean(10);
                    string Source = reader.GetString(11);
                    string LocationName = reader.GetString(12);
                    string StatusName = reader.GetString(13);

                    var product = new Product
                    {
                        SbsID = SbsID,
                        NcrID = NcrID,
                        ProductDescription = ProductDescription,
                        ModelID = ModelID,
                        Counts = Counts,
                        Price = Price,
                        Cost = Cost,
                        AdvEA = AdvEA,
                        StatusID = StatusID,
                        LocationID = LocationID,
                        Discontinued = Discontinued,
                        Source = Source,
                        LocationName = LocationName,
                        StatusName = StatusName,
                    };

                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            string connectionString = "Server=localhost;Database=SBS_Inventory;Trusted_Connection=True;";
            string query = @"INSERT INTO Product (SbsID, NcrID, ProductDescription, ModelID, Counts, Price, Cost, AdvEA, Discontinued, StatusID, LocationID, Source) 
            VALUES (@SbsID, @NcrID, @ProductDescription, @ModelID, @Counts, @Price, @Cost, @AdvEA, @Discontinued, @Status, @Status, @Source);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SbsID", product.SbsID);
                command.Parameters.AddWithValue("@NcrID", product.NcrID);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@ModelID", product.ModelID);
                command.Parameters.AddWithValue("@Counts", product.Counts);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Cost", product.Cost);
                command.Parameters.AddWithValue("@AdvEA", product.AdvEA);
                command.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                command.Parameters.AddWithValue("@Status", product.StatusID);
                command.Parameters.AddWithValue("@LocationID", product.LocationID);
                command.Parameters.AddWithValue("@Source", product.Source);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return Ok(true);
        }

        // I think because these are the same endpoint it is somehow triggering cors error???

        [HttpPost]
        [Route("products/update")] 
        public IActionResult UpdateProduct(Product product)
        {
            string connectionString = "Server=localhost;Database=SBS_Inventory;Trusted_Connection=True;";
            string query = @"UPDATE Product SET 
                            NcrID = @NcrID, 
                            ProductDescription = @ProductDescription, 
                            ModelID = @ModelID, 
                            Counts = @Counts, 
                            Price = @Price, 
                            Cost = @Cost, 
                            AdvEA = @AdvEA, 
                            Discontinued = @Discontinued, 
                            StatusID = @StatusID, 
                            LocationID = @LocationID, 
                            Source = @Source 
                            WHERE SbsID = @SbsID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SbsID", product.SbsID);
                command.Parameters.AddWithValue("@NcrID", product.NcrID);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@ModelID", product.ModelID);
                command.Parameters.AddWithValue("@Counts", product.Counts);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Cost", product.Cost);
                command.Parameters.AddWithValue("@AdvEA", product.AdvEA);
                command.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                command.Parameters.AddWithValue("@StatusID", product.StatusID);
                command.Parameters.AddWithValue("@LocationID", product.LocationID);
                command.Parameters.AddWithValue("@Source", product.Source);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return Ok(true);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            string connectionString = "Server=localhost;Database=SBS_Inventory;Trusted_Connection=True;";
            string query = "DELETE FROM Product WHERE ProductID = @ProductID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", id);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
