using System;
using System.Collections.Generic;
using UserReader.Models;

namespace UserReader.Services
{
    public class OrdersManager

    {
        public AnalyticStrategy analyticStrategy;

        public OrdersManager(AnalyticStrategy analyticStrategy)
        {
            this.analyticStrategy = analyticStrategy;
        }

        public List<CityInfo> Import() => new OrdersReader().LoadFile();

        public void PrintAnalitics()
        {
            var result = analyticStrategy.Analyze(Import());
            Console.WriteLine(result);
            //foreach (var info in result)
            //{
            //item.Category.ToList().ForEach(Console.WriteLine);
            //    Console.WriteLine("Destination:{0}, Result:{1}", info.Destination, info.Category);
            //}
        }
    }
}