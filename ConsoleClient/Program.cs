using ConsoleClient.Domain.Builder;
using Domain;
using Domain.Builders;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ProductBuilder();

            ProductDirector.MakeProductToSave(builder);

            var saveProduct = builder.GetProduct();
            saveProduct.Save(new Product());

            Console.WriteLine("Sucesso ao salvar produto");
        }
    }
}