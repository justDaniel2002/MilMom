using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilmomStore_DataAccessObject.BaseDAO;
using MilmomStore_DataAccessObject.IBaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore_DataAccessObject
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureDataAccessObjectService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AccountApplication>();
            services.AddScoped<Blog>();
            services.AddScoped<ImageBlog>();
            services.AddScoped<Product>();
            services.AddScoped<ImageProduct>();
            services.AddScoped<Cart>();
            services.AddScoped<Category>();
            services.AddScoped<Order>();
            services.AddScoped<OrderDetail>();
            services.AddScoped<Report>();
            services.AddScoped<ShippingInfor>();
            services.AddScoped<Transaction>();
            services.AddScoped<Rating>();
            services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
            return services;
        }
    }
}
