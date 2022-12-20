using System.Reflection;
using ConsoleApp1.Entities;
using Newtonsoft.Json;

namespace ConsoleApp1.Dal
{
    public interface IDataAccess
    {
        void SaveProduct(Product product);
    }

    public class DataAccess : IDataAccess
    {
        public void SaveProduct(Product product)
        {
            if (!Assembly.GetEntryAssembly()!.FullName!.StartsWith("ConsoleApp1,"))
            {
                throw new NotSupportedException("No database available");
            }

            // Save the product in the DB
            Console.WriteLine($"Saving product {JsonConvert.SerializeObject(product)}");
        }
    }
}
