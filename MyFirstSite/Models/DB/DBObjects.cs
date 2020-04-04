using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models
{
    public class DBObjects
    {
        public static void Initial(DataBaseContext context)
        {

            if (!context.Categories.Any())
                context.Categories.AddRange(Categories.Select(c => c.Value));

            if (!context.Product.Any())
                context.AddRange(
                    new Product { Name = "Маска", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 500, IsFavourite = true, Available = true, Category = Categories["Маски"] },
                    new Product { Name = "Антисептик", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 150, IsFavourite = true, Available = true, Category = Categories["Антисептики"] }, 
                    new Product { Name = "Костюм", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 50000, IsFavourite = true, Available = true, Category = Categories["Другое"] }
                    );
            context.SaveChanges();
        }

        public static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Маски", Desc = "100% защита"},
                        new Category {CategoryName = "Антисептики", Desc = "100% чистота"},
                        new Category {CategoryName = "Другое", Desc = "Интересное))"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}
