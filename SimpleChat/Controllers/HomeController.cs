using SimpleChat.chatModel;
using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
            ViewBag.UserCount = _db.Users.Count();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        public ActionResult Index()
        {
            ViewBag.SuccessMessage = "You've been registered Successfully";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}