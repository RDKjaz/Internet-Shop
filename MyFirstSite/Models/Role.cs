using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { set; get; }
        public List<User> Users { set; get; }
    }
}
