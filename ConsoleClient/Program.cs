using ConsoleClient.Domain.Builder;
using Domain;
using Domain.Builders;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando teste de produto");
            Console.WriteLine("Criando um builder");
            var builder = new ProductBuilder();

            Console.WriteLine("Pedindo ao diretor para que gere um objeto que consiga salvar um produto");
            ProductDirector.MakeProductToSave(builder);

            var saveProduct = builder.GetProduct();
            saveProduct.Save(new Product());
            Console.WriteLine("Sucesso ao salvar produto");

            Console.WriteLine("Pedindo ao diretor para que gere um objeto que consiga pegar a data atual");
            ProductDirector.MakeProductToGetDateNow(builder);
            var productDate = builder.GetProduct();
            Console.WriteLine($"Data atual: {productDate.DateNow()}");

            Console.WriteLine("Fim do teste de produto");
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
    }
}