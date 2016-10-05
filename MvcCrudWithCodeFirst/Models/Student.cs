using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class Student
    {
        // SCALAR PROPERTIES
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required, Index("IX_Student_FirstName", IsClustered = false, IsUnique = false)]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public Nullable<DateTime> DateOfBirth { get; set; }

        public int TeacherId { get; set; }

        // NAVIGATION PROPERTIES
        //[ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }

    }
}