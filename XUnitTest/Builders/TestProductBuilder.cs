using Data;
using Domain.Exceptions;
using Domain.Interfaces;
using Moq;
using System.Linq.Expressions;

namespace XUnitTest.Builders
{
    public class TestProductBuilder : IBuilder<ISaveProduct>
    {
        private Mock<IDateTimeProvider>? DateTimeProvider { get; set; }
        private Mock<IRepository>? Repository { get; set; }
        private Mock<IApiService>? ApiService { get; set; }

        public TestProductBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            DateTimeProvider = null;
            Repository = null;
            ApiService = null;
        }

        public void SetDateTimeProvider()
        {
            DateTimeProvider = new Mock<IDateTimeProvider>();
        }

        public void SetRepository()
        {
            Repository = new Mock<IRepository>();
        }

        public void SetApiService()
        {
            ApiService = new Mock<IApiService>();
        }

        public ISaveProduct GetProduct()
        {
            var product = new SaveProductToRepository(Repository?.Object, DateTimeProvider?.Object, ApiService?.Object);
            Reset();
            return product;
        }

        public void MockThrowsDateTimeProvider(Expression<Action<IDateTimeProvider>> action, Exception exception)
        {
            ThrowsIfMockIsNull(DateTimeProvider);
            DateTimeProvider?.Setup(action).Throws(exception);
        }

        public void MockThrowsRepository(Expression<Action<IRepository>> action, Exception exception)
        {
            ThrowsIfMockIsNull(Repository);
            Repository?.Setup(action).Throws(exception);
        }

        public void MockReturnsDateTimeProvider<T>(Expression<Func<IDateTimeProvider, T>> action, T returns)
        {
            ThrowsIfMockIsNull(DateTimeProvider);
            DateTimeProvider?.Setup(action).Returns(returns);
        }

        public void MockReturnsRepository<T>(Expression<Func<IRepository, T>> action, T returns)
        {
            ThrowsIfMockIsNull(Repository);
            Repository?.Setup(action).Returns(returns);
        }

        private static void ThrowsIfMockIsNull<T>(T? @object)
        {
            if (@object is null)
                throw new ProductWasNotBuilt($"Unable to change mock {typeof(T)} because it is null\nMake the mocks before generating the product");
        }
    }
}
