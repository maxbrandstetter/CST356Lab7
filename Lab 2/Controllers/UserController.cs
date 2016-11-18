using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab_2.Data;
using Lab_2.Models;
using Lab_2.Services;

namespace Lab_2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userRepository.GetUsers();

            foreach (var user in users)
            {
                user.OnlyChild = _userService.UserIsOnlyChild(user);
            }

            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUser(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            GetGroupList();

            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailAddress,NumberOfSiblings")] User user, List<int> groupIds)
        {
            if (ModelState.IsValid)
            {
                user.Groups = new List<Group>();
                foreach (var groupId in groupIds)
                {
                    user.Groups.Add(new Group
                    {
                        GroupId = groupId
                    });
                }

                _userRepository.AddUser(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUser(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,EmailAddress,NumberOfSiblings")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _userRepository.UpdateUser(user);

            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUser(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }

            _userRepository.RemoveUser(user);

            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _userRepository.GetUser(id);
            return RedirectToAction("Index");
        }

        private void GetGroupList()
        {
            var groups = _userRepository.GetGroups();
            ViewBag.GroupList = new MultiSelectList(groups, "GroupId", "Name");
        }
        
    }
}
