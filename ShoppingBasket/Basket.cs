using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Interfaces;
using ShoppingBasket.Services;

namespace ShoppingBasket
{
    public class Basket
    {
        private readonly IPromotionService _promotionService;

        public int Total { get; set; }
        public List<Product> Items { get; set; }

        public Basket(IPromotionService promotionService)
        {
            Items = new List<Product>();
            _promotionService = promotionService;
        }

        public int CalculateTotal(Basket basket)
        {
            var total = _promotionService.AreThereAnyValidPromotions(DateTime.Today) ? _promotionService.CalculateTotal(basket) : basket.Items.Sum(x => x.Price * x.Quantity);

            return total;
        }
    }
}
