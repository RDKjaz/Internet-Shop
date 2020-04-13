using Microsoft.EntityFrameworkCore;
using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Repository
{
    public class UserRepository : IUsers
    { 

    private readonly DataBaseContext dataBaseContext;
    public UserRepository(DataBaseContext dataBaseContext)
    {
        this.dataBaseContext = dataBaseContext;
    }
    public IEnumerable<User> Users => dataBaseContext.Users.Include(c => c.Role);
    public User getObjectUser(int userID) => dataBaseContext.Users.FirstOrDefault(p => p.UserId == userID);
    }
}
