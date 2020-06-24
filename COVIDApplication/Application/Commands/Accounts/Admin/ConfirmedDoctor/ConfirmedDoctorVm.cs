using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Accounts.Admin.ConfirmedDoctor
{
    public class ConfirmedDoctorVm:IRequest
    {
        public string Email { get; set; }
    }
}
