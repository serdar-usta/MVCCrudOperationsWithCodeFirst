using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class ComboViewModel
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}