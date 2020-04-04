using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int ProductID { get; set; }
        public uint Price { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }

    }
}
