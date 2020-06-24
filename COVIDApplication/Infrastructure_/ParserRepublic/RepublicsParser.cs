using Application.Interfaces;
using CsQuery;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure_.ParserRepublic
{
    public class RepublicsParser : IParser<Republic, CQ>
    {
        public IEnumerable<Republic> Parse(CQ document)
        {
            List<CQ> domObjects = new List<CQ>();
            var list = new List<Republic>();

            foreach (IDomObject obj in document.Find("tr"))
            {
                domObjects.Add(new CQ(obj));
            }
            var names = new List<string>();
            foreach (IDomObject obj in document.Find("tr").Find("a"))
            {
                names.Add(obj.InnerText);
            }
            var bla = domObjects.Select((x, i) => new { number = x.Find("td"), index = i }).ToList();

            foreach (var item in bla.Skip(1))
            {
                var nums = item.number.Skip(2).Select(x => x.InnerText).ToArray().Select(x => x.Replace(" ", string.Empty).Replace("N/A", string.Empty).Replace(",", string.Empty)).ToArray();
                list.Add(new Republic()
                {

                    Title = names[item.index - 1]
                        ,
                    Population = (nums[0] == string.Empty) ? 0 : int.Parse(nums[0])
                        ,
                    Square = (nums[4] == string.Empty) ? 0 : int.Parse(nums[4])
                });
            }
            return list.ToArray();
        }
    }
}
