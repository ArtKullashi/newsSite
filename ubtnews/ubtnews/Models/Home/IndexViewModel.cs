using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ubtnews.Models.Home
{
    public class IndexViewModel
    {
        public PaginatedList<Article> Articles { get; set; }
    }
}
