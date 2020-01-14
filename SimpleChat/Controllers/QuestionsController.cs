using Microsoft.AspNet.Identity;
using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SimpleChat.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _db;
        //This is the public constructor for the Questions Controller. the Application database context was Initialized here
        public QuestionsController()
        {
            _db = new ApplicationDbContext();
        }
        //it is a protected function that was overriden from the controller class. it is used to close the Application database context opened in the constructor
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        //this is a public function that returns the view for the questions Page
        [Authorize]
        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }
        //This is a public function that adds a new question submitted by a user in the application. it takes an Object parameter of Question Model Class then saves it in the Database
        public ActionResult Add(Questions questions)
        {
            questions.DateSent = DateTime.Now;

            string user = User.Identity.GetUserId();
            questions.UserId = user;

            _db.Questions.Add(questions);

            _db.SaveChanges();

            return RedirectToAction("AllQuestions");
        }
        //it is a public function that returns a View with a list of all the questions asked by users in this application.

        public ActionResult AllQuestions()
        {
            ViewBag.userCount = _db.Users.Count();
            var questions = _db.Questions.Include(u => u.User).ToList();
            
            return View(questions);
        }

    }
}