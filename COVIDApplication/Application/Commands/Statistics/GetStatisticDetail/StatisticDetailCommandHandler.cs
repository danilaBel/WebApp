using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Statistics.GetStatisticDetail
{
    public class StatisticDetailCommandHandler : IRequestHandler<StatisticDetailVm, StatisticDto>
    {
        ICovidDbContext context_;

        public StatisticDetailCommandHandler(ICovidDbContext context_)
        {
            this.context_ = context_;
        }

        public async Task<StatisticDto> Handle(StatisticDetailVm request, CancellationToken cancellationToken)
        {
            var statistic = await context_.Statistics.FindAsync(request.Republic);
            if (statistic!=null)
            {
                return new StatisticDto()
                {
                    Virus = statistic.VirusId
                                            ,
                    Republic = request.Republic
                                            ,
                    CountInfected = statistic.CountInfected
                                            ,
                    DateTime = statistic.DateTime
                                            ,
                    Dead = statistic.Dead
                                            ,
                    Recovered = statistic.Recovered
                }; 
            }
            return new StatisticDto();
        }
    }
}
