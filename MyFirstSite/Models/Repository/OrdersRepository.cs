using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly DataBaseContext dataBaseContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(DataBaseContext dataBaseContext, ShopCart shopCart)
        {
            this.dataBaseContext = dataBaseContext;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            dataBaseContext.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductID = el.product.ProductId,
                    orderID = order.id,
                    Price = el.product.Price
                };
                dataBaseContext.OrderDetail.Add(orderDetail);
            }
            dataBaseContext.SaveChanges();
        }
    }
}
