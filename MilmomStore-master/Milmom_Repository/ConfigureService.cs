using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Milmom_Repository.BaseRepository;
using Milmom_Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using MilmomStore_DataAccessObject;

namespace Milmom_Repository
{
    public static  class ConfigureService
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
            //
            services.AddScoped<IAccountAppRepository, AccountAppRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageProductRepository, ImageProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IImageBlogRepository, ImageBlogRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            //
            services.AddScoped<AccountDAO>();
            services.AddScoped<ProductDAO>();
            services.AddScoped<ImageProductDAO>();
            services.AddScoped<ImageBlogDAO>();
            services.AddScoped<CartDAO>();
            services.AddScoped<OrderDAO>();
            services.AddScoped<RatingDAO>();
            services.AddScoped<CategoryDAO>();
            services.AddScoped<ReportDAO>();
            services.AddScoped<BlogDAO>();
            //
            
            return services;
        }
    }
}
