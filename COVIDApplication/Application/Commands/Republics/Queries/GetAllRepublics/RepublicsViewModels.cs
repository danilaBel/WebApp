using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.Queries.GetAllRepublics
{
    public class RepublicsViewModel
    {
       public List<RepublicDto> Republics { get; set; }
    }
}
