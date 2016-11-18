using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_2.Models;

namespace Lab_2.Services
{
    public interface IUserService
    {
        bool UserIsOnlyChild(User user);
    }
}