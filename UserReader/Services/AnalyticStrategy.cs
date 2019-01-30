using System;
using System.Collections.Generic;
using System.Linq;
using UserReader.Models;

namespace UserReader.Services
{
    public class AnalyticStrategy
    {
        public virtual string Analyze(List<CityInfo> cityInfos)
        {
            Console.WriteLine("AnalyticStrategy");
            var result = cityInfos.GroupBy(n => n.Destination)
                     .Select(c => new CityString
                     {
                         Destination = c.Key,
                         Category = c.SelectMany(f => f.Products)
                         .GroupBy(q => q.Name)
                         .Select(r => new CategoryInfo
                         {
                             Name = r.Key,
                             Result = r.Sum(x => x.Cost)
                         }).ToList()
                     }).ToList();

            var stringResult = "";
            foreach (var item in result)
            {
                stringResult = stringResult + item.Destination + Environment.NewLine;
                foreach (var cat in item.Category)
                {
                    stringResult = stringResult + "-" + cat.Name + Environment.NewLine;
                    stringResult = stringResult + "-" + cat.Result + Environment.NewLine;
                }
            }
            return stringResult;
        }
    }
}