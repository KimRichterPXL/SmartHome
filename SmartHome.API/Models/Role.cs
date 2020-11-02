using Microsoft.AspNetCore.Identity;
using System;

namespace SmartHome.API.Models
{
    public class Role : IdentityRole<Guid>
    {
        public class Constants
        {
            public const string Administrator = "Administator";
            public const string Regular = "Regular";
        }
    }
}
