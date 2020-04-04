using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }
        public List<Product> Products { set; get; }
    }
}
