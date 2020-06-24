using Application.Interfaces;
using MediatR;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Republics.AddRepublic
{
    public class AddRepublicRequestHandler : IRequestHandler<AddRepublicViewModel>
    {
        ICovidDbContext covidDbContext;

        public AddRepublicRequestHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(AddRepublicViewModel request, CancellationToken cancellationToken)
        {
            var Republic = new Republic()
            {
                Title = request.Title,
                Population = request.Population,
                Square = request.Square
            };
            if (Republic!=null)
            {
                await covidDbContext.Republics.AddAsync(Republic);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
