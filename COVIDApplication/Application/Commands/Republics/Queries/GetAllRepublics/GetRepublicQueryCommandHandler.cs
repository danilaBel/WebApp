using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Application.Commands.Parser;
using Application.Interfaces;
using CsQuery;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Republics.Queries.GetAllRepublics
{
    public class GetRepublicQueryCommandHandler : IRequestHandler<GetRepublicsListQuery, RepublicsViewModel>
    {
        ICovidDbContext context_;
        IParser<Republic, CQ> parser_;
        IParserSettings<Republic> settings_;
        HtmlLoader<Republic> HtmlLoader_;

        public GetRepublicQueryCommandHandler(ICovidDbContext context_, IParser<Republic, CQ> parser_, IParserSettings<Republic> settings_)
        {
            this.context_ = context_;
            this.parser_ = parser_;
            this.settings_ = settings_;
        }

        public async Task<RepublicsViewModel> Handle(GetRepublicsListQuery request, CancellationToken cancellationToken)
        {
            if (!context_.Republics.Any())
            {
                HtmlLoader_ = new HtmlLoader<Republic>(this.settings_);
                var source_ = await HtmlLoader_.GetSourceByPageId();
                CQ cq = CQ.Create(source_);
                var result = parser_.Parse(cq).ToArray();

                for (int i = 0; i < result.Count(); i++)
                {      
                    context_.Republics.Add(result[i]);

                    await context_.SaveChanges(cancellationToken);
                }
                return new RepublicsViewModel() { Republics = result.Select(x => new RepublicDto() { Population = x.Population, Square = x.Square, Title = x.Title }).ToList() };
            }
            else
            {
                var republics = await context_.Republics.ToListAsync(cancellationToken);
                return new RepublicsViewModel() { Republics = republics.Select(x => new RepublicDto() { Population = x.Population, Square = x.Square, Title = x.Title }).ToList() };
            }
        }
    }
}
