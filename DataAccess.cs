using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ChoresDatabase
{
    class DataAccess
    {
        public void Run()
        {
            CreateDatabase();
            CreateChoreTable();
            AddChores();
            UpdateChore();
            DeleteChore();
            GetChores();
        }

        public void CreateDatabase()
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and create the Chores database.\n");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   // update me
                builder.UserID = "dbuser";              // update me
                builder.Password = "Password1!";      // update me
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Create a sample database
                    Console.Write("Dropping and creating database 'ChoresDB' ... ");
                    String sql = "DROP DATABASE IF EXISTS [ChoresDB]; CREATE DATABASE [ChoresDB]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                    connection.Close();
                    Console.WriteLine("Connection to SQL database closed.");

                }       
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done creating the database 'ChoresDB'. Press any key to finish...\n");
            Console.ReadKey(true);
        }

        public void CreateChoreTable()
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and create Chores table in Chores database.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   // update me
                builder.UserID = "dbuser";              // CHANGE ME BEFORE UPLOADING
                builder.Password = "Password1!";      // CHANGE ME BEFORE UPLOADING
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Create the Chores table
                    Console.Write("Creating Chores table in ChoresDB, press any key to continue...\n");
                    Console.ReadKey(true);
                    string sql = "USE ChoresDB; CREATE TABLE Chores ( ChoreID int primary key IDENTITY(1, 1) NOT NULL, ChoreName nvarchar(max) NOT NULL, ChoreAssignment nvarchar(max)) ;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                    connection.Close();
                    Console.WriteLine("Connection to SQL database closed.");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done creating the table 'Chores'. Press any key to finish...");
            Console.ReadKey(true);
        }

        public void AddChores()
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and add chores to Chores table.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   // update me
                builder.UserID = "dbuser";              // CHANGE ME BEFORE UPLOADING
                builder.Password = "Password1!";      // CHANGE ME BEFORE UPLOADING
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Add chores to the table
                    Console.WriteLine("Adding chores to Chores table in ChoresDB, press any key to continue...");
                    Console.ReadKey(true);
                    string sql = "USE ChoresDB; INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES (N'Wash dishes', N'Antwon'), (N'Vacuum floors', N'Heather'), (N'Walk the dog', N'Zoe'), (N'Empty trash', N'Zane');";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated");
                    }

                    connection.Close();
                    Console.WriteLine("Connection to SQL database closed.");

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done adding chores to the table 'Chores'. Press any key to finish...");
            Console.ReadKey(true);

        }


        public void UpdateChore()
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and perform update on Chores table.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   
                builder.UserID = "dbuser";       
                builder.Password = "Password1!";      
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Update items in the Chores table
                    Console.WriteLine("Updating the Chores table in ChoresDB, press any key to continue...");
                    Console.ReadKey(true);
                    string sql = "USE ChoresDB; UPDATE Chores SET ChoreAssignment = N'Antwon' WHERE ChoreID = 3;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated");
                    }

                    connection.Close();
                    Console.WriteLine("Connection to SQL database closed.");

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done updating chore 3 in the table 'Chores'. Press any key to finish...");
            Console.ReadKey(true);

        }

        public void DeleteChore()
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and perform delete on Chores table.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   // update me
                builder.UserID = "dbuser";              // CHANGE ME BEFORE UPLOADING
                builder.Password = "Password1!";      // CHANGE ME BEFORE UPLOADING
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Delete chore from the table
                    Console.WriteLine("Deleting item from the Chores table in ChoresDB, press any key to continue...");
                    Console.ReadKey(true);
                    string sql = "USE ChoresDB; DELETE FROM Chores WHERE ChoreAssignment = 'Zane';";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated");
                    }

                    connection.Close();
                    Console.WriteLine("Connection to SQL database closed.");

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done deleting Zane's chore in the table 'Chores'. Press any key to finish...");
            Console.ReadKey(true);

        }

        public List<string> GetChores()
        {
            var chores = new List<string>();

            int choreID;
            string choreName, choreAssignment;
            Console.WriteLine("Connect to SQL Server and display the Chores table.\n\n");

            // Build connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-EVJ0R7T\\SQLSERVER2019";   // update me
            builder.UserID = "dbuser";              // CHANGE ME BEFORE UPLOADING
            builder.Password = "Password1!";      // CHANGE ME BEFORE UPLOADING
            builder.InitialCatalog = "master";

            // Connect to SQL
            Console.Write("Connecting to SQL Server ... ");
            
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done.\n");
                Console.WriteLine("ChoreID\tChoreName\tChoreAssignment");
                var sql = "USE ChoresDB; SELECT ChoreID, ChoreName, ChoreAssignment FROM Chores;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //chores.Add($"{reader.GetSqlInt32(0)} {reader.GetString(1)} {reader.GetString(2)}");
                            choreID = reader.GetInt32(0);
                            choreName = reader.GetString(1);
                            choreAssignment = reader.GetString(2);
                            Console.WriteLine("{0}\t{1}\t{2}", choreID, choreName, choreAssignment);
                        }
                    }
                }

                connection.Close();
            }

            return chores;
        }

    }
}
