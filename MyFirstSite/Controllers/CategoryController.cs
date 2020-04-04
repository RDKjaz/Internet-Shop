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
                products = _allProducts.Products.OrderBy(i => i.ProductId);
                currCategory = "Все товары";
            }
            else
            {

                if (string.Equals("Maski", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Маски")).OrderBy(i => i.ProductId);
                    currCategory = "Маски";
                }



                else if (string.Equals("Anti", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Антисептики")).OrderBy(i => i.ProductId);
                    currCategory = "Антисептики";
                }



                else if (string.Equals("Other", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Другое")).OrderBy(i => i.ProductId);
                    currCategory = "Другое";
                }

                else
                { products = _allProducts.Products.OrderBy(i => i.ProductId); currCategory = "Все товары"; }

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
