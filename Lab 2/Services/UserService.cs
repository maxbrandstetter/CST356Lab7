using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_2.Models;

namespace Lab_2.Services
{
    public class UserService : IUserService
    {
        public bool UserIsOnlyChild(User user)
        {
            bool onlyChild = true;

            if (user.NumberOfSiblings != "0")
                onlyChild = false;

            return onlyChild;
        }
    }
}