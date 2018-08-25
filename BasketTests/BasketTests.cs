using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void WhenBasketIsNotEmpty_ShouldReturnCorrectTotal()
        {
            _classUnderTest.Items.Add(new Product { Price = 100, Description = "Bread", Quantity = 1});
            _classUnderTest.Items.Add(new Product { Price = 160, Description = "Butter", Quantity = 1});
            _classUnderTest.Items.Add(new Product { Price = 120, Description = "Milk", Quantity = 1});

            var actualTotal = _classUnderTest.Total;
            Assert.AreEqual(380, actualTotal);

        }
    }

    public class Basket
    {
        public Basket()
        {
            Items = new List<Product>();
        }

        public int Total
        {
            get { return Items.Sum(x => x.Price * x.Quantity); }
        }

        public List<Product> Items { get; set; }
    }

    public class Product
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
