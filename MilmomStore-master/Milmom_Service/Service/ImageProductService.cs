using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class ImageProductService : IImageProductService
    {
        private readonly IMapper _mapper;
        private readonly IImageProductRepository _imageRepository;

        public ImageProductService(IMapper mapper, IImageProductRepository imageRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllImageProductsResponse>>> GetAllImageProductsFromBase()
        {
            IEnumerable<ImageProduct> images = await _imageRepository.GetAllAsync();
            if(images == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Cannot get images!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var image = _mapper.Map<IEnumerable<GetAllImageProductsResponse>>(images);
            if(image == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Cannot get images!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllImageProductsResponse>>("Get all image product as base success",
                StatusCodeEnum.OK_200, image);
        }

        
    }
}
