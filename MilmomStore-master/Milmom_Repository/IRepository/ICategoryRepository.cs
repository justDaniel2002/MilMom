using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> SearchCategoryAsync(string? search, int pageIndex, int pageSize);

    }
}
