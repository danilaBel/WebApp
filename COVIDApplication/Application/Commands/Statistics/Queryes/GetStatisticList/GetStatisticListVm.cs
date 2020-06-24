using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Statistics.Queryes.GetStatisticList
{
    public class GetStatisticListVm:IRequest<StatisticsList>
    {
    }
}
