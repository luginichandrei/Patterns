using AbstractFactory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserReader.Models;
using UserReader.Services;
using Xunit;

namespace XUnitTest
{
    public  class Test_Strategy
    {
        [Fact]
        public void CostSumAnalyticStrategy()
        {
            string s = "New-York\r\n-1112556\r\nChicago\r\n-761800\r\nMiami\r\n-650000\r\n";
            var cityInfos = new List<CityInfo>()
            {
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits",
                            Cost =256
                        },
                        new Product()
                        {
                            Name="furniture",
                            Cost =12300
                        }
                    }  
                },
                new CityInfo(){
                    Destination="Chicago",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits",
                            Cost =400
                        },
                        new Product()
                        {
                            Name="Electronics", 
                            Cost =760000
                        }
                    }
                },
                new CityInfo(){
                    Destination="Miami",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =450000
                        },
                        new Product()
                        {
                            Name="wood", 
                            Cost =200000
                        }
                    }
                },
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =700000
                        }
                    }
                },
                new CityInfo(){
                    Destination="Chicago",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits", 
                            Cost =1400
                        }
                    }
                },
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =400000
                        }
                    }
                }
            };

            var mockOrdersManager = new Mock<OrdersManager>();
            mockOrdersManager.Setup(x => x.Import()).Returns(cityInfos);

            var result = new OrdersManager(new CostSumAnalyticStrategy());
            var stringRes = result.analyticStrategy.Analyze(cityInfos);
            Assert.Equal(s, stringRes);
        }

        [Fact]
        public void AverageAnalyticStrategy()
        {
            string s = "New-York\r\n-fruits\r\n-256\r\n-furniture\r\n-12300\r\n-cars\r\n-550000\r\nChicago\r\n-fruits\r\n-900\r\n-Electronics\r\n-760000\r\nMiami\r\n-cars\r\n-450000\r\n-wood\r\n-200000\r\n";

            var cityInfos = new List<CityInfo>()
            {
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits",
                            Cost =256
                        },
                        new Product()
                        {
                            Name="furniture",
                            Cost =12300
                        }
                    }
                },
                new CityInfo(){
                    Destination="Chicago",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits",
                            Cost =400
                        },
                        new Product()
                        {
                            Name="Electronics",
                            Cost =760000
                        }
                    }
                },
                new CityInfo(){
                    Destination="Miami",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =450000
                        },
                        new Product()
                        {
                            Name="wood",
                            Cost =200000
                        }
                    }
                },
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =700000
                        }
                    }
                },
                new CityInfo(){
                    Destination="Chicago",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="fruits",
                            Cost =1400
                        }
                    }
                },
                new CityInfo(){
                    Destination="New-York",
                    Products = new List<Product>(){
                        new Product()
                        {
                            Name="cars",
                            Cost =400000
                        }
                    }
                }
            };

            var mockOrdersManager = new Mock<OrdersManager>();
            mockOrdersManager.Setup(x => x.Import()).Returns(cityInfos);

            var result = new OrdersManager(new AverageAnalyticStrategy());
            var stringRes = result.analyticStrategy.Analyze(cityInfos);
            Assert.Equal(s, stringRes);
        }


    }
}
