using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IParser<T,result> where T:class
    {
        public IEnumerable<T> Parse(result document);
    }
}
