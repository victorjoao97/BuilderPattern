using Domain;
using Domain.Builders;
using Moq;
using XUnitTest.Builders;

namespace XUnitTest
{
    public class ProductTestUnit
    {
        [Fact]
        public void ShouldThrowsOnSaveProduct()
        {
            // ARRANGE
            var builder = new TestProductBuilder();
            ProductDirector.MakeProductToSave(builder);
            var saveProduct = builder.GetProduct();

            builder.MockThrowsRepository(x => x.Save(It.IsAny<Product>()), new Exception("VISH"));

            // ACT
            void act() => saveProduct.Save(It.IsAny<Product>());

            // ASSERT
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldSaveProduct()
        {
            // ARRANGE
            var builder = new TestProductBuilder();
            ProductDirector.MakeProductToSave(builder);
            var saveProduct = builder.GetProduct();

            // ACT
            saveProduct.Save(It.IsAny<Product>());
        }

        [Fact]
        public void ShouldThrowsOnGetDateNow()
        {
            // ARRANGE
            var builder = new TestProductBuilder();
            ProductDirector.MakeProductToGetDateNow(builder);
            var saveProduct = builder.GetProduct();

            builder.MockThrowsDateTimeProvider(x => x.Now(), new Exception("VISH"));

            // ACT
            void act() => saveProduct.DateNow();

            // ASSERT
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void ShouldGetDateNow()
        {
            // ARRANGE
            var builder = new TestProductBuilder();
            ProductDirector.MakeProductToGetDateNow(builder);
            var saveProduct = builder.GetProduct();

            builder.MockReturnsDateTimeProvider(x => x.Now(), new DateTime(2023, 6, 30));

            // ACT
            var now = saveProduct.DateNow();

            // ASSERT
            Assert.Equal(new DateTime(2023, 6, 30), now);
        }
    }
}