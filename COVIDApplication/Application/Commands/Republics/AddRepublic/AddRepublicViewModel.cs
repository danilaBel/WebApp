using MediatR;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.AddRepublic
{
    public class AddRepublicViewModel:IRequest
    {
        public string Title { get; set; }
        public double Population { get; set; }
        public double Square { get; set; }
    }
}
