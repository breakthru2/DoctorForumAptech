using SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.chatModel
{
    public class ViewReplies
    {
        public Replies Replies { get; set; }
        public IEnumerable<Replies> Reply { get; set; }
        public Questions Question { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
    }
}