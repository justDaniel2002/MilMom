using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Repository.IRepository
{
    public interface IAccountAppRepository : IBaseRepository<AccountApplication>
    {
       Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount)> GetTotalAccount();

    }
}
