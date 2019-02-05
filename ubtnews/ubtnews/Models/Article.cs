using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class Article
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }
        public DateTime CreatedAt { get; set; }

        
        

        public List<ArticleUser> ArticleUsers { get; set; }
    
        public List<ArticleCategory> ArticleCategories { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
