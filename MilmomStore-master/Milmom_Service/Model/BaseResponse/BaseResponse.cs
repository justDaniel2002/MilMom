using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Service.Models.Enums;

namespace Milmom_Service.Model.BaseResponse
{
    public class BaseResponse<T>
    {
        public string Message { get; set; } = "Sucessfull";
        public StatusCodeEnum StatusCode { get; set; }
        public T Data { get; set; }
        public BaseResponse(string? message, StatusCodeEnum statusCode, T? data)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }
}
