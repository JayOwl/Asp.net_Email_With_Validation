using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Message{
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Sender  { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }

        //<div class="alert alert-success">
  //<strong>Success!</strong> Indicates a successful or positive action.
//</div>

        public Message() { }
        public Message(string sender, string subject, string body) {
            Sender  = sender;
            Subject = subject;
            Body    = body;
        }
    }
}
