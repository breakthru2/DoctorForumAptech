using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleChat.Models
{
    public class Questions
    {
        public int Id { get; set; }

        [Display(Name = "Your Question")]
        public string QuestionText { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime DateSent { get; set; }
    }
}