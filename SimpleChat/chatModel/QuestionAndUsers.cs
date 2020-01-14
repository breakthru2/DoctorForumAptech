using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.chatModel
{
    public class QuestionAndUsers
    {
        public Questions Questions { get; set; }
        public ApplicationUser Users { get; set; }
    }
}