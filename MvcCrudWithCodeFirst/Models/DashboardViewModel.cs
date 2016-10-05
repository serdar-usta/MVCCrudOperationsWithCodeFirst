using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class DashboardViewModel
    {
        public int TasksCount { get; set; }
        public int NewCommentsCount { get; set; }
        public int NewOrdersCount { get; set; }
        public int SupportTicketsCount { get; set; }
    }
}