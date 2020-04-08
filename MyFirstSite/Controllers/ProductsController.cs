using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Models.Interfaces;
using MyFirstSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Controllers
{
    public class ProductsController : Controller
    {
        private IAllProducts _productRep;


        public ProductsController(IAllProducts productRep)
        {
            _productRep = productRep;
        }
        Random rnd = new Random();
        

        public ViewResult Index()
        {
            var homeProducts = new ProductsViewModel
            {
                products = _productRep.Products.OrderBy(a => Guid.NewGuid())
            };

            return View(homeProducts);
        }

        public ViewResult Index1()
        {
            var homeProducts = new ProductsViewModel
            {
                products = _productRep.getFavProducts.OrderBy(a => Guid.NewGuid())
            };
            return View(homeProducts);
        }

    }
}
