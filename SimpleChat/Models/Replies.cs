using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleChat.Models
{
    public class Replies
    {
        public int Id { get; set; }
        [Display(Name = "Your Reply")]
        public string RepliesText { get; set; }
        public Questions Question { get; set; }
        public int QuestionId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public DateTime ReplyDate { get; set; }
    }
}