using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.ImageProduct;
using Milmom_Service.Model.Request.Order;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Cart;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Checkout;
using Milmom_Service.Model.Response.ImageBlog;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Order;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Rating;
using Milmom_Service.Model.Response.Report;
using Milmom_Service.Model.Response.ShippingInfor;
using Milmom_Service.Model.Response.Transaction;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateNewUserRequest, AccountApplication>().ReverseMap();
            CreateMap<AccountApplication, CreateNewUserResponse>().ReverseMap();
            CreateMap<AccountApplication, GetAllUserResponse>();
            CreateMap<AccountApplication, GetUserByIdResponse>();
            CreateMap<AccountApplication, GetUserByStringIdResponse>();
            CreateMap<AccountApplication, DeleteUserResponse>();
            CreateMap<AccountApplication, UpdateUserResponse>();
            CreateMap<UpdateUserRequest, AccountApplication>().ReverseMap();
            CreateMap<Product, GetAllProductsResponse>();
            CreateMap<Product, GetProductByIdResponse>();

            CreateMap<AccountApplication, UpdateUserResponseByString>();
            CreateMap<UpdateUserRequestByString, AccountApplication>().ReverseMap();
            //

            CreateMap<Product, GetAllProductsForManagerResponse>();
            CreateMap<Product, GetProductDetailForHP>();

            CreateMap<ImageProduct, GetAllImageProductsResponse>();
            CreateMap<Product, ViewProductHomePageResponse>();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>();
            CreateMap<AddProductRequest, Product>().ReverseMap();
            CreateMap<Product, AddProductRequest>();
            CreateMap<Product, GetFilterProductResponse>();
            CreateMap<Product, GetFilterProductForManager>();
            CreateMap<Product, GetSearchProductResponse>();
            CreateMap<ImageProduct, ProductImage>();
            CreateMap<ProductImage, ImageProduct>().ReverseMap();

            CreateMap<Category, GetAllCategoryResponse>();
            CreateMap<Category, GetCategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();

            CreateMap<Report, ReportResponse>();
            CreateMap<ReportRequest, Report>().ReverseMap();
            CreateMap<ReportRequestUpdate, Report>().ReverseMap();

            CreateMap<ImageBlog, GetAllImageBlogResponse>();
            CreateMap<Blog, BlogResponse>();
            CreateMap<BlogRequest, Blog>().ReverseMap();
            CreateMap<UpdateBlogRequest, Blog>().ReverseMap();

            //
            CreateMap<Rating, GetRatingResponse>();
            CreateMap<UpdateRatingRequest, Rating>().ReverseMap();
            CreateMap<Rating, RatingResponse>();
            CreateMap<CreateRatingRequest, Rating>().ReverseMap();
            CreateMap<Rating, RatingResponse>();
            //

            CreateMap<Cart, CartResponse>();
            CreateMap<CartItem, CartItemResponse>();
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderDetail, OrderDetailResponse>();
            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<ShippingInfor, ShippingInforResponse>();
            CreateMap<Transaction, TransactionResponse>();

            //for admin dashboard
            /*CreateMap<Order, GetStoreRevenueByMonth>();
            CreateMap<Order, GetTotalOrdersTotalOrdersAmount>();*/
        }
    }
}
