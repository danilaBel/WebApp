using Application.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure_.ParserRepublic
{
    public class RepublicParserSettings:IParserSettings<Republic>
    {
        public string BaseUrl { get; set; } = "https://www.worldometers.info";
        public string Prefix { get; set; } = "world-population/population-by-country";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
