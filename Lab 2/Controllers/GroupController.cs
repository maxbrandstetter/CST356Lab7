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

namespace Lab_2.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public GroupController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Group
        public ActionResult Index()
        {
            var groups = _userRepository.GetGroups();
            return View(groups);
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Group group = _userRepository.GetGroup(id.Value);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddGroup(group);

                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Group group = _userRepository.GetGroup(id.Value);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Name")] Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }

            _userRepository.UpdateGroup(group);

            return RedirectToAction("Index");
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Group group = _userRepository.GetGroup(id.Value);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = _userRepository.GetGroup(id);
            return RedirectToAction("Index");
        }
    }
}
