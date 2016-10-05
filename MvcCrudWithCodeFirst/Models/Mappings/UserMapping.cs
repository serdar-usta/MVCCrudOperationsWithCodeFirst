using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models.Mappings
{
    public class UserMapping
    {
        private UserMapping() { }


        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<User> userConfig = modelBuilder.Entity<User>();
            userConfig.HasKey(u => u.Id );
            userConfig.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            userConfig.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            userConfig.Ignore(u => u.FullName);
            userConfig.Property(u => u.Username).IsRequired().HasMaxLength(50);
            userConfig.Property(u => u.Password).IsRequired().HasMaxLength(50);
        }


        //public UserMapping(DbModelBuilder modelBuilder)
        //{
        //    EntityTypeConfiguration<User> userConfig = modelBuilder.Entity<User>();
        //    userConfig.HasKey(u => u.Id);
        //    userConfig.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        //    userConfig.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        //    userConfig.Ignore(u => u.FullName);
        //    userConfig.Property(u => u.Username).IsRequired().HasMaxLength(50);
        //    userConfig.Property(u => u.Password).IsRequired().HasMaxLength(50);
        //}
    }
}