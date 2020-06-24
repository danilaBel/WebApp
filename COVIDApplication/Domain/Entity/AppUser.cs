using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entity
{
    public class AppUser :IdentityUser<string>
    {
        public string Certificate { get; set; }
        public DateTime DateReg { get; set; }
    }
}
