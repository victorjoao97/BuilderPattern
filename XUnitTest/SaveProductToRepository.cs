namespace XUnitTest
{
    public class SaveProductToRepository
    {
        public SaveProductToRepository(IRepository? repository, IDateTimeProvider? dateTimeProvider, IApiService? apiService)
        {
            Repository = repository;
            DateTimeProvider = dateTimeProvider;
            ApiService = apiService;
        }

        public IRepository? Repository { get; }
        public IDateTimeProvider? DateTimeProvider { get; }
        public IApiService? ApiService { get; }

        public void Save(Product product)
        {
            if (Repository == null)
                throw new Exception("Repository is null");
            var balance = Repository.Save(product);

            if (ApiService == null)
                throw new Exception("ApiService is null");
            ApiService.Balance(balance);
        }

        public DateTime DateNow()
        {
            if (DateTimeProvider == null)
                throw new Exception("DateTimeProvider is null");
            return DateTimeProvider.Now();
        }
    }
}
