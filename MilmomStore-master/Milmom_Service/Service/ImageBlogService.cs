using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.ImageBlog;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class ImageBlogService : IImageBlogService
    {
        private readonly IMapper _mapper;
        private readonly IImageBlogRepository _imageRepository;

        public ImageBlogService(IMapper mapper, IImageBlogRepository imageRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllImageBlogResponse>>> GetAllImageProductsFromBase()
        {
            IEnumerable<ImageBlog> images = await _imageRepository.GetAllAsync();
            if (images == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Cannot get Images",
                StatusCodeEnum.BadGateway_502, null);
            }
            var image = _mapper.Map<IEnumerable<GetAllImageBlogResponse>>(images);
            if(image == null)
            {
                return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Cannot get Images",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllImageBlogResponse>>("Get all image product as base success",
                StatusCodeEnum.OK_200, image);
        }
    }
}
