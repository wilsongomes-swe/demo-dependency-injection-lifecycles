namespace Api;

public record CreateProductInput(string Name, string Description, Decimal Price);

public interface ICreateProductUseCase
{
    Guid Execute(CreateProductInput input);
}

public class CreateProductUseCase : ICreateProductUseCase, IDisposable
{
    private readonly ILogger _logger;
    private readonly IProductRepository _repository;

    public CreateProductUseCase(
        ILogger logger,
        IProductRepository repository)
    {
        _logger = logger;
        _repository = repository;
        _logger.Log(this, "CreateProductUseCase Constructor (new instance)");
    }

    public Guid Execute(CreateProductInput input)
    {
        _logger.Log(this, $"Inserting new product {input.Name}");
        var product = new Product(input.Name, input.Description, input.Price);
        _repository.Insert(product);
        _logger.Log(this, $"Inserting new product {product.Name}/{product.Id}");
        return product.Id;
    }

    public void Dispose() => _logger.Log(this, "Disposing...");
}