using System;
using System.Collections.Generic;
using StudentInfoSystem.Entity;
using StudentInfoSystem.BusinessLayer;
using System.Data.SqlClient;
// using Microsoft.Data.SqlClient;
namespace StudentInfoSystem.BusinessLayer.Util;

public static class DBConnUtil
{
    private static string connectionString = "Server=localhost;Database=SISDB;User Id=SA;Password=MyNewPass@01;"; 

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to open connection: {ex.Message}");
            }
            return connection;
        }
}
