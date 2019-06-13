using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chat.Models;
using ChatModels;
using Microsoft.AspNetCore.Authorization;

namespace Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IGroupRepository db;
        public HomeController()
        {
            db = new GroupRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyGroups()
        {
            var groups = db.GetUserGroups(db.GetUser(User.Identity.Name));
            //var a= groups.Select(x => x.NameGroup).ToList();
            ViewBag.groups = groups;
            return View();
        }

        public IActionResult EnterGroup(string groupname)
        {
            ViewBag.groupname = groupname;
            ViewBag.name = User.Identity.Name;
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroup(string name)
        {
            var a = db.СreateGroup(db.GetUser(User.Identity.Name), name);
            return RedirectToAction("EnterGroup", "Home" ,new { groupname=a });
        }
    }
}
