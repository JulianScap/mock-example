using Autofac.Core;
using Autofac.Extras.Moq;
using ConsoleApp1.Dal;
using ConsoleApp1.Entities;
using ConsoleApp1.Services;
using Moq;

namespace MyRestApi.Tests
{
    public class MovieControllerTests
    {
        [Fact]
        public void TestThatWorks_WithMocks()
        {
            AutoMock mocker = AutoMock.GetLoose();
            Mock<IPriceService> priceService = mocker.Mock<IPriceService>(Array.Empty<Parameter>());
            Mock<IDataAccess> dataAccess = mocker.Mock<IDataAccess>(Array.Empty<Parameter>());

            priceService.Setup(service => service.ComplicatedPriceCalculation(It.IsAny<Product>()))
                .Returns(55);

            var productService = mocker.Create<ProductService>(Array.Empty<Parameter>());

            productService.SaveProduct(new Product
            {
                Id = 123,
                Name = "Toaster"
            });

            dataAccess.Verify(service => service.SaveProduct(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void TestThatDoesNotWork()
        {
            IDataAccess dataAccess = new DataAccess();
            IPriceService priceService = new PriceService();

            var productService = new ProductService(priceService, dataAccess);

            productService.SaveProduct(new Product
            {
                Id = 123,
                Name = "Toaster"
            });
        }
    }
}
