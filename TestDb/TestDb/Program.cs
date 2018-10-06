using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Data.Entity;

namespace TestDb
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class Program
    {
        static void Main(string[] args)
        {
            string user_id, password, database;
            Console.WriteLine("Enter User Id");
            user_id = Console.ReadLine();
            Console.WriteLine("Enter Password");
            password = Console.ReadLine();
            Console.WriteLine("Enter Dtabase Name");
            database = Console.ReadLine();
            string connectionString = "server=localhost;user id=" + user_id + ";password=" + password + ";database=" + database + ";persistsecurityinfo=True";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                using (var context = new ProductContext(connection, true))
                {
                    context.Database.CreateIfNotExists();
                    Console.WriteLine("Create A New Product");

                    Product product = new Product();
                    Console.WriteLine("Enter Price");
                    product.Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Product Name");
                    product.ProductName = Console.ReadLine();
                    Console.WriteLine("Enter Quantity");
                    product.Quantity = int.Parse(Console.ReadLine());
                    context.Products.Add(product);
                    if (context.SaveChanges() > 0)
                    {
                        Console.WriteLine("New Product Created");
                        Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("Error in Creating Product");
                    }


                }
            }
            catch
            {
                Console.WriteLine("Please enter correct data");
                Console.ReadKey();
            }



        }
    }
}
