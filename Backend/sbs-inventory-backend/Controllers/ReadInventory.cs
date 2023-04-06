using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace SBS_Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string connectionString = "Server=localhost;Database=SBSInventory;Trusted_Connection=True;";
            string query = "SELECT * FROM Inventory;";

            var inventories = new List<Inventory>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    int quantity = reader.GetInt32(2);
                    decimal price = reader.GetDecimal(3);

                    // Create a new Inventory object and set its properties from the database values
                    var inventory = new Inventory { InventoryItemID = id, InventoryItemName = productName, Count = quantity, Price = price };

                    // Add the inventory object to a list of inventories
                    inventories.Add(inventory);
                }
            }

            return Ok(inventories);
        }
    }
}
