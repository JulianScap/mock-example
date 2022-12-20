using ConsoleApp1.Dal;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    public interface IProductService
    {
        void SaveProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly IPriceService _priceService;
        private readonly IDataAccess _dataAccess;

        public ProductService(
            IPriceService priceService,
            IDataAccess dataAccess)
        {
            _priceService = priceService;
            _dataAccess = dataAccess;
        }

        public void SaveProduct(Product product)
        {
            product.Price = _priceService.ComplicatedPriceCalculation(product);

            _dataAccess.SaveProduct(product);
        }
    }
}
