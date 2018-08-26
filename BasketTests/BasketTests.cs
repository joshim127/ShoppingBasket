using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingBasket;
using ShoppingBasket.Interfaces;

namespace ShoppingBasketTests
{
    [TestClass]
    public class BasketTests
    {
        private IFixture _fixture;
        private Basket _classUnderTest;
        private Mock<IPromotionService> _promotionServicemock;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _promotionServicemock = _fixture.Create<Mock<IPromotionService>>();
            _classUnderTest = new Basket(_promotionServicemock.Object);
        }

        [TestMethod]
        public void BasketIsEmpty_TotalShouldBeZero()
        {
            var expectedValue = 0;
            var actualTotal = _classUnderTest.Total;

            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void BasketIsNotEmpty_ShouldReturnCorrectTotal()
        {
            _classUnderTest.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 1 });
            _classUnderTest.Items.Add(new Product { Price = 80, Description = "Butter", Quantity = 1 });
            _classUnderTest.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 1 });

            _promotionServicemock.Setup(x => x.AreThereAnyValidPromotions(DateTime.Today)).Returns(false);

            var expectedValue = 295;
            var actualTotal = _classUnderTest.CalculateTotal(_classUnderTest);

            Assert.AreEqual(expectedValue, actualTotal);
        }
    }
}
