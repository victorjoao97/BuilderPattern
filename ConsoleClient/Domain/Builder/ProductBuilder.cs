using Data;
using Domain.Interfaces;
using Infra;

namespace ConsoleClient.Domain.Builder;
public class ProductBuilder : IBuilder<ISaveProduct>
{
    private IDateTimeProvider? DateTimeProvider { get; set; }
    private IRepository? Repository { get; set; }
    private IApiService? ApiService { get; set; }

    public ProductBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        DateTimeProvider = null;
        Repository = null;
    }

    public void SetDateTimeProvider()
    {
        DateTimeProvider = new DateTimeProvider();
    }

    public void SetRepository()
    {
        Repository = new Repository();
    }

    public void SetApiService()
    {
        ApiService = new ApiService();
    }

    public ISaveProduct GetProduct()
    {
        var product = new SaveProductToRepository(Repository, DateTimeProvider, ApiService);
        Reset();
        return product;
    }
}
