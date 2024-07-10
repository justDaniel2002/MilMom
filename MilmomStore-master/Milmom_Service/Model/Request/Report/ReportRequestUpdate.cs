using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Request.Report
{
    public class ReportRequestUpdate
    {
        public string ReportText { get; set; }
        public string ResponseText { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? Image { get; set; }
    }
}
