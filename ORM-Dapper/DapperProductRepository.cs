using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        //public Product GetProduct(int id)
        //{
        //    return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;",
        //        new { id =  id });
        //}

        public void UpdatedProduct(Product produtct)
        {
            _conn.Execute("UPDATE product SET " +
                          "Name = @name, " +
                          "Price = @price, " +
                          "CategoryID =@catID," +
                          " OnSale = @onSale," +
                          "StockLevel= @stock" +
                          " WHERE ProductID = @id,);",
                          new {
                            
                         id = produtct.ProductID,
                         name = produtct.Name,
                         price = produtct.Price,
                         catID = produtct.CategoryID,
                         onSale = produtct.OnSale,
                          stock = produtct.StockLevel
                         });
           
        }
    }
}
