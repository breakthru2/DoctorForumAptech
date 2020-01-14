using Microsoft.AspNet.Identity;
using SimpleChat.chatModel;
using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SimpleChat.Controllers
{
    public class RepliesController : Controller
    {
        private ApplicationDbContext _db;
        //This is the public constructor for the Replies Controller. the Application database context was Initialized here.
        public RepliesController()
        {
            _db = new ApplicationDbContext();
        }
        //it is a protected function that was overriden from the controller class. it is used to close the Application database context opened in the constructor.
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        //it is a public function that returns a View with a list of all the replies for a particular question asked by a user in this application
        // GET: Replies
        public ActionResult Index()
        {

            return View();
        }

        //It is a public function with a parameter Id of type Integer used to get the question then returns a view with the question gotten by the parameter passed and with a list of all the replies for the question
        [Authorize]
        public ActionResult Reply(int id)
        {
            var ViewAllReply = _db.Replies.Include(u => u.User).Where(c => c.QuestionId == id).ToList();
            var viewSpecificQuestion = _db.Questions.Where(c => c.Id == id).ToList();

            var view = new ViewReplies
            {
                Reply = ViewAllReply,
                Questions = viewSpecificQuestion
            };

            return View(view);
        }


        //It is a public function with a parameter of type Object of the Replies Model Class and id of the question. it is used to save replies for a particular Question and returns a view with the question and a list of replies for the question
        public ActionResult ReplySave(Replies replies, int id)
        {
            string user = User.Identity.GetUserId();

            replies.QuestionId = id;
            replies.ReplyDate = DateTime.Now;
            replies.UserId = user;

            _db.Replies.Add(replies);
            _db.SaveChanges();
            
            // Replies to specific question
            var AllReplies = _db.Replies.Include(u => u.User).Where(c => c.QuestionId == id).ToList();
            var RepliedQuestion = _db.Questions.Where(c => c.Id == id).ToList();

            // Using View Model, Joining two tables together
            var ViewModel = new ViewReplies
            {
                Reply = AllReplies,
                Questions = RepliedQuestion
            };

            return View(ViewModel);
        }
        //It is a public function with a parameter Id of type Integer used to get all the replies for a particular Question.It returns a view with the list of replies for the question
        public ActionResult ViewAll(int id)
        {
            var ViewAllReply = _db.Replies.Include(u => u.User).Where(c => c.QuestionId == id).ToList();
            var viewSpecificQuestion = _db.Questions.Where(c => c.Id == id).ToList();

            var view = new ViewReplies
            {
                Reply = ViewAllReply,
                Questions = viewSpecificQuestion
            };

            return View(view);
        }
    }
}