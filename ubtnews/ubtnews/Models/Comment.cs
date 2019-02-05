using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string TheComment { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
