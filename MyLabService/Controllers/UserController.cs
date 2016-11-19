using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_2.Models;
using Lab_2.Data;

namespace MyLabService.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _userRepository.GetUsers();

            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
