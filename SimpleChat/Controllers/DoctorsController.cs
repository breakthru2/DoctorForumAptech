using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext _db;
        //This is the public constructor for the Doctors Controller. the Application database context was Initialized here.
        public DoctorsController()
        {
            _db = new ApplicationDbContext();
        }
        //it is a protected function that was overriden from the controller class. it is used to close the Application database context opened in the constructor to avoid unhandle datbase openings. 
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        //it is a public function that returns a View with a list of all the doctors registered in this application.
        // GET: Doctors
        public ActionResult Doctors()
        {
            ViewBag.userCount = _db.Users.Count();

            var Users = _db.Users.ToList();
            return View(Users);
        }
    }
}













