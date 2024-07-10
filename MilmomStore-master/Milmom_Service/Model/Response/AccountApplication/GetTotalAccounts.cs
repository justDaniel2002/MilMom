using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.AccountApplication
{
    public class GetTotalAccounts
    {
        public int totalAccount { get; set; } 
        public int staffsAccount {  get; set; } 
        public int managersAccount {  get; set; }
        public int customersAccount { get; set; }
    }
}
