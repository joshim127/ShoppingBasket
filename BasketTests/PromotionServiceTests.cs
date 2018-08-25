using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;
using ShoppingBasket.Services;

namespace ShoppingBasketTests
{
    [TestClass]
    public class PromotionServiceTests
    {
        private PromotionService _classUnderTest;
        private Basket _basket;

        [TestInitialize]
        public void TestInitialize()
        {
            _classUnderTest = new PromotionService();
            _basket = new Basket(_classUnderTest);
        }

        [TestMethod]
        public void WhenBasketIsNotEmpty_ShouldReturnCorrectTotal()
        {
            _basket.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 1 });
            _basket.Items.Add(new Product { Price = 80, Description = "Butter", Quantity = 1 });
            _basket.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 1 });

            var expectedValue = 295;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);

            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsTwoButterAndTwoBreads_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 2 });
            _basket.Items.Add(new Product { Price = 80, Description = "Butter", Quantity = 2 });

            var expectedValue = 310;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsFiveButterAndThreeBreads_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 3 });
            _basket.Items.Add(new Product { Price = 80, Description = "Butter", Quantity = 5 });

            var expectedValue = 600;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsFourMilks_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 4 });

            var expectedValue = 345;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsSevenMilks_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 7 });

            var expectedValue = 690;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsTwelveMilks_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 12 });

            var expectedValue = 1035;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }

        [TestMethod]
        public void WhenBasketContainsTwoButterOneBreadAndEightMilks_ShouldApplyCorrectDiscount()
        {
            _basket.Items.Add(new Product { Price = 115, Description = "Milk", Quantity = 8 });
            _basket.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 1 });
            _basket.Items.Add(new Product { Price = 80, Description = "Butter", Quantity = 2 });

            var expectedValue = 900;
            var actualTotal = _classUnderTest.CalculateTotal(_basket);
            Assert.AreEqual(expectedValue, actualTotal);
        }
    }
}
