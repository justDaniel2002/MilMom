using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Order
{
    public class GetStoreRevenueByMonth
    {
        public List<(string Month, double Revenue)> MonthList { get; set; }
    }
}
