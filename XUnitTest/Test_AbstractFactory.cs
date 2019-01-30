using AbstractFactory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTest
{
    public class Test_AbstractFactory
    {
        [Fact]
        public void ByAge()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id= Guid.NewGuid(),
                    Name="Steve",
                    Age=12,
                    City="Lviv"
                },
                new User()
                {
                    Id= Guid.NewGuid(),
                    Name="Mike",
                    Age=15,
                    City="Kyiv"
                },
            };

            var mockDatareader = new Mock<IDataReader>();
            var mockFactory = new Mock<IFactory>();
            mockDatareader.Setup(f => f.All()).Returns(users);
            mockFactory.Setup(x => x.GetReader()).Returns(mockDatareader.Object);
            var result = new UserManager(mockFactory.Object).ByAge(12);

            var allHaveCorrectAge = result.All(x => x.Age == 12);
            Assert.Equal(result.First(), users.First());
        }

        [Fact]
        public void Delete()
        {
            var guidId = new Guid("72004c9c-3587-49bd-bc5e-b0861c77a2b1");
            var users = new List<User>()
            {
                new User()
                {
                    Id= Guid.NewGuid(),
                    Name="Steve",
                    Age=12,
                    City="Lviv"
                },
                new User()
                {
                    Id= Guid.NewGuid(),
                    Name="Mike",
                    Age=15,
                    City="Kyiv"
                },
                new User()
                {
                    Id= new Guid("72004c9c-3587-49bd-bc5e-b0861c77a2b1"),
                    Name="Henry",
                    Age=50,
                    City="Before"
                }
            };

            var mockDataWritter = new Mock<IDataWriter>();
            var mockFactory = new Mock<IFactory>();
            bool calledWithCorrectParam = false;
            mockDataWritter.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>((guid) =>
            {
                if (guid == guidId)
                {
                    calledWithCorrectParam = true;
                }
            });
            mockFactory.Setup(s => s.GetWriter()).Returns(mockDataWritter.Object);

            var result = new UserManager(mockFactory.Object).Delete(guidId);



            Assert.True(calledWithCorrectParam, "");
        }
    }
}