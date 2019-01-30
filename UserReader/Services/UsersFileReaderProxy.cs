using System;
using System.Collections.Generic;
using UserReader.Models;

namespace UserReader.Services
{
    public class UsersFileReaderProxy : UsersFileReader
    {
        public bool NameChanged = false;

        public override string Name
        {
            get => base.Name;
            set
            {
                NameChanged = true;
                base.Name = value;
            }
        }

        public override User AddUser(UserInfo user)
        {
            var start_time = DateTime.Now.Millisecond;
            Console.WriteLine("UsersFileReaderProxy: Method name: Add User, Elapsed time: 'time for execution {0} Millisecond'", DateTime.Now.Millisecond - start_time);
            return base.AddUser(user);
        }

        public override List<User> ReadUsers()
        {
            int tryCount = 0;
            while (tryCount < 3)
            {
                try
                {
                    var start_time = DateTime.Now.Millisecond;
                    Console.WriteLine("UsersFileReaderProxy: Method name: Read Users, Elapsed time: 'time for execution {0} Millisecond'", DateTime.Now.Millisecond - start_time);
                    return base.ReadUsers();
                }
                catch (Exception e)
                {
                    tryCount++;
                }
            }
            return null;
        }
    }
}