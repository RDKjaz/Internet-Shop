using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFirstSite.Models.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly DataBaseContext dataBaseContext;
        public ProductRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public IEnumerable<Product> Products => dataBaseContext.Product.Include(c => c.Category);
        public IEnumerable<Product> getFavProducts => dataBaseContext.Product.Where(p => p.IsFavourite).Include(c => c.Category);
        public Product getObjectProduct(int productID) => dataBaseContext.Product.FirstOrDefault(p => p.ProductId == productID);
    }
}
