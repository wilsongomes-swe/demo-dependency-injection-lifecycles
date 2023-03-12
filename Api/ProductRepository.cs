namespace Api;

public interface IProductRepository
{
    IList<Product> GetAll();
    void Insert(Product product);
}

public class ProductRepository : IProductRepository, IDisposable
{
    private readonly IList<Product> _products;
    private readonly ILogger _logger;

    public ProductRepository()
    {
        _products = new List<Product>();
        _logger = new Logger(false);
        _logger.Log(this, "ProductRepository Constructor (new instance)");
    }

    public void Insert(Product product)
    {
        _logger.Log(this, $"Inserting new product {product.Id}");
        _products.Add(product);
    }

    public IList<Product> GetAll()
    {
        _logger.Log(this, $"Getting all products (logger: {_logger.GetHashCode()})");
        return new List<Product>(_products!);
    }

    public void Dispose() => _logger.Log(this, "Disposing...");
}