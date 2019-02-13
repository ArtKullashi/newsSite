using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ubtnews.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Permission> Permissions { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
