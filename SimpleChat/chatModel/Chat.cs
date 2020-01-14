using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.chatModel
{
    public class Chat
    {
        public Replies Replies { get; set; }
        public Questions Questions { get; set; }
    }
}