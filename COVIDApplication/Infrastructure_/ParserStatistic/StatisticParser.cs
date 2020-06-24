using AngleSharp.Html.Dom;
using Application.Commands.Statistics.Queryes.GetStatisticList;
using Application.Interfaces;
using CsQuery;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.ParserStatistic
{
    public class StatisticParser : IParser<StatisticDto_, CQ>
    {

        public IEnumerable<StatisticDto_> Parse(CQ document)
        {
            List<CQ> domObjects = new List<CQ>();
            var list = new List<StatisticDto_>();

            foreach (IDomObject obj in new CQ(document.Find("table")[0]).Find("tr"))
            {
                domObjects.Add(new CQ(obj));
            }
            var names = new List<string>();
            foreach (IDomObject obj in document.Find("tr").Find("a"))
            {
                if (!obj.InnerText.Any(x => char.IsNumber(x)))
                {
                    names.Add(obj.InnerText);
                }

            }
            var bla = domObjects.Select((x, i) => new { number = x.Find("td"), index = i }).ToList();

            foreach (var item in bla.Skip(9))
            {
                var nums = item.number.Select(x => x.InnerText).ToArray().Select(x => x.Replace(" ", string.Empty).Replace("N/A", string.Empty).Replace(",", string.Empty)).ToArray();
                list.Add(new StatisticDto_()
                {

                    Republic = names[item.index - 9]
                        ,
                    CountInfected = (nums[2] == string.Empty) ? 0 : int.Parse(nums[2])
                        ,
                    Recovered = (nums[6] == string.Empty) ? 0 : int.Parse(nums[6])
                        ,
                    Dead = (nums[4] == string.Empty) ? 0 : int.Parse(nums[4]),
                    Virus="Covid"
                });
            }
            return list.ToArray();
        }
    }
}
