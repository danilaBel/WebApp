using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Application.Commands.Parser;
using Application.Interfaces;
using CsQuery;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Statistics.Queryes.GetStatisticList
{
    public class GetStatisticListCommandHandler : IRequestHandler<GetStatisticListVm, StatisticsList>
    {
        ICovidDbContext context_;
        IParser<StatisticDto_, CQ> parser_;
        IParserSettings<StatisticDto_> settings;
        HtmlLoader<StatisticDto_> loader_;

        public GetStatisticListCommandHandler(ICovidDbContext context_, IParser<StatisticDto_, CQ> parser_, IParserSettings<StatisticDto_> settings)
        {
            this.context_ = context_;
            this.parser_ = parser_;
            this.settings = settings;
            
        }

        public async Task<StatisticsList> Handle(GetStatisticListVm request, CancellationToken cancellationToken)
        {
            if (context_.Statistics.Any(x=>x.DateTime.Date==DateTime.Now.Date))
            {
                var statistic = await context_.Statistics.ToListAsync(cancellationToken);

                return  StatisticsList(statistic.ToList());
            }
            else
            {
                loader_ = new HtmlLoader<StatisticDto_>(settings);
                var source_ = await loader_.GetSourceByPageId();
                CQ cq = CQ.Create(source_);
                var result = parser_.Parse(cq).ToList();
                //for (int i = 0; i < result.Count; i++)
                //{
                //    var republic = context_.Republics.Find(result[i].Republic);
                //    if (republic!=null)
                //    {
                //        await  context_.Statistics.AddAsync(new Statistic()
                //        {
                //            DateTime = DateTime.Now,
                //            CountInfected = result[i].CountInfected,
                //            Dead = result[i].Dead,
                //            Recovered = result[i].Recovered,
                //            RepublicId = republic.Title,
                //            VirusId = context_.Viruses.Find("Covid").Id
                //        });
                //        await context_.SaveChanges(cancellationToken);
                //    }
                //   
                //}
                return new StatisticsList { statisticList = result.ToList() };
            }

        }

        private static StatisticsList StatisticsList(List<Statistic> statistic)
        {
            return new StatisticsList()
            {
                statisticList = statistic.Where(x => x.DateTime.Date == DateTime.Now.Date).Select(x => new StatisticDto_()
                {
                    Republic = x.RepublicId
                                                                                          ,
                    CountInfected = x.CountInfected
                                                                                          ,
                    DateTime = x.DateTime,
                    Dead = x.Dead
                                                                                          ,
                    Recovered = x.Recovered
                                                                                          ,
                    Virus = x.VirusId
                }).ToList()
            };
        }
    }
}
