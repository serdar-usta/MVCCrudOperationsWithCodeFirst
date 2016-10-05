using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        public Proficiency Proficiency { get; set; }

        // NAVIGATION PROPERTIES
        public virtual List<Student> Students { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }
}