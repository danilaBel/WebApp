using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Accounts.Admin.GetAllDoctorsForConfirmed
{
    public class GetDoctorsListVm:IRequest<UsersList>
    {
    }
}
