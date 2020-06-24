using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Accounts.Admin.ConfirmedDoctor
{
    public class ConfirmedDoctorRequestHandler : IRequestHandler<ConfirmedDoctorVm>
    {
        UserManager<AppUser> UserManager;

        public ConfirmedDoctorRequestHandler(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmedDoctorVm request, CancellationToken cancellationToken)
        {
           
            var user = await UserManager.FindByNameAsync(request.Email);         
            if (user != null)
            {
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                await UserManager.ConfirmEmailAsync(user, code);
            }
            return Unit.Value;
        }
    }
}
