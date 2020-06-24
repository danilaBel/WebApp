using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Statistics.AddStatistic
{
    public class AddStatisticViewModel:IRequest
    {
        public string Republic { get; set; }
        public string Virus { get; set; }
        public double CountInfected { get; set; }
        public double Recovered { get; set; }
        public double Dead { get; set; }
    }
}
