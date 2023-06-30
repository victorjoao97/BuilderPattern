namespace Domain.Interfaces
{
    public interface ISaveProduct
    {
        void Save(Product product);
        DateTime DateNow();
    }
}