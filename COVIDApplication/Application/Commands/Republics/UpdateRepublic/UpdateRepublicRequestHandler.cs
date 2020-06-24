using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Republics.UpdateRepublic
{
    public class UpdateRepublicRequestHandler : IRequestHandler<UpdateRepublicViewModel>
    {
        ICovidDbContext covidDbContext;

        public UpdateRepublicRequestHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(UpdateRepublicViewModel request, CancellationToken cancellationToken)
        {
            var Republic = covidDbContext.Republics.Find(request.Title);
            if (Republic!=null)
            {
                covidDbContext.Republics.Update(Republic);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
