using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BaseCoffee.DAL.Entities.Concrete;

namespace BaseCoffee.DAL.Entities.Concrete;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    ICollection<Order>? Orders { get; set; }
}

