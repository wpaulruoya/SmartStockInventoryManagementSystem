using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace InventoryManagementSystem.Models
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;
        private readonly ILogger<DatabaseHelper> _logger;

        public DatabaseHelper(string connectionString, ILogger<DatabaseHelper> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    _logger.LogInformation("✅ Database connection to MySQL established successfully.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Database connection failed: {ex.Message}");
                return false;
            }
        }
    }
}
