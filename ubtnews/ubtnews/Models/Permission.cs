using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class Permission
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
