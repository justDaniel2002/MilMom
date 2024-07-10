using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class GetTopProductSoldInAMonth
    {
        public string? ProductName { get; set; }
        public int QuantitySold { get; set; }
    }
}
