using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Republics.DeleteRepublic
{
    public class DeleteRepublicRequestHandler : IRequestHandler<DeleteRepublicVIewModel>
    {
        public Task<Unit> Handle(DeleteRepublicVIewModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
