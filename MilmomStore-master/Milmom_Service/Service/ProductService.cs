using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Order;
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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>> GetAllProductsFromBase()
        {
            var products = await _productRepository.GetAllAsync();
            if(products == null)
            {
                return new BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>("Get all product as base fail",
                StatusCodeEnum.BadGateway_502, null);
            }
            var product = _mapper.Map<IEnumerable<GetAllProductsForManagerResponse>>(products);
            if(product == null)
            {
                return new BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>("Get all product as base fail",
                StatusCodeEnum.BadGateway_502, product);
            }
            return new BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>("Get all product as base success",
                StatusCodeEnum.OK_200, product);
        }

        public async Task<BaseResponse<GetProductDetailForHP>> GetProductByIdFromBase(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductDetailForHP>(product);
            return new BaseResponse<GetProductDetailForHP>("Get product details success", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetProductDetailsResponse>(product);
            return new BaseResponse<GetProductDetailsResponse>("Get product by id as base success",
                StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<UpdateProductRequest>> UpdateProductFromBase(int id, UpdateProductRequest request)
        {
            Product existingProduct = await _productRepository.GetByIdAsync(id);
            _mapper.Map(request, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);

            var result = _mapper.Map<UpdateProductRequest>(existingProduct);
            return new BaseResponse<UpdateProductRequest>("Update Product as base success", StatusCodeEnum.OK_200, result);
        }
        
        public async Task<BaseResponse<IEnumerable<GetFilterProductResponse>>> GetProductsAsync(string? search, double? lowPrice, double? highPrice, int? category, string sortBy, int pageIndex,
            int pageSize)
        {
            var products = await _productRepository.GetProductsAsync(search, lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
            var product = _mapper.Map<IEnumerable<GetFilterProductResponse>>(products);
            foreach (var item in product)
            {
                item.AverageRating = await GetRating(item.ProductId);
            }
            return new BaseResponse<IEnumerable<GetFilterProductResponse>>("Get filter product as base success",
                StatusCodeEnum.OK_200, product);
        }

        public async Task<bool> DeleteTest(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            return await _productRepository.DeleteTest(existingProduct);
        }

        public async Task<BaseResponse<AddProductRequest>> AddProductByIdFromBase(AddProductRequest request)
        { 
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);

            var response = _mapper.Map<AddProductRequest>(product);
            return new BaseResponse<AddProductRequest>("Create product as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<BaseResponse<List<GetTopProductSoldInAMonth>>> GetTopProductsSoldInMonthAsync(int top)
        {
            var products = await _productRepository.GetTopProductsSoldInMonthAsync(top);
            var response = products.Select(p => new GetTopProductSoldInAMonth
            {
                ProductName = p.ProductName,
                QuantitySold = p.QuantitySold
            }).ToList();
            if(response == null)
            {
                return new BaseResponse<List<GetTopProductSoldInAMonth>>("Get Top Product In A Month Fail", StatusCodeEnum.BadRequest_400, response);
            }
            return new BaseResponse<List<GetTopProductSoldInAMonth>>("Get Top Product In A Month Success", StatusCodeEnum.  OK_200, response);
        }

        private async Task<double> GetRating(int productId)
        {
            var ratings = await _ratingRepository.GetAverageRating(productId);
            return ratings;
        }

        public async Task<BaseResponse<SearchProductResponse>> SearchProductAsync(string? search, int pageIndex, int pageSize)
        {
            var products = await _productRepository.SearchProductAsync(search, pageIndex, pageSize);
            var totalPages = GetTotalPagesAsync(search ,products.ToList(), pageSize);
            var product = _mapper.Map<IEnumerable<GetFilterProductForManager>>(products);
            
            if(product == null)
            {
                return new BaseResponse<SearchProductResponse>("Get search product as base fail",
                StatusCodeEnum.BadGateway_502, null);
            }
            else
            {
                var response = new SearchProductResponse
                {
                    Products = product,
                    TotalPages = totalPages
                };
                return new BaseResponse<SearchProductResponse>("Get search product as base success",
                    StatusCodeEnum.OK_200, response);
            }
            
        }

        public  int GetTotalPagesAsync(string search,List<Product> products, int pageSize)
        {
            return  _productRepository.GetTotalPagesAsync(search,products, pageSize);
        }
    }
}
