
using Application.Commands.Statistics.Queryes.GetStatisticList;
using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure_.ParserStatistic
{
    public class StatisticParserSettings : IParserSettings<StatisticDto_>
    {
        public string BaseUrl { get; set; } = "https://www.worldometers.info";
        public string Prefix { get; set; } = "coronavirus";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
