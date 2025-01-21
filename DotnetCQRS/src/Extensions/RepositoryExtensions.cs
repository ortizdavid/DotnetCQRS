using Microsoft.Extensions.DependencyInjection;
using DotnetCQRS.Repositories.Users;
using DotnetCQRS.Repositories.Categories;
using DotnetCQRS.Repositories.Suppliers;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // User
            services.AddScoped<UserCommandRepository>();
            services.AddScoped<UserQueryRepository>();
            // Supplier
            services.AddScoped<SupplierCommandRepository>();
            services.AddScoped<SupplierQueryRepository>();
            // Category
            services.AddScoped<CategoryCommandRepository>();
            services.AddScoped<CategoryQueryRepository>();
            // Product
            services.AddScoped<ProductCommandRepository>();
            services.AddScoped<ProductQueryRepository>();
            services.AddScoped<ProductImageRepository>();
        }
    }
}