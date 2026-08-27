using System;
using System.Data.SqlClient;


public class Program
{


    static void Main(string[] args)
    {
        string connectionString = "/////////////////////";

        using (SqlConnection connection = new SqlConnection(connectionString)) {
            connection.Open();

            string query = "///////";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader()) { 
                    
                    //..
                    //....
                    //....


                    //release resources for reader by call IDispose();
                }

                //release resources for command by call IDispose();
            }

            //release resources for connection by call IDispose(); and close connection
        }

    



        Console.ReadKey();

    }
}