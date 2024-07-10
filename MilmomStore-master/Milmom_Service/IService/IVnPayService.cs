using Microsoft.AspNetCore.Http;
using Milmom_Service.Model.Request.VnPayModel;
using Milmom_Service.Model.Response.VNPayModel;

namespace Milmom_Service.IService;

public interface IVnPayService
{
    public string CreatePaymentUrl(HttpContext context, VnPayRequestModel requestModel);
    public VnPaymentResponseModel PaymentExecute(IQueryCollection collection);
}