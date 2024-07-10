using AutoMapper;
using Microsoft.AspNetCore.Http;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Report;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public ReportService(IMapper mapper, IReportRepository reportRepository, IOrderRepository orderRepository) 
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<ReportResponse>> CreateReportFromBase(ReportRequest request)
        {
            Report report = _mapper.Map<Report>(request);
            await _reportRepository.AddAsync(report);

            var response = _mapper.Map<ReportResponse>(report);
            if(response != null)
            {
                var order = await _orderRepository.GetByIdAsync(response.OrderID);
                if(order != null)
                {
                    order.ReportID = response.ReportID;
                    await _orderRepository.UpdateAsync(order);
                }
            }
            return new BaseResponse<ReportResponse>("Create Report as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<Report> DeleteReport(int id)
        {
            var reportExist = await _reportRepository.GetReportByIdAsync(id);
            if(reportExist != null)
            {
                var order = await _orderRepository.GetByIdAsync(reportExist.OrderID);
                if (order != null)
                {
                    order.ReportID = null;
                    await _orderRepository.UpdateAsync(order);
                }
            }
            return await _reportRepository.DeleteAsync(reportExist);
        }

        public async Task<BaseResponse<IEnumerable<ReportResponse>>> GetAllReportFromBase()
        {
            IEnumerable<Report> reports = await _reportRepository.GetAllReportsAsync();
            if(reports == null)
            {
                return new BaseResponse<IEnumerable<ReportResponse>>("Get all Reports as base fail",
                StatusCodeEnum.BadRequest_400, null);
            }
            var report = _mapper.Map<IEnumerable<ReportResponse>>(reports);
            if(report == null)
            {
                return new BaseResponse<IEnumerable<ReportResponse>>("Get all Reports as base fail",
                StatusCodeEnum.BadRequest_400, report);
            }
            return new BaseResponse<IEnumerable<ReportResponse>>("Get all Reports as base success",
                StatusCodeEnum.OK_200, report);
        }

        public async Task<BaseResponse<ReportResponse>> GetReportByIdFromBase(int id)
        {
            Report report = await _reportRepository.GetReportByIdAsync(id);
            var result = _mapper.Map<ReportResponse>(report);
            return new BaseResponse<ReportResponse>("Get Report details success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<IEnumerable<ReportResponse>>> GetSearchReportFromBase(string search, int pageIndex, int pageSize)
        {
            IEnumerable<Report> reports = await _reportRepository.SearchReportAsync(search, pageIndex, pageSize);
            var report = _mapper.Map<IEnumerable<ReportResponse>>(reports);
            return new BaseResponse<IEnumerable<ReportResponse>>("Get search Report as base success",
                StatusCodeEnum.OK_200, report);
        }

        public async Task<BaseResponse<ReportRequestUpdate>> UpdateReportFromBase(int id, ReportRequestUpdate report)
        {
            Report existingReport = await _reportRepository.GetReportByIdAsync(id);

            if (!string.IsNullOrEmpty(report.ReportText))
            {
                existingReport.ReportText = report.ReportText;
            }

            if (!string.IsNullOrEmpty(report.ResponseText))
            {
                existingReport.ResponseText = report.ResponseText;
            }

            // Update Image only if a new Image is provided
            if (report.Image != null && report.Image.Length > 0)
            {
                existingReport.Image = report.Image;
            }
             await _reportRepository.UpdateAsync(existingReport);

            var result = _mapper.Map<ReportRequestUpdate>(existingReport);
            return new BaseResponse<ReportRequestUpdate>("Update Report as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
