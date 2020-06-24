using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Statistics.Queryes.GetStatisticList
{
    public class StatisticDto_
    {
        public string Republic { get; set; }
        public double CountInfected { get; set; }
        public string Virus { get; set; }
        public double Recovered { get; set; }
        public double Dead { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
