using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.Queries.GetRepublicDetail
{
    public class RepublicDetailVm:IRequest<RepublicDetailDto>
    {
        public string Title { get; set; }
    }
}
