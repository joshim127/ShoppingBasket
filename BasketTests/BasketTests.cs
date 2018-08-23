using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingBasketTests
{
    [TestClass]
    public class UnitTest1
    {
        private Basket _classUnderTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _classUnderTest = new Basket();
        }

        [TestMethod]
        public void Basket_IsEmpty_TotalShouldBeZero()
        {
            var actualTotal = _classUnderTest.Total;
            Assert.AreEqual(0, actualTotal);
        }
    }

    public class Basket
    {
        public int Total { get; set; }
    }

}
