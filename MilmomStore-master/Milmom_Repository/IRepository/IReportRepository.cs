using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IRepository
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<IEnumerable<Report>> SearchReportAsync(string search, int pageIndex, int pageSize);
        Task<Report> GetReportByIdAsync(int id);
        
    }
}
