using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ubtnews.Models;

namespace ubtnews.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleUser>()
                .HasKey(t => new { t.ArticleId, t.UserId });

            modelBuilder.Entity<ArticleUser>()
                .HasOne(pt => pt.Article)
                .WithMany(a => a.ArticleUsers)
                .HasForeignKey(pt => pt.ArticleId);

            modelBuilder.Entity<ArticleUser>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Comment>()
                .HasKey(t => new { t.ArticleId, t.UserId });

            modelBuilder.Entity<Comment>()
                .HasOne(pt => pt.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(pt => pt.ArticleId);

            modelBuilder.Entity<Comment>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Article>()
                .HasMany(c => c.ArticleCategories)
                .WithOne(e => e.Article);

            modelBuilder.Entity<Article>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.Article);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ArticleCategories)
                .WithOne(e => e.Category);

            


        }


        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleUser> ArticleUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Messages> Messages { get; set; }


    }
}