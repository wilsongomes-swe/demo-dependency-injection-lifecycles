 using Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProductsModule();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


public static class ServiceCollectionExtensions
{
    public static void AddProductsModule(this IServiceCollection services)
    {
        services.AddScoped<Api.ILogger, Logger>();
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
        services.AddTransient<IListProductsUseCase, ListProductsUseCase>();
    }
}
