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
    public class ShopCartController : Controller
    {
        private IAllProducts _prodRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllProducts prodRep, ShopCart shopCart)
        {
            _prodRep = prodRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _prodRep.Products.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
