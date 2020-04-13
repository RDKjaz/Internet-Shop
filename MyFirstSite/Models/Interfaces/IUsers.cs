using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> Users { get; }
        User getObjectUser(int userID);
    }
}
