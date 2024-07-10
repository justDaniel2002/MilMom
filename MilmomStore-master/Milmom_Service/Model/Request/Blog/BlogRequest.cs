using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Blog
{
    public class BlogRequest
    {

        public string AccountID { get; set; }
        
        public string Title { get; set; }
     
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}
