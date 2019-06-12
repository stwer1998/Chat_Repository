using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApplication.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        IGroupRepository db;
        public ChatController()
        {
            db = new GroupRepository();
        }
        public IActionResult Index()
        {
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
            var a = db.СreateGroup(db.GetUser(User.Identity.Name),name);
            return View();
        }



    }
}