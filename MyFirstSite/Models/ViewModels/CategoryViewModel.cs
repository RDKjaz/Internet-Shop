using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string currCategory { get; set; }
    }
}
