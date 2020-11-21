using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Models;
using MyFirstSite.Models.Interfaces;
using MyFirstSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly ICategories _allCategories;


        public CategoryController(IAllProducts iAllProducts, ICategories iCategory)
        {
            _allProducts = iAllProducts;
            _allCategories = iCategory;
        }


        [Route("Category/List")]
        [Route("Category/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.Products.OrderBy(a => Guid.NewGuid());
                currCategory = "Все товары";
            }
            else
            {

                if (string.Equals("Maski", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Маски")).OrderBy(a => Guid.NewGuid()); ;
                    currCategory = "Маски";
                }


                else if (string.Equals("Anti", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Антисептики")).OrderBy(a => Guid.NewGuid());
                    currCategory = "Антисептики";
                }


                else if (string.Equals("Costume", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Защитные костюмы")).OrderBy(a => Guid.NewGuid());
                    currCategory = "Защитные костюмы";
                }

                else if (string.Equals("Medicine", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Лекарства")).OrderBy(a => Guid.NewGuid());
                    currCategory = "Лекарства";
                }

                else if (string.Equals("Gloves", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Перчатки")).OrderBy(a => Guid.NewGuid());
                    currCategory = "Перчатки";
                }


        

                else
                { products = _allProducts.Products.OrderBy(a => Guid.NewGuid()); currCategory = "Все товары"; }

            }

            var prodObj = new CategoryViewModel
            {
                AllProducts = products,
                currCategory = currCategory
            };

            ViewBag.Title = "Страница с товарами";


            return View(prodObj);
        }
    }
}
