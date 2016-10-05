using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCrudWithCodeFirst.Models.Mappings
{
    public class MessageMapping
    {
        private MessageMapping() { }

        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<Message>().Property(m => m.Subject).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Message>().Property(m => m.Body).IsRequired();

            // Sender
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(u => u.MessagesSended)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            // Receiver
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithMany(u => u.MessagesReceived)
                .HasForeignKey(m => m.ReceiverId)
                .WillCascadeOnDelete(false);

        }
    }
}