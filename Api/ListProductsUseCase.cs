namespace Api;

public record ListProductsItem(Guid Id, string Name, decimal Price);

public interface IListProductsUseCase
{
    IReadOnlyCollection<ListProductsItem> Execute();
}

public class ListProductsUseCase : IListProductsUseCase, IDisposable
{
    private readonly ILogger _logger;
    private readonly IProductRepository _repository;

    public ListProductsUseCase(
        ILogger logger, 
        IProductRepository repository)
    {
        _logger = logger;
        _repository = repository;
        _logger.Log(this, "ListProductsUseCase Constructor (new instance)");
    }

    public IReadOnlyCollection<ListProductsItem> Execute()
    {
        _logger.Log(this, "Listing products");
        var products = _repository.GetAll();
        _logger.Log(this, $"{products.Count} products");
        return products
            .Select(x => new ListProductsItem(x.Id, x.Name, x.Price))
            .ToList();
    }

    public void Dispose() => _logger.Log(this, "Disposing...");
}
