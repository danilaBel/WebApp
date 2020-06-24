using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.Queries.GetAllRepublics
{
   public class GetRepublicsListQuery:IRequest<RepublicsViewModel>
    {
    }
}
