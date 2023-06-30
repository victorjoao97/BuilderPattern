using Domain;
using Moq;
using XUnitTest.Builders;

namespace XUnitTest
{
    public class ProductTestUnit
    {
        internal TestProductBuilder Builder { get; }

        public ProductTestUnit()
        {
            Builder = new TestProductBuilder();
        }

        [Fact]
        public void ShouldThrowsOnSaveProduct()
        {
            Builder.SetDateTimeProvider();
            Builder.SetRepository();
            Builder.MockThrowsRepository(x => x.Save(It.IsAny<Product>()), new Exception("VISH"));
            var saveProduct = Builder.GetProduct();

            void act() => saveProduct.Save(It.IsAny<Product>());
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldSaveProduct()
        {
            Builder.SetDateTimeProvider();
            Builder.SetApiService();
            Builder.SetRepository();
            Builder.MockReturnsRepository(x => x.Save(It.IsAny<Product>()), new Balance());
            var saveProduct = Builder.GetProduct();

            saveProduct.Save(It.IsAny<Product>());
        }

        [Fact]
        public void ShouldThrowsOnGetDateNow()
        {
            Builder.SetDateTimeProvider();
            Builder.MockThrowsDateTimeProvider(x => x.Now(), new Exception("VISH"));

            var saveProduct = Builder.GetProduct();

            void act() => saveProduct.DateNow();
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldGetDateNow()
        {
            Builder.SetDateTimeProvider();
            Builder.MockReturnsDateTimeProvider(x => x.Now(), new DateTime(2023, 6, 30));

            var saveProduct = Builder.GetProduct();

            var now = saveProduct.DateNow();
            Assert.Equal(new DateTime(2023, 6, 30), now);
        }
    }
}