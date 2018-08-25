using System.Collections.Generic;
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
            return _promotionService.CalculateTotal(basket);
        }
    }
}
