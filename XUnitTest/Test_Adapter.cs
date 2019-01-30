using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UserReader.Interfaces;
using UserReader.Models;
using UserReader.Services;
using Xunit;

namespace XUnitTest
{
    public class Test_Adapter
    {
        [Fact]
        public void ImplementInterface()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var userFileReader = new UsersFileReader();
            var isInherit = userFileReader is IDataProvider;
            try
            {
                userFileReader.FromFile();
            } catch (NotImplementedException ex)
            {
                Assert.NotNull(ex);
            }
            catch (Exception e)
            {

            }

            Assert.True(userFileReader is IDataProvider);
        }

        [Fact]
        public void ReadUsers()
        {
            var users = new List<User>() {
                new User(){
                    Name="Stepan",
                    Age=30,
                    City="Lviv"
                },
                new User(){
                    Name="Steve",
                    Age=20,
                    City="New-York"
                }
            };
            var mockUsersFileReader = new Mock<UsersFileReader>() { CallBase = true };
            mockUsersFileReader.Setup(x => x.ReadUsers()).Returns(users);
            var userInfo = mockUsersFileReader.Object.FromFile();

            Assert.Equal(2, userInfo.Count());
            Assert.Equal(users.First().Name, userInfo.First().Name);
            Assert.Equal(users.First().Age, userInfo.First().Age);
        }

        [Fact]
        public void GetAll()
        {
            var usersInfo = new List<UserInfo>()
            {
                new UserInfo()
                {
                    Name="Mike",
                    Age=20
                },
                new UserInfo()
                {
                    Name="Fima",
                    Age=25
                }
            };

            var mockDateProvider = new Mock<IDataProvider>();
            mockDateProvider.Setup(x=>x.FromFile()).Returns(usersInfo);
            var users = new UserManager(mockDateProvider.Object, It.IsAny<string>()).GetAll();

            Assert.Equal(usersInfo, users);
        }
    }
}