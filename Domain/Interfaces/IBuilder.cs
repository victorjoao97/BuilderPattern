namespace Domain.Interfaces
{
    public interface IBuilder<T> : IBuilder
    {
        T GetProduct();
    }
    public interface IBuilder
    {
        void Reset();
        void SetRepository();
        void SetDateTimeProvider();
        void SetApiService();
    }
}
