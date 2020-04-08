using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Components
{
    public class ProductViewComponent
    {
        public IEnumerable<Product> products { get; set; }
        public string Invoke()
        {
            
                foreach (Product products1 in products)
                {
                    string a = $"Name : {products1.Name}";
                };
            return $"a";

        }
    }
}
