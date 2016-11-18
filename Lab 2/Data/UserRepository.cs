using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_2.Models;

namespace Lab_2.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext = new UserContext();

        public List<User> GetUsers()
        {
            return _userContext.User.ToList();
        }

        public void AddUser(User user)
        {
            _userContext.User.Add(user);
            _userContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _userContext.User.Find(id);
        }

        public void UpdateUser(User user)
        {
            _userContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _userContext.User.Remove(user);
            _userContext.SaveChanges();
        }

        public List<Group> GetGroups()
        {
            var groups = _userContext.Groups.ToList();
            List<Group> groupsList = new List<Group>();

            foreach (var group in groups)
            {
                if (group.Name != null)
                {
                    groupsList.Add(group);
                }
            }
            return groupsList;
        }

        public void AddGroup(Group group)
        {
            _userContext.Groups.Add(group);
            _userContext.SaveChanges();
        }

        public Group GetGroup(int id)
        {
            return _userContext.Groups.Find(id);
        }

        public void UpdateGroup(Group group)
        {
            _userContext.Entry(group).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }

        public void RemoveGroup(Group group)
        {
            _userContext.Groups.Remove(group);
            _userContext.SaveChanges();
        }
    }
}