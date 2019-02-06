using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
