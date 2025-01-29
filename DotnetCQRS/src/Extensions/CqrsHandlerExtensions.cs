using DotnetCQRS.Core.Users.Commands;
using DotnetCQRS.Core.Users.Queries;
using DotnetCQRS.Core.Suppliers.Commands;
using DotnetCQRS.Core.Suppliers.Queries;
using DotnetCQRS.Core.Categories.Commands;
using DotnetCQRS.Core.Categories.Queries;
using DotnetCQRS.Core.Products.Commands;
using DotnetCQRS.Core.Products.Queries;

namespace DotnetCQRS.Extensions;

public static class CqrsExtensions
{
    public static void AddCqrsHandlers(this IServiceCollection services)
    {
        AddUsersHandlers(services);
        AddSuppliersHandlers(services);
        AddCategoriesHandlers(services);
        AddProductsHandlers(services);
    }

    private static void AddUsersHandlers(this IServiceCollection services)
    {
        // Commands
        services.AddTransient<CreateUserHandler>();
        services.AddTransient<UpdateUserHandler>();
        services.AddTransient<DeleteUserHandler>();
        // Queries
        services.AddTransient<ListUsersHandler>();
        services.AddTransient<GetUserByIdHandler>();
        services.AddTransient<GetUserByUniqueIdHandler>();
    }
   
    private static void AddSuppliersHandlers(this IServiceCollection services)
    {
        // Commands
        services.AddTransient<CreateSupplierHandler>();
        services.AddTransient<UpdateSupplierHandler>();
        services.AddTransient<DeleteSupplierHandler>();
        // Queries
        services.AddTransient<ListSuppliersHandler>();
        services.AddTransient<GetSupplierByIdHandler>();
        services.AddTransient<GetSupplierByUniqueIdHandler>();
    }

    private static void AddCategoriesHandlers(this IServiceCollection services)
    {
        // Commands
        services.AddTransient<CreateCategoryHandler>();
        services.AddTransient<UpdateCategoryHandler>();
        services.AddTransient<DeleteCategoryHandler>();
        // Queries
        services.AddTransient<ListCategoriesHandler>();
        services.AddTransient<GetCategoryByIdHandler>();
        services.AddTransient<GetCategoryByUniqueIdHandler>();
    }

    private static void AddProductsHandlers(this IServiceCollection services)
    {
        // Commands
        services.AddTransient<CreateProductHandler>();
        services.AddTransient<UpdateProductHandler>();
        services.AddTransient<DeleteProductHandler>();
        // Queries
        services.AddTransient<ListProductsHandler>();
        services.AddTransient<GetProductByIdHandler>();
        services.AddTransient<GetProductByUniqueIdHandler>();
    }
}