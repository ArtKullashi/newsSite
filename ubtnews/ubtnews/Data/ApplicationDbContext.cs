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

        public DbSet<Article> Articles { get; set; }
        

    }
}
