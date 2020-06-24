using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.UpdateRepublic
{
    public class UpdateRepublicViewModel:IRequest
    {
        public string Title { get; set; }
        public double Population { get; set; }
        public double Square { get; set; }
    }
}
