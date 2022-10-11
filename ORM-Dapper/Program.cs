
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            Console.WriteLine("Departments:");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine(". ");
            }
            Console.WriteLine();

            #region Department Section
            
            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID}{department.Name}");
                Console.WriteLine();
                Console.WriteLine();

            }
            #endregion
            Console.WriteLine("Products:");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine(". ");
            }
            Console.WriteLine();

            #region Product Section
            var productRepository = new DapperProductRepository(conn);

            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.Write($"{product.ProductID}");
                Console.WriteLine();
                Console.Write($"{product.Name}");
                Console.WriteLine();
                Console.Write($"{product.Price}");
                Console.WriteLine();
                Console.Write($"{product.CatecgoryID}");
                Console.WriteLine();
                Console.Write($"{product.OnSale}");
                Console.WriteLine();
                Console.Write($"{product.StockLevel}");
                Console.WriteLine();
                Console.WriteLine();

            }



            #endregion
        }
    }
}

