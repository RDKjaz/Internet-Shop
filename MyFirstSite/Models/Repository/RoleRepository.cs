using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Repository
{
    public class RoleRepository : IRoles
    {
        private readonly DataBaseContext dataBaseContext;
        public RoleRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public IEnumerable<Role> AllRoles => dataBaseContext.Roles;
    }
}
