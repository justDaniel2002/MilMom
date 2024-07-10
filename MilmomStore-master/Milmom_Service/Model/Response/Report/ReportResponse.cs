using Microsoft.AspNetCore.Http;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Report
{
    public class ReportResponse
    {
        public int ReportID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string ReportText { get; set; }
        public string ResponseText { get; set; }

        public string AccountID { get; set; }
        public GetUserByStringIdResponse AccountsApplication { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public GetProductByIdResponse Products { get; set; }

        public string? Image { get; set; }
        
        /*public string? ImageBase64 
        {
            get
            {
                if (Image != null)
                {
                    return Convert.ToBase64String(Image);
                }
                return null; // or return "" if you prefer an empty string for null Image
            }
            set { } // This setter is here just to satisfy the compiler; it's not used.
        }*/
    }
}
