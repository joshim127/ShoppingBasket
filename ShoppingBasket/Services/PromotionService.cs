using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Interfaces;

namespace ShoppingBasket.Services
{

    public class PromotionService : IPromotionService
    {
        public int CalculateTotal(Basket basket)
        {
            basket.Total = basket.Items.Sum(x => x.Price * x.Quantity);

            if (ShouldBreadDiscountApply(basket.Items))
            {
                var numberOfButter = basket.Items.First(x => x.Description == "Butter").Quantity;
                var numberOfBread = basket.Items.First(x => x.Description == "Bread").Quantity;

                var numberOfDiscount = numberOfButter / 2;

                if (numberOfBread < numberOfDiscount)
                {
                    numberOfDiscount = numberOfBread;
                }

                basket.Total -= (50 * numberOfDiscount);
            }

            if (ShouldMilkDiscountApply(basket.Items))
            {
                var numberOfMilks = basket.Items.First(x => x.Description == "Milk").Quantity;

                var numberOfDiscount = numberOfMilks / 4;

                if (numberOfMilks < numberOfDiscount)
                {
                    numberOfDiscount = numberOfMilks;
                }

                basket.Total -= (115 * numberOfDiscount);
            }
            
            return basket.Total;
        }

        private static bool ShouldMilkDiscountApply(List<Product> products)
        {
            bool shouldApplyDiscount = products.Exists(x => x.Description == "Milk" && x.Quantity > 2);

            return shouldApplyDiscount;
        }

        private static bool ShouldBreadDiscountApply(List<Product> products)
        {
            var butter = 0;
            var bread = 0;
            var shouldApplyDiscount = false;

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

            if (butter >= 2 && bread >= 1)
            {
                shouldApplyDiscount = true;
            }

            return shouldApplyDiscount;
        }
    }
}
