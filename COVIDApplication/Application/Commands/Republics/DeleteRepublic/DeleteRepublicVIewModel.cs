using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Republics.DeleteRepublic
{
    public class DeleteRepublicVIewModel:IRequest
    {
        public int Title { get; set; }
             
    }
}
