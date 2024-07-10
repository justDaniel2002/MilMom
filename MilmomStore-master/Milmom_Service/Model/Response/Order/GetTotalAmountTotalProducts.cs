using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Order
{
    public class GetTotalAmountTotalProducts
    {
      public double totalAmount {  get; set; }
      public double totalProfit { get; set; }
      public int totalProducts { get; set; }
    }
}
