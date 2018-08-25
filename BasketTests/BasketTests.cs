using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingBasket;
using ShoppingBasket.Services;

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
        public void Basket_IsEmpty_TotalShouldBeZero()
        {
            var expectedValue = 0;
            var actualTotal = _classUnderTest.Total;

            Assert.AreEqual(expectedValue, actualTotal);
        }
    }
}
