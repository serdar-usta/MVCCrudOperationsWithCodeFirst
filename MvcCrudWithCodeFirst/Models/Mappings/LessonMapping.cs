using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models.Mappings
{
    public static class LessonMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Lesson> lessonConfig = modelBuilder.Entity<Lesson>();
            lessonConfig.HasKey(l => l.Id);
            lessonConfig.Property(l => l.Name).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            lessonConfig.HasRequired(l => l.Teacher).WithMany(t => t.Lessons).HasForeignKey(l => l.TeacherId);
            
        }
    }
}