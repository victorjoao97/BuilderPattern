using Data;
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
            DateTimeProvider?.Setup(action).Throws(exception);
        }

        public void MockThrowsRepository(Expression<Action<IRepository>> action, Exception exception)
        {
            Repository?.Setup(action).Throws(exception);
        }

        public void MockReturnsDateTimeProvider<T>(Expression<Func<IDateTimeProvider, T>> action, T returns)
        {
            DateTimeProvider?.Setup(action).Returns(returns);
        }

        public void MockReturnsRepository<T>(Expression<Func<IRepository, T>> action, T returns)
        {
            Repository?.Setup(action).Returns(returns);
        }
    }
}
