using Domain;
using Domain.Interfaces;

namespace Infra
{
    public class Repository : IRepository
    {
        public Balance Save(Product product)
        {
            return new Balance();
        }
    }
}
