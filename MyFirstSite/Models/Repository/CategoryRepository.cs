using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Repository
{
    public class CategoryRepository : ICategories
    {
        private readonly DataBaseContext dataBaseContext;
        public CategoryRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public IEnumerable<Category> AllCategories => dataBaseContext.Categories;
    }
}
