using Microsoft.AspNetCore.Identity;
using System;

namespace SmartHome.API.Models
{
    public class User : IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
