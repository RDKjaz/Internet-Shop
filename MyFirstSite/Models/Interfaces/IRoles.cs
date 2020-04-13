using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models.Interfaces
{
    public interface IRoles
    {
        IEnumerable<Role> AllRoles { get; }

    }
}
