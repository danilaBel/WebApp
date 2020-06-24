using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Statistics.AddStatistic
{
    public class AddStatisticRequestHandler : IRequestHandler<AddStatisticViewModel>
    {
        ICovidDbContext covidDbContext;

        public AddStatisticRequestHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(AddStatisticViewModel request, CancellationToken cancellationToken)
        {
            var Republic = await covidDbContext.Republics.FindAsync(request.Republic);
            var Virus = await covidDbContext.Viruses.FindAsync(request.Virus);
            if ((Republic!=null)&&(Virus!=null))
            {
                var Stat = new Statistic()
                {
                    CountInfected = request.CountInfected,
                    Dead = request.Dead,
                    Recovered = request.Recovered,
                    Republic = Republic,
                    Virus = Virus,
                    DateTime = DateTime.Now
                };
                await covidDbContext.Statistics.AddAsync(Stat);
                await covidDbContext.SaveChanges(cancellationToken);
            }      
            return Unit.Value;
        }
    }
}
