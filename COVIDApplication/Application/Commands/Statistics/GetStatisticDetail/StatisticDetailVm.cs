using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Statistics.GetStatisticDetail
{
    public class StatisticDetailVm:IRequest<StatisticDto>
    {
        public string Republic { get; set; }
    }
}
