using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Accounts.Admin.GetAllDoctorsForConfirmed
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Certificate { get; set; }
    }
}
