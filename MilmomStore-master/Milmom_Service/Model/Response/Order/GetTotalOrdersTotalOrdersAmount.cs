using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Order
{
    public class GetTotalOrdersTotalOrdersAmount
    {
       public object span { get; set; }
       public int totalOrders {  get; set; }
       public double totalOrdersAmount { get; set; }
    }
}
