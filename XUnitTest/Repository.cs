namespace XUnitTest
{
    public class Repository : IRepository
    {
        public Balance Save(Product product)
        {
            return new Balance();
        }

        public Repository GetRepository()
        {
            return new Repository();
        }
    }
}
