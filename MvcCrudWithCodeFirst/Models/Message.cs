using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime MessageDate { get; set; }

        // NAVIGATION PROPERTIES
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}