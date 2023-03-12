using Microsoft.AspNetCore.Mvc;

namespace Api;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase, IDisposable
{
    private readonly ILogger _logger;

    public ProductsController(
        ILogger logger)
    {
        _logger = logger;
        _logger.Log(this, "ProductsController constructor");
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<ListProductsItem>> ListProducts(
        [FromServices] IListProductsUseCase _listProductsUseCase)
    {
        _logger.Log(this, "Request for list proceeding to use cases");
        var allProducts = _listProductsUseCase.Execute();
        return Ok(allProducts);
    }

    [HttpPost]
    public ActionResult<Guid> CreateProduct(
        CreateProductInput input,
        ICreateProductUseCase _createProductsUseCase)
    {
        _logger.Log(this, "Request for CreateProduct proceeding to use cases");
        var id = _createProductsUseCase.Execute(input);
        return Created("", new { Id = id });
    }

    public void Dispose() => _logger.Log(this, "Disposing...");
}
