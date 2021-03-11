using Microsoft.EntityFrameworkCore;
using REST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Data
{
    public class FlashcardsContext : DbContext
    {
        public FlashcardsContext(DbContextOptions
        <FlashcardsContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        public DbSet<DeckOfCards> DecksOfCards { get; set; }
        //public DbSet<Like> Likes { get; set; }
        //public DbSet<SubComment> SubComments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(true);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique(true);


            modelBuilder.Entity<Card>().HasKey(c => new { c.DeckOfCards.DeckOfCardsID, c.CardID });
            //modelBuilder.Entity<Comment>().HasKey(c => new { c.DeckOfCardsID, c.UserID, c.CommentID });
            //modelBuilder.Entity<Like>().HasKey(l => new { l.DeckOfCardsID, l.UserID });
            //modelBuilder.Entity<SubComment>().HasKey(s => new { s.CommentID, s.SubCommentID,s.SubCommentedByID });

        }
    }
}
