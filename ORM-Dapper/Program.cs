using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

//var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("New Department");

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//    Console.WriteLine();
//}

var productRepository = new DapperProductRepository(conn);

//var productToUpdate = productRepository.GetProduct(800);

//productToUpdate.Name = "UPDATED!!!";
//productToUpdate.OnSale = false;
//productToUpdate.CategoryID = 1;
//productToUpdate.StockLevel = 1000;
//productToUpdate.Price = 12.99;


//productRepository.UpdatedProduct(productToUpdate);


 var products = productRepository.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.Name);
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();

}