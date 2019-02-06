using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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

            modelBuilder.Entity<Permission>()
                .HasKey(t => new { t.ArticleId, t.UserId });

            modelBuilder.Entity<Permission>()
                .HasOne(pt => pt.Article)
                .WithMany(a => a.Permissions)
                .HasForeignKey(pt => pt.ArticleId);

            modelBuilder.Entity<Permission>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Article>()
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
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Messages> Messages { get; set; }


    }
}