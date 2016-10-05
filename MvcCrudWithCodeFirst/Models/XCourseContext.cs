using MvcCrudWithCodeFirst.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models
{
    public class XCourseContext : DbContext
    {
        public XCourseContext()
            : base("XCourseConnection")
        {
            // Zaten default ayarlarda aşağıdaki değerler true
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;
        }

        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Entity Framework - Fluent API (Fluent mapping)

            Mappings.UserMapping.Map(modelBuilder);
            Mappings.MessageMapping.Map(modelBuilder);
            Mappings.LessonMapping.Map(modelBuilder);
        }
    }
}