using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_2.Models;

namespace Lab_2.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void AddUser(User user);
        User GetUser(int id);
        void UpdateUser(User id);
        void RemoveUser(User id);
        List<Group> GetGroups();
        void AddGroup(Group group);
        Group GetGroup(int id);
        void UpdateGroup(Group id);
        void RemoveGroup(Group id);
                
    }
}