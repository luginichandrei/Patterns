using System.Collections.Generic;
using UserReader.Models;

namespace UserReader.Interfaces
{
    public interface IDataProvider
    {
        List<UserInfo> FromFile();

        User AddUser(UserInfo userInfo);
    }
}