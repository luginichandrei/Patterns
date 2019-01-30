using AbstractFactory;
using System;
using UserReader.Models;
using UserReader.Services;

namespace UserReader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //StrategyInit
            var om = new OrdersManager(new AnalyticStrategy());
            om.PrintAnalitics();
            om.analyticStrategy = new CostSumAnalyticStrategy();
            om.PrintAnalitics();
            om.analyticStrategy = new AverageAnalyticStrategy();
            om.PrintAnalitics();
            //AbstractFactoryInin
            var manageFile = new AbstractFactory.UserManager(new FileFactory());
            var manageJson = new AbstractFactory.UserManager(new JsonFactory());
            manageFile.Add("Steve", 1, "NewYork");
            manageJson.Add("Steve", 2, "Lviv");
            var usersJson = manageJson.GetAll();
            var usersFile = manageFile.GetAll();
            foreach (var u in usersFile)
            {
                Console.WriteLine("Name:{0},Age:{1},City:{2}", u.Name, u.Age, u.City);
            }
            foreach (var u in usersJson)
            {
                Console.WriteLine("Name:{0},Age:{1},City:{2}", u.Name, u.Age, u.City);
            }

            //AdapterInit
            var provider = new UsersFileReader();
            var userManager = new Services.UserManager(provider, "");

            foreach (var u in provider.FromFile())
            {
                Console.WriteLine("Name:{0} Age:{1}", u.Name, u.Age);
            }

            //ProxyInit
            UsersFileReaderProxy dpProxy = new UsersFileReaderProxy();
            dpProxy.AddUser(new UserInfo());
            dpProxy.ReadUsers();
            Console.ReadKey();
        }
    }
}