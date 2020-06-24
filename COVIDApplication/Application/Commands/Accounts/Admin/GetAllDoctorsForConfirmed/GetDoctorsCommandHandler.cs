using Application.Models.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Accounts.Admin.GetAllDoctorsForConfirmed
{
    public class GetDoctorsCommandHandler : IRequestHandler<GetDoctorsListVm, UsersList>
    {
        UserManager<AppUser> UserManager;
        

        public GetDoctorsCommandHandler(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<UsersList> Handle(GetDoctorsListVm request, CancellationToken cancellationToken)
        {
            
            var Users = await UserManager.GetUsersInRoleAsync("Doctor");
            
            Users = Users.Where(x=>x.EmailConfirmed==false).ToList();
            return new UsersList()
            {
                Users = Users.Select(x => new UserDto() { Email = x.Email, Certificate = Path.GetFileName(x.Certificate) }).ToList()
            };
        }

    }
}
