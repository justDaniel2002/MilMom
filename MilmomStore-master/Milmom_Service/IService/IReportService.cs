using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Report;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IReportService
    {
        Task<BaseResponse<IEnumerable<ReportResponse>>> GetAllReportFromBase();
        Task<BaseResponse<ReportResponse>> GetReportByIdFromBase(int id);
        Task<BaseResponse<ReportResponse>> CreateReportFromBase(ReportRequest request);
        Task<BaseResponse<ReportRequestUpdate>> UpdateReportFromBase(int id, ReportRequestUpdate report);
        Task<Report> DeleteReport(int id);
        Task<BaseResponse<IEnumerable<ReportResponse>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize);
    }
}
