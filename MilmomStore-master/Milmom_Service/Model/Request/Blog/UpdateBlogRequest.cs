using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Blog
{
    public class UpdateBlogRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}
