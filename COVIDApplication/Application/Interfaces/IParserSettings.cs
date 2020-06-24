using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IParserSettings<T>where T:class
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
