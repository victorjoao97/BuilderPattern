namespace XUnitTest
{
    public class ProductBuilder : IBuilder
    {
        private IDateTimeProvider? DateTimeProvider { get; set; }
        private IRepository? Repository { get; set; }
        private IApiService? ApiService { get; set; }

        public ProductBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            DateTimeProvider = null;
            Repository = null;
        }

        public void SetDateTimeProvider()
        {
            DateTimeProvider = new DateTimeProvider();
        }

        public void SetRepository()
        {
            Repository = new Repository();
        }

        public void SetApiService()
        {
            ApiService = new ApiService();
        }

        public SaveProductToRepository GetProduct()
        {
            var product = new SaveProductToRepository(Repository, DateTimeProvider, ApiService);
            Reset();
            return product;
        }
    }
}
