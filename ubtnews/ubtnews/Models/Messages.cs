using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ubtnews.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //ktu Emri Message po e kom bo emrin e klases Messages shpresoj te mos ket konfuzion
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
