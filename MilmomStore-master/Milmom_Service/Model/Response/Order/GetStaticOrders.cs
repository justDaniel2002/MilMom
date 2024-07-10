using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Order
{
    public class GetStaticOrders
    {
       public int ordersReturnOrCancell {  get; set; }
       public int orders { get; set; }
       public int ordersComplete { get; set; }
       public int ordersCancell { get; set; }
       public int ordersReturnRefund { get; set; }
       public int ordersReport { get; set; }
    }
}
