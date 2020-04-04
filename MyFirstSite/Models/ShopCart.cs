using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstSite.Models
{
    public class ShopCart
    {
        private readonly DataBaseContext dataBaseContext;
        public ShopCart(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DataBaseContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        public void AddToCart(Product product)
        {
            dataBaseContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                product = product,
                Price = product.Price
            });

            dataBaseContext.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return dataBaseContext.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.product).ToList();
        }

    }
}
