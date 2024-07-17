using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class ReportDAO : BaseDAO<Report>
    {
        private readonly MilmomSystemContext _context;
        public ReportDAO(MilmomSystemContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _context.Reports
                .Include(r => r.AccountsApplication)
                .Include(r => r.Products)
                .ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
             var entity = await _context.Set<Report>()
                .Include(r => r.AccountsApplication)
                .Include(r => r.Products)
                .SingleOrDefaultAsync(r => r.ReportID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }

        public async Task<IEnumerable<Report>> SearchReportAsync(string search, int pageIndex, int pageSize)
        {
            IQueryable<Report> searchReports = _context.Reports;

            if (!string.IsNullOrEmpty(search))
            {
                searchReports = searchReports
                            .Include(r => r.AccountsApplication)
                            .Include(r => r.Products)
                            .Where(r => r.ReportText.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Report>.Create(searchReports, pageIndex, pageSize).ToList();
            return result;
        }
    }
}
