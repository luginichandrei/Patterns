using System;
using System.Collections.Generic;
using System.Linq;
using UserReader.Models;

namespace UserReader.Services
{
    public class CostSumAnalyticStrategy : AnalyticStrategy
    {
        public override string Analyze(List<CityInfo> cityInfos)
        {
            Console.WriteLine("CostSumAnalyticStrategy");
            var result = cityInfos.GroupBy(n => n.Destination)
                    .Select(c => new CityView
                    {
                        Destination = c.Key,
                        Result = c.SelectMany(x => x.Products).Sum(x => x.Cost)
                    }).ToList();

            var stringResult = "";
            foreach (var item in result)
            {
                stringResult = stringResult + item.Destination + Environment.NewLine + "-" + item.Result + Environment.NewLine;
            }
            return stringResult;
        }
    }
}