using Moq;

namespace XUnitTest
{
    public class TestProductUnit
    {
        internal TestProductBuilder Builder { get; }

        public TestProductUnit()
        {
            Builder = new TestProductBuilder();
        }

        [Fact]
        public void ShouldThrowsOnSaveProduct()
        {
            Builder.SetDateTimeProvider();
            Builder.SetRepository();
            Builder.MockThrowsRepository(x => x.Save(It.IsAny<Product>()), new Exception("VISH"));
            var product = Builder.GetProduct();

            void act() => product.Save(It.IsAny<Product>());
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldSaveProduct()
        {
            Builder.SetDateTimeProvider();
            Builder.SetApiService();
            Builder.SetRepository();
            Builder.MockReturnsRepository(x => x.Save(It.IsAny<Product>()), new Balance());
            var product = Builder.GetProduct();

            product.Save(It.IsAny<Product>());
        }

        [Fact]
        public void ShouldThrowsOnGetDateNow()
        {
            Builder.SetDateTimeProvider();
            Builder.MockThrowsDateTimeProvider(x => x.Now(), new Exception("VISH"));

            var product = Builder.GetProduct();

            void act() => product.DateNow();
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldGetDateNow()
        {
            Builder.SetDateTimeProvider();
            Builder.MockReturnsDateTimeProvider(x => x.Now(), new DateTime(2023, 6, 30));

            var product = Builder.GetProduct();

            var now = product.DateNow();
            Assert.Equal(new DateTime(2023, 6, 30), now);
        }
    }
}