using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Username { get; set; }
        public string Password { get; set; }

        // NAVIGATION PROPERTIES
        public ICollection<Message> MessagesSended { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }

    }
}