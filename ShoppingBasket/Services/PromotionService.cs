using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Services
{
    public interface IPromotionService
    {
        int CalculateTotal(Basket basket);
    }

    public class PromotionService : IPromotionService
    {
        public int CalculateTotal(Basket basket)
        {
            if (BreadDiscountShouldApply(basket.Items))
            {
                basket.Total = basket.Items.Sum(x => x.Price * x.Quantity) - 50;
            }
            else
            {
                basket.Total = basket.Items.Sum(x => x.Price * x.Quantity);
            }

            return basket.Total;
        }

        private bool BreadDiscountShouldApply(List<Product> products)
        {
            var butter = 0;
            var bread = 0;

            foreach (var product in products)
            {
                if (product.Description == "Butter")
                {
                    butter += product.Quantity;
                }

                if (product.Description == "Bread")
                {
                    bread += product.Quantity;
                }
            }

            if (butter == 2 && bread >= 1)
            {
                return true;
            }

            return false;
        }
    }
}
