using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Report
{
    public class CreateReportRequest
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string ReportText { get; set; }
        public string ResponseText { get; set; }
        public string AccountID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
