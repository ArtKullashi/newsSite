using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class ArticleCategory
    {
        public int Id { get; set; }
 
        public Article Article { get; set; }
        public int ArticleId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
