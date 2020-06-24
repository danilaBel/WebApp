using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Republics.Queries.GetRepublicDetail
{
    public class GetRepublicDetailRequestHandler : IRequestHandler<RepublicDetailVm, RepublicDetailDto>
    {
        ICovidDbContext context_;

        public GetRepublicDetailRequestHandler(ICovidDbContext context_)
        {
            this.context_ = context_;
        }
        public async Task<RepublicDetailDto> Handle(RepublicDetailVm request, CancellationToken cancellationToken)
        {
            var republic = await context_.Republics.FindAsync(request.Title);
            if (republic!=null)
            {
                return new RepublicDetailDto() { Title = republic.Title, Population = republic.Population, Square = republic.Square };
            }
            return new RepublicDetailDto();
        }
    }
}
