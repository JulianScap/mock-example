using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    public class PriceService : IPriceService
    {
        public decimal ComplicatedPriceCalculation(Product product)
        {
            return 1377.12m * product.Id;
        }
    }

    public interface IPriceService
    {
        decimal ComplicatedPriceCalculation(Product product);
    }
}
